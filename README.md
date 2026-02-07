# NZWalks API 🌍🚶‍♂️

NZWalks API is a **learning-focused ASP.NET Core Web API project** built to understand backend fundamentals such as **REST APIs**, **Entity Framework Core**, **SQL Server**, and **CRUD operations**.

This API manages walking routes along with their associated **Regions** and **Difficulty levels**.

---

## 🚀 Features

- RESTful API using ASP.NET Core
- Entity Framework Core with SQL Server
- CRUD operations for Regions
- GUID-based Primary and Foreign Keys
- Dependency Injection
- Swagger UI for API testing
- Clean project structure following best practices

---

## 🛠 Tech Stack

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server (LocalDB)  
- C#  
- Swagger / OpenAPI  

---

## 📂 Project Structure

NzWalks.API
│
├── Controllers
│ └── RegionsController.cs
│
├── Data
│ └── NZWalksDbContext.cs
│
├── Models
│ └── Domain
│ ├── Region.cs
│ ├── Walk.cs
│ └── Difficulty.cs
│
├── appsettings.json
├── Program.cs
└── README.md


## 📌 API Endpoints

### Get All Regions

### Get Region By ID


> `id` must be a valid **GUID**

---

## ⚙️ Database Configuration

Connection string is configured in `appsettings.json`:

```json
"ConnectionStrings": {
  "NZWalksConnectionString": "Server=(localdb)\\MSSQLLocalDB; Database=NZWalks; Trusted_Connection=True; TrustServerCertificate=True"
}

Add-Migration InitialCreate
Update-Database
