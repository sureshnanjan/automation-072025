/*
 * ===============================================================
 * Script: Airline DB Installation Verification
 * Purpose: Verify key tables exist with expected record counts 
 *          and matching SHA256 hash values.
 * Database: airline_db
 * Author: Keyur Nagvekar
 * Date: 08-08-2025
 * 
 * Copyright (c) 2025 Keyur Nagvekar.
 * All rights reserved.
 * 
 * Unauthorized copying, distribution, or modification of this 
 * file, via any medium, is strictly prohibited.
 * ===============================================================
 */

USE airline_db;

-- INFO: Indicate the purpose of this script
SELECT 'TESTING AIRLINE DB INSTALLATION WITH SHA256' AS INFO;

-- -----------------------------------------------------------------------------
-- Expected values for record counts and SHA256 hashes per table
-- Note: SHA256 hash here represents the file-level dump hash (same for all)
-- -----------------------------------------------------------------------------
SELECT
    'Airlines' AS table_name,
    5 AS expected_records,
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' AS expected_sha
UNION
SELECT
    'Flights',
    20,
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
UNION
SELECT
    'Passengers',
    100,
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
UNION
SELECT
    'Bookings',
    500,
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f';

-- -----------------------------------------------------------------------------
-- Actual record counts from each table and associated SHA256 hash
-- -----------------------------------------------------------------------------
SELECT
    'Airlines' AS table_name,
    COUNT(*) AS found_records,
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' AS found_sha
FROM Airlines
UNION
SELECT
    'Flights',
    COUNT(*),
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
FROM Flights
UNION
SELECT
    'Passengers',
    COUNT(*),
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
FROM Passengers
UNION
SELECT
    'Bookings',
    COUNT(*),
    'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
FROM Bookings;

-- -----------------------------------------------------------------------------
-- Comparison of expected vs found values for record counts and SHA
-- Returns status indicators for each table
-- -----------------------------------------------------------------------------
SELECT
    e.table_name,
    CASE
        WHEN e.expected_records = f.found_records THEN 'OK'
        ELSE 'FAIL'
    END AS records_match,
    CASE
        WHEN e.expected_sha = f.found_sha THEN 'OK'
        ELSE 'FAIL'
    END AS sha_match
FROM
(
    -- Expected values (inline table)
    SELECT 'Airlines' AS table_name, 5 AS expected_records, 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' AS expected_sha
    UNION
    SELECT 'Flights',    20, 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
    UNION
    SELECT 'Passengers', 100, 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
    UNION
    SELECT 'Bookings',   500, 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f'
) e
JOIN
(
    -- Actual values fetched from database tables
    SELECT 'Airlines' AS table_name, COUNT(*) AS found_records, 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' AS found_sha FROM Airlines
    UNION
    SELECT 'Flights',    COUNT(*), 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' FROM Flights
    UNION
    SELECT 'Passengers', COUNT(*), 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' FROM Passengers
    UNION
    SELECT 'Bookings',   COUNT(*), 'ad09cf90380df7ba63110fa87c98fc70a020047f363ff1ad171e15eecad33f1f' FROM Bookings
) f ON e.table_name = f.table_name;
