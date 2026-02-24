# TicketsManagement

## Project Description
This project is a modern enterprise .NET application designed to manage service requests (tickets) and users. The system allows users to list, create, update, and delete tickets and user profiles. It serves as a demonstration of a robust, scalable system built using clean layered architecture, Dependency Injection, Minimal APIs, Entity Framework Core with SQL Server, Cosmos DB integration, and a Blazor WebAssembly front-end.

## Architecture Overview
The solution is built using a clean, multi-project enterprise architecture to ensure separation of concerns. The layers are structured as follows:

* **ServiceRequest.Domain:** The core of the application. It contains the business entities (Tickets, User) and enums. This layer is completely independent and has no dependencies on other projects or external frameworks.
* **ServiceRequest.Application:** Contains the application contracts. It defines the Data Transfer Objects (DTOs), validation logic, and interfaces for both repositories and services (e.g., `ITicketsRepository`, `IUserService`).
* **ServiceRequest.Infrastructure:** Handles data persistence and external concerns. It implements the repository interfaces using Entity Framework Core for SQL Server operations and includes the database migrations. It also contains the configuration for Cosmos DB.
* **ServiceRequest.Service:** The business logic layer. It implements the service interfaces defined in the Application layer, orchestrating data between the controllers and the repositories.
* **ServiceRequest.API:** The presentation layer for the backend. It uses Minimal APIs to expose REST endpoints (GET, POST, PUT, DELETE), handles Dependency Injection (DI) registration, and provides Swagger for API documentation and testing.
* **ServiceRequest.Client:** The front-end application built with Blazor WebAssembly. It consumes the REST API to display, insert, update, and delete data through a user interface.

## SQL Configuration

### SQL Server Configuration
The relational database is handled by SQL Server. The connection string must be configured in the `appsettings.json` file located in the `ServiceRequest.API` project under the `ConnectionStrings` section:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=TicketsManagementDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
}
```
## Migrations

Entity Framework Core is used to manage the SQL Server database schema. To apply the latest migrations and create the database, open a terminal at the root of the solution and execute the following command:

```bash
dotnet ef database update --project src/ServiceRequest.Infrastructure --startup-project src/ServiceRequest.API
```
If you need to create a new migration after modifying your domain entities, run:

```bash
dotnet ef migrations add "MigrationName" --project src/ServiceRequest.Infrastructure --startup-project src/ServiceRequest.API
```

## How to run the API

To start the backend Minimal API and access the Swagger documentation, follow these steps:
- Open a terminal or command prompt.
- Navigate to the API project directory:
```bash
cd src/ServiceRequest.API
```
- Restore the dependencies:
```bash
dotnet restore
```
- Run the project:
```bash
dotnet run
```
- Once the application is running, open your web browser and navigate to the local URL provided in the console output, appending /swagger to the URL to view and test the API endpoints.

## How to run the Client
To start the Blazor WebAssembly front-end application, follow these steps:

- Open a new terminal or command prompt (keep the API running in the first terminal).
- Navigate to the Client project directory:
```bash
cd src/ServiceRequest.Client
```
- Restore the dependencies:
```bash
dotnet restore
```
- Run the project:
```bash
dotnet run
```
- Open your web browser and navigate to the local URL provided in the console output to interact with the user interface. Ensure the API is running simultaneously so the client can fetch and modify data successfully.

## One Drive Link
https://1drv.ms/f/c/b784f24557a4bf9d/IgCtQWVf3FGIRIq6yFIOY7avAc1ENv2ZdB7iK4RwL6OB44U?e=NlErgo
