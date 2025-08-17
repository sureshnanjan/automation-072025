-- © 2025 Elangovan R
-- Licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License.
-- See: http://creativecommons.org/licenses/by-sa/3.0/

-- show_elapsed.sql
-- This script calculates the approximate duration between the earliest table creation 
-- and the latest table update within the 'shopping_website_db' database.
-- It provides an estimate of the total data load or modification time.

SELECT TIMEDIFF(
    -- Get the latest update time among all tables in the database
    (SELECT MAX(UPDATE_TIME)
     FROM information_schema.tables
     WHERE table_schema = 'shopping_website_db'),
     
    -- Get the earliest creation time among all tables in the database
    (SELECT MIN(CREATE_TIME)
     FROM information_schema.tables
     WHERE table_schema = 'shopping_website_db')
) AS data_load_time_diff;

