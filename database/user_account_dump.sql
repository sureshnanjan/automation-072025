--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `user_account_dump` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************
INSERT INTO `user_account` (username, first_name, last_name, email_address) VALUES
('user1','Arun','Kumar','arun.kumar@example.com'),
('user2','Bhavana','Sharma','bhavana.sharma@example.com'),
('user3','Chitra','Iyer','chitra.iyer@example.com'),
('user4','Deepak','Reddy','deepak.reddy@example.com'),
('user5','Elena','Raj','elena.raj@example.com'),
('user6','Farhan','Khan','farhan.khan@example.com'),
('user7','Gita','Menon','gita.menon@example.com'),
('user8','Hema','Das','hema.das@example.com'),
('user9','Irfan','Ahmed','irfan.ahmed@example.com'),
('user10','Jaya','Patel','jaya.patel@example.com'),
('user11','Kiran','Sen','kiran.sen@example.com'),
('user12','Leela','Gupta','leela.gupta@example.com'),
('user13','Manish','Prasad','manish.prasad@example.com'),
('user14','Nisha','Kumar','nisha.kumar@example.com'),
('user15','Omar','Shaikh','omar.shaikh@example.com');