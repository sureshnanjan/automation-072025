-- Optional: set your schema
-- USE banksystem;

-- NOTE:
-- If your table is named `transaction`, keep the backticks as shown below.

DELIMITER //

-- ─────────────────────────────────────────────────────────
-- A) Create a customer (returns new customer_id)
-- ─────────────────────────────────────────────────────────
DROP PROCEDURE IF EXISTS add_customer//
CREATE PROCEDURE add_customer(
  IN p_first_name VARCHAR(50),
  IN p_last_name  VARCHAR(50),
  IN p_dob        DATE,
  IN p_signup     DATE
)
BEGIN
  IF p_first_name IS NULL OR p_last_name IS NULL OR p_dob IS NULL OR p_signup IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'All customer fields are required';
  END IF;

  INSERT INTO customer(first_name, last_name, date_of_birth, signup_date)
  VALUES (p_first_name, p_last_name, p_dob, p_signup);

  SELECT LAST_INSERT_ID() AS customer_id;
END//
-- Example:
-- CALL add_customer('Asha','Rao','1990-01-10','2024-06-01');

-- ─────────────────────────────────────────────────────────
-- B) Open an account (returns new account_number)
-- ─────────────────────────────────────────────────────────
DROP PROCEDURE IF EXISTS open_account//
CREATE PROCEDURE open_account(
  IN p_account_type_id INT,
  IN p_status_id INT,
  IN p_date_opened DATE
)
BEGIN
  IF NOT EXISTS (SELECT 1 FROM account_type WHERE account_type_id = p_account_type_id) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown account_type_id';
  END IF;

  IF NOT EXISTS (SELECT 1 FROM account_status WHERE status_id = p_status_id) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown status_id';
  END IF;

  IF p_date_opened IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'date_opened is required';
  END IF;

  INSERT INTO account(account_type_id, status_id, date_opened, date_closed)
  VALUES (p_account_type_id, p_status_id, p_date_opened, NULL);

  SELECT LAST_INSERT_ID() AS account_number;
END//
-- Example:
-- CALL open_account(1, 1, '2024-06-01');

-- ─────────────────────────────────────────────────────────
-- C) Link a customer to an account (idempotent insert)
-- ─────────────────────────────────────────────────────────
DROP PROCEDURE IF EXISTS add_customer_account//
CREATE PROCEDURE add_customer_account(
  IN p_customer_id INT,
  IN p_account_number INT
)
BEGIN
  IF NOT EXISTS (SELECT 1 FROM customer WHERE customer_id = p_customer_id) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown customer_id';
  END IF;

  IF NOT EXISTS (SELECT 1 FROM account WHERE account_number = p_account_number) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown account_number';
  END IF;

  INSERT INTO customer_account(customer_id, account_number)
  VALUES (p_customer_id, p_account_number)
  ON DUPLICATE KEY UPDATE account_number = VALUES(account_number);
END//
-- Example:
-- CALL add_customer_account(1, 10001);

-- ─────────────────────────────────────────────────────────
-- D) Add a simple transaction (description only; amount not modeled)
--    Keep the backticks if your table is named `transaction`.
-- ─────────────────────────────────────────────────────────
DROP PROCEDURE IF EXISTS add_simple_transaction//
CREATE PROCEDURE add_simple_transaction(
  IN p_from_account INT,
  IN p_to_account   INT,
  IN p_description  VARCHAR(255)
)
BEGIN
  IF p_from_account IS NULL AND p_to_account IS NULL THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'At least one account (from/to) is required';
  END IF;

  IF p_from_account IS NOT NULL
     AND NOT EXISTS (SELECT 1 FROM account WHERE account_number = p_from_account) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown from_account';
  END IF;

  IF p_to_account IS NOT NULL
     AND NOT EXISTS (SELECT 1 FROM account WHERE account_number = p_to_account) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown to_account';
  END IF;

  INSERT INTO `transaction`(transaction_datetime, from_account, to_account, description)
  VALUES (NOW(), p_from_account, p_to_account, p_description);
END//
-- Example:
-- CALL add_simple_transaction(10001, 10002, 'Practice transfer');

-- ─────────────────────────────────────────────────────────
-- E) Close an account (basic date validation)
-- ─────────────────────────────────────────────────────────
DROP PROCEDURE IF EXISTS close_account//
CREATE PROCEDURE close_account(
  IN p_account_number INT,
  IN p_date_closed DATE
)
BEGIN
  IF NOT EXISTS (SELECT 1 FROM account WHERE account_number = p_account_number) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unknown account_number';
  END IF;

  -- Ensure closing date is not before opening date (and not NULL)
  IF EXISTS (
    SELECT 1
    FROM account
    WHERE account_number = p_account_number
      AND (p_date_closed IS NULL OR p_date_closed < date_opened)
  ) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'date_closed must be >= date_opened and not NULL';
  END IF;

  UPDATE account
  SET date_closed = p_date_closed
  WHERE account_number = p_account_number;
END//
-- Example:
-- CALL close_account(10001, '2025-01-10');

-- ─────────────────────────────────────────────────────────
-- F) Lookups (read-only helpers)
-- ─────────────────────────────────────────────────────────
DROP PROCEDURE IF EXISTS get_customer_accounts//
CREATE PROCEDURE get_customer_accounts(IN p_customer_id INT)
BEGIN
  SELECT a.account_number,
         at.account_type,
         s.status_value,
         a.date_opened,
         a.date_closed
  FROM customer_account ca
  JOIN account a       ON a.account_number = ca.account_number
  JOIN account_type at ON at.account_type_id = a.account_type_id
  JOIN account_status s ON s.status_id = a.status_id
  WHERE ca.customer_id = p_customer_id
  ORDER BY a.account_number;
END//
-- Example:
-- CALL get_customer_accounts(1);

DROP PROCEDURE IF EXISTS get_account_customers//
CREATE PROCEDURE get_account_customers(IN p_account_number INT)
BEGIN
  SELECT c.customer_id,
         c.first_name,
         c.last_name
  FROM customer_account ca
  JOIN customer c ON c.customer_id = ca.customer_id
  WHERE ca.account_number = p_account_number
  ORDER BY c.customer_id;
END//
-- Example:
-- CALL get_account_customers(10001);

DELIMITER ;