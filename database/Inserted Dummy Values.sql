use shopping_website_db;

INSERT INTO address (house_unit_no, address_line1, address_line2, city, region, postal_code, country) VALUES
('101A', 'Main Street', '', 'Hyderabad', 'Telangana', '500001', 'India'),
('202B', 'Park Lane', 'Near Mall', 'Chennai', 'Tamil Nadu', '600001', 'India'),
('303C', 'MG Road', '', 'Bangalore', 'Karnataka', '560001', 'India'),
('404D', 'Ring Road', 'Sector 5', 'Delhi', 'Delhi', '110001', 'India'),
('505E', 'Link Road', '', 'Mumbai', 'Maharashtra', '400001', 'India'),
('601F', 'Civil Lines', '', 'Lucknow', 'UP', '226001', 'India'),
('702G', 'Rajpath', '', 'Ahmedabad', 'Gujarat', '380001', 'India'),
('803H', 'Nehru Street', '', 'Pune', 'Maharashtra', '411001', 'India'),
('904I', 'Gandhi Marg', '', 'Jaipur', 'Rajasthan', '302001', 'India'),
('1005J', 'Nelson Street', '', 'Nagpur', 'Maharashtra', '440001', 'India'),
('1106K', 'Vivek Nagar', '', 'Bhopal', 'MP', '462001', 'India'),
('1207L', 'Palam Vihar', '', 'Gurgaon', 'Haryana', '122001', 'India'),
('1308M', 'IT Park', '', 'Noida', 'UP', '201301', 'India'),
('1409N', 'Sector 10', '', 'Chandigarh', 'Punjab', '160010', 'India'),
('1501O', 'DLF Phase 1', '', 'Gurgaon', 'Haryana', '122002', 'India'),
('1602P', 'Hitech City', '', 'Hyderabad', 'Telangana', '500081', 'India'),
('1703Q', 'Connaught Place', '', 'Delhi', 'Delhi', '110001', 'India'),
('1804R', 'Koregaon Park', '', 'Pune', 'Maharashtra', '411001', 'India'),
('1905S', 'Salt Lake', '', 'Kolkata', 'West Bengal', '700091', 'India'),
('2006T', 'Anna Nagar', '', 'Chennai', 'Tamil Nadu', '600040', 'India');


INSERT INTO user_account (username, first_name, last_name, email_address) VALUES
('user1', 'Teja', 'Reddy', 'user1@example.com'),
('user2', 'Nisha', 'Kumar', 'user2@example.com'),
('user3', 'Rahul', 'Verma', 'user3@example.com'),
('user4', 'Sneha', 'Singh', 'user4@example.com'),
('user5', 'Arjun', 'Das', 'user5@example.com'),
('user6', 'Anita', 'Roy', 'user6@example.com'),
('user7', 'Vikas', 'Sharma', 'user7@example.com'),
('user8', 'Deepa', 'Mehta', 'user8@example.com'),
('user9', 'Karan', 'Yadav', 'user9@example.com'),
('user10', 'Priya', 'Jain', 'user10@example.com'),
('user11', 'Amit', 'Kohli', 'user11@example.com'),
('user12', 'Neha', 'Saxena', 'user12@example.com'),
('user13', 'Ravi', 'Joshi', 'user13@example.com'),
('user14', 'Divya', 'Kapoor', 'user14@example.com'),
('user15', 'Manoj', 'Tripathi', 'user15@example.com'),
('user16', 'Sunita', 'Gupta', 'user16@example.com'),
('user17', 'Sameer', 'Khan', 'user17@example.com'),
('user18', 'Pooja', 'Desai', 'user18@example.com'),
('user19', 'Sanjay', 'Mishra', 'user19@example.com'),
('user20', 'Arpita', 'Neogi', 'user20@example.com');

INSERT INTO user_address (username, address_id) VALUES
('user1', 1),  ('user2', 2),  ('user3', 3),  ('user4', 4),  ('user5', 5),
('user6', 6),  ('user7', 7),  ('user8', 8),  ('user9', 9),  ('user10', 10),
('user11', 11),('user12', 12),('user13', 13),('user14', 14),('user15', 15),
('user16', 16),('user17', 17),('user18', 18),('user19', 19),('user20', 20);

INSERT INTO product_category (category_name) VALUES
('Clothing'), ('Footwear'), ('Accessories'), ('Electronics'), ('Home & Kitchen');

INSERT INTO brand (brand_name) VALUES
('Nike'), ('Adidas'), ('Samsung'), ('Apple'), ('Zara');

INSERT INTO colour (colour_name) VALUES
('Red'), ('Black'), ('Blue'), ('White'), ('Green');

INSERT INTO size (size_name) VALUES
('S'), ('M'), ('L'), ('XL'), ('XXL');

INSERT INTO supplier (supplier_name) VALUES
('Alpha Traders'), ('Beta Corp'), ('Gamma Supplies'), ('Delta Exports'), ('Omega Imports');

INSERT INTO product (product_name, product_category_id, brand_id, colour_id, size_id, supplier_id) VALUES
('T-Shirt', 1, 1, 1, 2, 1),
('Running Shoes', 2, 2, 2, 3, 2),
('Smartphone', 4, 3, 3, 1, 3),
('Jeans', 1, 5, 1, 4, 1),
('Sneakers', 2, 1, 2, 3, 2),
('Smartwatch', 4, 4, 4, 1, 3),
('Laptop', 4, 3, 5, 2, 3),
('Backpack', 3, 5, 3, 2, 4),
('Microwave', 5, 3, 2, 1, 5),
('Dress', 1, 5, 1, 2, 1),
('Sandals', 2, 2, 3, 3, 2),
('Jacket', 1, 1, 4, 5, 1),
('Blender', 5, 3, 5, 1, 5),
('Formal Shoes', 2, 2, 2, 4, 2),
('Tablet', 4, 4, 1, 1, 3),
('Heels', 2, 5, 1, 3, 2),
('Cap', 3, 1, 1, 1, 1),
('Earrings', 3, 5, 3, 2, 4),
('Trousers', 1, 5, 2, 4, 1),
('Mixer Grinder', 5, 3, 5, 2, 5);

INSERT INTO customer_order (order_discount, shipping_address, billing_address, username, order_date) VALUES
(5.00, 1, 1, 'user1', '2025-08-01'),
(10.00, 2, 2, 'user2', '2025-08-01'),
(0.00, 3, 3, 'user3', '2025-08-01'),
(7.50, 4, 4, 'user4', '2025-08-01'),
(6.00, 5, 5, 'user5', '2025-08-01'),
(9.00, 6, 6, 'user6', '2025-08-02'),
(4.50, 7, 7, 'user7', '2025-08-02'),
(3.00, 8, 8, 'user8', '2025-08-02'),
(2.50, 9, 9, 'user9', '2025-08-02'),
(8.00, 10, 10, 'user10', '2025-08-02'),
(7.00, 11, 11, 'user11', '2025-08-03'),
(6.50, 12, 12, 'user12', '2025-08-03'),
(5.50, 13, 13, 'user13', '2025-08-03'),
(4.00, 14, 14, 'user14', '2025-08-03'),
(3.50, 15, 15, 'user15', '2025-08-03'),
(9.50, 16, 16, 'user16', '2025-08-04'),
(10.00, 17, 17, 'user17', '2025-08-04'),
(8.50, 18, 18, 'user18', '2025-08-04'),
(7.25, 19, 19, 'user19', '2025-08-04'),
(6.75, 20, 20, 'user20', '2025-08-04');

INSERT INTO customer_order_line (order_id, product_id, qty, discount, price) VALUES
(1, 1, 1, 0.00, 499.99), (2, 2, 1, 5.00, 2999.99), (3, 3, 1, 0.00, 15999.00),
(4, 4, 2, 10.00, 999.00), (5, 5, 1, 0.00, 1299.99), (6, 6, 1, 0.00, 8999.99),
(7, 7, 1, 5.00, 49999.00), (8, 8, 1, 0.00, 999.99), (9, 9, 1, 10.00, 6999.99),
(10, 10, 1, 0.00, 799.99), (11, 11, 2, 0.00, 1199.99), (12, 12, 1, 0.00, 1999.99),
(13, 13, 1, 0.00, 4999.99), (14, 14, 1, 0.00, 22999.00), (15, 15, 2, 5.00, 1999.99),
(16, 16, 1, 0.00, 299.99), (17, 17, 1, 0.00, 499.99), (18, 18, 1, 0.00, 999.99),
(19, 19, 2, 0.00, 1099.99), (20, 20, 1, 0.00, 3999.99);

INSERT INTO supplier_order (order_discount, supplier_id, order_date) VALUES
(5.00, 1, '2025-07-25'),
(2.00, 2, '2025-07-26'),
(4.00, 3, '2025-07-27'),
(3.00, 4, '2025-07-28'),
(6.00, 5, '2025-07-29');

INSERT INTO supplier_order_line (order_id, product_id, qty, discount, price) VALUES
(1, 1, 10, 5.00, 350.00), (1, 2, 5, 0.00, 2700.00), (2, 3, 3, 2.00, 13000.00),
(2, 4, 8, 3.00, 750.00), (3, 5, 6, 0.00, 1100.00), (3, 6, 4, 1.00, 8500.00),
(4, 7, 2, 0.00, 45000.00), (4, 8, 10, 5.00, 799.99), (5, 9, 3, 2.00, 6700.00),
(5, 10, 7, 0.00, 699.00), (1, 11, 4, 0.00, 1000.00), (2, 12, 6, 0.00, 1500.00),
(3, 13, 2, 1.00, 4500.00), (4, 14, 1, 0.00, 22000.00), (5, 15, 3, 0.00, 1700.00),
(1, 16, 10, 0.00, 199.00), (2, 17, 5, 0.00, 299.00), (3, 18, 3, 0.00, 799.00),
(4, 19, 4, 0.00, 900.00), (5, 20, 5, 0.00, 3500.00);
