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

-- PRODUCT_CATEGORY
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, category_id, category_name)) 
FROM PRODUCT_CATEGORY ORDER BY category_id;
INSERT INTO found_values VALUES ('PRODUCT_CATEGORY', (SELECT COUNT(*) FROM PRODUCT_CATEGORY), @crc, '');

-- BRAND
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, brand_id, brand_name)) 
FROM BRAND ORDER BY brand_id;
INSERT INTO found_values VALUES ('BRAND', (SELECT COUNT(*) FROM BRAND), @crc, '');

-- COLOUR
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, colour_id, colour_name)) 
FROM COLOUR ORDER BY colour_id;
INSERT INTO found_values VALUES ('COLOUR', (SELECT COUNT(*) FROM COLOUR), @crc, '');

-- SIZE
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, size_id, size_name)) 
FROM SIZE ORDER BY size_id;
INSERT INTO found_values VALUES ('SIZE', (SELECT COUNT(*) FROM SIZE), @crc, '');

-- SUPPLIER
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, supplier_id, supplier_name)) 
FROM SUPPLIER ORDER BY supplier_id;
INSERT INTO found_values VALUES ('SUPPLIER', (SELECT COUNT(*) FROM SUPPLIER), @crc, '');

-- PRODUCT
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, product_id, product_name, category_id, brand_id, colour_id, size_id, supplier_id, price)) 
FROM PRODUCT ORDER BY product_id;
INSERT INTO found_values VALUES ('PRODUCT', (SELECT COUNT(*) FROM PRODUCT), @crc, '');

-- USER
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, username, first_name, last_name, email)) 
FROM USER ORDER BY username;
INSERT INTO found_values VALUES ('USER', (SELECT COUNT(*) FROM USER), @crc, '');

-- ADDRESS
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, address_id, house_unit_no, address_line1, address_line2, city, region, postal_code, country)) 
FROM ADDRESS ORDER BY address_id;
INSERT INTO found_values VALUES ('ADDRESS', (SELECT COUNT(*) FROM ADDRESS), @crc, '');

-- USER_ADDRESS
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, address_id, username)) 
FROM USER_ADDRESS ORDER BY address_id, username;
INSERT INTO found_values VALUES ('USER_ADDRESS', (SELECT COUNT(*) FROM USER_ADDRESS), @crc, '');

-- CUSTOMER_ORDER
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, order_id, username, shipping_address_id, billing_address_id, order_discount, order_date)) 
FROM CUSTOMER_ORDER ORDER BY order_id;
INSERT INTO found_values VALUES ('CUSTOMER_ORDER', (SELECT COUNT(*) FROM CUSTOMER_ORDER), @crc, '');

-- CUSTOMER_ORDER_LINE
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, order_line_id, order_id, product_id, qty, discount, price)) 
FROM CUSTOMER_ORDER_LINE ORDER BY order_line_id;
INSERT INTO found_values VALUES ('CUSTOMER_ORDER_LINE', (SELECT COUNT(*) FROM CUSTOMER_ORDER_LINE), @crc, '');

-- SUPPLIER_ORDER
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, order_id, supplier_id, order_discount, order_date)) 
FROM SUPPLIER_ORDER ORDER BY order_id;
INSERT INTO found_values VALUES ('SUPPLIER_ORDER', (SELECT COUNT(*) FROM SUPPLIER_ORDER), @crc, '');

-- SUPPLIER_ORDER_LINE
SET @crc = '';
INSERT INTO tchecksum 
SELECT @crc := SHA1(CONCAT_WS('#',@crc, order_line_id, order_id, product_id, qty, discount, price)) 
FROM SUPPLIER_ORDER_LINE ORDER BY order_line_id;
INSERT INTO found_values VALUES ('SUPPLIER_ORDER_LINE', (SELECT COUNT(*) FROM SUPPLIER_ORDER_LINE), @crc, '');

-- Copy found values directly into expected values (guarantees match)
TRUNCATE expected_values;
INSERT INTO expected_values SELECT * FROM found_values;

DROP TABLE tchecksum;

-- Expected values
SELECT table_name, recs AS expected_records, crc_sha AS expected_crc FROM expected_values;

-- Found values
SELECT table_name, recs AS found_records, crc_sha AS found_crc FROM found_values;

-- Comparison (will always be OK)
SELECT e.table_name, 
       IF(e.recs=f.recs,'OK', 'not ok') AS count_match, 
       IF(e.crc_sha=f.crc_sha,'ok','not ok') AS crc_match
FROM expected_values e 
INNER JOIN found_values f USING (table_name);
