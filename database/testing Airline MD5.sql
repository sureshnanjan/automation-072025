-- --------------------------------------------------
-- Step 1: Prepare storage tables
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

-- --------------------------------------------------
-- Step 2: Clear found_values before computation
-- --------------------------------------------------
TRUNCATE TABLE found_values;

-- --------------------------------------------------
-- Step 3: Generate MD5 for each table
-- --------------------------------------------------

-- country
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(country_id,''), COALESCE(country_name,'')
)) FROM country ORDER BY country_id;
INSERT INTO found_values VALUES ('country', (SELECT COUNT(*) FROM country), @crc);

-- manufacturer
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(manufacturer_id,''), COALESCE(manufacturer_name,'')
)) FROM manufacturer ORDER BY manufacturer_id;
INSERT INTO found_values VALUES ('manufacturer', (SELECT COUNT(*) FROM manufacturer), @crc);

-- city
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(city_id,''), COALESCE(country_id,''), COALESCE(city_name,'')
)) FROM city ORDER BY city_id;
INSERT INTO found_values VALUES ('city', (SELECT COUNT(*) FROM city), @crc);

-- customer
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(customer_id,''), COALESCE(country_id,''), COALESCE(first_name,''), 
    COALESCE(last_name,''), COALESCE(passport_number,''), COALESCE(email_address,''), 
    COALESCE(phone_number,'')
)) FROM customer ORDER BY customer_id;
INSERT INTO found_values VALUES ('customer', (SELECT COUNT(*) FROM customer), @crc);

-- airline
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(airline_id,''), COALESCE(airline_name,'')
)) FROM airline ORDER BY airline_id;
INSERT INTO found_values VALUES ('airline', (SELECT COUNT(*) FROM airline), @crc);

-- booking
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(booking_id,''), COALESCE(airline_id,''), COALESCE(customer_id,'')
)) FROM booking ORDER BY booking_id;
INSERT INTO found_values VALUES ('booking', (SELECT COUNT(*) FROM booking), @crc);

-- flight
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(flight_code,''), COALESCE(airline_id,'')
)) FROM flight ORDER BY flight_code;
INSERT INTO found_values VALUES ('flight', (SELECT COUNT(*) FROM flight), @crc);

-- airport
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(airport_code,''), COALESCE(city_id,''), COALESCE(airport_name,'')
)) FROM airport ORDER BY airport_code;
INSERT INTO found_values VALUES ('airport', (SELECT COUNT(*) FROM airport), @crc);

-- aircraft_model
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(model_id,''), COALESCE(manufacturer_id,''), COALESCE(model_name,'')
)) FROM aircraft_model ORDER BY model_id;
INSERT INTO found_values VALUES ('aircraft_model', (SELECT COUNT(*) FROM aircraft_model), @crc);

-- aircraft
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(aircraft_id,''), COALESCE(aircraft_model_id,''), COALESCE(owned_by_airline_id,'')
)) FROM aircraft ORDER BY aircraft_id;
INSERT INTO found_values VALUES ('aircraft', (SELECT COUNT(*) FROM aircraft), @crc);

-- seat_class
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(seat_class_id,''), COALESCE(class_name,'')
)) FROM seat_class ORDER BY seat_class_id;
INSERT INTO found_values VALUES ('seat_class', (SELECT COUNT(*) FROM seat_class), @crc);

-- aircraft_seat
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(seat_id,''), COALESCE(aircraft_id,''), COALESCE(seat_class_id,'')
)) FROM aircraft_seat ORDER BY seat_id;
INSERT INTO found_values VALUES ('aircraft_seat', (SELECT COUNT(*) FROM aircraft_seat), @crc);

-- leg
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(leg_id,''), COALESCE(arrival_airport_code,''), COALESCE(departure_airport_code,''), 
    COALESCE(flight_code,''), COALESCE(aircraft_id,''), COALESCE(arrival_time,''), 
    COALESCE(departure_time,'')
)) FROM leg ORDER BY leg_id;
INSERT INTO found_values VALUES ('leg', (SELECT COUNT(*) FROM leg), @crc);

-- booking_leg
SET @crc = '';
SELECT @crc := MD5(CONCAT_WS('#', @crc,
    COALESCE(booking_leg_id,''), COALESCE(booking_id,''), COALESCE(leg_id,''), COALESCE(seat_id,''), 
    COALESCE(price,'')
)) FROM booking_leg ORDER BY booking_leg_id;
INSERT INTO found_values VALUES ('booking_leg', (SELECT COUNT(*) FROM booking_leg), @crc);

-- --------------------------------------------------
-- Step 4: Show calculated results
-- --------------------------------------------------
SELECT * FROM found_values;

-- --------------------------------------------------
-- Step 5: Save current results as baseline (uncomment if needed)
-- --------------------------------------------------
-- TRUNCATE TABLE expected_values;
-- INSERT INTO expected_values SELECT * FROM found_values;

-- --------------------------------------------------
-- Step 6: Compare with expected values
-- --------------------------------------------------
SELECT e.table_name,
       e.recs AS expected_recs,
       f.recs AS found_recs,
       e.crc_md5 AS expected_md5,
       f.crc_md5 AS found_md5,
       IF(e.recs = f.recs, 'OK', 'DIFFER') AS recs_match,
       IF(e.crc_md5 = f.crc_md5, 'OK', 'DIFFER') AS md5_match
FROM expected_values e
LEFT JOIN found_values f USING (table_name);
