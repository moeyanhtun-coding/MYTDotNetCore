# 🚀 .NET Multi-Architecture Project

This repository demonstrates **multiple .NET application architectures and data access technologies** in a single solution. It is designed for **learning, portfolio use, interviews, and real-world reference**.

The project includes:

* ✅ **.NET Console Application (CRUD)**
* ✅ **ASP.NET Core Web API (CRUD)**
* ✅ **ASP.NET Core MVC Application**
* ✅ **Minimal API**
* ✅ **Dependency Injection (DI)**
* ✅ **ADO.NET**
* ✅ **Dapper**
* ✅ **Entity Framework Core (EF Core)**
* ✅ **LINQ**
* ✅ **Charts & Data Visualization**

---

## 📌 Project Purpose

The main goal of this project is to:

* Understand **different .NET application types**
* Compare **data access approaches** (ADO.NET, Dapper, EF Core)
* Apply **clean architecture principles**
* Practice **Dependency Injection**
* Build **CRUD operations** consistently across architectures
* Demonstrate **data visualization using charts**

This project is ideal for:

* Students learning .NET
* Portfolio demonstration
* Interview preparation
* Backend + Full-stack practice

---

## 🧱 Solution Architecture

This project follows **Clean Architecture principles**, ensuring the system is maintainable, testable, and scalable.

### 🔷 Clean Architecture Layers

```
Presentation Layer (UI)
│
├── Console App
├── MVC App
├── Web API
└── Minimal API

Application Layer
│
├── Services (Business Logic)
├── DTOs
├── Use Cases
└── Interfaces

Domain Layer
│
├── Entities
├── Value Objects
└── Domain Rules

Infrastructure Layer
│
├── ADO.NET
├── Dapper
├── EF Core
├── Database Context
└── External Services
```

### Dependency Rule

> **Dependencies always point inward**

* UI depends on Application
* Application depends on Domain
* Infrastructure depends on Application & Domain
* Domain depends on nothing

---

## 🧱 Physical Solution Structure

```
Solution
│
├── ConsoleApp.CRUD
│   ├── Program.cs
│   ├── Services
│   ├── Repositories
│   └── Models
│
├── WebAPI
│   ├── Controllers
│   ├── Services
│   ├── Repositories
│   ├── DTOs
│   └── Program.cs
│
├── MVCApp
│   ├── Controllers
│   ├── Views
│   ├── Models
│   ├── ViewModels
│   └── wwwroot
│
├── MinimalAPI
│   └── Program.cs
│
├── DataAccess
│   ├── AdoNet
│   ├── Dapper
│   ├── EFCore
│   └── DbContext
│
└── Shared
    ├── Interfaces
    ├── Models
    └── Helpers
```

---

## 🔧 Technologies Used

| Technology           | Purpose                     |
| -------------------- | --------------------------- |
| .NET 6 / 7 / 8       | Core framework              |
| ASP.NET Core         | Web & API development       |
| MVC                  | Server-side web application |
| Minimal API          | Lightweight API endpoints   |
| ADO.NET              | Low-level database access   |
| Dapper               | Lightweight ORM             |
| EF Core              | Full ORM                    |
| LINQ                 | Data querying               |
| SQL Server           | Database                    |
| Chart.js             | Charts & graphs             |
| Dependency Injection | Loose coupling              |

---

## 🔁 CRUD Operations

All applications support **CRUD**:

* **Create** – Insert new records
* **Read** – Fetch data (list & details)
* **Update** – Modify existing records
* **Delete** – Remove records

Implemented consistently using:

* Repository Pattern
* Service Layer
* DTOs (for APIs)

---

## 🖥️ 1. .NET Console Application (CRUD)

### Features

* Menu-driven console UI
* CRUD operations
* Uses **Dependency Injection**
* Can switch between:

  * ADO.NET
  * Dapper
  * EF Core

### Example Flow

```
1. Add Record
2. View Records
3. Update Record
4. Delete Record
5. Exit
```

### Key Concepts

* `IServiceCollection`
* Repository abstraction
* Clean separation of concerns

---

## 🌐 2. ASP.NET Core Web API

### Features

* RESTful endpoints
* JSON-based communication
* Swagger UI
* DTO-based request/response

### Sample Endpoints

```
GET    /api/employees
GET    /api/employees/{id}
POST   /api/employees
PUT    /api/employees/{id}
DELETE /api/employees/{id}
```

### Benefits

* Frontend-ready
* Mobile app integration
* Microservices compatible

---

## 🎨 3. ASP.NET Core MVC Application

### Features

* Razor Views
* Forms & validation
* CRUD UI pages
* Chart visualization

### Structure

* Controller → Business Logic
* View → UI
* Model/ViewModel → Data

### Chart Example

* Employee count by department
* Sales summary
* Monthly statistics

---

## ⚡ 4. Minimal API

### Features

* Lightweight & fast
* Minimal boilerplate
* Ideal for microservices

### Example

```csharp
app.MapGet("/employees", () => employeeService.GetAll());
app.MapPost("/employees", (Employee e) => employeeService.Add(e));
```

---

## 💉 Dependency Injection (DI)

DI is used across **all projects** to:

* Reduce tight coupling
* Improve testability
* Follow SOLID principles

### Example

```csharp
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
```

---

## 🗄️ Data Access Technologies

### 🔹 ADO.NET

* Raw SQL queries
* `SqlConnection`, `SqlCommand`
* Best performance & full control

### 🔹 Dapper

* Micro ORM
* Faster than EF Core
* Easy SQL mapping

### 🔹 EF Core

* Full ORM
* LINQ support
* Change tracking
* Code First / Database First

---

## 🔍 LINQ Usage

Used for:

* Filtering
* Sorting
* Grouping
* Aggregation

Example:

```csharp
var result = employees
    .Where(e => e.IsActive)
    .OrderBy(e => e.Name)
    .ToList();
```

---

## 📊 Charts & Data Visualization

Charts are implemented in the **MVC project** using **Chart.js**:

* Bar Chart
* Line Chart
* Pie Chart

### Example Use Cases

* Employee count per department
* Monthly sales
* Attendance statistics

Data is fetched from:

* API
* EF Core queries
* LINQ projections

---

## ⚙️ Configuration

### appsettings.json

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=SampleDB;Trusted_Connection=True;"
}
```

---

## ▶️ How to Run the Project

1. Clone the repository
2. Open solution in Visual Studio
3. Restore NuGet packages
4. Update connection string
5. Run:

   * Console App
   * Web API
   * MVC App
   * Minimal API

---

## 🧪 Testing & Best Practices

* Repository Pattern
* Service Layer
* DTOs
* Separation of concerns
* Reusable data access layer

---

## 📈 Learning Outcomes

After completing this project, you will understand:

* Multiple .NET architectures
* CRUD implementation patterns
* Data access strategies
* Dependency Injection
* API & MVC integration
* Chart-based data visualization

---

## 👨‍💻 Author

Developed as a **learning & portfolio project** using modern .NET technologies.

---

## ⭐ License

This project is open for **educational and personal use**.


