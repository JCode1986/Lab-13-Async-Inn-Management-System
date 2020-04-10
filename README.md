# Project Async Inn

---

## Web Application

---

## Tools Used
Microsoft Visual Studio Community 2019

- C#
- ASP.Net Core
- Entity Framework
- MVC

---

## Recent Updates

---

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://github.com/JCode1986/Lab-13-Async-Inn-Management-System.git
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the AmandaFE subdirectory at the root of the repository.
```
cd YourRepo/YourProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the /AmandaFE/AmandaFE/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd YourRepo/YourProject
dotnet run
```

---

## Usage


### Overview of Recent Posts
![ERD](assets/ERD.png)

### Data from Postman
![ERD](assets/hotels.png)

![ERD](assets/hotelID.png)

---

## Model Properties and Requirements

---

## Change Log
* 1.2 - Default data seeded for CRUD operations 04/06/2020
* 1.1 - Database added 04/03/2020

---

## Authors
* Brandon Johnson
* Joseph Hangarter

---


