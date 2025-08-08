--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `product` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `product` (product_name, product_category_id, brand_id, colour_id, size_id, supplier_id) VALUES
('Prod1',1,1,1,1,1),
('Prod2',2,2,2,2,2),
('Prod3',3,3,3,3,3),
('Prod4',4,4,4,4,4),
('Prod5',5,5,5,5,5),
('Prod6',6,6,6,6,6),
('Prod7',7,7,7,7,7),
('Prod8',8,8,8,8,8),
('Prod9',9,9,9,9,9),
('Prod10',10,10,10,10,10),
('Prod11',11,11,11,11,11),
('Prod12',12,12,12,12,12),
('Prod13',13,13,13,13,13),
('Prod14',14,14,14,14,14),
('Prod15',15,15,15,15,15);