# NomNomNosh Hub

## General Description

The NomNomNosh Hub project is a .NET application that uses Clean Architecture and follows the approach of a modular monolith.

In the case of NomNomNosh Hub, it has been implemented as a modular monolith. This means that the application is developed as a single unit, but is divided into modules that handle different functionalities. This modular structure allows for low coupling between modules and high cohesion within each one.

It uses Entity Framework (EF) as an ORM and SQL Server as a database. The repository pattern and service pattern are implemented, along with other design patterns, to ensure a modular and scalable structure.

The main goal of NomNomNosh Hub is to provide a platform for sharing and discovering cooking recipes. Through an intuitive and user-friendly interface, users can search, post, rate, comment and save recipes, as well as interact with other users.

## Architecture

The backend application is divided into the following modules:

- **Domain:** This module defines the data models and business rules of the application.
    - Entities
- **Infrastructure:** This module provides the infrastructure for data access (BD)
    - Repositories
    - Data (DbContext)
- **Application:** This module orchestrates communication between the view (API) and infrastructure.
    - DTOs
    - Interfaces
    - Services
    - Utils
- **API:** This module provides an application programming interface (API) for external clients to interact with the application.
    - Controllers
    - Migrations
    - Config (Auth Config, Request n Response Interface, ErroHandler, Filter)
