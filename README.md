#Extinct Animals API – Backend

Backend developed in .NET 9 that consumes a public API of extinct animals and exposes its own REST endpoints following Clean Architecture, SOLID principles, and production-ready design practices.

#Tech Stack

.NET 9
ASP.NET Core Web API
HttpClientFactory
System.Text.Json
Swagger / OpenAPI
Dependency Injection
Clean Architecture

#Architecture

The solution is structured using a layered architecture, clearly separating responsibilities and decoupling the domain from external concerns.

src/
 ├── ExtinctAnimals.Api            → Presentation layer (Controllers, Swagger)
 ├── ExtinctAnimals.Application    → Application logic, use cases, DTOs
 ├── ExtinctAnimals.Domain         → Domain entities
 └── ExtinctAnimals.Infrastructure → External API access, HttpClients, Repositories

#Layers overview
Domain

Contains domain entities
No dependencies on other layers or frameworks

Application

Defines interfaces, services, and DTOs
Orchestrates use cases
Independent from infrastructure details

Infrastructure

Handles communication with the external API
Contains external DTOs and mappings
Applies an Anti-Corruption Layer to protect the domain

API

#Exposes REST endpoints
Configures Swagger, DI, and middleware
This backend consumes the following public API:

https://extinct-api.herokuapp.com/api/v1/animal/

Characteristics:

Returns extinct animals (random or by quantity)
Responses are wrapped in a { status, data } object
The external contract is adapted, not exposed directly.

#Available Endpoints
Get a random extinct animal
GET /api/animals/random

Get a list of extinct animals
GET /api/animals?count=10
count accepts values between 1 and 804.

#Key Design Decisions

HttpClientFactory to avoid socket exhaustion and improve testability
Clear separation between external DTOs and domain models
Explicit wrapper DTO to match the real external JSON structure
Manual mapping (no AutoMapper) for clarity and control
Validation and business rules in the Application layer
Domain completely framework-agnostic

#Swagger / OpenAPI

Swagger is enabled in development environments:
https://localhost:{port}/swagger

#Running the Project

Clone the repository
Restore dependencies
Run the API project

dotnet restore
dotnet run --project ExtinctAnimals.Api

#Planned improvements:

In-memory caching
Advanced error handling
Unit tests
Angular frontend (standalone)
Azure deployment
