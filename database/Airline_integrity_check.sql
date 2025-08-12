SELECT 'TESTING AIRLINE SYSTEM INTEGRITY' AS INFO;

-- Drop old tables if exist
DROP TABLE IF EXISTS expected_values, found_values;

-- Create expected and found tables
CREATE TABLE expected_values (
    table_name VARCHAR(30) NOT NULL PRIMARY KEY,
    recs INT NOT NULL,
    crc_md5 VARCHAR(100) NOT NULL
);

CREATE TABLE found_values LIKE expected_values;

-- Compute and store current hashes and counts in found_values

-- COUNTRY
INSERT INTO found_values
SELECT 'country',
       COUNT(*),
       MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(country_id,''), COALESCE(country_name,'')) ORDER BY country_id SEPARATOR '|'))
FROM country;

-- MANUFACTURER
INSERT INTO found_values
SELECT 'manufacturer',
       COUNT(*),
       MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(manufacturer_id,''), COALESCE(manufacturer_name,'')) ORDER BY manufacturer_id SEPARATOR '|'))
FROM manufacturer;

-- CITY
INSERT INTO found_values
SELECT 'city',
       COUNT(*),
       MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(city_id,''), COALESCE(country_id,''), COALESCE(city_name,'')) ORDER BY city_id SEPARATOR '|'))
FROM city;

-- CUSTOMER
INSERT INTO found_values
SELECT 'customer',
       COUNT(*),
       MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(customer_id,''), COALESCE(country_id,''), COALESCE(first_name,''), COALESCE(last_name,''), COALESCE(passport_number,''), COALESCE(email_address,''), COALESCE(phone_number,'')) ORDER BY customer_id SEPARATOR '|'))
FROM customer;

-- AIRPORT
INSERT INTO found_values
SELECT 'airport',
       COUNT(*),
       MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(airport_code,''), COALESCE(city_id,''), COALESCE(airport_name,'')) ORDER BY airport_code SEPARATOR '|'))
FROM airport;

-- AIRLINE
INSERT INTO found_values
SELECT 'airline',
       COUNT(*),
       MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(airline_id,''), COALESCE(airline_name,'')) ORDER BY airline_id SEPARATOR '|'))
FROM airline;

-- Initialize expected_values on first run
INSERT INTO expected_values (table_name, recs, crc_md5)
SELECT table_name, recs, crc_md5 FROM found_values
WHERE NOT EXISTS (SELECT 1 FROM expected_values LIMIT 1);

-- Show current hashes
SELECT 'CURRENT DATA HASHES' AS info;
SELECT * FROM found_values;

-- Validate tables
CALL CheckTableIntegrity('country',
    (SELECT recs FROM expected_values WHERE table_name = 'country'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'country'));

CALL CheckTableIntegrity('manufacturer',
    (SELECT recs FROM expected_values WHERE table_name = 'manufacturer'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'manufacturer'));

CALL CheckTableIntegrity('city',
    (SELECT recs FROM expected_values WHERE table_name = 'city'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'city'));

CALL CheckTableIntegrity('customer',
    (SELECT recs FROM expected_values WHERE table_name = 'customer'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'customer'));

CALL CheckTableIntegrity('airport',
    (SELECT recs FROM expected_values WHERE table_name = 'airport'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'airport'));

CALL CheckTableIntegrity('airline',
    (SELECT recs FROM expected_values WHERE table_name = 'airline'),
    (SELECT crc_md5 FROM expected_values WHERE table_name = 'airline'));