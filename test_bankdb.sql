USE bankdb;

-- Drop temp tables if exist
DROP TEMPORARY TABLE IF EXISTS found_values;
DROP TEMPORARY TABLE IF EXISTS expected_values;

-- Test 1: Total number of customers = 501
CREATE TEMPORARY TABLE found_values 
SELECT COUNT(*) AS total_customers FROM customer;

CREATE TEMPORARY TABLE expected_values (total_customers INT);
INSERT INTO expected_values VALUES (501);

SELECT
  CASE
    WHEN f.total_customers = e.total_customers 
    THEN '✅ Test 1 Passed: Customer count matches'
    ELSE CONCAT('❌ Test 1 Failed: Expected ', e.total_customers, ' but got ', f.total_customers)
  END AS result
FROM found_values f
JOIN expected_values e;

-- Clean up
DROP TEMPORARY TABLE found_values;
DROP TEMPORARY TABLE expected_values;

-- Test 2: Average account balance is greater than 1000
CREATE TEMPORARY TABLE found_values 
SELECT AVG(balance) AS avg_balance FROM account;

CREATE TEMPORARY TABLE expected_values (min_balance DECIMAL(10,2));
INSERT INTO expected_values VALUES (1000.00);

SELECT
  CASE
    WHEN f.avg_balance >= e.min_balance 
    THEN '✅ Test 2 Passed: Avg. balance is sufficient'
    ELSE CONCAT('❌ Test 2 Failed: Avg balance too low: ', f.avg_balance)
  END AS result
FROM found_values f
JOIN expected_values e;

-- Clean up
DROP TEMPORARY TABLE found_values;
DROP TEMPORARY TABLE expected_values;

-- Test 3: Valid join between customer and account via customer_account
CREATE TEMPORARY TABLE found_values
SELECT COUNT(*) AS join_count
FROM customer c
JOIN customer_account ca ON c.customer_id = ca.customer_id
JOIN account a ON ca.account_number = a.account_number;

CREATE TEMPORARY TABLE expected_values (min_count INT);
INSERT INTO expected_values VALUES (100); -- Adjust as needed

SELECT
  CASE
    WHEN f.join_count >= e.min_count 
    THEN '✅ Test 3 Passed: Join valid'
    ELSE CONCAT('❌ Test 3 Failed: Not enough joined records, found ', f.join_count)
  END AS result
FROM found_values f
JOIN expected_values e;

-- Clean up
DROP TEMPORARY TABLE found_values;
DROP TEMPORARY TABLE expected_values;

-- Test 4: Transaction types check
CREATE TEMPORARY TABLE found_values
SELECT DISTINCT transaction_type FROM transaction ORDER BY transaction_type;

SELECT '🧪 Test 4: Distinct transaction types' AS test_name;
SELECT * FROM found_values;

-- Clean up
DROP TEMPORARY TABLE found_values;

-- Test 5: Sample high-value transaction check
CREATE TEMPORARY TABLE found_values
SELECT COUNT(*) AS high_value_txn FROM transaction WHERE amount > 90000;

CREATE TEMPORARY TABLE expected_values (min_txns INT);
INSERT INTO expected_values VALUES (5);

SELECT
  CASE
    WHEN f.high_value_txn >= e.min_txns 
    THEN '✅ Test 5 Passed: High-value transactions found'
    ELSE CONCAT('❌ Test 5 Failed: Found only ', f.high_value_txn, ' high-value transactions')
  END AS result
FROM found_values f
JOIN expected_values e;

-- Final Cleanup
DROP TEMPORARY TABLE found_values;
DROP TEMPORARY TABLE expected_values;
