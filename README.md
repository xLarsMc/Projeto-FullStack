# Projeto-FullStack

.NET 8 REST API with a layered architecture, automated tests and CI. Covers user registration with validation, password hashing and localised error messages.

## Structure (`Backend/Solution`)

| Project | Role |
|---|---|
| `Solution.API` | Controllers, filters and exception-handling middleware |
| `Solution.Application` | Use cases, AutoMapper profiles, password encryption service |
| `Solution.Domain` | Entities and repository contracts |
| `Solution.Infraestructure` | EF Core context, repositories, migrations (FluentMigrator / Dapper) on PostgreSQL |
| `Solution.Comunication` | Request and response contracts |
| `Solution.Exceptions` | Custom exceptions and pt-BR resource messages |
| `Validators.Test`, `UseCases.Test`, `WebApi.Test` | Unit tests and integration tests (`WebApplicationFactory`) |

## Highlights

- Input validation with **FluentValidation**, error messages in resource files (pt-BR).
- Centralised exception handling through filters.
- Unit tests (xUnit) and end-to-end API tests with `WebApplicationFactory`.
- GitHub Actions workflow with **SonarCloud** analysis.
- Dockerfile for the API.

## Stack

.NET 8, ASP.NET Core, PostgreSQL (Npgsql), Dapper, FluentMigrator, FluentValidation, AutoMapper, xUnit.

## Running locally

```bash
cd Backend/Solution
dotnet test
dotnet run --project Solution.API
```

Configure the PostgreSQL connection string in `Solution.API/appsettings.Development.json` first.
