--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `customer_order_line` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `customer_order_line` (order_id, product_id, qty, discount, price) VALUES
(1,1,2,0.00,100.00),
(2,2,1,5.00,200.00),
(3,3,3,10.00,150.00),
(4,4,1,0.00,300.00),
(5,5,5,2.50,80.00),
(6,6,2,7.50,120.00),
(7,7,4,0.00,60.00),
(8,8,1,3.00,400.00),
(9,9,2,1.50,250.00),
(10,10,1,0.00,500.00),
(11,11,3,4.00,220.00),
(12,12,2,6.00,180.00),
(13,13,1,0.00,130.00),
(14,14,2,8.25,90.00),
(15,15,1,0.00,70.00);