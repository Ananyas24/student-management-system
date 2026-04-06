Student Management API
Project Overview

Student Management API is a RESTful Web API built with .NET 8. It allows you to manage student records with full CRUD operations. The API is secured using JWT authentication, includes global exception handling, and comes with Swagger documentation for easy testing. The project follows a layered architecture (Controller → Service → Repository) to keep the code organized and maintainable.

Tech Stack
Backend: .NET 8 Web API
Database: SQL Server
ORM: Entity Framework Core
Authentication: JWT (JSON Web Tokens)
Logging: Serilog
API Documentation: Swagger
Features
Add, view, update, and delete students
Secure endpoints using JWT
Global exception handling middleware
Clear layered architecture
Swagger-based API documentation and testing
Database Schema

Student Table

Column	Type
Id	int (Primary Key)
Name	nvarchar(100)
Email	nvarchar(100)
Age	int
Course	nvarchar(100)
CreatedDate	datetime

Setup Instructions
Clone the repository
git clone https://github.com/<your-username>/<repo-name>.git

Navigate to the project folder
cd StudentManagementAPI

Update the connection string
Edit appsettings.json with your SQL Server details.
Apply database migrations
dotnet ef database update

Run the application
dotnet run

Test APIs using Swagger
Open in your browser:
https://localhost:<port>/swagger

Authentication

Login Endpoint: POST /api/auth/login

Request Body:

{
  "username": "admin",
  "password": "1234"
}


Usage:
Use the returned JWT token for protected routes:

Authorization: Bearer <token>

API Endpoints
Method	Endpoint	Description
GET	/api/students	Get all students
GET	/api/students/{id}	Get student by ID
POST	/api/students	Add new student
PUT	/api/students/{id}	Update student
DELETE	/api/students/{id}	Delete student



Notes
Ensure the backend is running before testing APIs.
Swagger provides an interactive interface for testing endpoints.
Default admin credentials:
Username: admin
Password: 1234
Username: admin
Password: 1234
