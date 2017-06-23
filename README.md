# MassQuery
Query multiple SQL Server databases simultaneously and display the results in a grid. Includes SQL syntax checking, highlighting, and generating lists of machines from Active Directory.

# Features
* Layout familiar to SSMS users
* Syntax Highlighting using [FastColoredTextBox](https://github.com/PavelTorgashov/FastColoredTextBox)
* SQL syntax checking using Microsoft.SqlServer.TransactSql.ScriptDom
* Multithreaded queries for fast results
* Dynamic gridview displays results from all machines, with Hostname column added for clarity
* Import list of machines from a text file
* Retrieve list of machines from Active directory using LDAP url
* Filter list of machines with Regex
