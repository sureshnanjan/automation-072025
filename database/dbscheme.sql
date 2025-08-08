/* --------------------------------------------------
   Shopping Website Database Schema
   Author: Shreya S G
   Date:   2025-08-08
   Version: 1.0

   © 2025 AscendionQA. All rights reserved.
   Licensed under the MIT License. You may use, copy, 
   modify, merge, publish, and distribute this file, 
   provided that copyright notice and permission notice 
   are included in all copies or substantial portions 
   of the Software.

   Description:
   This script creates the database schema for a 
   shopping website, including tables for users, 
   products, orders, suppliers, and relationships 
   between them.

   Usage:
   1. Open MySQL Workbench / CLI / phpMyAdmin.
   2. Copy and paste this script.
   3. Execute the entire file.
   -------------------------------------------------- */

/* --------------------------------------------------
   1. Create and select database
   -------------------------------------------------- */
CREATE DATABASE IF NOT EXISTS shopping_website_db;
USE shopping_website_db;

/* --------------------------------------------------
   2. Address Table
   Stores customer and supplier addresses.
   -------------------------------------------------- */
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

/* --------------------------------------------------
   3. User Account Table
   Stores user profile information.
   -------------------------------------------------- */
CREATE TABLE user_account (
    username VARCHAR(50) PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email_address VARCHAR(100)
);

/* --------------------------------------------------
   4. User Address Mapping Table
   Many-to-Many relation between users and addresses.
   -------------------------------------------------- */
CREATE TABLE user_address (
    username VARCHAR(50),
    address_id INT,
    PRIMARY KEY (username, address_id),
    FOREIGN KEY (username) REFERENCES user_account(username),
    FOREIGN KEY (address_id) REFERENCES address(address_id)
);

/* --------------------------------------------------
   5. Product Category Table
   -------------------------------------------------- */
CREATE TABLE product_category (
    category_id INT PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(100)
);

/* --------------------------------------------------
   6. Brand Table
   -------------------------------------------------- */
CREATE TABLE brand (
    brand_id INT PRIMARY KEY AUTO_INCREMENT,
    brand_name VARCHAR(100)
);

/* --------------------------------------------------
   7. Colour Table
   -------------------------------------------------- */
CREATE TABLE colour (
    colour_id INT PRIMARY KEY AUTO_INCREMENT,
    colour_name VARCHAR(50)
);

/* --------------------------------------------------
   8. Size Table
   -------------------------------------------------- */
CREATE TABLE size (
    size_id INT PRIMARY KEY AUTO_INCREMENT,
    size_name VARCHAR(50)
);

/* --------------------------------------------------
   9. Supplier Table
   -------------------------------------------------- */
CREATE TABLE supplier (
    supplier_id INT PRIMARY KEY AUTO_INCREMENT,
    supplier_name VARCHAR(100)
);

/* --------------------------------------------------
   10. Product Table
   Stores product information and foreign keys 
   to category, brand, colour, size, and supplier.
   -------------------------------------------------- */
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

/* --------------------------------------------------
   11. Customer Order Table
   -------------------------------------------------- */
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

/* --------------------------------------------------
   12. Customer Order Line Table
   -------------------------------------------------- */
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

/* --------------------------------------------------
   13. Supplier Order Table
   -------------------------------------------------- */
CREATE TABLE supplier_order (
    order_id INT PRIMARY KEY AUTO_INCREMENT,
    order_discount DECIMAL(5,2),
    supplier_id INT,
    order_date DATE,
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

/* --------------------------------------------------
   14. Supplier Order Line Table
   -------------------------------------------------- */
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

/* --------------------------------------------------
   End of Schema Creation
   -------------------------------------------------- */
