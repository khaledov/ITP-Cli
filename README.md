# ITP-Cli
Creating custom command client that parse tsv (Tab Separated Value) file 
---
## Problem to solve

Write a console application which reads some input data, transforms the data
according to the following instructions and finally outputs the results to console.

The application should support the following command line arguments (only the first
one is mandatory):

--file <path>             full path to the input file
--sortByStartDate         sort results by column "Start date" in ascending order
--project <project id>    filter results by column "Project"

The following requirements define the program functionality
and refer to the data sample below (between and excluding the lines starting with "***"):

* Input data is tab-separated UTF-8 text with a header row.

* It only includes the columns listed below.

* Dates (Start date) should conform to the format yyyy-mm-dd hh:mm:ss.sss

* Money (Savings amount) values should conform be numbers with a point as the decimal separator

* Columns "Savings amount" and "Currency" can have missing values denoted
as NULL. Those should be printed as empty strings.

* Column "Complexity" has a certain set of values (Simple, Moderate, Hazardous).
The program should report an error if a source value differs from those three
but keep in mind that more options (e.g. "VeryHigh") can be added in the future.

* The output should also have a header line.

* Lines that are empty or start with comment mark # are skipped.

* Order (but not names) of columns might be changed in future.

* In case of an invalid source value (in a date, money or Complexity column) a
descriptive error message should be printed to console and the program terminated.

   
```python
***********************************************************************************************************************************************
# Input file contents are between the two lines marked with stars
Project	Description	Start date	Category	Responsible	Savings amount	Currency	Complexity
2	Harmonize Lactobacillus acidophilus sourcing	2014-01-01 00:00:00.000	Dairy	Daisy Milks	NULL	NULL	Simple
3	Substitute Crème fraîche with evaporated milk in ice-cream products	2013-01-01 00:00:00.000	Dairy	Daisy Milks	141415.942696	EUR	Moderate
3	Substitute Crème fraîche with evaporated milk in ice-cream products	2013-01-01 00:00:00.000	Dairy	Daisy Milks	141415.942696	EUR	Moderate
4	Decrease production related non-categorized side costs	2013-01-01 00:00:00.000	Dairy	Daisy Milks	11689.322459	EUR	Hazardous
4	Decrease production related non-categorized side costs	2013-01-01 00:00:00.000	Dairy	Daisy Milks	11689.322459	EUR	Hazardous
5	Stop using Kryptonite in production	2013-04-01 00:00:00.000	Dairy	Clark Kent	NULL	NULL	Moderate
6	Black and white logo paper	2012-06-01 00:00:00.000	Office supplies	Clark Kent	4880.199567	EUR	Simple
6	Black and white logo paper	2012-06-01 00:00:00.000	Office supplies	Clark Kent	4880.199567	EUR	Simple
***********************************************************************************************************************************************
```
## How to run
Allocate itp.exe file inside ITP_Cli.ShellCmd and run from there windows command prompt and run this command
```shell
$ itp --file "tsv file path" --sortByStartDate --project [any number]
```
