DROP PROCEDURE IF EXISTS validate_table_sha256;
DELIMITER $$

CREATE PROCEDURE validate_table_sha256(
    IN tbl_name VARCHAR(64),
    IN expected_count INT,
    IN expected_hash VARCHAR(100)
)
BEGIN
    DECLARE actual_count INT DEFAULT 0;
    DECLARE actual_hash VARCHAR(100) DEFAULT '';
    DECLARE sql_text TEXT;

    -- Allow large concatenations so the SHA256 is calculated fully
    SET SESSION group_concat_max_len = 1000000;

    -- ✅ Calculate actual row count
    SET @sql_text = CONCAT('SELECT COUNT(*) INTO @ac FROM ', tbl_name);
    PREPARE stmt FROM @sql_text;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
    SET actual_count = @ac;

    -- ✅ Calculate actual SHA256 with NULL handling & consistent order
    IF tbl_name = 'Airlines' THEN
        SET @sql_text = "SELECT SHA2(GROUP_CONCAT(CONCAT_WS('#', COALESCE(Airline_ID,''), COALESCE(Airline_Name,'')) ORDER BY Airline_ID SEPARATOR '|'), 256) INTO @ah FROM Airlines";
    ELSEIF tbl_name = 'Flights' THEN
        SET @sql_text = "SELECT SHA2(GROUP_CONCAT(CONCAT_WS('#', COALESCE(Flight_ID,''), COALESCE(Flight_No,''), COALESCE(Airline_ID,''), COALESCE(Source,''), COALESCE(Destination,'')) ORDER BY Flight_ID SEPARATOR '|'), 256) INTO @ah FROM Flights";
    ELSEIF tbl_name = 'Passengers' THEN
        SET @sql_text = "SELECT SHA2(GROUP_CONCAT(CONCAT_WS('#', COALESCE(Passenger_ID,''), COALESCE(Passenger_Name,''), COALESCE(Passenger_Email,'')) ORDER BY Passenger_ID SEPARATOR '|'), 256) INTO @ah FROM Passengers";
    ELSEIF tbl_name = 'Bookings' THEN
        SET @sql_text = "SELECT SHA2(GROUP_CONCAT(CONCAT_WS('#', COALESCE(Booking_ID,''), COALESCE(Passenger_ID,''), COALESCE(Flight_ID,''), COALESCE(Seat_No,'')) ORDER BY Booking_ID SEPARATOR '|'), 256) INTO @ah FROM Bookings";
    ELSE
        SET actual_hash = 'UNKNOWN_TABLE';
    END IF;

    -- ✅ Execute hash calculation if valid table
    IF actual_hash != 'UNKNOWN_TABLE' THEN
        PREPARE stmt FROM @sql_text;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
        SET actual_hash = @ah;
    END IF;

    -- ✅ Show results
    SELECT
        tbl_name AS TableName,
        expected_count AS ExpectedCount,
        actual_count AS ActualCount,
        expected_hash AS ExpectedHash,
        actual_hash AS ActualHash,
        IF(expected_count = actual_count, 'OK', 'FAIL') AS CountMatch,
        IF(expected_hash = actual_hash, 'OK', 'FAIL') AS HashMatch;
END$$

DELIMITER ;
CALL validate_table_sha256(
    'Airlines',
    5,
    'c133bf1b51ebc56c175d6d9c7a798df046fcb46f019f2f06328ebb0ab7c33509'
);


