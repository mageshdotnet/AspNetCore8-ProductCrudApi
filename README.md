# ProductHub API (.NET 8)

A clean and modern Product Management CRUD API built using **ASP.NET Core 8** and **SQL Server**. Ideal for showcasing backend skills like clean architecture, API testing, and database handling.

## 🔥 Features
- Full CRUD operations (Create, Read, Update, Delete)
- Search by product name
- Sort by name (ASC/DESC)
- Pagination support
- Repository + Unit of Work Pattern
- DTO Mapping
- Swagger & Postman support

## 🛠 Tech Stack
- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Swagger for API docs
- Postman for testing

## 🚀 Getting Started

1. Clone the repository
2. Open the solution in Visual Studio 2022+
3. Update your `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Your_Db_Name;Trusted_Connection=True;"
}
