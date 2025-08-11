/*
================================================================================
  Airline Database Basic Queries and Data Validation
  -------------------------------------------------
  This script performs basic aggregate queries and data integrity checks
  on the 'airline_db' database tables:
    - Counting total records for Passengers, Flights, and Bookings
    - Identifying invalid Bookings with non-existent Passengers or Flights
    - Displaying sample booking details by joining related tables

  Author: Keyur Nagvekar
  Date: 2025-08-08
  License: MIT License (or specify your preferred license)

  Usage:
    - Use this script to get summary stats and identify data inconsistencies.
    - Modify the LIMIT clause in the sample join query as needed.
================================================================================
*/

USE airline_db;

-- 1. Count total number of passengers in the Passengers table
SELECT COUNT(*) AS total_passengers FROM Passengers;

-- 2. Count total number of flights in the Flights table
SELECT COUNT(*) AS total_flights FROM Flights;

-- 3. Count total number of bookings in the Bookings table
SELECT COUNT(*) AS total_bookings FROM Bookings;

-- 4. Find bookings that reference a Passenger_ID not present in the Passengers table
SELECT * FROM Bookings 
WHERE Passenger_ID NOT IN (SELECT Passenger_ID FROM Passengers);

-- 5. Find bookings that reference a Flight_ID not present in the Flights table
SELECT * FROM Bookings 
WHERE Flight_ID NOT IN (SELECT Flight_ID FROM Flights);

-- 6. Display sample booking details by joining Bookings with Passengers, Flights, and Airlines
--    This shows booking ID, passenger name, flight number, airline name, source and destination airports, and seat number
SELECT 
    b.Booking_ID,
    p.Passenger_Name,
    f.Flight_No,
    a.Airline_Name,
    f.Source,
    f.Destination,
    b.Seat_No
FROM Bookings b
JOIN Passengers p ON b.Passenger_ID = p.Passenger_ID
JOIN Flights f ON b.Flight_ID = f.Flight_ID
JOIN Airlines a ON f.Airline_ID = a.Airline_ID
LIMIT 10;  -- Limit output to first 10 results for brevity
