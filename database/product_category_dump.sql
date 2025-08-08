--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `product_category` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `product_category` (category_name) VALUES
('Electronics'),
('Apparel'),
('Furniture'),
('Toys'),
('Books'),
('Groceries'),
('Beauty'),
('Sports'),
('Automotive'),
('Music'),
('Jewelry'),
('Health'),
('Office Supplies'),
('Garden'),
('Pet Supplies');