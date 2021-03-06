[![Build Status](https://dev.azure.com/robertlarue/MassQuery/_apis/build/status/MassQuery-.NET%20Desktop-CI?branchName=master)](https://dev.azure.com/robertlarue/MassQuery/_build/latest?definitionId=2&branchName=master)

# MassQuery
Query multiple SQL Server databases simultaneously and display the results in a grid. Includes SQL syntax checking, highlighting, and generating lists of machines from Active Directory.

![MassQuery Query Page Screenshot](/MassQuery_Query_Page.png?raw=true)

![MassQuery Machines Page Screenshot](/MassQuery_Machines_Page.png?raw=true)

# Features
* Layout familiar to SSMS users
* Syntax Highlighting using [FastColoredTextBox](https://github.com/PavelTorgashov/FastColoredTextBox)
* SQL syntax checking using Microsoft.SqlServer.TransactSql.ScriptDom
* Multithreaded queries for fast results
* Dynamic gridview displays results from all machines, with Hostname column added for clarity
* Import list of machines from a text file
* Retrieve list of machines from Active directory using LDAP url
* Filter list of machines with Regex
* Save query templates to central repository
* Save query results to CSV file
* Use the same SQL server credentials across all machines
* Retrieve SQL server credentials from a connection string with an xml file stored on the machine
* Connection strings are located using the UNC path to the file and the xpath within the file
