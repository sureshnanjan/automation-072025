-- © 2025 Teja Reddy
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

-- Use the database for which we want to verify data integrity
USE shopping_website_db;

-- Drop any existing 'found_values' and temporary checksum table to avoid conflicts
DROP TABLE IF EXISTS found_values;
DROP TABLE IF EXISTS tchecksum;  

-- Create a table to store the current (found) record counts and SHA1 checksums per table
CREATE TABLE found_values (
    table_name VARCHAR(50) PRIMARY KEY,  -- Table name
    recs INT NOT NULL,                   -- Number of records found in the table
    crc_sha1 VARCHAR(100) NOT NULL       -- SHA1 checksum of the table data content
);

-- Temporary table to hold intermediate checksum calculations
CREATE TABLE tchecksum (chk CHAR(100));

-- ----------- Calculate checksum for 'address' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, 
    address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country))
FROM address ORDER BY address_id;
INSERT INTO found_values VALUES ('address', (SELECT COUNT(*) FROM address), @crc);

-- ----------- Calculate checksum for 'brand' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, brand_id, brand_name))
FROM brand ORDER BY brand_id;
INSERT INTO found_values VALUES ('brand', (SELECT COUNT(*) FROM brand), @crc);

-- ----------- Calculate checksum for 'colour' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, colour_id, colour_name))
FROM colour ORDER BY colour_id;
INSERT INTO found_values VALUES ('colour', (SELECT COUNT(*) FROM colour), @crc);

-- ----------- Calculate checksum for 'customer_order' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_id, order_discount, shipping_address, billing_address, username, order_date))
FROM customer_order ORDER BY order_id;
INSERT INTO found_values VALUES ('customer_order', (SELECT COUNT(*) FROM customer_order), @crc);

-- ----------- Calculate checksum for 'customer_order_line' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
FROM customer_order_line ORDER BY order_line_id;
INSERT INTO found_values VALUES ('customer_order_line', (SELECT COUNT(*) FROM customer_order_line), @crc);

-- ----------- Calculate checksum for 'product' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, product_id, product_name, product_category_id, brand_id, colour_id, size_id, supplier_id))
FROM product ORDER BY product_id;
INSERT INTO found_values VALUES ('product', (SELECT COUNT(*) FROM product), @crc);

-- ----------- Calculate checksum for 'product_category' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, category_id, category_name))
FROM product_category ORDER BY category_id;
INSERT INTO found_values VALUES ('product_category', (SELECT COUNT(*) FROM product_category), @crc);

-- ----------- Calculate checksum for 'size' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, size_id, size_name))
FROM size ORDER BY size_id;
INSERT INTO found_values VALUES ('size', (SELECT COUNT(*) FROM size), @crc);

-- ----------- Calculate checksum for 'supplier' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, supplier_id, supplier_name))
FROM supplier ORDER BY supplier_id;
INSERT INTO found_values VALUES ('supplier', (SELECT COUNT(*) FROM supplier), @crc);

-- ----------- Calculate checksum for 'supplier_order' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_id, order_discount, supplier_id, order_date))
FROM supplier_order ORDER BY order_id;
INSERT INTO found_values VALUES ('supplier_order', (SELECT COUNT(*) FROM supplier_order), @crc);

-- ----------- Calculate checksum for 'supplier_order_line' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
FROM supplier_order_line ORDER BY order_line_id;
INSERT INTO found_values VALUES ('supplier_order_line', (SELECT COUNT(*) FROM supplier_order_line), @crc);

-- ----------- Calculate checksum for 'user_account' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, username, first_name, last_name, email_address))
FROM user_account ORDER BY username;
INSERT INTO found_values VALUES ('user_account', (SELECT COUNT(*) FROM user_account), @crc);

-- ----------- Calculate checksum for 'user_address' table -----------
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#', @crc, username, address_id))
FROM user_address ORDER BY username, address_id;
INSERT INTO found_values VALUES ('user_address', (SELECT COUNT(*) FROM user_address), @crc);

-- Drop the temporary checksum table as it's no longer needed
DROP TABLE tchecksum;

-- Output the current record counts and checksums for each table for comparison or verification
SELECT * FROM found_values ORDER BY table_name;
