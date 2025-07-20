# User Management System (.NET MVC)

## Tech Stack
- ASP.NET MVC 
- Entity Framework
- SQL Server (MSSQL)
- Vanilla JavaScript, HTML/CSS

## Features
- Create, Read, Update, Delete (CRUD) Users
- Search by Name, Email
- Filter by Status (Active/Inactive)
- Sort by Age (Asc/Desc)

## Setup Instructions

1. Clone this repository: git clone https://github.com/rezwan07/UserManagementSystem.git

2. Open the solution in Visual Studio.

3. Update the connection string in `appsettings.json` or `web.config` as needed.

4. Run the following commands in **Package Manager Console**:

Update-Database

5. Press `F5` or `Ctrl+F5` to run.

## 🗃️ Database Schema

- Table: `Users`
| Column     | Type     | Description          |
|------------|----------|----------------------|
| Id         | int      | Primary Key          |
| Name       | string   | User's full name     |
| Email      | string   | Unique email         |
| Age        | int      | Age                  |
| Status     | string   | Active / Inactive    |
