# AppointmentsSystem

Academic ASP.NET Core API project for managing patients, doctors and appointments.

The project was created as part of university coursework and focuses on backend architecture, API design, authentication, CQRS and testing.

## Technologies

- C#
- ASP.NET Core
- Clean Architecture
- MediatR / CQRS
- Entity Framework Core
- JWT-based authentication
- Swagger
- Razor Pages
- NUnit
- gRPC module

## Features

- Managing patients, doctors and appointments
- REST API endpoints
- CQRS pattern with MediatR
- JWT-based authentication
- Entity Framework Core data access
- Swagger API documentation
- Razor Pages frontend module
- Unit tests with NUnit
- Basic gRPC module

## Project structure

The solution follows a Clean Architecture approach and separates the main responsibilities into different layers:

- `Appointments.Domain` - core business entities
- `Appointments.Application` - application logic, commands, queries and handlers
- `Appointments.Infrastructure` - data access and infrastructure-related services
- `Appointments.API` - REST API endpoints and application entry point
- `Appointments.Razor` - Razor Pages frontend module
- `Appointments.gRPC` - basic gRPC module
- `Appointments.Tests` - unit tests for selected application logic
  
## Project type

Academic project developed as part of software engineering coursework.

## Status

Completed.
