DROP PROCEDURE IF EXISTS check_md5_for_all_tables;

DELIMITER $$

CREATE PROCEDURE check_md5_for_all_tables()
BEGIN
    -- Temporary table to store results
    DROP TEMPORARY TABLE IF EXISTS temp_md5_results;
    CREATE TEMPORARY TABLE temp_md5_results (
        TableName VARCHAR(50),
        ExpectedCount INT,
        ActualCount INT,
        ExpectedHash CHAR(32),
        ActualHash CHAR(32),
        CountMatch VARCHAR(4),
        HashMatch VARCHAR(4)
    );

    -- Insert product table results
    INSERT INTO temp_md5_results
    SELECT 
        'product' AS TableName,
        15 AS ExpectedCount,
        COUNT(*) AS ActualCount,
        MD5(GROUP_CONCAT(CONCAT_WS('#', product_name, product_category_id, brand_id, colour_id, size_id, supplier_id) ORDER BY product_name)) AS ExpectedHash,
        MD5(GROUP_CONCAT(CONCAT_WS('#', product_name, product_category_id, brand_id, colour_id, size_id, supplier_id) ORDER BY product_name)) AS ActualHash,
        IF(15 = COUNT(*), 'PASS', 'FAIL') AS CountMatch,
        IF(
            MD5(GROUP_CONCAT(CONCAT_WS('#', product_name, product_category_id, brand_id, colour_id, size_id, supplier_id) ORDER BY product_name)) =
            MD5(GROUP_CONCAT(CONCAT_WS('#', product_name, product_category_id, brand_id, colour_id, size_id, supplier_id) ORDER BY product_name)),
            'PASS', 'FAIL'
        ) AS HashMatch
    FROM product;

    -- Insert product_category table results
    INSERT INTO temp_md5_results
    SELECT 
        'product_category', 15, COUNT(*),
        MD5(GROUP_CONCAT(category_name ORDER BY category_name)),
        MD5(GROUP_CONCAT(category_name ORDER BY category_name)),
        IF(15 = COUNT(*), 'PASS', 'FAIL'),
        IF(
            MD5(GROUP_CONCAT(category_name ORDER BY category_name)) =
            MD5(GROUP_CONCAT(category_name ORDER BY category_name)),
            'PASS', 'FAIL'
        )
    FROM product_category;

    -- Insert brand table results
    INSERT INTO temp_md5_results
    SELECT 
        'brand', 15, COUNT(*),
        MD5(GROUP_CONCAT(brand_name ORDER BY brand_name)),
        MD5(GROUP_CONCAT(brand_name ORDER BY brand_name)),
        IF(15 = COUNT(*), 'PASS', 'FAIL'),
        IF(
            MD5(GROUP_CONCAT(brand_name ORDER BY brand_name)) =
            MD5(GROUP_CONCAT(brand_name ORDER BY brand_name)),
            'PASS', 'FAIL'
        )
    FROM brand;

    -- Insert colour table results
    INSERT INTO temp_md5_results
    SELECT 
        'colour', 15, COUNT(*),
        MD5(GROUP_CONCAT(colour_name ORDER BY colour_name)),
        MD5(GROUP_CONCAT(colour_name ORDER BY colour_name)),
        IF(15 = COUNT(*), 'PASS', 'FAIL'),
        IF(
            MD5(GROUP_CONCAT(colour_name ORDER BY colour_name)) =
            MD5(GROUP_CONCAT(colour_name ORDER BY colour_name)),
            'PASS', 'FAIL'
        )
    FROM colour;

    -- Insert size table results
    INSERT INTO temp_md5_results
    SELECT 
        'size', 15, COUNT(*),
        MD5(GROUP_CONCAT(size_name ORDER BY size_name)),
        MD5(GROUP_CONCAT(size_name ORDER BY size_name)),
        IF(15 = COUNT(*), 'PASS', 'FAIL'),
        IF(
            MD5(GROUP_CONCAT(size_name ORDER BY size_name)) =
            MD5(GROUP_CONCAT(size_name ORDER BY size_name)),
            'PASS', 'FAIL'
        )
    FROM size;

    -- Insert supplier table results
    INSERT INTO temp_md5_results
    SELECT 
        'supplier', 15, COUNT(*),
        MD5(GROUP_CONCAT(supplier_name ORDER BY supplier_name)),
        MD5(GROUP_CONCAT(supplier_name ORDER BY supplier_name)),
        IF(15 = COUNT(*), 'PASS', 'FAIL'),
        IF(
            MD5(GROUP_CONCAT(supplier_name ORDER BY supplier_name)) =
            MD5(GROUP_CONCAT(supplier_name ORDER BY supplier_name)),
            'PASS', 'FAIL'
        )
    FROM supplier;

    -- Final select to show results
    SELECT * FROM temp_md5_results;
END$$

DELIMITER ;

-- Run the procedure
CALL check_md5_for_all_tables();
