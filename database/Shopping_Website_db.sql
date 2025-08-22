-- ==============================================================
-- Shopping Website Database Schema and Data Initialization Script
-- Author: Teja Reddy
-- 
-- Description:
-- This script completely sets up the `shopping_website_db` database from scratch.
-- It covers:
--   - Dropping and creating the database
--   - Creating all required tables with relationships and constraints
--   - Creating useful views for reporting
--   - Flushing binary logs for replication hygiene
--   - Loading initial data dumps in the correct dependency order
--   - Optional stored procedure loading and verification scripts
--   - Elapsed time reporting for performance tracking
--
-- Usage Instructions:
-- 1. Run this script in your MySQL environment with a user account that has
--    privileges to create databases, tables, and load data.
-- 2. Place the data dump files (*.dump) in the directory from which you run MySQL,
--    or adjust the paths in the `SOURCE` commands.
-- 3. Foreign key checks are automatically disabled during loading to avoid 
--    constraint issues, then re-enabled afterward.
-- 4. If the database already has data, rerunning this script will erase it 
--    and reinitialize everything from scratch.
--
-- Prerequisites:
-- - MySQL Server with InnoDB storage engine.
-- - Access to all required data dump files.
--
-- Sections:
-- - Database creation and selection
-- - Dropping tables if they already exist
-- - Creating tables with keys and constraints
-- - Creating views for reporting
-- - Flushing binary logs
-- - Loading data in dependency-safe order
-- - (Optional) Loading stored procedures and test scripts
-- - (Optional) Elapsed time reporting
--
-- License:
-- This work is licensed under the Creative Commons Attribution-Share Alike 3.0 Unported License.
-- See http://creativecommons.org/licenses/by-sa/3.0/ for details.
--
-- Disclaimer:
-- All data in this setup is fabricated for demonstration and testing only.
-- Any similarity to real persons or organizations is purely coincidental.
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

CREATE TABLE user_account (
    username VARCHAR(50) PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email_address VARCHAR(100)
);

CREATE TABLE user_address (
    username VARCHAR(50),
    address_id INT,
    PRIMARY KEY (username, address_id),
    FOREIGN KEY (username) REFERENCES user_account(username) ON DELETE CASCADE,
    FOREIGN KEY (address_id) REFERENCES address(address_id) ON DELETE CASCADE
);

CREATE TABLE product_category (
    category_id INT PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(100)
);

CREATE TABLE brand (
    brand_id INT PRIMARY KEY AUTO_INCREMENT,
    brand_name VARCHAR(100)
);

CREATE TABLE colour (
    colour_id INT PRIMARY KEY AUTO_INCREMENT,
    colour_name VARCHAR(50)
);

CREATE TABLE size (
    size_id INT PRIMARY KEY AUTO_INCREMENT,
    size_name VARCHAR(50)
);

CREATE TABLE supplier (
    supplier_id INT PRIMARY KEY AUTO_INCREMENT,
    supplier_name VARCHAR(100)
);

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

CREATE TABLE supplier_order (
    order_id INT PRIMARY KEY AUTO_INCREMENT,
    order_discount DECIMAL(5,2),
    supplier_id INT,
    order_date DATE,
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

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

CREATE OR REPLACE VIEW recent_user_orders AS
    SELECT username, MAX(order_date) AS last_order_date
    FROM customer_order
    GROUP BY username;

CREATE OR REPLACE VIEW product_count_by_category AS
    SELECT pc.category_name, COUNT(p.product_id) AS product_count
    FROM product_category pc
    LEFT JOIN product p ON pc.category_id = p.product_category_id
    GROUP BY pc.category_name;

-- ===========================
-- FLUSH BINARY LOGS
-- ===========================

FLUSH /*!50503 BINARY */ LOGS;

-- ===========================
-- LOAD DATA FROM DUMP FILES
-- ===========================
-- Note: The order of loading is important to respect foreign key dependencies.

SELECT 'LOADING useraccount' AS 'INFO';
SOURCE load_useraccount.dump;

SELECT 'LOADING address' AS 'INFO';
SOURCE load_address.dump;

SELECT 'LOADING useraddress' AS 'INFO';
SOURCE load_useraddress.dump;

SELECT 'LOADING productcategory' AS 'INFO';
SOURCE load_productcategory.dump;

SELECT 'LOADING brand' AS 'INFO';
SOURCE load_brand.dump;

SELECT 'LOADING colour' AS 'INFO';
SOURCE load_colour.dump;

SELECT 'LOADING size' AS 'INFO';
SOURCE load_size.dump;

SELECT 'LOADING supplier' AS 'INFO';
SOURCE load_supplier.dump;

SELECT 'LOADING product' AS 'INFO';
SOURCE load_product.dump;

SELECT 'LOADING customerorder' AS 'INFO';
SOURCE load_customerorder.dump;

SELECT 'LOADING customerorderline' AS 'INFO';
SOURCE load_customerorderline.dump;

SELECT 'LOADING supplierorder' AS 'INFO';
SOURCE load_supplierorder.dump;

SELECT 'LOADING supplierorderline' AS 'INFO';
SOURCE load_supplierorderline.dump;


