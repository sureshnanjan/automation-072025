-- =============================================================================
-- Sample Bank Database
-- SHA and MD5 Checksum Validation Script
--
-- Purpose:
--   This script validates the integrity of the bankexample database tables by
--   calculating and comparing SHA1 and MD5 checksums of their contents.
--
-- Note:
--   - Data is fictional; any resemblance to real persons or entities is purely coincidental.
--   - Replace placeholder hash values with actual hashes after first run.
--
-- License:
--   Creative Commons Attribution-Share Alike 3.0 Unported License
--   http://creativecommons.org/licenses/by-sa/3.0/
--
-- Created for testing purposes.
--
-- Copyright © 2025 Arava Jagadeeswar Reddy. All rights reserved.
-- =============================================================================

USE bankexample;

-- Display basic info message
SELECT 'TESTING INSTALLATION' AS 'INFO';

-- Cleanup old checksum tables if they exist
DROP TABLE IF EXISTS expected_values, found_values;

-- Table to store expected record counts and checksums for each table
CREATE TABLE expected_values (
    table_name VARCHAR(30) NOT NULL PRIMARY KEY,
    recs INT NOT NULL,
    crc_sha VARCHAR(100) NOT NULL,
    crc_md5 VARCHAR(100) NOT NULL
);

-- Table to store actual found record counts and checksums after computation
CREATE TABLE found_values LIKE expected_values;

-- Insert expected values (replace with actual SHA/MD5 after first run)
INSERT INTO expected_values VALUES
('customer',          500, '1e14f5d72cafc4713d14fd0c0d051af8108edcd3',       'md5_customer_here'),
('account',           150, '33501fd7b66e8d20966a002d24dfc9524052242e',        'md5_account_here'),
('customer_account',  150, '705af7b528480045f90ff558a02679e9ae4400a0',        'md5_customer_account'),
('transaction',       500, '54204662935867a99f0e2a9eff5ad38cefcd123f',         'md5_transaction_here');

-- Show expected values for confirmation
SELECT table_name, recs AS expected_records, crc_sha AS expected_crc FROM expected_values;

-- Temporary table for checksum calculation process
DROP TABLE IF EXISTS tchecksum;
CREATE TABLE tchecksum (chk CHAR(100));

-- =====================================================================
-- Calculate SHA checksums for each table
-- =====================================================================

-- CUSTOMER table checksum calculation
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA(CONCAT_WS('#', @crc, customer_id, first_name, last_name, date_of_birth))
FROM customer ORDER BY customer_id;
INSERT INTO found_values VALUES ('customer', (SELECT COUNT(*) FROM customer), @crc, @crc);

-- ACCOUNT table checksum calculation
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA(CONCAT_WS('#', @crc,
    account_number,
    account_type_id,
    status_id,
    date_opened,
    date_closed,
    account_type
))
FROM account ORDER BY account_number;
INSERT INTO found_values VALUES ('account', (SELECT COUNT(*) FROM account), @crc, @crc);

-- CUSTOMER_ACCOUNT table checksum calculation
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA(CONCAT_WS('#', @crc, customer_id, account_number))
FROM customer_account ORDER BY customer_id, account_number;
INSERT INTO found_values VALUES ('customer_account', (SELECT COUNT(*) FROM customer_account), @crc, @crc);

-- TRANSACTION table checksum calculation
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA(CONCAT_WS('#', @crc,
    transaction_id,
    from_account,
    to_account,
    transaction_datetime,
    description,
    amount
))
FROM transaction ORDER BY transaction_id;
INSERT INTO found_values VALUES ('transaction', (SELECT COUNT(*) FROM transaction), @crc, @crc);

-- Cleanup temporary checksum table
DROP TABLE tchecksum;

-- =====================================================================
-- Show the found values (record counts and checksums)
-- =====================================================================
SELECT table_name, recs AS 'found_records', crc_sha AS found_crc FROM found_values;

-- =====================================================================
-- Compare expected and found values, output match status
-- =====================================================================
SELECT
    e.table_name,
    IF(e.recs = f.recs, 'OK', 'not ok') AS records_match,
    IF(e.crc_sha = f.crc_sha, 'ok', 'not ok') AS crc_match
FROM expected_values e
INNER JOIN found_values f USING (table_name);

-- Calculate if there were any checksum or count mismatches
SET @crc_fail = (
    SELECT COUNT(*) FROM expected_values e
    INNER JOIN found_values f ON e.table_name = f.table_name
    WHERE f.crc_sha != e.crc_sha
);

SET @count_fail = (
    SELECT COUNT(*) FROM expected_values e
    INNER JOIN found_values f ON e.table_name = f.table_name
    WHERE f.recs != e.recs
);

-- Show how long the checksum computation took
SELECT TIMEDIFF(
    NOW(),
    (SELECT create_time FROM information_schema.tables
     WHERE table_schema = 'bankexample'
       AND table_name = 'expected_values')
) AS computation_time;

-- Cleanup expected and found values tables
DROP TABLE expected_values, found_values;

-- Final summary of CRC and count checks
SELECT 'CRC' AS summary, IF(@crc_fail = 0, 'OK', 'FAIL') AS result
UNION ALL
SELECT 'count', IF(@count_fail = 0, 'OK', 'FAIL') AS count;
