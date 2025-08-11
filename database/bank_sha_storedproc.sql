DELIMITER $$

DROP PROCEDURE IF EXISTS validate_bankdb_sha$$

CREATE PROCEDURE validate_bankdb_sha(
    IN tbl_name VARCHAR(64),
    IN expected_count INT,
    IN expected_hash VARCHAR(100)
)
BEGIN
    DECLARE actual_count INT DEFAULT 0;
    DECLARE actual_hash VARCHAR(100) DEFAULT '';
    DECLARE sql_text TEXT;

    -- Make sure GROUP_CONCAT is large enough for big tables
    SET SESSION group_concat_max_len = 1000000;

    -- Step 1: Calculate actual row count dynamically
    SET @sql_text = CONCAT('SELECT COUNT(*) INTO @actual_count FROM `', REPLACE(tbl_name,'`','``'), '`');
    PREPARE stmt FROM @sql_text;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

    SET actual_count = @actual_count;

    -- Step 2: Choose hashing logic based on table name
    IF tbl_name = 'account' THEN
        SET @sql_text = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', account_number, account_type_id, status_id, date_opened, IFNULL(date_closed, 'NULL'), account_type) ORDER BY account_number SEPARATOR '')) INTO @actual_hash FROM `account`"
        );

    ELSEIF tbl_name = 'customer' THEN
        SET @sql_text = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', customer_id, first_name, last_name, date_of_birth, signup_date) ORDER BY customer_id SEPARATOR '')) INTO @actual_hash FROM `customer`"
        );

    ELSEIF tbl_name = 'customer_account' THEN
        SET @sql_text = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', customer_id, account_number) ORDER BY customer_id, account_number SEPARATOR '')) INTO @actual_hash FROM `customer_account`"
        );

    ELSEIF tbl_name = 'transaction' THEN
        SET @sql_text = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', transaction_id, from_account, to_account, transaction_datetime, description, amount) ORDER BY transaction_id SEPARATOR '')) INTO @actual_hash FROM `transaction`"
        );

    ELSEIF tbl_name = 'amount' THEN
        SET @sql_text = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', id, amount, transaction_date) ORDER BY id SEPARATOR '')) INTO @actual_hash FROM `amount`"
        );

    ELSE
        SET @actual_hash = 'UNKNOWN_TABLE';
    END IF;

    -- Step 3: Execute hash calculation if known table
    IF @actual_hash != 'UNKNOWN_TABLE' THEN
        PREPARE stmt FROM @sql_text;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
        SET actual_hash = @actual_hash;
    END IF;

    -- Step 4: Output results
    SELECT
        tbl_name AS TableName,
        expected_count AS ExpectedCount,
        actual_count AS ActualCount,
        expected_hash AS ExpectedHash,
        actual_hash AS ActualHash,
        IF(expected_count = actual_count, 'OK', 'FAIL') AS CountMatch,
        IF(expected_hash = actual_hash, 'OK', 'FAIL') AS HashMatch;
END $$

DELIMITER ;

CALL validate_bankdb_sha('customer', 500, '3f786850e387550fdab836ed7e6dc881de23001b');

