/* =======================================================================================================
   File        : validate_table_sha.sql
   Author      : Arava Jagadeeswar Reddy
   Description : Stored Procedure to validate row count and SHA1 hash integrity for specified banking tables.
   Created On  : 2025-08-11
   =======================================================================================================
   COPYRIGHT © 2025 Arava Jagadeeswar Reddy. ALL RIGHTS RESERVED.
   Redistribution or use of this file in source or binary forms, with or without modification, is not allowed
   without prior written permission from the author.
   ======================================================================================================= */

DELIMITER $$

CREATE PROCEDURE validate_table_sha(
    IN p_table_name     VARCHAR(64),   -- Name of the table to validate
    IN p_expected_count INT,           -- Expected row count
    IN p_expected_hash  VARCHAR(100)   -- Expected SHA1 hash of table data
)
BEGIN
    -- Variable Declarations
    DECLARE v_actual_count INT DEFAULT 0;
    DECLARE v_actual_hash  VARCHAR(100) DEFAULT '';
    DECLARE v_sql_count    TEXT;
    DECLARE v_sql_hash     TEXT;

    /* ============================================================
       Step 1: Get Actual Row Count for the given table
    ============================================================ */
    SET @v_sql_count = CONCAT('SELECT COUNT(*) INTO @tmp_count FROM ', p_table_name);
    PREPARE stmt_count FROM @v_sql_count;
    EXECUTE stmt_count;
    DEALLOCATE PREPARE stmt_count;
    SET v_actual_count = @tmp_count;

    /* ============================================================
       Step 2: Build SHA1 Hash Query based on Table Name
    ============================================================ */
    IF p_table_name = 'account' THEN
        SET @v_sql_hash = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', account_number, account_type_id, status_id, date_opened, IFNULL(date_closed, 'NULL'), account_type) ORDER BY account_number)) INTO @tmp_hash FROM account"
        );

    ELSEIF p_table_name = 'customer' THEN
        SET @v_sql_hash = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', customer_id, first_name, last_name, date_of_birth, signup_date) ORDER BY customer_id)) INTO @tmp_hash FROM customer"
        );

    ELSEIF p_table_name = 'customer_account' THEN
        SET @v_sql_hash = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', customer_id, account_number) ORDER BY customer_id, account_number)) INTO @tmp_hash FROM customer_account"
        );

    ELSEIF p_table_name = 'transaction' THEN
        SET @v_sql_hash = CONCAT(
            "SELECT SHA1(GROUP_CONCAT(CONCAT_WS('#', transaction_id, from_account, to_account, transaction_datetime, description, amount) ORDER BY transaction_id)) INTO @tmp_hash FROM transaction"
        );

    ELSE
        SET v_actual_hash = 'UNKNOWN_TABLE';
    END IF;

    /* ============================================================
       Step 3: Execute Hash Query if Table is Recognized
    ============================================================ */
    IF v_actual_hash != 'UNKNOWN_TABLE' THEN
        PREPARE stmt_hash FROM @v_sql_hash;
        EXECUTE stmt_hash;
        DEALLOCATE PREPARE stmt_hash;
        SET v_actual_hash = @tmp_hash;
    END IF;

    /* ============================================================
       Step 4: Return Validation Results
    ============================================================ */
    SELECT
        p_table_name       AS TableName,
        p_expected_count   AS ExpectedCount,
        v_actual_count     AS ActualCount,
        p_expected_hash    AS ExpectedHash,
        v_actual_hash      AS ActualHash,
        IF(p_expected_count = v_actual_count, 'OK', 'FAIL') AS CountMatch,
        IF(p_expected_hash  = v_actual_hash,  'OK', 'FAIL') AS HashMatch;

END $$
DELIMITER ;

-- Example Call:
CALL validate_table_sha('account', 150, '33501fd7b66e8d20966a002d24dfc9524052242e');
