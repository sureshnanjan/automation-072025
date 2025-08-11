/* ==================================================================================================
  File Name      : md5_StoredProcedure.sql
  Author         : Keyur Nagvekar
  Created On     : 2025-08-11
  Description    : This stored procedure (md5_StoredProcedure) validates database table data integrity
                   against expected baseline values using MD5 checksums.
                   It:
                      - Iterates over all tables listed in 'expected_values'
                      - Computes row counts and MD5 checksums of concatenated data
                      - Stores computed values in 'found_values'
                      - Compares them with the expected values

  Usage          :
      CALL md5_StoredProcedure();

  Requirements   :
      - A table named 'expected_values' with:
            table_name  VARCHAR(...)
            recs        INT
            crc_md5     VARCHAR(100)
      - Sufficient privileges to query INFORMATION_SCHEMA and execute dynamic SQL.
      - group_concat_max_len should be increased to avoid truncation.

  Notes          :
      - If no PRIMARY KEY exists for a table, all columns are used for ordering to ensure
        deterministic checksum computation.
      - NULL values are replaced with the string "<NULL>" to avoid inconsistencies.

  License        :
      © 2025 Keyur Nagvekar. All rights reserved.
      This code is provided for educational and internal business purposes only.
      Redistribution or modification without prior written consent of the author is prohibited.

================================================================================================== */

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `md5_StoredProcedure`()
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE tname VARCHAR(64);
    DECLARE col_list TEXT;
    DECLARE pk_list TEXT;

    DECLARE dyn_recs INT;
    DECLARE dyn_crc VARCHAR(100);

    DECLARE cur CURSOR FOR SELECT table_name FROM expected_values;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    -- Increase group_concat_max_len to avoid truncation
    SET SESSION group_concat_max_len = 1000000;

    SELECT 'TESTING INSTALLATION' AS INFO;

    DROP TABLE IF EXISTS found_values;
    CREATE TABLE found_values (
        table_name VARCHAR(50) PRIMARY KEY,
        recs INT NOT NULL,
        crc_md5 VARCHAR(100) NOT NULL
    );

    OPEN cur;
    read_loop: LOOP
        FETCH cur INTO tname;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Build IFNULL-wrapped column list to handle NULLs
        SELECT GROUP_CONCAT(
            CONCAT('IFNULL(`', column_name, '`, "<NULL>")')
            ORDER BY ordinal_position SEPARATOR ', ')
        INTO col_list
        FROM information_schema.columns
        WHERE table_schema = DATABASE()
          AND table_name = tname;

        -- Get primary key columns, ordered by position, quoted
        SELECT GROUP_CONCAT(CONCAT('`', column_name, '`') ORDER BY ordinal_position SEPARATOR ', ')
        INTO pk_list
        FROM information_schema.key_column_usage
        WHERE table_schema = DATABASE()
          AND table_name = tname
          AND constraint_name = 'PRIMARY';

        -- If no PK found, fallback to all columns
        IF pk_list IS NULL OR pk_list = '' THEN
            SET pk_list = col_list;
        END IF;

        -- Build dynamic SQL for row count and MD5 checksum
        SET @sql = CONCAT(
            'SELECT COUNT(*) AS recs, ',
            'MD5(GROUP_CONCAT(CONCAT_WS("#", ', col_list, ') ORDER BY ', pk_list, ' SEPARATOR "#")) AS crc ',
            'INTO @dyn_recs, @dyn_crc ',
            'FROM `', REPLACE(tname,'`','``'), '`'
        );

        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;

        SET dyn_recs = @dyn_recs;
        SET dyn_crc = @dyn_crc;

        INSERT INTO found_values VALUES (tname, dyn_recs, dyn_crc);
    END LOOP;
    CLOSE cur;

    -- Output expected values
    SELECT table_name, recs AS expected_records, crc_md5 AS expected_crc
    FROM expected_values
    ORDER BY table_name;

    -- Output found values
    SELECT table_name, recs AS found_records, crc_md5 AS found_crc
    FROM found_values
    ORDER BY table_name;

    -- Compare expected and found values
    SELECT 
        e.table_name,
        IF(e.recs = f.recs, 'OK', 'FAIL') AS records_match,
        IF(e.crc_md5 = f.crc_md5, 'OK', 'FAIL') AS crc_match
    FROM expected_values e
    JOIN found_values f USING (table_name)
    ORDER BY e.table_name;
END$$

DELIMITER ;
