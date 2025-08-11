SELECT 'TESTING BANKING SYSTEM INSTALLATION' AS 'INFO';

-- Remove old temp tables
DROP TABLE IF EXISTS expected_values, found_values;
CREATE TABLE expected_values (
    table_name VARCHAR(30) NOT NULL PRIMARY KEY,
    recs INT NOT NULL,
    crc_md5 VARCHAR(100) NOT NULL
);

CREATE TABLE found_values LIKE expected_values;

-- TEMP checksum table
DROP TABLE IF EXISTS tchecksum;
CREATE TABLE tchecksum (chk CHAR(100));

-- ====== CUSTOMER ======
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                customer_id, first_name, last_name, date_of_birth, signup_date))
    FROM customer ORDER BY customer_id;
INSERT INTO found_values VALUES ('customer', (SELECT COUNT(*) FROM customer), @crc);

-- ====== ACCOUNT_TYPE ======
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                account_type_id, account_type))
    FROM account_type ORDER BY account_type_id;
INSERT INTO found_values VALUES ('account_type', (SELECT COUNT(*) FROM account_type), @crc);

-- ====== ACCOUNT_STATUS ======
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                status_id, status_value))
    FROM account_status ORDER BY status_id;
INSERT INTO found_values VALUES ('account_status', (SELECT COUNT(*) FROM account_status), @crc);

-- ====== ACCOUNT ======
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                account_number, account_type_id, status_id, date_opened, date_closed))
    FROM account ORDER BY account_number;
INSERT INTO found_values VALUES ('account', (SELECT COUNT(*) FROM account), @crc);

-- ====== CUSTOMER_ACCOUNT ======
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                account_number, customer_id))
    FROM customer_account ORDER BY account_number, customer_id;
INSERT INTO found_values VALUES ('customer_account', (SELECT COUNT(*) FROM customer_account), @crc);

-- ====== TRANSACTION ======
SET @crc = '';
INSERT INTO tchecksum
    SELECT @crc := MD5(CONCAT_WS('#', @crc,
                transaction_id, transaction_datetime, from_account, to_account, description))
    FROM transaction ORDER BY transaction_id;
INSERT INTO found_values VALUES ('transaction', (SELECT COUNT(*) FROM transaction), @crc);

DROP TABLE tchecksum;

-- ====== AUTO-FILL expected_values ON FIRST RUN ======
INSERT INTO expected_values (table_name, recs, crc_md5)
SELECT table_name, recs, crc_md5
FROM found_values
WHERE NOT EXISTS (SELECT 1 FROM expected_values LIMIT 1);

-- ====== Show current hash values ======
SELECT 'CURRENT DATA HASHES' AS info;
SELECT * FROM found_values;

-- ====== Compare expected vs found ======
SELECT  
    e.table_name,
    f.recs AS found_records,
    e.recs AS expected_records,
    IF(e.recs = f.recs, 'OK', 'FAIL') AS record_count_check,
    IF(e.crc_md5 = f.crc_md5, 'OK', 'FAIL') AS data_integrity_check
FROM expected_values e
JOIN found_values f USING (table_name);

-- ====== Summary ======
SET @crc_fail = (
    SELECT COUNT(*) FROM expected_values e
    JOIN found_values f USING (table_name)
    WHERE e.crc_md5 != f.crc_md5
);
SET @count_fail = (
    SELECT COUNT(*) FROM expected_values e
    JOIN found_values f USING (table_name)
    WHERE e.recs != f.recs
);

SELECT 'CRC' AS summary, IF(@crc_fail = 0, 'OK', 'FAIL') AS result
UNION ALL
SELECT 'Count', IF(@count_fail = 0, 'OK', 'FAIL');
