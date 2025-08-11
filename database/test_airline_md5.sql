/*
================================================================================
  Airline Database Integrity Verification Script
  -------------------------------------------------
  This script verifies the installation and data integrity of the 'airline_db'
  database by computing record counts and CRC32 checksums for the main tables:
    - Airlines
    - Flights
    - Passengers
    - Bookings
  
  The script stores computed values into variables, then recomputes and compares
  them to ensure no data corruption or loss has occurred.

  Author: K VAMSI KRISHNA
  Date: 2025-08-08
  License: MIT License (or specify your preferred license)

  Usage:
    - Run this script after importing the 'airline_db' schema and data dump.
    - Review the comparison results for "OK" and "ok" statuses indicating data integrity.
================================================================================
*/

USE airline_db;

-- Informational message for user
SELECT 'TESTING AIRLINE DB INSTALLATION' AS INFO;

-- Compute record counts and CRC checksums for each table, store in variables
SELECT COUNT(*) INTO @air_rec FROM Airlines;
SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Airline_ID, Airline_Name)) AS UNSIGNED)), 0) INTO @air_crc FROM Airlines;

SELECT COUNT(*) INTO @flt_rec FROM Flights;
SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Flight_ID, Flight_No, Airline_ID, Source, Destination)) AS UNSIGNED)), 0) INTO @flt_crc FROM Flights;

SELECT COUNT(*) INTO @pas_rec FROM Passengers;
SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Passenger_ID, Passenger_Name, Passenger_Email)) AS UNSIGNED)), 0) INTO @pas_crc FROM Passengers;

SELECT COUNT(*) INTO @bok_rec FROM Bookings;
SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Booking_ID, Passenger_ID, Flight_ID, Seat_No)) AS UNSIGNED)), 0) INTO @bok_crc FROM Bookings;

-- Display the expected record counts and CRC checksums (stored variables)
SELECT 'Airlines' AS table_name, @air_rec AS expected_records, @air_crc AS expected_crc
UNION
SELECT 'Flights', @flt_rec, @flt_crc
UNION
SELECT 'Passengers', @pas_rec, @pas_crc
UNION
SELECT 'Bookings', @bok_rec, @bok_crc;

-- Recompute and display the actual record counts and CRC checksums directly from tables
SELECT 'Airlines' AS table_name,
       COUNT(*) AS found_records,
       COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Airline_ID, Airline_Name)) AS UNSIGNED)), 0) AS found_crc
FROM Airlines
UNION
SELECT 'Flights',
       COUNT(*),
       COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Flight_ID, Flight_No, Airline_ID, Source, Destination)) AS UNSIGNED)), 0)
FROM Flights
UNION
SELECT 'Passengers',
       COUNT(*),
       COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Passenger_ID, Passenger_Name, Passenger_Email)) AS UNSIGNED)), 0)
FROM Passengers
UNION
SELECT 'Bookings',
       COUNT(*),
       COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Booking_ID, Passenger_ID, Flight_ID, Seat_No)) AS UNSIGNED)), 0)
FROM Bookings;

-- Compare expected and found results to report integrity status
SELECT 'Airlines' AS table_name,
       CASE WHEN @air_rec = (SELECT COUNT(*) FROM Airlines) THEN 'OK' ELSE 'FAIL' END AS records_match,
       CASE WHEN @air_crc = (SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Airline_ID, Airline_Name)) AS UNSIGNED)), 0) FROM Airlines) THEN 'ok' ELSE 'fail' END AS crc_match
UNION
SELECT 'Flights',
       CASE WHEN @flt_rec = (SELECT COUNT(*) FROM Flights) THEN 'OK' ELSE 'FAIL' END,
       CASE WHEN @flt_crc = (SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Flight_ID, Flight_No, Airline_ID, Source, Destination)) AS UNSIGNED)), 0) FROM Flights) THEN 'ok' ELSE 'fail' END
UNION
SELECT 'Passengers',
       CASE WHEN @pas_rec = (SELECT COUNT(*) FROM Passengers) THEN 'OK' ELSE 'FAIL' END,
       CASE WHEN @pas_crc = (SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Passenger_ID, Passenger_Name, Passenger_Email)) AS UNSIGNED)), 0) FROM Passengers) THEN 'ok' ELSE 'fail' END
UNION
SELECT 'Bookings',
       CASE WHEN @bok_rec = (SELECT COUNT(*) FROM Bookings) THEN 'OK' ELSE 'FAIL' END,
       CASE WHEN @bok_crc = (SELECT COALESCE(BIT_XOR(CAST(CRC32(CONCAT_WS('#', Booking_ID, Passenger_ID, Flight_ID, Seat_No)) AS UNSIGNED)), 0) FROM Bookings) THEN 'ok' ELSE 'fail' END;
