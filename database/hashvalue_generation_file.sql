-- ************************************************************************************
--  File:        sync_expected_with_found.sql
--  Description: This script clears the 'expected_values' table and repopulates it
--               from the 'found_values' table. Typically used in checksum or 
--               data verification scenarios where we want the expected dataset 
--               to match the most recent "found" dataset.
--
--  Usage:       Execute in the target database where 'expected_values' and 
--               'found_values' tables exist. 
--               Example:
--                   mysql -u <user> -p <database> < sync_expected_with_found.sql
--
--  Author:      Shreya S G
--  Created On:  2025-08-08
--  Version:     1.0
--
--  License:     Copyright (c) 2025 AscendionQA
--               Licensed under the Apache License, Version 2.0 (the "License");
--               you may not use this file except in compliance with the License.
--               You may obtain a copy of the License at
--
--                   http://www.apache.org/licenses/LICENSE-2.0
--
--               Unless required by applicable law or agreed to in writing, software
--               distributed under the License is distributed on an "AS IS" BASIS,
--               WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
--               See the License for the specific language governing permissions
--               and limitations under the License.
-- ************************************************************************************

-- Step 1: Remove all existing rows from expected_values
TRUNCATE TABLE expected_values;

-- Step 2: Repopulate expected_values with the latest data from found_values
INSERT INTO expected_values SELECT * FROM found_values;