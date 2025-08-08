-- © 2025 Elangovan R
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

USE shopping_website_db;

DELIMITER $$

-- Stored Procedure: GetCustomerOrders
-- Input: cust_username (VARCHAR) - username of the customer
-- Output: All orders placed by the given customer
CREATE PROCEDURE GetCustomerOrders(IN cust_username VARCHAR(50))
BEGIN
    SELECT * 
    FROM customer_order
    WHERE username = cust_username;
END $$

-- Stored Function: TotalOrderValue
-- Input: orderId (INT) - ID of the order
-- Output: Total value of the order (sum of price * quantity of all order lines)
CREATE FUNCTION TotalOrderValue(orderId INT) RETURNS DECIMAL(10,2)
READS SQL DATA
BEGIN
    DECLARE total DECIMAL(10,2);
    SELECT SUM(price * qty)
    INTO total
    FROM customer_order_line
    WHERE order_id = orderId;
    -- Return 0.00 if no matching records found (NULL)
    RETURN IFNULL(total, 0.00);
END $$

DELIMITER ;
