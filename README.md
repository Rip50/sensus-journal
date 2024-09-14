# Summary
<b>SensusJournal</b> is REST API service for tracking and sharing emotional experiences. Built with .NET 8, EF Core, and Redis, it allows patients to log emotions and securely share insights with psychologists via shareable links. Designed with a microservice architecture in mind for scalability and flexibility.

# Architecture
The solution follows Clean Architecture principles to ensure separation of concerns and flexibility for future modifications. This architecture pattern allows for the scalability and maintainability of the codebase, especially in a microservices-driven environment.
## Layers
- Domain Layer (SensusJournal.Core): Contains domain entities.
- Application Layer (SensusJournal.Application): Holds the service interfaces, DTOs, and application logic.
- Infrastructure Layer (SensusJournal.Infra): Handles database, caching, and external service access.
- Presentation Layer (SensusJournal.API): Exposes the API endpoints through REST.

# Technologies
- ASP.NET Core 8
- EF Core 8
- PostreSQL
- xUnit
- Redis
