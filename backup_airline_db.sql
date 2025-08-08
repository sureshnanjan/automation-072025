/*
 * Copyright (c) 2025 K VAMSI KRISHNA
 * All rights reserved.
 *
 * This SQL dump file contains the schema and data for the airline_db database.
 * Unauthorized copying, distribution, or modification of this file,
 * or any part thereof, without the express written permission of
 * K VAMSI KRISHNA is strictly prohibited.
 *
 * Created on: 2025-08-07
 * MySQL dump version: 10.13  Distrib 8.0.43, for Win64 (x86_64)
 * Host: localhost
 * Server version: 8.0.43
 *
 * This dump includes tables: airlines, bookings, flights, passengers.
 * The schema includes primary keys, foreign keys, and indexes for relational integrity.
 * Data is inserted for all tables with sample records.
 */

-- Session settings to ensure consistent import behavior
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `airlines`
--

DROP TABLE IF EXISTS `airlines`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `airlines` (
  `Airline_ID` int NOT NULL AUTO_INCREMENT,
  `Airline_Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Airline_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `airlines`
--

LOCK TABLES `airlines` WRITE;
/*!40000 ALTER TABLE `airlines` DISABLE KEYS */;
INSERT INTO `airlines` VALUES 
  (1,'IndiGo'),
  (2,'SpiceJet'),
  (3,'Air India'),
  (4,'Vistara'),
  (5,'Go First');
/*!40000 ALTER TABLE `airlines` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bookings`
--

DROP TABLE IF EXISTS `bookings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bookings` (
  `Booking_ID` int NOT NULL AUTO_INCREMENT,
  `Passenger_ID` int DEFAULT NULL,
  `Flight_ID` int DEFAULT NULL,
  `Seat_No` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Booking_ID`),
  KEY `Passenger_ID` (`Passenger_ID`),
  KEY `Flight_ID` (`Flight_ID`),
  CONSTRAINT `bookings_ibfk_1` FOREIGN KEY (`Passenger_ID`) REFERENCES `passengers` (`Passenger_ID`),
  CONSTRAINT `bookings_ibfk_2` FOREIGN KEY (`Flight_ID`) REFERENCES `flights` (`Flight_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=501 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bookings`
--

LOCK TABLES `bookings` WRITE;
/*!40000 ALTER TABLE `bookings` DISABLE KEYS */;
INSERT INTO `bookings` VALUES 
(1,84,3,'7A'),(2,79,12,'13B'),(3,25,20,'26E'),(4,40,1,'30D'),(5,98,2,'15F'),
(6,14,15,'25C'),(7,68,10,'27A'),(8,6,19,'5D'),(9,50,8,'16D'),(10,12,19,'11C'),
-- (data continues as in your original dump) --
(499,18,20,'19E'),(500,93,20,'3B');
/*!40000 ALTER TABLE `bookings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `flights`
--

DROP TABLE IF EXISTS `flights`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `flights` (
  `Flight_ID` int NOT NULL AUTO_INCREMENT,
  `Flight_No` varchar(10) NOT NULL,
  `Airline_ID` int DEFAULT NULL,
  `Source` varchar(100) DEFAULT NULL,
  `Destination` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Flight_ID`),
  KEY `Airline_ID` (`Airline_ID`),
  CONSTRAINT `flights_ibfk_1` FOREIGN KEY (`Airline_ID`) REFERENCES `airlines` (`Airline_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flights`
--

LOCK TABLES `flights` WRITE;
/*!40000 ALTER TABLE `flights` DISABLE KEYS */;
INSERT INTO `flights` VALUES 
  (1,'FL1000',1,'Mumbai','Chennai'),
  (2,'FL1001',4,'Bangalore','Pune'),
  (3,'FL1002',4,'Hyderabad','Chennai'),
  (4,'FL1003',4,'Pune','Mumbai'),
  (5,'FL1004',3,'Delhi','Kolkata'),
  (6,'FL1005',3,'Chennai','Hyderabad'),
  (7,'FL1006',1,'Delhi','Kolkata'),
  (8,'FL1007',3,'Pune','Mumbai'),
  (9,'FL1008',4,'Ahmedabad','Delhi'),
  (10,'FL1009',3,'Chennai','Mumbai'),
  (11,'FL1010',3,'Delhi','Ahmedabad'),
  (12,'FL1011',4,'Mumbai','Hyderabad'),
  (13,'FL1012',4,'Ahmedabad','Kolkata'),
  (14,'FL1013',5,'Chennai','Delhi'),
  (15,'FL1014',4,'Ahmedabad','Mumbai'),
  (16,'FL1015',5,'Mumbai','Chennai'),
  (17,'FL1016',2,'Delhi','Pune'),
  (18,'FL1017',3,'Bangalore','Delhi'),
  (19,'FL1018',3,'Pune','Delhi'),
  (20,'FL1019',2,'Mumbai','Delhi');
/*!40000 ALTER TABLE `flights` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `passengers`
--

DROP TABLE IF EXISTS `passengers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `passengers` (
  `Passenger_ID` int NOT NULL AUTO_INCREMENT,
  `Passenger_Name` varchar(100) NOT NULL,
  `Passenger_Email` varchar(100) NOT NULL,
  PRIMARY KEY (`Passenger_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=101 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `passengers`
--

LOCK TABLES `passengers` WRITE;
/*!40000 ALTER TABLE `passengers` DISABLE KEYS */;
INSERT INTO `passengers` VALUES 
(1,'Susan Mayer','stevenscharles@hotmail.com'),
(2,'Samantha Paul','kgriffin@lewis.org'),
(3,'Charles Taylor','tonya33@jordan.info'),
-- (data continues as in your original dump) --
(100,'Tammy Perez','rogersrodney@bennett.com');
/*!40000 ALTER TABLE `passengers` ENABLE KEYS */;
UNLOCK TABLES;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-08-07 16:50:55
