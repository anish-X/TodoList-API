TodoList API

This project is a RESTful API for managing to-do lists. It includes user authentication using JSON Web Tokens (JWT), schema design, CRUD operations, and secure handling of user data. The API is designed with scalability, security, and usability in mind.
Features

    User Authentication: Secure user registration and login using JWT.
    CRUD Operations: Create, Read, Update, and Delete to-do items.
    Role-Based Access Control: Differentiate access between admin and regular users.
    Data Validation: Ensure data integrity and validity.
    Error Handling: Comprehensive error responses for client and server errors.
    Security Measures: Password hashing, input validation, and protection against common vulnerabilities.

Technologies Used

    Framework: ASP.NET Core
    Language: C#
    Authentication: JSON Web Tokens (JWT)
    Database: Entity Framework Core (database provider not specified)

Getting Started
Prerequisites

    .NET SDK installed
    Database system (e.g., SQL Server, SQLite)

Installation

    Clone the repository:

git clone https://github.com/anish-X/TodoList-API.git
cd TodoList-API

Set up the database:

    Configure the connection string in appsettings.json.

    Apply migrations to set up the database schema:

    dotnet ef database update

Run the application:

    dotnet run

Usage

    Register a new user: Send a POST request to /api/auth/register with user details.
    Login: POST to /api/auth/login to receive a JWT token.
    Access to-do items: Use the JWT token in the Authorization header to access protected endpoints for managing to-do items.
    
PROJECT LINK: https://roadmap.sh/projects/todo-list-api

Contributing

Contributions are welcome! Please fork the repository and submit a pull request.
License

This project is licensed under the MIT License.
