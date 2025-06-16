📦 Products Management System
A web-based application built with ASP.NET Core MVC that follows the Clean Architecture pattern. 
The system is designed to manage products and their corresponding service providers, supporting full CRUD operations and advanced filtering capabilities.



🛠 Features
✅ Add, edit, delete, and list products

✅ Manage service providers (create, update, delete, list)

✅ Filter products by price range, creation date, and service provider

✅ Integrated with Entity Framework Core and SQL Server

✅ Clean separation of concerns via Clean Architecture principles

✅ Use of Mapster for mapping between ViewModels and domain entities

✅ Dynamic Razor Views with strong typing

🧱 Project Structure
This project is structured using Clean Architecture with the following layers:

├── ProductsManagment.Core             
# Entities and Interfaces
├── ProductsManagment.ApplicationLeyar 
# Interfaces and DTOs/ViewModels
├── ProductsManagment.Infrastructure   
# EF Core, Services Implementation
├── ProductsManagment.Web              
# ASP.NET Core MVC UI Layer (Controllers, Views)

🔧 Technologies Used
ASP.NET Core MVC (.NET 8)

Entity Framework Core

SQL Server

Clean Architecture

Mapster (object-to-object mapper)

Bootstrap (for frontend styling)

LINQ (for filtering and querying)

📂 Key Functionalities
Home Page: Central hub linking to both the Product and Service Provider sections.

Products: List, Create, Edit, Delete, Filter.

Service Providers: List, Create, Edit, Delete.

Validation: Model validation on both server-side and client-side.

Error Handling: Developer-friendly error pages using middleware.



