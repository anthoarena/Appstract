# Appstract
Code Assignment
Implementation with .net core and mssql
Solution is build with Entity framework core and code first approach based on Onion architecture.
Due to the size of the assignment part of the solution has been kept simple and major improvement could be implemented.

The solution has a backend, frontend part, unit test project and a console application to generate serial number and export PDF.
Frontend part has been implemented  as a simple website. 

Backend has 3 folders
- webapi : contains WebApi Controller 
- core   : class library contains Model, Migration, Repository implementation
- infrastructure : class library contains DTO, interfaces


Unit Test project with test toward the data validation and rules validation of the contest

SEO Compliant : The website is really simple to make it SEO compliant first I could use bootstrap to create a responsive UI that can be used accross different platform, use meta data, use key words in Title, or other key html tag


Step - 
Cloned the repo
Change All Connection string : StartUp and DbContext file
Run the EF core migration tools in dev powershell 
the command is =>  dotnet ef database update
this should create the database and tables

After creating the database and table 
Run the AcmeInitTool console app
--> Generate serial number
I used Guid as serial number type, I beleived to be a good choice 
- secure : it will be hard to guess any serial number
- no impact on performance
--> Export PDF
you can generate a pdf file by giving a directory path 

To run the solution 
Start the BackEnd
Start the FrontEnd

You can create new contestant
and you can access the list of contestant

Unit test project contains some test of the contest data and rules.

Disclaimer, due to time spend on all different parts the Website looks really ugly (no bootstrap, no css,...),
 only a few unit test have been implemented, and same about the backend, 
I look forward to discuss it with you.