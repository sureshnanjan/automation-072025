/*
--------------------------------------------------------------------------------
 Title      : Airline Reservation Database Schema
 Description: This SQL script defines the structure for an Airline Reservation 
              System. It includes tables for managing countries, cities, airports,
              aircrafts, flights, customers, bookings, and related entities.
              
 Author     : Keyur Nagvekar
 Created On : August 8, 2025
 Last Edited: August 8, 2025

 --------------------------------------------------------------------------------
 Table Summary:
 --------------------------------------------------------------------------------
 1. country         : Stores country information.
 2. city            : Stores city details with a reference to its country.
 3. airport         : Stores airport data linked to a city.
 4. manufacturer    : Stores aircraft manufacturers.
 5. aircraft_model  : Stores aircraft models linked to manufacturers.
 6. airline         : Stores airline company details.
 7. aircraft        : Stores aircrafts linked to a model and owning airline.
 8. seat_class      : Stores different seat class types (e.g., Economy, Business).
 9. aircraft_seat   : Stores individual seats linked to aircrafts and seat class.
10. flight          : Stores basic flight details linked to airlines.
11. leg             : Stores each leg (segment) of a flight, with departure and 
                      arrival details.
12. customer        : Stores customer information including contact details.
13. booking         : Stores customer bookings made through an airline.
14. booking_leg     : Stores seat assignments and pricing per leg per booking.

 --------------------------------------------------------------------------------
 Copyright Notice:
 --------------------------------------------------------------------------------
 © 2025 Keyur Nagvekar. All rights reserved.

 This script is provided for academic, demonstration, and development purposes.
 Unauthorized distribution or use of this script, in part or in full, for commercial 
 purposes without the author's explicit permission is prohibited.

 You are free to use and modify this script for educational or non-commercial 
 projects, provided this notice remains intact.-- Select the database to use
 
*/
CREATE DATABASE IF NOT EXISTS airline_reservations;
USE airline_reservations;

-- Table: country
CREATE TABLE country (
    country_id INT PRIMARY KEY,
    country_name VARCHAR(100) NOT NULL
);

-- Table: city
CREATE TABLE city (
    city_id INT PRIMARY KEY,
    city_name VARCHAR(100) NOT NULL,
    country_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES country(country_id)
);

-- Table: airport
CREATE TABLE airport (
    airport_code VARCHAR(10) PRIMARY KEY,
    airport_name VARCHAR(100) NOT NULL,
    city_id INT NOT NULL,
    FOREIGN KEY (city_id) REFERENCES city(city_id)
);

-- Table: manufacturer
CREATE TABLE manufacturer (
    manufacturer_id INT PRIMARY KEY,
    manufacturer_name VARCHAR(100) NOT NULL
);

-- Table: aircraft_model
CREATE TABLE aircraft_model (
    model_id INT PRIMARY KEY,
    model_name VARCHAR(100) NOT NULL,
    manufacturer_id INT NOT NULL,
    FOREIGN KEY (manufacturer_id) REFERENCES manufacturer(manufacturer_id)
);

-- Table: airline
CREATE TABLE airline (
    airline_id INT PRIMARY KEY,
    airline_name VARCHAR(100) NOT NULL
);

-- Table: aircraft
CREATE TABLE aircraft (
    aircraft_id INT PRIMARY KEY,
    aircraft_model_id INT NOT NULL,
    owned_by_airline_id INT NOT NULL,
    FOREIGN KEY (aircraft_model_id) REFERENCES aircraft_model(model_id),
    FOREIGN KEY (owned_by_airline_id) REFERENCES airline(airline_id)
);

-- Table: seat_class
CREATE TABLE seat_class (
    seat_class_id INT PRIMARY KEY,
    class_name VARCHAR(50) NOT NULL
);

-- Table: aircraft_seat
CREATE TABLE aircraft_seat (
    seat_id INT PRIMARY KEY,
    aircraft_id INT NOT NULL,
    seat_class_id INT NOT NULL,
    FOREIGN KEY (aircraft_id) REFERENCES aircraft(aircraft_id),
    FOREIGN KEY (seat_class_id) REFERENCES seat_class(seat_class_id)
);

-- Table: flight
CREATE TABLE flight (
    flight_code VARCHAR(20) PRIMARY KEY,
    airline_id INT NOT NULL,
    FOREIGN KEY (airline_id) REFERENCES airline(airline_id)
);

-- Table: leg
CREATE TABLE leg (
    leg_id INT PRIMARY KEY,
    flight_code VARCHAR(20) NOT NULL,
    arrival_airport_code VARCHAR(10) NOT NULL,
    departure_airport_code VARCHAR(10) NOT NULL,
    arrival_time DATETIME NOT NULL,
    departure_time DATETIME NOT NULL,
    aircraft_id INT NOT NULL,
    FOREIGN KEY (flight_code) REFERENCES flight(flight_code),
    FOREIGN KEY (arrival_airport_code) REFERENCES airport(airport_code),
    FOREIGN KEY (departure_airport_code) REFERENCES airport(airport_code),
    FOREIGN KEY (aircraft_id) REFERENCES aircraft(aircraft_id)
);

-- Table: customer
CREATE TABLE customer (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    passport_number VARCHAR(20) NOT NULL UNIQUE,
    email_address VARCHAR(100),
    phone_number VARCHAR(20),
    country_id INT NOT NULL,
    FOREIGN KEY (country_id) REFERENCES country(country_id)
);

-- Table: booking
CREATE TABLE booking (
    booking_id INT PRIMARY KEY,
    airline_id INT NOT NULL,
    customer_id INT NOT NULL,
    FOREIGN KEY (airline_id) REFERENCES airline(airline_id),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);

-- Table: booking_leg
CREATE TABLE booking_leg (
    booking_leg_id INT PRIMARY KEY,
    booking_id INT NOT NULL,
    leg_id INT NOT NULL,
    seat_id INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (booking_id) REFERENCES booking(booking_id),
    FOREIGN KEY (leg_id) REFERENCES leg(leg_id),
    FOREIGN KEY (seat_id) REFERENCES aircraft_seat(seat_id)
);
