# Cherry Burn

This is a full-stack web application built with a **.NET (C#)** backend, a **React** frontend, and a **PostgreSQL** database. It follows a modern architecture for scalable and maintainable development.

## 📁 Project Structure

- **Backend**: ASP .NET Core Web API (C#)
- **Frontend**: React (with Vite)
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core
- **API Communication**: REST (JSON)
- **Containerization**: Docker

---

## Pre-requisites

- [.NET 6+ SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js (v18+)](https://nodejs.org/)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) *(optional)*

---

## Getting started 

1. Run a local instance of the database

```bash
docker-compose up -d cherry-burn
```

2. Update PostgreSQL connections string in `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=your_db;Username=your_user;Password=your_password"
}
```

3. Run the application backend (build + run)
```bash
dotnet run
```