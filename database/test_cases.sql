/*
================================================================================
  Airline Database Basic Queries and Data Validation
  -------------------------------------------------
  This script performs basic aggregate queries and data integrity checks
  on the 'airline_db' database tables:
    - Counting total records for Passengers, Flights, and Bookings
    - Identifying invalid Bookings with non-existent Passengers or Flights
    - Displaying sample booking details by joining related tables

  Author: K VAMSI KRISHNA
  Date: 2025-08-08
  License: MIT License (or specify your preferred license)

  Usage:
    - Use this script to get summary stats and identify data inconsistencies.
    - Modify the LIMIT clause in the sample join query as needed.
================================================================================
*/

USE airline_db;

-- 1. Count total number of passengers
SELECT COUNT(*) AS total_passengers FROM Passengers;

-- 2. Count total number of flights
SELECT COUNT(*) AS total_flights FROM Flights;

-- 3. Count total number of bookings
SELECT COUNT(*) AS total_bookings FROM Bookings;

-- 4. Find bookings with invalid Passenger_ID (i.e., passengers not existing in Passengers table)
SELECT * FROM Bookings 
WHERE Passenger_ID NOT IN (SELECT Passenger_ID FROM Passengers);

-- 5. Find bookings with invalid Flight_ID (i.e., flights not existing in Flights table)
SELECT * FROM Bookings 
WHERE Flight_ID NOT IN (SELECT Flight_ID FROM Flights);

-- 6. Sample join query to show booking details including passenger, flight, airline, and seat info
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
LIMIT 10;
