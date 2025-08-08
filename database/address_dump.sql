-- ****************************************************************************
--  Title:         Address Table Seed Data
--  Description:   This script inserts sample address records into the `address`
--                 table for the shopping_website_db schema.
--                 Data is for development and testing purposes only.
--  
--  Author:        Shreya S G
--  Created on:    2025-08-08
--  Last updated:  2025-08-08
--
--  Usage:         Execute this script after creating the `address` table to 
--                 populate it with initial data.
--
--  Notes:         - Ensure that the database `shopping_website_db` is selected.
--                 - Modify or extend the data as per project requirements.
--
--  License:       © 2025 AscendionQA. All rights reserved.
--                 This script is licensed for use under MIT License.
--                 See LICENSE file in the project root for license information.
-- ****************************************************************************

INSERT INTO `address` 
    (house_unit_no, address_line1, address_line2, city, region, postal_code, country) 
VALUES
    ('Apt 101','123 Elm St','','Chennai','Tamil Nadu','600001','India'),
    ('Flat 5B','456 Oak Rd','','Chennai','Tamil Nadu','600002','India'),
    ('Suite 12','789 Pine Ave','Block C','Chennai','Tamil Nadu','600003','India'),
    ('House 7','11 Mango Lane','','Chennai','Tamil Nadu','600004','India'),
    ('Unit 3','22 Banana St','','Chennai','Tamil Nadu','600005','India'),
    ('Apt 9','33 Cotton Rd','','Chennai','Tamil Nadu','600006','India'),
    ('Flat 2A','44 Silk St','','Chennai','Tamil Nadu','600007','India'),
    ('Suite 21','55 Rose Ave','','Chennai','Tamil Nadu','600008','India'),
    ('House 17','66 Jasmine Rd','','Chennai','Tamil Nadu','600009','India'),
    ('Unit 4','77 Lotus Ln','','Chennai','Tamil Nadu','600010','India'),
    ('Apt 11','88 Lily St','','Chennai','Tamil Nadu','600011','India'),
    ('Flat 6C','99 Marigold Rd','','Chennai','Tamil Nadu','600012','India'),
    ('Suite 33','100 Tulip Ave','','Chennai','Tamil Nadu','600013','India'),
    ('House 25','111 Orchid St','','Chennai','Tamil Nadu','600014','India'),
    ('Unit 8','122 Daisy Rd','','Chennai','Tamil Nadu','600015','India');
