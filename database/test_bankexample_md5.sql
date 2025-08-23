-- =============================================================================
-- Sample Bank Database
-- MD5 Checksum Validation Queries
--
-- Purpose:
--   This script validates the integrity of bankexample database tables by
--   calculating and comparing MD5 checksums of their concatenated column values.
--
-- Note:
--   - Data is fictional; any resemblance to real persons or entities is purely coincidental.
--   - Replace the placeholder expected CRC values with actual values after first run.
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

-- =====================
-- ACCOUNT Table
-- =====================

-- Count total records in 'account' table
SELECT 'account' AS table_name, COUNT(*) AS found_records FROM account;

-- Calculate MD5 checksum by concatenating relevant columns ordered by account_number
SELECT
  MD5(GROUP_CONCAT(CONCAT_WS('#',
    account_number,
    account_type_id,
    status_id,
    date_opened,
    IFNULL(date_closed, 'NULL')
  ) ORDER BY account_number)) AS crc
FROM account;

-- =====================
-- CUSTOMER Table
-- =====================

-- Set expected values (replace with actual hash after first run)
SET @expected_customer_count = 500;
SET @expected_customer_crc = 'd166318517a6f7d4c5cc11410c0b12fe';

-- Find actual count of records
SELECT COUNT(*) INTO @found_customer_count FROM customer;

-- Calculate actual MD5 checksum of concatenated customer columns ordered by customer_id
SELECT
  MD5(GROUP_CONCAT(CONCAT_WS('#',
    customer_id,
    first_name,
    last_name,
    date_of_birth,
    signup_date
  ) ORDER BY customer_id)) INTO @found_customer_crc
FROM customer;

-- Compare expected vs found and show result for customer table
SELECT
  'customer' AS table_name,
  @expected_customer_count AS expected_records,
  @expected_customer_crc AS expected_crc,
  @found_customer_count AS found_records,
  @found_customer_crc AS found_crc,
  IF(@expected_customer_count = @found_customer_count, 'OK', 'FAIL') AS records_match,
  IF(@expected_customer_crc = @found_customer_crc, 'OK', 'FAIL') AS crc_match;

-- =====================
-- TRANSACTION Table
-- =====================

-- Set expected values (replace with actual hash after first run)
SET @expected_transaction_count = 500;
SET @expected_transaction_crc = 'd166318517a6f7d4c5cc11410c0b12fe';

-- Find actual count of records
SELECT COUNT(*) INTO @found_transaction_count FROM `transaction`;

-- Calculate actual MD5 checksum of concatenated transaction columns ordered by transaction_id
SELECT
  MD5(GROUP_CONCAT(CONCAT_WS('#',
    transaction_id,
    transaction_datetime,
    from_account,
    to_account,
    description,
    amount
  ) ORDER BY transaction_id)) INTO @found_transaction_crc
FROM `transaction`;

-- Compare expected vs found and show result for transaction table
SELECT
  'transaction' AS table_name,
  @expected_transaction_count AS expected_records,
  @expected_transaction_crc AS expected_crc,
  @found_transaction_count AS found_records,
  @found_transaction_crc AS found_crc,
  IF(@expected_transaction_count = @found_transaction_count, 'OK', 'FAIL') AS records_match,
  IF(@expected_transaction_crc = @found_transaction_crc, 'OK', 'FAIL') AS crc_match;

-- =====================
-- CUSTOMER_ACCOUNT Table
-- =====================

-- Set expected values (replace with actual hash after first run)
SET @expected_customer_account_count = 150;
SET @expected_customer_account_crc = '234344444';

-- Find actual count of records
SELECT COUNT(*) INTO @found_customer_account_count FROM customer_account;

-- Calculate actual MD5 checksum of concatenated customer_account columns ordered by customer_id and account_number
SELECT
  MD5(GROUP_CONCAT(CONCAT_WS('#',
    customer_id,
    account_number
  ) ORDER BY customer_id, account_number)) INTO @found_customer_account_crc
FROM customer_account;

-- Compare expected vs found and show result for customer_account table
SELECT
  'customer_account' AS table_name,
  @expected_customer_account_count AS expected_records,
  @expected_customer_account_crc AS expected_crc,
  @found_customer_account_count AS found_records,
  @found_customer_account_crc AS found_crc,
  IF(@expected_customer_account_count = @found_customer_account_count, 'OK', 'FAIL') AS records_match,
  IF(@expected_customer_account_crc = @found_customer_account_crc, 'OK', 'FAIL') AS crc_match;
