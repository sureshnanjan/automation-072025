# **Shopping Website Database**
A sample shopping website database schema and test suite designed for demonstration, testing, and educational purposes.

**About This Project**
This repository contains the database schema, data dumps, checksum-based integrity tests, and optional stored procedures for a simulated shopping website backend. It serves as a practical example to test applications, verify database integrity, and explore relational database design and testing.

**Origin and Purpose**
The database schema and data were created and maintained by Elangovan R specifically for educational and demonstration use cases around shopping platforms.

The dataset and schema are fictional and designed to cover common e-commerce data structures, including users, products, orders, suppliers, and related entities.

**Prerequisites**
MySQL Server version 5.7 or higher (InnoDB support recommended)

**User privileges:**

SELECT, INSERT, UPDATE, DELETE
CREATE, DROP, ALTER
REFERENCES, INDEX
LOCK TABLES
EXECUTE (for stored procedures)
CREATE VIEW (for views)

**Installation Instructions**
1.Download the repository
2.Change directory to the repository

**Then run**

`mysql < shopping_website.sql`

**Run this command to generate hash values for md5 and sha**

For md5 = `mysql < generate_crc_baseline.sql`
For sha = `mysql < generate_sha_baseline.sql`

**Run this command to Testing the installation**

For md5 = `mysql < test_shopping_website_md5.sql`
For sha = `mysql < test_shopping_website_sha.sql`


**Output will be like this**


```text
+----------------------+
| INFO                 |
+----------------------+
| TESTING INSTALLATION |
+----------------------+

+---------------------+------------------+----------------------------------+
| table_name          | expected_records | expected_crc                     |
+---------------------+------------------+----------------------------------+
| address             |               50 | 3038773c07ca3defe8c54f669b8d13d1 |
| brand               |               50 | b8c8bf5170f3861d522b08527cd631c4 |
| colour              |                8 | e594800bcb1df8e984d9f49555785a21 |
| customer_order      |               50 | 7b54d013f51057c3e42169172e6fd743 |
| customer_order_line |               50 | 4171d845d7c23844f4ff0308965bde88 |
| product             |               50 | 9037f99f0f70faa988a403e9ef9a20f6 |
| product_category    |                5 | 80108f78ff05afc73569418e1d3579dc |
| size                |                7 | db3636d58cae2af350d814cdb4c26a8d |
| supplier            |                6 | 1ed270e2786b9d5ea375e692964009f0 |
| supplier_order      |               50 | b4069f32a198d96e3855edd43eb191bf |
| supplier_order_line |               50 | 515e4a3d62a5312e8c0bc354bef79856 |
| user_account        |               50 | 033ec9496994f252720e16572d9ec4e3 |
| user_address        |               50 | 4a3c52fe92ed7f2cdefdabadad1088c8 |
+---------------------+------------------+----------------------------------+

+---------------------+---------------+----------------------------------+
| table_name          | found_records | found_crc                        |
+---------------------+---------------+----------------------------------+
| address             |            50 | 3038773c07ca3defe8c54f669b8d13d1 |
| brand               |            50 | b8c8bf5170f3861d522b08527cd631c4 |
| colour              |             8 | e594800bcb1df8e984d9f49555785a21 |
| customer_order      |            50 | 7b54d013f51057c3e42169172e6fd743 |
| customer_order_line |            50 | 4171d845d7c23844f4ff0308965bde88 |
| product             |            50 | 9037f99f0f70faa988a403e9ef9a20f6 |
| product_category    |             5 | 80108f78ff05afc73569418e1d3579dc |
| size                |             7 | db3636d58cae2af350d814cdb4c26a8d |
| supplier            |             6 | 1ed270e2786b9d5ea375e692964009f0 |
| supplier_order      |            50 | b4069f32a198d96e3855edd43eb191bf |
| supplier_order_line |            50 | 515e4a3d62a5312e8c0bc354bef79856 |
| user_account        |            50 | 033ec9496994f252720e16572d9ec4e3 |
| user_address        |            50 | 4a3c52fe92ed7f2cdefdabadad1088c8 |
+---------------------+---------------+----------------------------------+

+---------------------+---------------+-----------+
| table_name          | records_match | crc_match |
+---------------------+---------------+-----------+
| address             | OK            | ok        |
| brand               | OK            | ok        |
| colour              | OK            | ok        |
| customer_order      | OK            | ok        |
| customer_order_line | OK            | ok        |
| product             | OK            | ok        |
| product_category    | OK            | ok        |
| size                | OK            | ok        |
| supplier            | OK            | ok        |
| supplier_order      | OK            | ok        |
| supplier_order_line | OK            | ok        |
| user_account        | OK            | ok        |
| user_address        | OK            | ok        |
+---------------------+---------------+-----------+
```

**Usage**

*Use this database to practice SQL queries, application integration, and data validation.
*Extend the schema with new tables or fields as your project requires.
*Modify or add stored procedures and verification routines as needed.

**Disclaimer**
All data in this database is completely fictional and created solely for learning and testing purposes.

Any resemblance to real persons, companies, or products is purely coincidental.

**License**
This project is licensed under the
Creative Commons Attribution-Share Alike 3.0 Unported License (CC BY-SA 3.0).

To view the full license, visit:
http://creativecommons.org/licenses/by-sa/3.0/

Or send correspondence to:
Creative Commons, 171 Second Street, Suite 300, San Francisco, California, 94105, USA.



