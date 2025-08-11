USE your_database_name;  -- Change this to your DB name

SELECT 'TESTING INSTALLATION' AS 'INFO';

-- Drop old checksum tables if they exist
DROP TABLE IF EXISTS expected_values, found_values;

-- Expected values table
CREATE TABLE expected_values (
    table_name VARCHAR(30) NOT NULL PRIMARY KEY,
    recs INT NOT NULL,
    crc_md5 VARCHAR(100) NOT NULL
);

-- Found values table
CREATE TABLE found_values LIKE expected_values;

-- =====================================================
--  Customer Table MD5
-- =====================================================
SET @crc = '';
INSERT INTO found_values
SELECT 
    'customer',
    COUNT(*),
    (SELECT @crc := MD5(CONCAT_WS('#', @crc,
            customer_id, first_name, last_name, date_of_birth, signup_date))
     FROM customer ORDER BY customer_id)
FROM customer;

-- =====================================================
--  Account Type Table MD5
-- =====================================================
SET @crc = '';
INSERT INTO found_values
SELECT 
    'account_type',
    COUNT(*),
    (SELECT @crc := MD5(CONCAT_WS('#', @crc,
            account_type_id, account_type))
     FROM account_type ORDER BY account_type_id)
FROM account_type;

-- =====================================================
--  Account Status Table MD5
-- =====================================================
SET @crc = '';
INSERT INTO found_values
SELECT 
    'account_status',
    COUNT(*),
    (SELECT @crc := MD5(CONCAT_WS('#', @crc,
            status_id, status_value))
     FROM account_status ORDER BY status_id)
FROM account_status;

-- =====================================================
--  Account Table MD5
-- =====================================================
SET @crc = '';
INSERT INTO found_values
SELECT 
    'account',
    COUNT(*),
    (SELECT @crc := MD5(CONCAT_WS('#', @crc,
            account_number, account_type_id, status_id, date_opened, date_closed))
     FROM account ORDER BY account_number)
FROM account;

-- =====================================================
--  Customer Account Link Table MD5
-- =====================================================
SET @crc = '';
INSERT INTO found_values
SELECT 
    'customer_account',
    COUNT(*),
    (SELECT @crc := MD5(CONCAT_WS('#', @crc,
            customer_id, account_number))
     FROM customer_account ORDER BY customer_id, account_number)
FROM customer_account;

-- =====================================================
--  Transaction Table MD5
-- =====================================================
SET @crc = '';
INSERT INTO found_values
SELECT 
    'transaction',
    COUNT(*),
    (SELECT @crc := MD5(CONCAT_WS('#', @crc,
            transaction_id, transaction_datetime, from_account, to_account, description))
     FROM transaction ORDER BY transaction_id)
FROM transaction;

-- =====================================================
--  Show found checksums
-- =====================================================
SELECT table_name, recs AS found_records, crc_md5 AS found_crc 
FROM found_values;
