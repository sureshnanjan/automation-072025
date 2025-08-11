DELIMITER $$

-- -------------------------------------------------------------------------------------------------
-- © 2025 Elangovan R. All rights reserved.
-- This file is part of the Database Validation Suite.
-- Unauthorized copying or distribution of this code, via any medium, is strictly prohibited.
-- Proprietary and confidential.
--
-- Author: Elangovan R.
-- Created On: 2025-08-11
--
-- Description:
-- This stored procedure ValidateAllTablesSHA1 validates data integrity for all tables listed in the
-- 'expected_values' table within the current database schema. It computes a SHA1 checksum over the
-- concatenated row data of each table, ordered by primary key columns (or all columns if no primary key),
-- and compares the result against expected baseline values.
--
-- The procedure performs the following:
-- 1. Iterates through all table names in 'expected_values'.
-- 2. For each table:
--    - Retrieves a list of all columns, wrapping NULLs safely.
--    - Retrieves the primary key columns or falls back to all columns for ordering.
--    - Computes the row count and a SHA1 hash of concatenated column values, ordered by the PK.
-- 3. Inserts the computed counts and hashes into a temporary 'found_values' table.
-- 4. Outputs three result sets:
--    a. Expected baseline values.
--    b. Computed found values.
--    c. Comparison results showing if record counts and checksums match.
--
-- Usage:
-- CALL ValidateAllTablesSHA1();
--
-- Notes:
-- - The procedure sets the session variable 'group_concat_max_len' to a high value to avoid truncation.
-- - NULL values are represented as '<NULL>' in concatenation for checksum stability.
-- -------------------------------------------------------------------------------------------------

CREATE PROCEDURE ValidateAllTablesSHA1()
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE tname VARCHAR(64);
    DECLARE col_list TEXT;
    DECLARE pk_list TEXT;
    DECLARE dyn_recs INT;
    DECLARE dyn_crc CHAR(40);

    DECLARE cur CURSOR FOR SELECT table_name FROM expected_values;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    -- Increase group_concat_max_len to avoid truncation of concatenated string
    SET SESSION group_concat_max_len = 1000000;

    SELECT 'TESTING INSTALLATION' AS INFO;

    DROP TABLE IF EXISTS found_values;
    CREATE TABLE found_values (
        table_name VARCHAR(50) PRIMARY KEY,
        recs INT NOT NULL,
        crc_sha1 CHAR(40) NOT NULL
    );

    OPEN cur;
    read_loop: LOOP
        FETCH cur INTO tname;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Build IFNULL-wrapped column list to handle NULLs safely in concat
        SELECT GROUP_CONCAT(
            CONCAT('IFNULL(`', column_name, '`, "<NULL>")')
            ORDER BY ordinal_position SEPARATOR ', ')
        INTO col_list
        FROM information_schema.columns
        WHERE table_schema = DATABASE()
          AND table_name = tname;

        -- Get primary key columns ordered by position
        SELECT GROUP_CONCAT(CONCAT('`', column_name, '`') ORDER BY ordinal_position SEPARATOR ', ')
        INTO pk_list
        FROM information_schema.key_column_usage
        WHERE table_schema = DATABASE()
          AND table_name = tname
          AND constraint_name = 'PRIMARY';

        -- Fallback if no PK found: order by all columns (to ensure deterministic order)
        IF pk_list IS NULL OR pk_list = '' THEN
            SET pk_list = col_list;
        END IF;

        -- Prepare dynamic SQL to compute record count and SHA1 checksum over concatenated rows
        SET @sql = CONCAT(
            'SELECT COUNT(*) AS recs, ',
            'SHA1(GROUP_CONCAT(CONCAT_WS("#", ', col_list, ') ORDER BY ', pk_list, ' SEPARATOR "#")) AS crc_sha1 ',
            'INTO @dyn_recs, @dyn_crc ',
            'FROM `', REPLACE(tname, '`', '``'), '`'
        );

        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;

        SET dyn_recs = @dyn_recs;
        SET dyn_crc = @dyn_crc;

        INSERT INTO found_values VALUES (tname, dyn_recs, dyn_crc);
    END LOOP;
    CLOSE cur;

    -- Output expected baseline
    SELECT table_name, recs AS expected_records, crc_sha1 AS expected_crc
    FROM expected_values
    ORDER BY table_name;

    -- Output computed found values
    SELECT table_name, recs AS found_records, crc_sha1 AS found_crc
    FROM found_values
    ORDER BY table_name;

    -- Output comparison results
    SELECT 
        e.table_name,
        IF(e.recs = f.recs, 'OK', 'FAIL') AS records_match,
        IF(e.crc_sha1 = f.crc_sha1, 'OK', 'FAIL') AS crc_match
    FROM expected_values e
    JOIN found_values f USING (table_name)
    ORDER BY e.table_name;
END$$

DELIMITER ;