USE bankdb;

-- Show header
SELECT 'TESTING BANKDB INSTALLATION' AS INFO;

-- Drop temporary tables if they exist
DROP TEMPORARY TABLE IF EXISTS expected_checksums;
DROP TEMPORARY TABLE IF EXISTS found_checksums;

-- Create expected checksums table
CREATE TEMPORARY TABLE expected_checksums (
    table_name VARCHAR(64),
    expected_records INT,
    expected_crc CHAR(32)
);

-- Insert your expected row counts and dummy CRCs (update after first run)
INSERT INTO expected_checksums VALUES 
('customer', 501, 'dummy_crc_1'),
('account', 501, 'dummy_crc_2'),
('customer_account', 229, 'dummy_crc_3'),
('transaction', 172, 'dummy_crc_4');

-- Create found_checksums table
CREATE TEMPORARY TABLE found_checksums (
    table_name VARCHAR(64),
    found_records INT,
    found_crc CHAR(32)
);

-- Calculate record count and safe checksum via SUM() for each table

INSERT INTO found_checksums
SELECT 
    'customer',
    COUNT(*),
    MD5(SUM(customer_id))
FROM customer;

INSERT INTO found_checksums
SELECT 
    'account',
    COUNT(*),
    MD5(SUM(account_number))
FROM account;

INSERT INTO found_checksums
SELECT 
    'customer_account',
    COUNT(*),
    MD5(SUM(customer_id + account_number))
FROM customer_account;

INSERT INTO found_checksums
SELECT 
    'transaction',
    COUNT(*),
    MD5(SUM(transaction_id + amount))
FROM transaction;

-- Show expected values
SELECT 'EXPECTED VALUES' AS info;
SELECT * FROM expected_checksums;

-- Show actual (found) values
SELECT 'FOUND VALUES' AS info;
SELECT * FROM found_checksums;

-- Final comparison output
SELECT 
    f.table_name,
    CASE 
        WHEN f.found_records = e.expected_records THEN 'OK' 
        ELSE CONCAT('❌ Expected ', e.expected_records, ', Got ', f.found_records)
    END AS records_match,
    CASE 
        WHEN f.found_crc = e.expected_crc THEN 'ok'
        ELSE CONCAT('❌ CRC Mismatch: ', f.found_crc)
    END AS crc_match
FROM found_checksums f
JOIN expected_checksums e ON f.table_name = e.table_name;

-- Cleanup
DROP TEMPORARY TABLE IF EXISTS expected_checksums;
DROP TEMPORARY TABLE IF EXISTS found_checksums;
