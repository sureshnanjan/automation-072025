-- © 2025 Elangovan R
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

-- sp_check.sql
-- Switch to the shopping_website_db database
USE shopping_website_db;

-- Test the stored procedure 'GetCustomerOrders' for customer with ID = 1
CALL GetCustomerOrders(1);

-- Test the stored function 'TotalOrderValue' for customer with ID = 1
-- Returns the total value of orders placed by that customer
SELECT TotalOrderValue(1) AS order_value;
