--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `supplier_orde_line` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `supplier_order_line` (order_id, product_id, qty, discount, price) VALUES
(1,1,10,0.00,90.00),
(2,2,20,5.00,180.00),
(3,3,15,10.00,140.00),
(4,4,5,0.00,280.00),
(5,5,25,2.50,75.00),
(6,6,30,7.50,110.00),
(7,7,12,0.00,55.00),
(8,8,8,3.00,380.00),
(9,9,18,1.50,230.00),
(10,10,10,0.00,480.00),
(11,11,22,4.00,210.00),
(12,12,17,6.00,170.00),
(13,13,9,0.00,120.00),
(14,14,14,8.25,85.00),
(15,15,11,0.00,65.00);