--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `user_address` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `user_address` (username, address_id) VALUES
('user1',1),
('user1',2),
('user2',3),
('user3',4),
('user4',5),
('user5',6),
('user6',7),
('user7',8),
('user8',9),
('user9',10),
('user10',11),
('user11',12),
('user12',13),
('user13',14),
('user14',15);