# iConduct API

## Description

The API provides two main endpoints for working with employee data:
- **GetEmployeeById** - retrieve an employee with their subordinates in a tree structure
- **EnableEmployee** - change the Enable flag for an employee

## Requirements

- .NET 10
- MS SQL 2022

## Installation

### 1. Clone the repository

git clone https://github.com/Alex-Reef/iConduct-Test.git
cd iConduct_TEST

### 2. Create a database

Create a database in MS SQL and execute the following SQL script:

\\\sql
CREATE TABLE Employee (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    ManagerId INT NULL,
    Enable BIT NOT NULL DEFAULT(1),

    CONSTRAINT FK_Employee_Manager 
        FOREIGN KEY (ManagerId) REFERENCES Employee(ID)
);

INSERT INTO Employee(Name, ManagerId) 
    VALUES  
        ('Andrey', NULL),
        ('Alexey', 2),
        ('Roman', 2)
\\\

### 3. Configure the connection

Update \appsettings.json\ with your MS SQL connection string:

\\\json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=iconduct;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
\\\

### 4. Run the application

\\\bash
dotnet run
\\\

The API will be available at: \https://localhost:5000\ or \http://localhost:5001\

## ?? API Endpoints

#### 1. Get an employee

\\\
Method: GET
URL: https://localhost:5000/api/employee/1
Headers:
  - Accept: application/json
\\\

#### 2. Update Enable status

\\\
Method: PUT
URL: https://localhost:5000/api/employee/2/enable
Headers:
  - Content-Type: application/json
Body (raw JSON):
  {
    \"enable\": false
  }
\\\

## Data Structure

### EmployeeDto (API response)

\\\json
{
  \"id\": 1,
  \"name\": \"Andrey\",
  \"managerId\": null,
  \"enable\": true
}
\\\

### UpdateEmployeeRequest (request body)

\\\json
{
  \"enable\": true
}
\\\
