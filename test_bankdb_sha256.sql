USE bankdb;

-- Show header
SELECT 'TESTING BANKDB INSTALLATION (SHA256)' AS INFO;

-- Drop temp tables if they exist
DROP TEMPORARY TABLE IF EXISTS expected_checksums;
DROP TEMPORARY TABLE IF EXISTS found_checksums;

-- Expected values table
CREATE TEMPORARY TABLE expected_checksums (
    table_name VARCHAR(64),
    expected_records INT,
    expected_crc CHAR(64)
);

-- INSERT expected record counts and SHA256 checksums here
-- Update the CRCs after first run
INSERT INTO expected_checksums VALUES 
('customer', 501, 'dummy_sha256_1'),
('account', 501, 'dummy_sha256_2'),
('customer_account', 229, 'dummy_sha256_3'),
('transaction', 172, 'dummy_sha256_4');

-- Create actual checksum results
CREATE TEMPORARY TABLE found_checksums (
    table_name VARCHAR(64),
    found_records INT,
    found_crc CHAR(64)
);

-- Calculate SHA256-based checksums using simple SUM() pattern
INSERT INTO found_checksums
SELECT 
    'customer',
    COUNT(*),
    SHA2(SUM(customer_id), 256)
FROM customer;

INSERT INTO found_checksums
SELECT 
    'account',
    COUNT(*),
    SHA2(SUM(account_number), 256)
FROM account;

INSERT INTO found_checksums
SELECT 
    'customer_account',
    COUNT(*),
    SHA2(SUM(customer_id + account_number), 256)
FROM customer_account;

INSERT INTO found_checksums
SELECT 
    'transaction',
    COUNT(*),
    SHA2(SUM(transaction_id + amount), 256)
FROM transaction;

-- Show expected
SELECT 'EXPECTED VALUES' AS info;
SELECT * FROM expected_checksums;

-- Show actual
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
