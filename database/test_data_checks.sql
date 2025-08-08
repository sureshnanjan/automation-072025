-- © 2025 Elangovan R
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

USE shopping_website_db;

-- Test 1: Check that every customer order has at least one associated order line.
-- This query finds orders in customer_order table that do NOT have any matching
-- entries in customer_order_line table (meaning no items ordered). 
SELECT 'Checking orders have at least one line item...' AS test_name;
SELECT o.order_id
FROM customer_order o
LEFT JOIN customer_order_line ol ON o.order_id = ol.order_id
WHERE ol.order_id IS NULL;

-- Test 2: Verify referential integrity between supplier_order and supplier tables.
-- This query finds supplier orders where the supplier_id does not exist in the supplier table.
SELECT 'Checking supplier orders reference existing suppliers...' AS test_name;
SELECT order_id
FROM supplier_order
WHERE supplier_id NOT IN (SELECT supplier_id FROM supplier);

