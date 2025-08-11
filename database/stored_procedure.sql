DELIMITER //

CREATE PROCEDURE CheckTableIntegrity(
    IN p_table_name VARCHAR(30),
    IN p_expected_count INT,
    IN p_expected_hash VARCHAR(100)
)
BEGIN
    DECLARE v_actual_count INT;
    DECLARE v_actual_hash VARCHAR(100);

    IF p_table_name = 'country' THEN
        SELECT COUNT(*) INTO v_actual_count FROM country;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(country_id,''), COALESCE(country_name,'')) 
               ORDER BY country_id SEPARATOR '|')) INTO v_actual_hash FROM country;

    ELSEIF p_table_name = 'manufacturer' THEN
        SELECT COUNT(*) INTO v_actual_count FROM manufacturer;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(manufacturer_id,''), COALESCE(manufacturer_name,''))
               ORDER BY manufacturer_id SEPARATOR '|')) INTO v_actual_hash FROM manufacturer;

    ELSEIF p_table_name = 'city' THEN
        SELECT COUNT(*) INTO v_actual_count FROM city;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(city_id,''), COALESCE(country_id,''), COALESCE(city_name,''))
               ORDER BY city_id SEPARATOR '|')) INTO v_actual_hash FROM city;

    ELSEIF p_table_name = 'customer' THEN
        SELECT COUNT(*) INTO v_actual_count FROM customer;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(customer_id,''), COALESCE(country_id,''), COALESCE(first_name,''), COALESCE(last_name,''), COALESCE(passport_number,''), COALESCE(email_address,''), COALESCE(phone_number,''))
               ORDER BY customer_id SEPARATOR '|')) INTO v_actual_hash FROM customer;

    ELSEIF p_table_name = 'airport' THEN
        SELECT COUNT(*) INTO v_actual_count FROM airport;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(airport_code,''), COALESCE(city_id,''), COALESCE(airport_name,''))
               ORDER BY airport_code SEPARATOR '|')) INTO v_actual_hash FROM airport;

    ELSEIF p_table_name = 'airline' THEN
        SELECT COUNT(*) INTO v_actual_count FROM airline;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(airline_id,''), COALESCE(airline_name,''))
               ORDER BY airline_id SEPARATOR '|')) INTO v_actual_hash FROM airline;

    ELSEIF p_table_name = 'booking' THEN
        SELECT COUNT(*) INTO v_actual_count FROM booking;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(booking_id,''), COALESCE(airline_id,''), COALESCE(customer_id,''))
               ORDER BY booking_id SEPARATOR '|')) INTO v_actual_hash FROM booking;

    ELSEIF p_table_name = 'flight' THEN
        SELECT COUNT(*) INTO v_actual_count FROM flight;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(flight_code,''), COALESCE(airline_id,''))
               ORDER BY flight_code SEPARATOR '|')) INTO v_actual_hash FROM flight;

    ELSEIF p_table_name = 'aircraft' THEN
        SELECT COUNT(*) INTO v_actual_count FROM aircraft;
        SELECT MD5(GROUP_CONCAT(CONCAT_WS('#', COALESCE(aircraft_id,''), COALESCE(aircraft_model_id,''), COALESCE(owned_by_airline_id,''))
               ORDER BY aircraft_id SEPARATOR '|')) INTO v_actual_hash FROM aircraft;

    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Table not supported for validation';
    END IF;

    -- Output comparison
    SELECT 
        p_table_name AS table_name,
        p_expected_count AS expected_count,
        v_actual_count AS actual_count,
        IF(p_expected_count = v_actual_count, 'OK', 'FAIL') AS count_check,
        p_expected_hash AS expected_hash,
        v_actual_hash AS actual_hash,
        IF(p_expected_hash = v_actual_hash, 'OK', 'FAIL') AS hash_check;
END //

DELIMITER ;
