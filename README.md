# TimeTracker

This small application will enable a law firm to easily track times spent on individual cases.

## Setup

### 1. Create the solution

     dotnet new sln -n TimeTracker

### 2. Create the Web API project

     dotnet new webapi -n Backend

### 3. Register the project in the solution

     dotnet sln add Backend/Backend.csproj

### 4. Add dependencies in _Backend_

     dotnet add package Microsoft.EntityFrameworkCore.Sqlite
     dotnet add package Microsoft.EntityFrameworkCore.Design

### Create .gitignore+

     dotnet new gitignore

### Run Command

    dotnet run

## ERM

![ERM of the Time Tracker](/Docs/ERM.drawio.png)

## Database

### Install EF Core CLI

     dotnet tool install --global dotnet-ef

### Create and run initial migration

     dotnet ef migrations add InitialCreate
     dotnet ef database update
