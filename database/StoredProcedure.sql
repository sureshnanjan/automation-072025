-- Drop procedure if exists
DROP PROCEDURE IF EXISTS CheckTableIntegrity;

DELIMITER $$

CREATE PROCEDURE CheckTableIntegrity(
    IN p_table_name VARCHAR(100),
    IN p_expected_count INT,
    IN p_expected_md5 CHAR(32)
)
BEGIN
    DECLARE v_sql TEXT;
    DECLARE v_cols TEXT;
    DECLARE v_pk TEXT;
    DECLARE v_count INT;
    DECLARE v_md5 CHAR(32);
    DECLARE v_result VARCHAR(10);

    -- Get list of columns for the table
    SELECT GROUP_CONCAT(CONCAT('COALESCE(', COLUMN_NAME, ', "")')
           ORDER BY ORDINAL_POSITION SEPARATOR ', "#" ,')
    INTO v_cols
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = DATABASE()
      AND TABLE_NAME = p_table_name;

    -- Get primary key column(s)
    SELECT GROUP_CONCAT(COLUMN_NAME ORDER BY ORDINAL_POSITION)
    INTO v_pk
    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
    WHERE TABLE_SCHEMA = DATABASE()
      AND TABLE_NAME = p_table_name
      AND CONSTRAINT_NAME = 'PRIMARY';

    -- Build the dynamic SQL to get count and MD5
    SET v_sql = CONCAT(
        'SELECT COUNT(*), ',
        'MD5(GROUP_CONCAT(CONCAT_WS("#", ', v_cols, ') ORDER BY ', v_pk, ' SEPARATOR "#")) ',
        'FROM ', p_table_name
    );

    -- Create temp table to hold results
    CREATE TEMPORARY TABLE tmp_result (cnt INT, md5 CHAR(32));

    -- Insert results of dynamic query into temp table
    SET @ins_sql = CONCAT('INSERT INTO tmp_result ', v_sql);
    PREPARE stmt FROM @ins_sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

    -- Retrieve into variables
    SELECT cnt, md5 INTO v_count, v_md5 FROM tmp_result;
    DROP TEMPORARY TABLE tmp_result;

    -- Compare
    IF v_count = p_expected_count AND v_md5 = p_expected_md5 THEN
        SET v_result = 'OK';
    ELSE
        SET v_result = 'DIFFER';
    END IF;

    -- Output
    SELECT 
        p_table_name AS table_name,
        p_expected_count AS expected_count,
        v_count AS found_count,
        p_expected_md5 AS expected_md5,
        v_md5 AS found_md5,
        v_result AS status;
END$$

DELIMITER ;


CALL CheckTableIntegrity('airport',
    (SELECT recs FROM expected_values WHERE table_name = 'airport'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'airport'));

CALL CheckTableIntegrity('airline',
    (SELECT recs FROM expected_values WHERE table_name = 'airline'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'airline'));
