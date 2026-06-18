# Expense Tracker (Full-Stack)

A professional expense management application built with an **ASP.NET Core** backend and an **Angular** frontend.

## Architecture
- **Backend:** ASP.NET Core Web API (C#, Entity Framework Core, SQL Server).
- **Frontend:** Angular (TypeScript, RxJS, Angular Services).

## Features
- **Authentication:** Secure user registration and login flow.
- **Data Persistence:** Expense data is managed via a .NET API and stored in a database.
- **Full-Stack Integration:** Angular `HttpClient` services communicate with .NET API controllers.

## Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Node.js & Angular CLI

### Backend (.NET)
1. Navigate to the `webapp/` directory.
2. Run the server: `dotnet run`
3. The API will be available at `https://localhost:5001/`

### Frontend (Angular)
1. Navigate to the `client/` directory.
2. Install dependencies: `npm install`
3. Run the development server: `ng serve`
4. Navigate to `http://localhost:4200/`

## How it works
This application utilizes a decoupled architecture where the Angular frontend consumes RESTful API endpoints exposed by the .NET backend. State management is handled through Angular Services, and data integrity is maintained via Entity Framework Core on the server side.
