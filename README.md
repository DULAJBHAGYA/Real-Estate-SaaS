# Real Estate SaaS - Clean Architecture

A comprehensive Real Estate SaaS application built with .NET 9, following Clean Architecture (Onion Architecture) principles.

## Architecture Overview

This project follows Clean Architecture with the following layers:

- **Domain Layer** (`RealEstate.Domain`): Contains entities, enums, and domain interfaces
- **Application Layer** (`RealEstate.Application`): Contains business logic, DTOs, commands, queries, and handlers (CQRS pattern)
- **Infrastructure Layer** (`RealEstate.Infrastructure`): Contains external service implementations and dependency injection configuration
- **Persistence Layer** (`RealEstate.Persistence`): Contains database context and repository implementations
- **API Layer** (`RealEstateAPI`): Contains controllers and API configuration

## Features

### Core Features
- **User Management**: Registration, login, role-based access control
- **Property Listings**: CRUD operations for properties with images
- **Search & Filter**: Advanced property search with multiple criteria
- **Appointments**: Booking system for property visits
- **Admin Dashboard**: Management interface for users and properties

### Security Features
- JWT Authentication
- Role-based authorization (Admin, Agent, User)
- Password hashing and validation
- Input validation and sanitization
- HTTPS/TLS enforcement

### Technical Features
- Clean Architecture (Onion Architecture)
- CQRS pattern with MediatR
- Repository pattern with Unit of Work
- AutoMapper for object mapping
- Entity Framework Core with MySQL
- Serilog for structured logging
- Swagger/OpenAPI documentation

## Database

The application uses MySQL database with the following connection string:
```
Server=localhost;Database=RealEstateSaaS;Uid=root;Pwd=dulaj1998;
```

## Getting Started

### Prerequisites
- .NET 9 SDK
- MySQL Server
- Visual Studio 2022 or VS Code

### Installation

1. Clone the repository
2. Navigate to the project directory
3. Restore packages:
   ```bash
   dotnet restore
   ```

4. Update the connection string in `appsettings.json` if needed

5. Build the solution:
   ```bash
   dotnet build
   ```

6. Run the application:
   ```bash
   dotnet run --project RealEstateAPI
   ```

### API Endpoints

The API will be available at `https://localhost:7000` (or the configured port).

#### Authentication
- `POST /api/auth/register` - User registration
- `POST /api/auth/login` - User login

#### Properties
- `GET /api/properties` - Get all properties (with search/filter)
- `GET /api/properties/{id}` - Get property by ID
- `POST /api/properties` - Create property (requires authentication)
- `PUT /api/properties/{id}` - Update property (requires authentication)
- `DELETE /api/properties/{id}` - Delete property (requires authentication)

### Swagger Documentation

Once the application is running, you can access the Swagger UI at:
`https://localhost:7000/swagger`

## Project Structure

```
Real-Estate-SaaS/
├── RealEstate.Domain/           # Domain layer
│   ├── Entities/               # Domain entities
│   ├── Enums/                  # Domain enums
│   └── Interfaces/             # Repository interfaces
├── RealEstate.Application/      # Application layer
│   ├── Commands/               # CQRS commands
│   ├── Queries/                # CQRS queries
│   ├── Handlers/               # Command/Query handlers
│   ├── DTOs/                   # Data Transfer Objects
│   ├── Mappings/               # AutoMapper profiles
│   └── Common/                 # Common utilities
├── RealEstate.Infrastructure/   # Infrastructure layer
│   ├── Extensions/             # Service collection extensions
│   └── Services/               # External service implementations
├── RealEstate.Persistence/      # Persistence layer
│   ├── Context/                # DbContext
│   └── Repositories/           # Repository implementations
└── RealEstateAPI/              # API layer
    ├── Controllers/            # API controllers
    └── Program.cs              # Application entry point
```

## Technologies Used

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **MySQL** (Pomelo.EntityFrameworkCore.MySql)
- **ASP.NET Identity**
- **JWT Authentication**
- **MediatR** (CQRS)
- **AutoMapper**
- **FluentValidation**
- **Serilog**
- **Swagger/OpenAPI**

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is licensed under the MIT License.