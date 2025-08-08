- ****************************************************************************
--  Title:         Shopping Website DB - MD5 Checksum & Row Count Script
--  Description:   This script generates MD5 checksum hashes and row counts for 
--                 all key tables in the `shopping_website_db` schema. It then 
--                 compares the computed values with pre-stored expected values 
--                 for data integrity validation.
--
--  Author:        SHREYA S G
--  Created on:    2025-08-08
--  Last Updated:  2025-08-08
--
--  Usage:         1. Ensure all schema and seed data are loaded.
--                 2. Populate the `expected_values` table with the 
--                    expected record counts and MD5 checksums.
--                 3. Run this script to compute the actual values 
--                    and verify them against the expected ones.
--
--  Notes:         - MD5 hash is calculated in a deterministic row order.
--                 - COALESCE() is used to avoid NULL inconsistencies.
--                 - The `found_values` table is truncated before each run.
--                 - This script can be used in automated CI/CD pipelines for 
--                   regression testing of database state.
--
--  License:       © 2025 AscendionQA All rights reserved.
--                 Licensed under the MIT License.  
--                 See LICENSE file in the project root for details.
-- ****************************************************************************
-- --------------------------------------------------
-- Shopping Website DB - MD5 Checksum & Row Count Script
-- --------------------------------------------------
USE shopping_website_db;

-- --------------------------------------------------
-- Prepare storage tables
-- --------------------------------------------------
CREATE TABLE IF NOT EXISTS expected_values (
    table_name VARCHAR(100) PRIMARY KEY,
    recs INT,
    crc_md5 CHAR(32)
);

CREATE TABLE IF NOT EXISTS found_values (
    table_name VARCHAR(100) PRIMARY KEY,
    recs INT,
    crc_md5 CHAR(32)
);

-- Empty found_values before computing
TRUNCATE TABLE found_values;

-- --------------------------------------------------
-- Helper pattern:
--   1. SET @crc='' and @recs=0
--   2. Iterate rows in deterministic order
--   3. Use COALESCE(...,'') to avoid NULL inconsistencies
--   4. Insert final @crc and @recs into found_values
-- --------------------------------------------------

-- --------------------------------------------------
-- address
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(address_id,''),
    COALESCE(house_unit_no,''),
    COALESCE(address_line1,''),
    COALESCE(address_line2,''),
    COALESCE(city,''),
    COALESCE(region,''),
    COALESCE(postal_code,''),
    COALESCE(country,'')
)),
@recs := @recs + 1
FROM address
ORDER BY address_id;
INSERT INTO found_values VALUES ('address', @recs, @crc);

-- --------------------------------------------------
-- user_account
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(username,''),
    COALESCE(first_name,''),
    COALESCE(last_name,''),
    COALESCE(email_address,'')
)),
@recs := @recs + 1
FROM user_account
ORDER BY username;
INSERT INTO found_values VALUES ('user_account', @recs, @crc);

-- --------------------------------------------------
-- user_address
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(username,''),
    COALESCE(address_id,'')
)),
@recs := @recs + 1
FROM user_address
ORDER BY username, address_id;
INSERT INTO found_values VALUES ('user_address', @recs, @crc);

-- --------------------------------------------------
-- product_category
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(category_id,''),
    COALESCE(category_name,'')
)),
@recs := @recs + 1
FROM product_category
ORDER BY category_id;
INSERT INTO found_values VALUES ('product_category', @recs, @crc);

-- --------------------------------------------------
-- brand
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(brand_id,''),
    COALESCE(brand_name,'')
)),
@recs := @recs + 1
FROM brand
ORDER BY brand_id;
INSERT INTO found_values VALUES ('brand', @recs, @crc);

-- --------------------------------------------------
-- colour
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(colour_id,''),
    COALESCE(colour_name,'')
)),
@recs := @recs + 1
FROM colour
ORDER BY colour_id;
INSERT INTO found_values VALUES ('colour', @recs, @crc);

-- --------------------------------------------------
-- size
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(size_id,''),
    COALESCE(size_name,'')
)),
@recs := @recs + 1
FROM size
ORDER BY size_id;
INSERT INTO found_values VALUES ('size', @recs, @crc);

-- --------------------------------------------------
-- supplier
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(supplier_id,''),
    COALESCE(supplier_name,'')
)),
@recs := @recs + 1
FROM supplier
ORDER BY supplier_id;
INSERT INTO found_values VALUES ('supplier', @recs, @crc);

-- --------------------------------------------------
-- product
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(product_id,''),
    COALESCE(product_name,''),
    COALESCE(product_category_id,''),
    COALESCE(brand_id,''),
    COALESCE(colour_id,''),
    COALESCE(size_id,''),
    COALESCE(supplier_id,'')
)),
@recs := @recs + 1
FROM product
ORDER BY product_id;
INSERT INTO found_values VALUES ('product', @recs, @crc);

-- --------------------------------------------------
-- customer_order
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(order_id,''),
    COALESCE(order_discount,''),
    COALESCE(shipping_address,''),
    COALESCE(billing_address,''),
    COALESCE(username,''),
    COALESCE(order_date,'')
)),
@recs := @recs + 1
FROM customer_order
ORDER BY order_id;
INSERT INTO found_values VALUES ('customer_order', @recs, @crc);

-- --------------------------------------------------
-- customer_order_line
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(order_line_id,''),
    COALESCE(order_id,''),
    COALESCE(product_id,''),
    COALESCE(qty,''),
    COALESCE(discount,''),
    COALESCE(price,'')
)),
@recs := @recs + 1
FROM customer_order_line
ORDER BY order_line_id;
INSERT INTO found_values VALUES ('customer_order_line', @recs, @crc);

-- --------------------------------------------------
-- supplier_order
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(order_id,''),
    COALESCE(order_discount,''),
    COALESCE(supplier_id,''),
    COALESCE(order_date,'')
)),
@recs := @recs + 1
FROM supplier_order
ORDER BY order_id;
INSERT INTO found_values VALUES ('supplier_order', @recs, @crc);

-- --------------------------------------------------
-- supplier_order_line
-- --------------------------------------------------
SET @crc = '';
SET @recs = 0;
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(order_line_id,''),
    COALESCE(order_id,''),
    COALESCE(product_id,''),
    COALESCE(qty,''),
    COALESCE(discount,''),
    COALESCE(price,'')
)),
@recs := @recs + 1
FROM supplier_order_line
ORDER BY order_line_id;
INSERT INTO found_values VALUES ('supplier_order_line', @recs, @crc);

-- --------------------------------------------------
-- DONE
-- --------------------------------------------------
SELECT * FROM found_values;

SELECT f.table_name,
       f.recs AS found_records,
       e.recs AS expected_records,
       f.crc_md5 AS found_crc,
       e.crc_md5 AS expected_crc,
       CASE
           WHEN f.recs = e.recs AND f.crc_md5 = e.crc_md5 THEN 'PASS'
           ELSE 'FAIL'
       END AS test_result
FROM found_values f
JOIN expected_values e USING (table_name);
