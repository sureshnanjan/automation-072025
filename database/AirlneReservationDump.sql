-- More Countries
INSERT INTO country (country_name) VALUES
('Japan'), ('Australia'), ('Canada'), ('Brazil'), ('UAE');

-- More Cities
INSERT INTO city (country_id, city_name) VALUES
(6, 'Tokyo'), (6, 'Osaka'),
(7, 'Sydney'), (7, 'Melbourne'),
(8, 'Toronto'), (8, 'Vancouver'),
(9, 'Rio de Janeiro'), (9, 'Sao Paulo'),
(10, 'Dubai'), (10, 'Abu Dhabi');

-- More Airports
INSERT INTO airport (airport_code, city_id, airport_name) VALUES
('HND', 8, 'Haneda Airport'),
('KIX', 9, 'Kansai International Airport'),
('SYD', 10, 'Sydney Kingsford Smith'),
('MEL', 11, 'Melbourne Airport'),
('YYZ', 12, 'Toronto Pearson'),
('YVR', 13, 'Vancouver International'),
('GIG', 14, 'Rio Galeão'),
('GRU', 15, 'São Paulo–Guarulhos'),
('DXB', 16, 'Dubai International'),
('AUH', 17, 'Abu Dhabi International');

-- More Manufacturers
INSERT INTO manufacturer (manufacturer_name) VALUES
('Bombardier'), ('Mitsubishi');

-- More Aircraft Models
INSERT INTO aircraft_model (manufacturer_id, model_name) VALUES
(4, 'CRJ900'),
(5, 'MRJ90');

-- More Airlines
INSERT INTO airline (airline_name) VALUES
('Qantas'), ('Emirates'), ('Air Canada'), ('Japan Airlines');

-- More Aircraft
INSERT INTO aircraft (aircraft_model_id, owned_by_airline_id) VALUES
(6, 5), (7, 5), -- Qantas
(1, 6), (2, 6), -- Emirates
(3, 7), (4, 7), -- Air Canada
(5, 8);         -- Japan Airlines

-- More Seat Classes
INSERT INTO seat_class (class_name) VALUES
('Premium Economy'), ('Ultra Luxury');

-- More Aircraft Seats
INSERT INTO aircraft_seat (aircraft_id, seat_class_id) VALUES
(6, 1), (6, 2), (6, 4),
(7, 1), (7, 3),
(8, 1), (8, 2), (8, 5),
(9, 1), (10, 2), (11, 1);

-- More Flights
INSERT INTO flight (flight_code, airline_id) VALUES
('QF400', 5),
('EK202', 6),
('AC305', 7),
('JL789', 8);

-- More Legs
INSERT INTO leg (flight_code, departure_airport_code, arrival_airport_code, aircraft_id, departure_time, arrival_time) VALUES
('QF400', 'SYD', 'MEL', 6, '2025-09-05 07:00:00', '2025-09-05 08:30:00'),
('EK202', 'DXB', 'LHR', 8, '2025-09-06 09:00:00', '2025-09-06 13:00:00'),
('AC305', 'YYZ', 'YVR', 9, '2025-09-07 10:00:00', '2025-09-07 13:00:00'),
('JL789', 'HND', 'LAX', 11, '2025-09-08 15:00:00', '2025-09-08 08:00:00');

-- More Customers
INSERT INTO customer (country_id, first_name, last_name, passport_number, email_address, phone_number) VALUES
(6, 'Hiroshi', 'Tanaka', 'JP112233', 'hiroshi.tanaka@example.com', '+81 901234567'),
(7, 'Olivia', 'Brown', 'AU445566', 'olivia.brown@example.com', '+61 412345678'),
(8, 'Liam', 'Smith', 'CA778899', 'liam.smith@example.com', '+1 6041234567'),
(9, 'Carlos', 'Silva', 'BR998877', 'carlos.silva@example.com', '+55 2198765432'),
(10, 'Fatima', 'Al Mansoori', 'AE556677', 'fatima.mansoori@example.com', '+971 501234567');

-- More Bookings
INSERT INTO booking (airline_id, customer_id) VALUES
(5, 5), (6, 6), (7, 7), (8, 8), (6, 9);

-- More Booking Legs
INSERT INTO booking_leg (booking_id, leg_id, seat_id, price) VALUES
(5, 5, 10, 250.00),
(6, 6, 12, 1200.00),
(7, 7, 13, 450.00),
(8, 8, 15, 900.00),
(9, 2, 6, 1800.00);
