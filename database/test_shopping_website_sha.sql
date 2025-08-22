-- © 2025 Teja Reddy
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

-- Switch to the shopping_website_db database
USE shopping_website_db;

-- Print a simple info message indicating the start of the test process 
SELECT 'TESTING INSTALLATION' AS INFO;

-- Drop existing tables if they exist to ensure clean state for this test run
DROP TABLE IF EXISTS expected_values, found_values;

-- Create table to hold known baseline (expected) record counts and SHA1 checksums
CREATE TABLE expected_values (
    table_name VARCHAR(50) PRIMARY KEY, -- Table name
    recs INT NOT NULL,                  -- Expected number of records
    crc_sha1 VARCHAR(100) NOT NULL     -- Expected SHA1 checksum of the table data
);

-- Create table with identical structure to hold computed values during this test run
CREATE TABLE found_values LIKE expected_values;

-- Insert the known baseline expected values into expected_values
-- These values must be updated to your verified baseline for correct validation
INSERT INTO expected_values VALUES
('address', 20, 'c78647290ee7b2ac7ddc6765759105c388094135'),
('brand', 5, '896d4182621264f49a2790c2285504d8d5fc5d2c'),
('colour', 5, '8cbab66e08e9621b6e90c3973bf8cffa975251ab'),
('customer_order', 20, '1c3e69b5bd22f6af9e384c8971c1618be1659b8e'),
('customer_order_line', 20, 'b3f9e2f5a89fdab838915e1189e29755c72d6c30'),
('product', 20, 'a297baaf5b75d5ad6c535f9af1dfdea6bb7ff0ab'),
('product_category', 5, 'fd9c44f9d5ca79c2b27a70bfd1f14d2ec80a512a'),
('size', 5, 'f05344ac8e138b5430cda9bd88cbb5d59f445e2d'),
('supplier', 5, 'f29c9a2082191e9a206f81fe8f7cbf16e9f819d4'),
('supplier_order', 5, 'f1d378b7e0d1b364175aa4891281d44c18a7520f'),
('supplier_order_line', 20, 'ef7da212193a56108597e07b7c51849d56520433'),
('user_account', 20, '97f3deb7020ba30ab95fdad7cd0936f37ea5d06b'),
('user_address', 20, '7cdaa40acc056f394c4c0b2795018a1efdd7e41e');

-- Drop temporary checksum table if exists to ensure clean setup
DROP TABLE IF EXISTS tchecksum;

-- Create a temporary table to hold intermediate checksum computation values
CREATE TABLE tchecksum (chk CHAR(100));

-- ------------------------
-- Compute SHA1 checksums and record counts for each table
-- Steps for each table:
-- 1. Initialize a session variable @crc to empty string
-- 2. Use SHA1 hashing to accumulate a checksum over ordered concatenated row values
-- 3. Insert the computed checksum and record count into found_values table
-- ------------------------

-- Compute checksum for 'address' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, 
    address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country))
FROM address ORDER BY address_id;
INSERT INTO found_values VALUES ('address', (SELECT COUNT(*) FROM address), @crc);

-- Compute checksum for 'brand' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, brand_id, brand_name))
FROM brand ORDER BY brand_id;
INSERT INTO found_values VALUES ('brand', (SELECT COUNT(*) FROM brand), @crc);

-- Compute checksum for 'colour' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, colour_id, colour_name))
FROM colour ORDER BY colour_id;
INSERT INTO found_values VALUES ('colour', (SELECT COUNT(*) FROM colour), @crc);

-- Compute checksum for 'customer_order' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_id, order_discount, shipping_address, billing_address, username, order_date))
FROM customer_order ORDER BY order_id;
INSERT INTO found_values VALUES ('customer_order', (SELECT COUNT(*) FROM customer_order), @crc);

-- Compute checksum for 'customer_order_line' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
FROM customer_order_line ORDER BY order_line_id;
INSERT INTO found_values VALUES ('customer_order_line', (SELECT COUNT(*) FROM customer_order_line), @crc);

-- Compute checksum for 'product' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, product_id, product_name, product_category_id, brand_id, colour_id, size_id, supplier_id))
FROM product ORDER BY product_id;
INSERT INTO found_values VALUES ('product', (SELECT COUNT(*) FROM product), @crc);

-- Compute checksum for 'product_category' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, category_id, category_name))
FROM product_category ORDER BY category_id;
INSERT INTO found_values VALUES ('product_category', (SELECT COUNT(*) FROM product_category), @crc);

-- Compute checksum for 'size' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, size_id, size_name))
FROM size ORDER BY size_id;
INSERT INTO found_values VALUES ('size', (SELECT COUNT(*) FROM size), @crc);

-- Compute checksum for 'supplier' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, supplier_id, supplier_name))
FROM supplier ORDER BY supplier_id;
INSERT INTO found_values VALUES ('supplier', (SELECT COUNT(*) FROM supplier), @crc);

-- Compute checksum for 'supplier_order' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_id, order_discount, supplier_id, order_date))
FROM supplier_order ORDER BY order_id;
INSERT INTO found_values VALUES ('supplier_order', (SELECT COUNT(*) FROM supplier_order), @crc);

-- Compute checksum for 'supplier_order_line' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
FROM supplier_order_line ORDER BY order_line_id;
INSERT INTO found_values VALUES ('supplier_order_line', (SELECT COUNT(*) FROM supplier_order_line), @crc);

-- Compute checksum for 'user_account' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, username, first_name, last_name, email_address))
FROM user_account ORDER BY username;
INSERT INTO found_values VALUES ('user_account', (SELECT COUNT(*) FROM user_account), @crc);

-- Compute checksum for 'user_address' table
SET @crc = '';
INSERT INTO tchecksum
SELECT @crc := SHA1(CONCAT_WS('#', @crc, username, address_id))
FROM user_address ORDER BY username, address_id;
INSERT INTO found_values VALUES ('user_address', (SELECT COUNT(*) FROM user_address), @crc);

-- Drop the temporary checksum table as it's no longer needed
DROP TABLE tchecksum;

-- ---------------------------
-- Display expected baseline record counts and SHA1 checksums for verification
-- ---------------------------
SELECT table_name, recs AS expected_records, crc_sha1 AS expected_crc 
FROM expected_values 
ORDER BY table_name;

-- ---------------------------
-- Display found record counts and computed SHA1 checksums
-- ---------------------------
SELECT table_name, recs AS found_records, crc_sha1 AS found_crc 
FROM found_values 
ORDER BY table_name;

-- ---------------------------
-- Compare expected and found values for record counts and checksums
-- Output result as 'OK'/'FAIL' for record counts, 'ok'/'not ok' for checksums
-- ---------------------------
SELECT 
    e.table_name,
    IF(e.recs = f.recs, 'OK', 'FAIL') AS records_match,
    IF(e.crc_sha1 = f.crc_sha1, 'ok', 'not ok') AS crc_match
FROM expected_values e
JOIN found_values f USING (table_name)
ORDER BY e.table_name;
