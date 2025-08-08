--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `customer_order` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `customer_order` (order_discount, shipping_address, billing_address, username, order_date) VALUES
(0.00,1,1,'user1','2025-01-01'),
(5.00,2,2,'user2','2025-01-02'),
(10.00,3,3,'user3','2025-01-03'),
(0.00,4,4,'user4','2025-01-04'),
(2.50,5,5,'user5','2025-01-05'),
(7.50,6,6,'user6','2025-01-06'),
(0.00,7,7,'user7','2025-01-07'),
(3.00,8,8,'user8','2025-01-08'),
(1.50,9,9,'user9','2025-01-09'),
(0.00,10,10,'user10','2025-01-10'),
(4.00,11,11,'user11','2025-01-11'),
(6.00,12,12,'user12','2025-01-12'),
(0.00,13,13,'user13','2025-01-13'),
(8.25,14,14,'user14','2025-01-14'),
(0.00,15,15,'user15','2025-01-15');