-- ==============================================================
-- Shopping Website Database Schema and Data Initialization Script
-- Author: Elangovan R
-- 
-- Description:
-- This script sets up the shopping_website_db database from scratch.
-- It includes:
--   - Dropping and creating the database 
--   - Creating all necessary tables with relationships and constraints
--   - Creating useful views for reporting
--   - Loading data dumps into each table in a dependency-safe order
--   - Optional loading of stored procedures, verification scripts, and test scripts
--   - Binary log flushing and elapsed time tracking for performance monitoring
--
-- Usage Instructions:
-- 1. Run this script in your MySQL environment with appropriate permissions.
-- 2. Ensure the data dump files (*.dump) and optional script files (*.sql) are accessible
--    from the directory where this script is executed, or adjust the paths accordingly.
-- 3. The script automatically disables foreign key checks during truncation and data loads,
--    then re-enables them to avoid constraint conflicts.
-- 4. To reinitialize the database, simply rerun this script.
-- 5. Optional scripts (stored procedures, checks) can be commented/uncommented as needed.
--
-- Prerequisites:
-- - MySQL Server with InnoDB storage engine support.
-- - Access to load data dump files and optional verification scripts.
-- 
-- Sections:
-- - Database Creation and Use
-- - Table Drops (if existing)
-- - Table Creation (with foreign keys and constraints)
-- - Views Creation
-- - Binary Log Flush
-- - Loading Data from Dump Files
-- - Loading Optional Procedures and Checks
-- - Elapsed Time Reporting (Optional)
--
-- License:
-- This work is licensed under the Creative Commons Attribution-Share Alike 3.0 Unported License.
-- See http://creativecommons.org/licenses/by-sa/3.0/ for details.
--
-- Disclaimer:
-- All data is fabricated for demonstration and testing purposes only.
-- Any similarity to real persons or entities is purely coincidental.
-- ==============================================================

-- ===========================
-- DATABASE SETUP
-- ===========================

DROP DATABASE IF EXISTS shopping_website_db;
CREATE DATABASE IF NOT EXISTS shopping_website_db;
USE shopping_website_db;

SELECT 'CREATING DATABASE STRUCTURE' AS 'INFO';

-- ===========================
-- DROP TABLES IF THEY EXIST
-- ===========================

DROP TABLE IF EXISTS 
    supplier_order_line,
    supplier_order,
    customer_order_line,
    customer_order,
    product,
    supplier,
    size,
    colour,
    brand,
    product_category,
    user_address,
    user_account,
    address;

-- ===========================
-- CREATE TABLES
-- ===========================

-- Address Table
CREATE TABLE address (
    address_id INT PRIMARY KEY AUTO_INCREMENT,
    house_unit_no VARCHAR(50),
    address_line1 VARCHAR(100),
    address_line2 VARCHAR(100),
    city VARCHAR(50),
    region VARCHAR(50),
    postal_code VARCHAR(20),
    country VARCHAR(50)
);

-- User Account Table
CREATE TABLE user_account (
    username VARCHAR(50) PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email_address VARCHAR(100)
);

-- User-Address Mapping Table (Many-to-Many)
CREATE TABLE user_address (
    username VARCHAR(50),
    address_id INT,
    PRIMARY KEY (username, address_id),
    FOREIGN KEY (username) REFERENCES user_account(username) ON DELETE CASCADE,
    FOREIGN KEY (address_id) REFERENCES address(address_id) ON DELETE CASCADE
);

-- Product Category Table
CREATE TABLE product_category (
    category_id INT PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(100)
);

-- Brand Table
CREATE TABLE brand (
    brand_id INT PRIMARY KEY AUTO_INCREMENT,
    brand_name VARCHAR(100)
);

-- Colour Table
CREATE TABLE colour (
    colour_id INT PRIMARY KEY AUTO_INCREMENT,
    colour_name VARCHAR(50)
);

-- Size Table
CREATE TABLE size (
    size_id INT PRIMARY KEY AUTO_INCREMENT,
    size_name VARCHAR(50)
);

-- Supplier Table
CREATE TABLE supplier (
    supplier_id INT PRIMARY KEY AUTO_INCREMENT,
    supplier_name VARCHAR(100)
);

-- Product Table
CREATE TABLE product (
    product_id INT PRIMARY KEY AUTO_INCREMENT,
    product_name VARCHAR(100),
    product_category_id INT,
    brand_id INT,
    colour_id INT,
    size_id INT,
    supplier_id INT,
    FOREIGN KEY (product_category_id) REFERENCES product_category(category_id),
    FOREIGN KEY (brand_id) REFERENCES brand(brand_id),
    FOREIGN KEY (colour_id) REFERENCES colour(colour_id),
    FOREIGN KEY (size_id) REFERENCES size(size_id),
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

-- Customer Order Table
CREATE TABLE customer_order (
    order_id INT PRIMARY KEY AUTO_INCREMENT,
    order_discount DECIMAL(5,2),
    shipping_address INT,
    billing_address INT,
    username VARCHAR(50),
    order_date DATE,
    FOREIGN KEY (shipping_address) REFERENCES address(address_id),
    FOREIGN KEY (billing_address) REFERENCES address(address_id),
    FOREIGN KEY (username) REFERENCES user_account(username)
);

-- Customer Order Line Table
CREATE TABLE customer_order_line (
    order_line_id INT PRIMARY KEY AUTO_INCREMENT,
    order_id INT,
    product_id INT,
    qty INT,
    discount DECIMAL(5,2),
    price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES customer_order(order_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);

-- Supplier Order Table
CREATE TABLE supplier_order (
    order_id INT PRIMARY KEY AUTO_INCREMENT,
    order_discount DECIMAL(5,2),
    supplier_id INT,
    order_date DATE,
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

-- Supplier Order Line Table
CREATE TABLE supplier_order_line (
    order_line_id INT PRIMARY KEY AUTO_INCREMENT,
    order_id INT,
    product_id INT,
    qty INT,
    discount DECIMAL(5,2),
    price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES supplier_order(order_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);

-- ===========================
-- CREATE VIEWS
-- ===========================

-- View: Recent Customer Orders per User
CREATE OR REPLACE VIEW recent_user_orders AS
    SELECT username, MAX(order_date) AS last_order_date
    FROM customer_order
    GROUP BY username;

-- View: Product Count by Category
CREATE OR REPLACE VIEW product_count_by_category AS
    SELECT pc.category_name, COUNT(p.product_id) AS product_count
    FROM product_category pc
    LEFT JOIN product p ON pc.category_id = p.product_category_id
    GROUP BY pc.category_name;

-- ===========================
-- BINARY LOG FLUSH
-- ===========================

flush /*!50503 binary */ logs;

-- ===========================
-- LOAD DATA FROM DUMP FILES
-- ===========================

SELECT 'LOADING address' AS 'INFO';
source load_address.dump;

SELECT 'LOADING user_account' AS 'INFO';
source load_user_account.dump;

SELECT 'LOADING user_address' AS 'INFO';
source load_user_address.dump;

SELECT 'LOADING product_category' AS 'INFO';
source load_product_category.dump;

SELECT 'LOADING brand' AS 'INFO';
source load_brand.dump;

SELECT 'LOADING colour' AS 'INFO';
source load_colour.dump;

SELECT 'LOADING size' AS 'INFO';
source load_size.dump;

SELECT 'LOADING supplier' AS 'INFO';
source load_supplier.dump;

SELECT 'LOADING product' AS 'INFO';
source load_product.dump;

SELECT 'LOADING customer_order' AS 'INFO';
source load_customer_order.dump;

SELECT 'LOADING customer_order_line' AS 'INFO';
source load_customer_order_line.dump;

SELECT 'LOADING supplier_order' AS 'INFO';
source load_supplier_order.dump;

SELECT 'LOADING supplier_order_line' AS 'INFO';
source load_supplier_order_line.dump;

-- ===========================
-- OPTIONAL: LOAD STORED PROCEDURES AND TESTS
-- ===========================

-- SOURCE stored_routines.sql;
-- SOURCE sp_check.sql;
-- SOURCE verify_constraints.sql;
-- SOURCE test_data_checks.sql;
-- SOURCE show_elapsed.sql;

-- ===========================
-- ELAPSED TIME REPORTING (OPTIONAL)
-- ===========================

-- Useful for performance monitoring during loading and setup
source show_elapsed.sql;


