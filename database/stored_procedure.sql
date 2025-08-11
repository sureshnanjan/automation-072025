DELIMITER //

CREATE PROCEDURE CheckTableIntegrity(
    IN p_table_name VARCHAR(30),
    IN p_expected_count INT,
    IN p_expected_hash VARCHAR(100)
)
BEGIN
    DECLARE v_actual_count INT;
    DECLARE v_actual_hash VARCHAR(100);

    -- Choose table and generate its hash
    IF p_table_name = 'customer' THEN
        SELECT COUNT(*) INTO v_actual_count FROM customer;
        SET @crc = '';
        SELECT @crc := MD5(CONCAT_WS('#', @crc,
            customer_id, first_name, last_name, date_of_birth, signup_date))
        FROM customer ORDER BY customer_id;
        SET v_actual_hash = @crc;

    ELSEIF p_table_name = 'account_type' THEN
        SELECT COUNT(*) INTO v_actual_count FROM account_type;
        SET @crc = '';
        SELECT @crc := MD5(CONCAT_WS('#', @crc,
            account_type_id, account_type))
        FROM account_type ORDER BY account_type_id;
        SET v_actual_hash = @crc;

    ELSEIF p_table_name = 'account_status' THEN
        SELECT COUNT(*) INTO v_actual_count FROM account_status;
        SET @crc = '';
        SELECT @crc := MD5(CONCAT_WS('#', @crc,
            status_id, status_value))
        FROM account_status ORDER BY status_id;
        SET v_actual_hash = @crc;

    ELSEIF p_table_name = 'account' THEN
        SELECT COUNT(*) INTO v_actual_count FROM account;
        SET @crc = '';
        SELECT @crc := MD5(CONCAT_WS('#', @crc,
            account_number, account_type_id, status_id, date_opened, date_closed))
        FROM account ORDER BY account_number;
        SET v_actual_hash = @crc;

    ELSEIF p_table_name = 'customer_account' THEN
        SELECT COUNT(*) INTO v_actual_count FROM customer_account;
        SET @crc = '';
        SELECT @crc := MD5(CONCAT_WS('#', @crc,
            account_number, customer_id))
        FROM customer_account ORDER BY account_number, customer_id;
        SET v_actual_hash = @crc;

    ELSEIF p_table_name = 'transaction' THEN
        SELECT COUNT(*) INTO v_actual_count FROM transaction;
        SET @crc = '';
        SELECT @crc := MD5(CONCAT_WS('#', @crc,
            transaction_id, transaction_datetime, from_account, to_account, description))
        FROM transaction ORDER BY transaction_id;
        SET v_actual_hash = @crc;
    END IF;

    -- Output comparison
    SELECT p_table_name AS table_name,
           p_expected_count AS expected_count,
           v_actual_count AS actual_count,
           IF(p_expected_count = v_actual_count, 'OK', 'FAIL') AS count_check,
           p_expected_hash AS expected_hash,
           v_actual_hash AS actual_hash,
           IF(p_expected_hash = v_actual_hash, 'OK', 'FAIL') AS hash_check;
END //

DELIMITER ;
