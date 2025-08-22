-- Address Table
CREATE TABLE address (
    address_id INT PRIMARY KEY AUTO_INCREMENT,
    house_unit_no VARCHAR(50),
    address_line1 VARCHAR(100),
    address_line2 VARCHAR(100),
    city VARCHAR(50),
    region VARCHAR(50),
    postal_code VARCHAR(20),
    country VARCHAR(50)
);

-- User Address Mapping Table
CREATE TABLE user_address (
    username VARCHAR(50),
    address_id INT,
    PRIMARY KEY (username, address_id),
    FOREIGN KEY (username) REFERENCES user_account(username),
    FOREIGN KEY (address_id) REFERENCES address(address_id)
);

-- Product Category
CREATE TABLE product_category (
    category_id INT PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(100)
);

-- Brand Table
CREATE TABLE brand (
    brand_id INT PRIMARY KEY AUTO_INCREMENT,
    brand_name VARCHAR(100)
);

-- Colour Table
CREATE TABLE colour (
    colour_id INT PRIMARY KEY AUTO_INCREMENT,
    colour_name VARCHAR(50)
);

-- Size Table
CREATE TABLE size (
    size_id INT PRIMARY KEY AUTO_INCREMENT,
    size_name VARCHAR(50)
);

-- Supplier Table
CREATE TABLE supplier (
    supplier_id INT PRIMARY KEY AUTO_INCREMENT,
    supplier_name VARCHAR(100)
);

-- Product Table
CREATE TABLE product (
    product_id INT PRIMARY KEY AUTO_INCREMENT,
    product_name VARCHAR(100),
    product_category_id INT,
    brand_id INT,
    colour_id INT,
    size_id INT,
    supplier_id INT,
    FOREIGN KEY (product_category_id) REFERENCES product_category(category_id),
    FOREIGN KEY (brand_id) REFERENCES brand(brand_id),
    FOREIGN KEY (colour_id) REFERENCES colour(colour_id),
    FOREIGN KEY (size_id) REFERENCES size(size_id),
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

-- Customer Order Table
CREATE TABLE customer_order (
    order_id INT PRIMARY KEY AUTO_INCREMENT,
    order_discount DECIMAL(5,2),
    shipping_address INT,
    billing_address INT,
    username VARCHAR(50),
    order_date DATE,
    FOREIGN KEY (shipping_address) REFERENCES address(address_id),
    FOREIGN KEY (billing_address) REFERENCES address(address_id),
    FOREIGN KEY (username) REFERENCES user_account(username)
);

-- Customer Order Line Table
CREATE TABLE customer_order_line (
    order_line_id INT PRIMARY KEY AUTO_INCREMENT,
    order_id INT,
    product_id INT,
    qty INT,
    discount DECIMAL(5,2),
    price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES customer_order(order_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);

-- Supplier Order Table
CREATE TABLE supplier_order (
    order_id INT PRIMARY KEY AUTO_INCREMENT,
    order_discount DECIMAL(5,2),
    supplier_id INT,
    order_date DATE,
    FOREIGN KEY (supplier_id) REFERENCES supplier(supplier_id)
);

-- Supplier Order Line Table
CREATE TABLE supplier_order_line (
    order_line_id INT PRIMARY KEY AUTO_INCREMENT,
    order_id INT,
    product_id INT,
    qty INT,
    discount DECIMAL(5,2),
    price DECIMAL(10,2),
    FOREIGN KEY (order_id) REFERENCES supplier_order(order_id),
    FOREIGN KEY (product_id) REFERENCES product(product_id)
);
