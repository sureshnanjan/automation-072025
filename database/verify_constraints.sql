-- © 2025 Elangovan R
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

USE shopping_website_db;

-- Check 1: Verify there are no NULL values in mandatory fields across important tables.
-- This helps ensure essential data integrity by identifying missing required information.
SELECT 'Checking for NULL values in mandatory fields...' AS check_name;

-- Check user_account table for missing usernames or email addresses (both required).
SELECT 'user_account table', COUNT(*) AS null_count
FROM user_account
WHERE username IS NULL OR email_address IS NULL;

-- Check product table for missing product names.
SELECT 'product table', COUNT(*) AS null_count
FROM product
WHERE product_name IS NULL;

-- Check customer_order table for missing usernames or order dates.
SELECT 'customer_order table', COUNT(*) AS null_count
FROM customer_order
WHERE username IS NULL OR order_date IS NULL;

-- Check 2: Validate foreign key relationships to prevent orphaned records or integrity issues.
SELECT 'Checking foreign key violations...' AS check_name;

-- Find customer orders referencing non-existent usernames.
SELECT order_id
FROM customer_order
WHERE username NOT IN (SELECT username FROM user_account);

-- Find order lines referencing non-existent orders.
SELECT order_line_id
FROM customer_order_line
WHERE order_id NOT IN (SELECT order_id FROM customer_order);

-- Find order lines referencing non-existent products.
SELECT order_line_id
FROM customer_order_line
WHERE product_id NOT IN (SELECT product_id FROM product);
