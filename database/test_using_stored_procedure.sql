SELECT 'TESTING BANKING SYSTEM INSTALLATION' AS 'INFO';

-- Remove old temp tables
DROP TABLE IF EXISTS expected_values, found_values;
CREATE TABLE expected_values (
    table_name VARCHAR(30) NOT NULL PRIMARY KEY,
    recs INT NOT NULL,
    crc_md5 VARCHAR(100) NOT NULL
);

CREATE TABLE found_values LIKE expected_values;

-- TEMP checksum table
DROP TABLE IF EXISTS tchecksum;
CREATE TABLE tchecksum (chk CHAR(100));

-- CUSTOMER
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                customer_id, first_name, last_name, date_of_birth, signup_date))
    FROM customer ORDER BY customer_id;
INSERT INTO found_values VALUES ('customer', (SELECT COUNT(*) FROM customer), @crc);

-- ACCOUNT_TYPE
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                account_type_id, account_type))
    FROM account_type ORDER BY account_type_id;
INSERT INTO found_values VALUES ('account_type', (SELECT COUNT(*) FROM account_type), @crc);

-- ACCOUNT_STATUS
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                status_id, status_value))
    FROM account_status ORDER BY status_id;
INSERT INTO found_values VALUES ('account_status', (SELECT COUNT(*) FROM account_status), @crc);

-- ACCOUNT
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                account_number, account_type_id, status_id, date_opened, date_closed))
    FROM account ORDER BY account_number;
INSERT INTO found_values VALUES ('account', (SELECT COUNT(*) FROM account), @crc);

-- CUSTOMER_ACCOUNT
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                account_number, customer_id))
    FROM customer_account ORDER BY account_number, customer_id;
INSERT INTO found_values VALUES ('customer_account', (SELECT COUNT(*) FROM customer_account), @crc);

-- TRANSACTION
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                transaction_id, transaction_datetime, from_account, to_account, description))
    FROM transaction ORDER BY transaction_id;
INSERT INTO found_values VALUES ('transaction', (SELECT COUNT(*) FROM transaction), @crc);

DROP TABLE tchecksum;

-- AUTO-FILL expected_values ON FIRST RUN
INSERT INTO expected_values (table_name, recs, crc_md5)
SELECT table_name, recs, crc_md5
FROM found_values
WHERE NOT EXISTS (SELECT 1 FROM expected_values LIMIT 1);

-- Show current hash values
SELECT 'CURRENT DATA HASHES' AS info;
SELECT * FROM found_values;

-- Validate each table
CALL CheckTableIntegrity('customer', 
    (SELECT recs FROM expected_values WHERE table_name = 'customer'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'customer'));

CALL CheckTableIntegrity('account_type', 
    (SELECT recs FROM expected_values WHERE table_name = 'account_type'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'account_type'));

CALL CheckTableIntegrity('account_status', 
    (SELECT recs FROM expected_values WHERE table_name = 'account_status'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'account_status'));

CALL CheckTableIntegrity('account', 
    (SELECT recs FROM expected_values WHERE table_name = 'account'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'account'));

CALL CheckTableIntegrity('customer_account', 
    (SELECT recs FROM expected_values WHERE table_name = 'customer_account'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'customer_account'));

CALL CheckTableIntegrity('transaction', 
    (SELECT recs FROM expected_values WHERE table_name = 'transaction'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'transaction'));
