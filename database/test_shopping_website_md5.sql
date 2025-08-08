-- © 2025 Elangovan R
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

-- Use the shopping_website_db database to perform validation tests
USE shopping_website_db;

-- Display informational message indicating start of installation testing
SELECT 'TESTING INSTALLATION' AS INFO;

-- Drop old tables if they exist to start fresh for this test run
DROP TABLE IF EXISTS expected_values, found_values;

-- Create a table to hold the known baseline expected record counts and MD5 checksums
CREATE TABLE expected_values (
    table_name VARCHAR(50) PRIMARY KEY,  -- Table name
    recs INT NOT NULL,                   -- Expected number of records in the table
    crc_md5 VARCHAR(100) NOT NULL       -- Expected MD5 checksum of the table data
);

-- Create a table to store the checksums and record counts found during this test run
CREATE TABLE found_values LIKE expected_values;

-- Insert the known baseline expected values into expected_values table
-- These values should be updated to match your verified baseline data
INSERT INTO expected_values VALUES
('address', 50, '3038773c07ca3defe8c54f669b8d13d1'),
('brand', 50, 'b8c8bf5170f3861d522b08527cd631c4'),
('colour', 8, 'e594800bcb1df8e984d9f49555785a21'),
('customer_order', 50, '7b54d013f51057c3e42169172e6fd743'),
('customer_order_line', 50, '4171d845d7c23844f4ff0308965bde88'),
('product', 50, '9037f99f0f70faa988a403e9ef9a20f6'),
('product_category', 5, '80108f78ff05afc73569418e1d3579dc'),
('size', 7, 'db3636d58cae2af350d814cdb4c26a8d'),
('supplier', 6, '1ed270e2786b9d5ea375e692964009f0'),
('supplier_order', 50, 'b4069f32a198d96e3855edd43eb191bf'),
('supplier_order_line', 50, '515e4a3d62a5312e8c0bc354bef79856'),
('user_account', 50, '033ec9496994f252720e16572d9ec4e3'),
('user_address', 50, '4a3c52fe92ed7f2cdefdabadad1088c8');

-- Drop temporary checksum table if exists (cleanup from previous runs)
DROP TABLE IF EXISTS tchecksum;

-- Create a temporary table to hold intermediate checksum computations
CREATE TABLE tchecksum (chk CHAR(100));

-- ------------------------------------
-- Generate MD5 checksums for each table based on concatenated row data
-- and insert the computed record count and checksum into found_values
-- ------------------------------------

-- Calculate checksum for 'address' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, 
    address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country))
FROM address ORDER BY address_id;
INSERT INTO found_values VALUES ('address', (SELECT COUNT(*) FROM address), @crc);

-- Calculate checksum for 'brand' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, brand_id, brand_name))
FROM brand ORDER BY brand_id;
INSERT INTO found_values VALUES ('brand', (SELECT COUNT(*) FROM brand), @crc);

-- Calculate checksum for 'colour' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, colour_id, colour_name))
FROM colour ORDER BY colour_id;
INSERT INTO found_values VALUES ('colour', (SELECT COUNT(*) FROM colour), @crc);

-- Calculate checksum for 'customer_order' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, order_id, order_discount, shipping_address, billing_address, username, order_date))
FROM customer_order ORDER BY order_id;
INSERT INTO found_values VALUES ('customer_order', (SELECT COUNT(*) FROM customer_order), @crc);

-- Calculate checksum for 'customer_order_line' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
FROM customer_order_line ORDER BY order_line_id;
INSERT INTO found_values VALUES ('customer_order_line', (SELECT COUNT(*) FROM customer_order_line), @crc);

-- Calculate checksum for 'product' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, product_id, product_name, product_category_id, brand_id, colour_id, size_id, supplier_id))
FROM product ORDER BY product_id;
INSERT INTO found_values VALUES ('product', (SELECT COUNT(*) FROM product), @crc);

-- Calculate checksum for 'product_category' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, category_id, category_name))
FROM product_category ORDER BY category_id;
INSERT INTO found_values VALUES ('product_category', (SELECT COUNT(*) FROM product_category), @crc);

-- Calculate checksum for 'size' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, size_id, size_name))
FROM size ORDER BY size_id;
INSERT INTO found_values VALUES ('size', (SELECT COUNT(*) FROM size), @crc);

-- Calculate checksum for 'supplier' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, supplier_id, supplier_name))
FROM supplier ORDER BY supplier_id;
INSERT INTO found_values VALUES ('supplier', (SELECT COUNT(*) FROM supplier), @crc);

-- Calculate checksum for 'supplier_order' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, order_id, order_discount, supplier_id, order_date))
FROM supplier_order ORDER BY order_id;
INSERT INTO found_values VALUES ('supplier_order', (SELECT COUNT(*) FROM supplier_order), @crc);

-- Calculate checksum for 'supplier_order_line' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
FROM supplier_order_line ORDER BY order_line_id;
INSERT INTO found_values VALUES ('supplier_order_line', (SELECT COUNT(*) FROM supplier_order_line), @crc);

-- Calculate checksum for 'user_account' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, username, first_name, last_name, email_address))
FROM user_account ORDER BY username;
INSERT INTO found_values VALUES ('user_account', (SELECT COUNT(*) FROM user_account), @crc);

-- Calculate checksum for 'user_address' table
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := MD5(CONCAT_WS('#', @crc, username, address_id))
FROM user_address ORDER BY username, address_id;
INSERT INTO found_values VALUES ('user_address', (SELECT COUNT(*) FROM user_address), @crc);

-- Drop temporary checksum table after use
DROP TABLE tchecksum;

-- ---------------------------
-- Output the baseline expected data for reference
-- ---------------------------
SELECT table_name, recs AS expected_records, crc_md5 AS expected_crc 
FROM expected_values 
ORDER BY table_name;

-- ---------------------------
-- Output the actual found data for comparison
-- ---------------------------
SELECT table_name, recs AS found_records, crc_md5 AS found_crc 
FROM found_values 
ORDER BY table_name;

-- ---------------------------
-- Compare expected vs found data for record count and checksum
-- Outputs 'OK'/'FAIL' and 'ok'/'not ok' accordingly
-- ---------------------------
SELECT 
    e.table_name,
    IF(e.recs = f.recs, 'OK', 'FAIL') AS records_match,
    IF(e.crc_md5 = f.crc_md5, 'ok', 'not ok') AS crc_match
FROM expected_values e
JOIN found_values f USING (table_name)
ORDER BY e.table_name;
