CREATE DATABASE banking_system;
USE banking_system;
# customer
CREATE TABLE customer (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    date_of_birth DATE,
    signup_date DATE
);
#account_type
CREATE TABLE account_type (
    account_type_id INT PRIMARY KEY,
    account_type VARCHAR(50)
);
#account_status
CREATE TABLE account_status (
    status_id INT PRIMARY KEY,
    status_value VARCHAR(50)
);
#account
CREATE TABLE account (
    account_number INT PRIMARY KEY,
    account_type_id INT,
    status_id INT,
    date_opened DATE,
    date_closed DATE,
    FOREIGN KEY (account_type_id) REFERENCES account_type(account_type_id),
    FOREIGN KEY (status_id) REFERENCES account_status(status_id)
);
#customer_account
CREATE TABLE customer_account (
    account_number INT,
    customer_id INT,
    PRIMARY KEY (account_number, customer_id),
    FOREIGN KEY (account_number) REFERENCES account(account_number),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);
#transaction
CREATE TABLE transaction (
    transaction_id INT PRIMARY KEY,
    transaction_datetime DATETIME,
    from_account INT,
    to_account INT,
    description VARCHAR(255),
    FOREIGN KEY (from_account) REFERENCES account(account_number),
    FOREIGN KEY (to_account) REFERENCES account(account_number)
);

