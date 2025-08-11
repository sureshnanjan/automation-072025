CREATE TABLE Airport (
  airport_code VARCHAR(10) PRIMARY KEY,
  airport_name VARCHAR(100),
  city VARCHAR(50),
  country VARCHAR(50)
);
INSERT INTO Airport (airport_code, airport_name, city, country)
VALUES ('BLR', 'Kempegowda International Airport', 'Bangalore', 'India');
