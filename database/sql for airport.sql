-- 1. country table
CREATE TABLE country (
    country_id INT PRIMARY KEY,
    country_name VARCHAR(100)
);

-- 2. manufacturer table
CREATE TABLE manufacturer (
    manufacturer_id INT PRIMARY KEY,
    manufacturer_name VARCHAR(100)
);

-- 3. city table
CREATE TABLE city (
    city_id INT PRIMARY KEY,
    country_id INT,
    city_name VARCHAR(100),
    FOREIGN KEY (country_id) REFERENCES country(country_id)
);

-- 4. customer table
CREATE TABLE customer (
    customer_id INT PRIMARY KEY,
    country_id INT,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    passport_number VARCHAR(20),
    email_address VARCHAR(100),
    phone_number VARCHAR(20),
    FOREIGN KEY (country_id) REFERENCES country(country_id)
);

-- 5. airline table
CREATE TABLE airline (
    airline_id INT PRIMARY KEY,
    airline_name VARCHAR(100)
);

-- 6. booking table
CREATE TABLE booking (
    booking_id INT PRIMARY KEY,
    airline_id INT,
    customer_id INT,
    FOREIGN KEY (airline_id) REFERENCES airline(airline_id),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);

-- 7. flight table
CREATE TABLE flight (
    flight_code VARCHAR(10) PRIMARY KEY,
    airline_id INT,
    FOREIGN KEY (airline_id) REFERENCES airline(airline_id)
);

-- 8. airport table
CREATE TABLE airport (
    airport_code VARCHAR(10) PRIMARY KEY,
    city_id INT,
    airport_name VARCHAR(100),
    FOREIGN KEY (city_id) REFERENCES city(city_id)
);

-- 9. aircraft_model table
CREATE TABLE aircraft_model (
    model_id INT PRIMARY KEY,
    manufacturer_id INT,
    model_name VARCHAR(100),
    FOREIGN KEY (manufacturer_id) REFERENCES manufacturer(manufacturer_id)
);

-- 10. aircraft table
CREATE TABLE aircraft (
    aircraft_id INT PRIMARY KEY,
    aircraft_model_id INT,
    owned_by_airline_id INT,
    FOREIGN KEY (aircraft_model_id) REFERENCES aircraft_model(model_id),
    FOREIGN KEY (owned_by_airline_id) REFERENCES airline(airline_id)
);

-- 11. seat_class table
CREATE TABLE seat_class (
    seat_class_id INT PRIMARY KEY,
    class_name VARCHAR(50)
);

-- 12. aircraft_seat table
CREATE TABLE aircraft_seat (
    seat_id INT PRIMARY KEY,
    aircraft_id INT,
    seat_class_id INT,
    FOREIGN KEY (aircraft_id) REFERENCES aircraft(aircraft_id),
    FOREIGN KEY (seat_class_id) REFERENCES seat_class(seat_class_id)
);

-- 13. leg table
CREATE TABLE leg (
    leg_id INT PRIMARY KEY,
    arrival_airport_code VARCHAR(10),
    departure_airport_code VARCHAR(10),
    flight_code VARCHAR(10),
    aircraft_id INT,
    arrival_time TIMESTAMP,
    departure_time TIMESTAMP,
    FOREIGN KEY (arrival_airport_code) REFERENCES airport(airport_code),
    FOREIGN KEY (departure_airport_code) REFERENCES airport(airport_code),
    FOREIGN KEY (flight_code) REFERENCES flight(flight_code),
    FOREIGN KEY (aircraft_id) REFERENCES aircraft(aircraft_id)
);

-- 14. booking_leg table
CREATE TABLE booking_leg (
    booking_leg_id INT PRIMARY KEY,
    booking_id INT,
    leg_id INT,
    seat_id INT,
    price DECIMAL(10,2),
    FOREIGN KEY (booking_id) REFERENCES booking(booking_id),
    FOREIGN KEY (leg_id) REFERENCES leg(leg_id),
    FOREIGN KEY (seat_id) REFERENCES aircraft_seat(seat_id)
);
DROP TABLE airport;

CREATE TABLE airport (
    airport_code VARCHAR(10) PRIMARY KEY,
    city_id INT,
    airport_name VARCHAR(100),
    FOREIGN KEY (city_id) REFaircraft_seatERENCES city(city_id)
);
