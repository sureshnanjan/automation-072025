TRUNCATE TABLE expected_values;
INSERT INTO expected_values
SELECT * FROM found_values;
