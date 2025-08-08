--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `supplier_order` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `supplier_order` (order_discount, supplier_id, order_date) VALUES
(0.00,1,'2025-02-01'),
(5.00,2,'2025-02-02'),
(10.00,3,'2025-02-03'),
(0.00,4,'2025-02-04'),
(2.50,5,'2025-02-05'),
(7.50,6,'2025-02-06'),
(0.00,7,'2025-02-07'),
(3.00,8,'2025-02-08'),
(1.50,9,'2025-02-09'),
(0.00,10,'2025-02-10'),
(4.00,11,'2025-02-11'),
(6.00,12,'2025-02-12'),
(0.00,13,'2025-02-13'),
(8.25,14,'2025-02-14'),
(0.00,15,'2025-02-15');