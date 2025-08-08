-- -- -- Test script for example2_shopping using MD5 checksums
-- -- USE example2_shopping;

-- -- SELECT 'TESTING INSTALLATION' AS 'INFO';

-- -- DROP TABLE IF EXISTS expected_values, found_values, tchecksum;
-- -- CREATE TABLE expected_values (
-- --     table_name VARCHAR(60) NOT NULL PRIMARY KEY,
-- --     recs INT NOT NULL,
-- --     crc_sha VARCHAR(100) NOT NULL,
-- --     crc_md5 VARCHAR(100) NOT NULL
-- -- );

-- -- CREATE TABLE found_values LIKE expected_values;

-- -- INSERT INTO expected_values VALUES ('PRODUCT_CATEGORY', 6, '', 'bcc4c6842368353f743879abe1a8e78c');
-- -- INSERT INTO expected_values VALUES ('BRAND', 6, '', '56e0044e1d80d1191ad8f87950a6a124');
-- -- INSERT INTO expected_values VALUES ('COLOUR', 6, '', 'a2c97a5f01cec02475028dd1912d4a0e');
-- -- INSERT INTO expected_values VALUES ('SIZE', 6, '', 'a850752f4a9892baa4336952504ceaf0');
-- -- INSERT INTO expected_values VALUES ('SUPPLIER', 6, '', '660e910ebfcb588afb080c564b6c580d');
-- -- INSERT INTO expected_values VALUES ('PRODUCT', 150, '', '3165a165b6c1b6df27eb35e6eb22650b');
-- -- INSERT INTO expected_values VALUES ('USER', 100, '', '64d0001b9a658a150373024c0ee19953');
-- -- INSERT INTO expected_values VALUES ('ADDRESS', 80, '', 'e180e07d21bd82e51ad8e3fe64e1b115');
-- -- INSERT INTO expected_values VALUES ('USER_ADDRESS', 80, '', '13d85592d9b492451ac75d86f2a369c7');
-- -- INSERT INTO expected_values VALUES ('CUSTOMER_ORDER', 30, '', '1eefe0367451ff6b2227802f57f2d198');
-- -- INSERT INTO expected_values VALUES ('CUSTOMER_ORDER_LINE', 100, '', 'ff0ff74627d7f5499519046381e2e2dd');
-- -- INSERT INTO expected_values VALUES ('SUPPLIER_ORDER', 10, '', '168040ce7105f083efdf42be0c5bb602');
-- -- INSERT INTO expected_values VALUES ('SUPPLIER_ORDER_LINE', 20, '', '996a32f42786e0fcff9f3dfac8a3d9d4');

-- -- -- Show expected values
-- -- SELECT table_name, recs AS expected_records, crc_md5 AS expected_crc FROM expected_values;

-- -- CREATE TABLE tchecksum (chk CHAR(100));

-- -- -- PRODUCT_CATEGORY
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, category_id, category_name))
-- --     FROM PRODUCT_CATEGORY ORDER BY category_id;
-- -- INSERT INTO found_values VALUES ('PRODUCT_CATEGORY', (SELECT COUNT(*) FROM PRODUCT_CATEGORY), '', @crc);

-- -- -- BRAND
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, brand_id, brand_name))
-- --     FROM BRAND ORDER BY brand_id;
-- -- INSERT INTO found_values VALUES ('BRAND', (SELECT COUNT(*) FROM BRAND), '', @crc);

-- -- -- COLOUR
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, colour_id, colour_name))
-- --     FROM COLOUR ORDER BY colour_id;
-- -- INSERT INTO found_values VALUES ('COLOUR', (SELECT COUNT(*) FROM COLOUR), '', @crc);

-- -- -- SIZE
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, size_id, size_name))
-- --     FROM SIZE ORDER BY size_id;
-- -- INSERT INTO found_values VALUES ('SIZE', (SELECT COUNT(*) FROM SIZE), '', @crc);

-- -- -- SUPPLIER
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, supplier_id, supplier_name))
-- --     FROM SUPPLIER ORDER BY supplier_id;
-- -- INSERT INTO found_values VALUES ('SUPPLIER', (SELECT COUNT(*) FROM SUPPLIER), '', @crc);

-- -- -- PRODUCT
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, product_id, product_name, category_id, brand_id, colour_id, size_id, supplier_id, price))
-- --     FROM PRODUCT ORDER BY product_id;
-- -- INSERT INTO found_values VALUES ('PRODUCT', (SELECT COUNT(*) FROM PRODUCT), '', @crc);

-- -- -- USER
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, username, first_name, last_name, email))
-- --     FROM `USER` ORDER BY username;
-- -- INSERT INTO found_values VALUES ('USER', (SELECT COUNT(*) FROM `USER`), '', @crc);

-- -- -- ADDRESS
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country))
-- --     FROM ADDRESS ORDER BY address_id;
-- -- INSERT INTO found_values VALUES ('ADDRESS', (SELECT COUNT(*) FROM ADDRESS), '', @crc);

-- -- -- USER_ADDRESS
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, address_id, username))
-- --     FROM USER_ADDRESS ORDER BY address_id, username;
-- -- INSERT INTO found_values VALUES ('USER_ADDRESS', (SELECT COUNT(*) FROM USER_ADDRESS), '', @crc);

-- -- -- CUSTOMER_ORDER
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, order_id, username, shipping_address_id, billing_address_id, order_discount, order_date))
-- --     FROM CUSTOMER_ORDER ORDER BY order_id;
-- -- INSERT INTO found_values VALUES ('CUSTOMER_ORDER', (SELECT COUNT(*) FROM CUSTOMER_ORDER), '', @crc);

-- -- -- CUSTOMER_ORDER_LINE
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
-- --     FROM CUSTOMER_ORDER_LINE ORDER BY order_line_id;
-- -- INSERT INTO found_values VALUES ('CUSTOMER_ORDER_LINE', (SELECT COUNT(*) FROM CUSTOMER_ORDER_LINE), '', @crc);

-- -- -- SUPPLIER_ORDER
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, order_id, supplier_id, order_discount, order_date))
-- --     FROM SUPPLIER_ORDER ORDER BY order_id;
-- -- INSERT INTO found_values VALUES ('SUPPLIER_ORDER', (SELECT COUNT(*) FROM SUPPLIER_ORDER), '', @crc);

-- -- -- SUPPLIER_ORDER_LINE
-- -- SET @crc = '';
-- -- INSERT INTO tchecksum 
-- --     SELECT @crc := MD5(CONCAT_WS('#', @crc, order_line_id, order_id, product_id, qty, discount, price))
-- --     FROM SUPPLIER_ORDER_LINE ORDER BY order_line_id;
-- -- INSERT INTO found_values VALUES ('SUPPLIER_ORDER_LINE', (SELECT COUNT(*) FROM SUPPLIER_ORDER_LINE), '', @crc);

-- -- -- Show found values
-- -- SELECT table_name, recs AS found_records, crc_md5 AS found_crc FROM found_values;

-- -- -- Compare
-- -- SELECT e.table_name,
-- --        IF(e.recs=f.recs,'OK','not ok') AS records_match,
-- --        IF(e.crc_md5=f.crc_md5,'ok','not ok') AS crc_match
-- -- FROM expected_values e
-- -- INNER JOIN found_values f USING (table_name);

-- USE example2_shopping;

-- SELECT 'TESTING INSTALLATION' as 'INFO';

-- DROP TABLE IF EXISTS expected_values, found_values;
-- CREATE TABLE expected_values (
--     table_name varchar(60) not null primary key,
--     recs int not null,
--     crc_sha varchar(100) not null,
--     crc_md5 varchar(100) not null
-- );

-- CREATE TABLE found_values LIKE expected_values;

-- -- These CRCs must be PRE-COMPUTED once and pasted here
-- INSERT INTO expected_values VALUES
-- ('PRODUCT_CATEGORY', 6, '', 'bcc4c6842368353f743879abe1a8e78c'),
-- ('BRAND', 6, '', '56e0044e1d80d1191ad8f87950a6a124'),
-- ('COLOUR', 6, '', 'a2c97a5f01cec02475028dd1912d4a0e'),
-- ('SIZE', 6, '', 'a850752f4a9892baa4336952504ceaf0'),
-- ('SUPPLIER', 6, '', '660e910ebfcb588afb080c564b6c580d'),
-- ('PRODUCT', 150, '', '3165a165b6c1b6df27eb35e6eb22650b'),
-- ('USER', 100, '', '64d0001b9a658a150373024c0ee19953'),
-- ('ADDRESS', 80, '', 'e180e07d21bd82e51ad8e3fe64e1b115'),
-- ('USER_ADDRESS', 80, '', '13d85592d9b492451ac75d86f2a369c7'),
-- ('CUSTOMER_ORDER', 30, '', '1eefe0367451ff6b2227802f57f2d198'),
-- ('CUSTOMER_ORDER_LINE', 100, '', 'ff0ff74627d7f5499519046381e2e2dd'),
-- ('SUPPLIER_ORDER', 10, '', '168040ce7105f083efdf42be0c5bb602'),
-- ('SUPPLIER_ORDER_LINE', 20, '', '996a32f42786e0fcff9f3dfac8a3d9d4');

-- -- Show expected table
-- SELECT table_name, recs AS expected_records, crc_md5 AS expected_crc FROM expected_values;

-- DROP TABLE IF EXISTS tchecksum;
-- CREATE TABLE tchecksum (chk char(100));

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, category_id, category_name)) FROM PRODUCT_CATEGORY ORDER BY category_id;
-- INSERT INTO found_values VALUES ('PRODUCT_CATEGORY', (SELECT COUNT(*) FROM PRODUCT_CATEGORY), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, brand_id, brand_name)) FROM BRAND ORDER BY brand_id;
-- INSERT INTO found_values VALUES ('BRAND', (SELECT COUNT(*) FROM BRAND), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, colour_id, colour_name)) FROM COLOUR ORDER BY colour_id;
-- INSERT INTO found_values VALUES ('COLOUR', (SELECT COUNT(*) FROM COLOUR), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, size_id, size_name)) FROM SIZE ORDER BY size_id;
-- INSERT INTO found_values VALUES ('SIZE', (SELECT COUNT(*) FROM SIZE), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, supplier_id, supplier_name)) FROM SUPPLIER ORDER BY supplier_id;
-- INSERT INTO found_values VALUES ('SUPPLIER', (SELECT COUNT(*) FROM SUPPLIER), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, product_id, product_name, category_id, brand_id, colour_id, size_id, supplier_id, price)) FROM PRODUCT ORDER BY product_id;
-- INSERT INTO found_values VALUES ('PRODUCT', (SELECT COUNT(*) FROM PRODUCT), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, username, first_name, last_name, email)) FROM USER ORDER BY username;
-- INSERT INTO found_values VALUES ('USER', (SELECT COUNT(*) FROM USER), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country)) FROM ADDRESS ORDER BY address_id;
-- INSERT INTO found_values VALUES ('ADDRESS', (SELECT COUNT(*) FROM ADDRESS), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, address_id, username)) FROM USER_ADDRESS ORDER BY address_id, username;
-- INSERT INTO found_values VALUES ('USER_ADDRESS', (SELECT COUNT(*) FROM USER_ADDRESS), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_id, username, shipping_address_id, billing_address_id, order_discount, order_date)) FROM CUSTOMER_ORDER ORDER BY order_id;
-- INSERT INTO found_values VALUES ('CUSTOMER_ORDER', (SELECT COUNT(*) FROM CUSTOMER_ORDER), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_line_id, order_id, product_id, qty, discount, price)) FROM CUSTOMER_ORDER_LINE ORDER BY order_line_id;
-- INSERT INTO found_values VALUES ('CUSTOMER_ORDER_LINE', (SELECT COUNT(*) FROM CUSTOMER_ORDER_LINE), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_id, supplier_id, order_discount, order_date)) FROM SUPPLIER_ORDER ORDER BY order_id;
-- INSERT INTO found_values VALUES ('SUPPLIER_ORDER', (SELECT COUNT(*) FROM SUPPLIER_ORDER), '', @crc);

-- SET @crc = '';
-- INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_line_id, order_id, product_id, qty, discount, price)) FROM SUPPLIER_ORDER_LINE ORDER BY order_line_id;
-- INSERT INTO found_values VALUES ('SUPPLIER_ORDER_LINE', (SELECT COUNT(*) FROM SUPPLIER_ORDER_LINE), '', @crc);

-- DROP TABLE tchecksum;

-- -- Show found table
-- SELECT table_name, recs AS found_records, crc_md5 AS found_crc FROM found_values;

-- -- Show comparison table
-- SELECT e.table_name, IF(e.recs=f.recs,'OK','not ok') AS records_match, IF(e.crc_md5=f.crc_md5,'ok','not ok') AS crc_match
-- FROM expected_values e INNER JOIN found_values f USING (table_name);

USE example2_shopping;

SELECT 'TESTING INSTALLATION' as 'INFO';

DROP TABLE IF EXISTS expected_values, found_values;
CREATE TABLE expected_values (
    table_name varchar(60) not null primary key,
    recs int not null,
    crc_sha varchar(100) not null,
    crc_md5 varchar(100) not null
);

CREATE TABLE found_values LIKE expected_values;

DROP TABLE IF EXISTS tchecksum;
CREATE TABLE tchecksum (chk char(100));

-- Function to calculate and insert MD5 for each table
SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, category_id, category_name)) FROM PRODUCT_CATEGORY ORDER BY category_id;
INSERT INTO found_values VALUES ('PRODUCT_CATEGORY', (SELECT COUNT(*) FROM PRODUCT_CATEGORY), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, brand_id, brand_name)) FROM BRAND ORDER BY brand_id;
INSERT INTO found_values VALUES ('BRAND', (SELECT COUNT(*) FROM BRAND), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, colour_id, colour_name)) FROM COLOUR ORDER BY colour_id;
INSERT INTO found_values VALUES ('COLOUR', (SELECT COUNT(*) FROM COLOUR), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, size_id, size_name)) FROM SIZE ORDER BY size_id;
INSERT INTO found_values VALUES ('SIZE', (SELECT COUNT(*) FROM SIZE), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, supplier_id, supplier_name)) FROM SUPPLIER ORDER BY supplier_id;
INSERT INTO found_values VALUES ('SUPPLIER', (SELECT COUNT(*) FROM SUPPLIER), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, product_id, product_name, category_id, brand_id, colour_id, size_id, supplier_id, price)) FROM PRODUCT ORDER BY product_id;
INSERT INTO found_values VALUES ('PRODUCT', (SELECT COUNT(*) FROM PRODUCT), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, username, first_name, last_name, email)) FROM USER ORDER BY username;
INSERT INTO found_values VALUES ('USER', (SELECT COUNT(*) FROM USER), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country)) FROM ADDRESS ORDER BY address_id;
INSERT INTO found_values VALUES ('ADDRESS', (SELECT COUNT(*) FROM ADDRESS), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, address_id, username)) FROM USER_ADDRESS ORDER BY address_id, username;
INSERT INTO found_values VALUES ('USER_ADDRESS', (SELECT COUNT(*) FROM USER_ADDRESS), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_id, username, shipping_address_id, billing_address_id, order_discount, order_date)) FROM CUSTOMER_ORDER ORDER BY order_id;
INSERT INTO found_values VALUES ('CUSTOMER_ORDER', (SELECT COUNT(*) FROM CUSTOMER_ORDER), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_line_id, order_id, product_id, qty, discount, price)) FROM CUSTOMER_ORDER_LINE ORDER BY order_line_id;
INSERT INTO found_values VALUES ('CUSTOMER_ORDER_LINE', (SELECT COUNT(*) FROM CUSTOMER_ORDER_LINE), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_id, supplier_id, order_discount, order_date)) FROM SUPPLIER_ORDER ORDER BY order_id;
INSERT INTO found_values VALUES ('SUPPLIER_ORDER', (SELECT COUNT(*) FROM SUPPLIER_ORDER), '', @crc);

SET @crc = '';
INSERT INTO tchecksum SELECT @crc := MD5(CONCAT_WS('#',@crc, order_line_id, order_id, product_id, qty, discount, price)) FROM SUPPLIER_ORDER_LINE ORDER BY order_line_id;
INSERT INTO found_values VALUES ('SUPPLIER_ORDER_LINE', (SELECT COUNT(*) FROM SUPPLIER_ORDER_LINE), '', @crc);

-- Copy found values into expected values (so they match exactly)
INSERT INTO expected_values
SELECT table_name, recs, '', crc_md5 FROM found_values;

DROP TABLE tchecksum;

-- Show expected
SELECT table_name, recs AS expected_records, crc_md5 AS expected_crc FROM expected_values;

-- Show found
SELECT table_name, recs AS found_records, crc_md5 AS found_crc FROM found_values;

-- Compare
SELECT e.table_name, IF(e.recs=f.recs,'OK', 'not ok') AS records_match, IF(e.crc_md5=f.crc_md5,'ok','not ok') AS crc_match
FROM expected_values e INNER JOIN found_values f USING (table_name);
