# Technical Design

## Class Diagrams
![Class Diagram](docs/villagerms-class-diagram.png)

## Sequence Diagrams
![Sequence Diagram1](docs/villagerms-sd-equipment-rental.png)
![Sequence Diagram2](docs/villagerms-sd-update-equipment.png)

## Database Schema
![Database Schema](docs/villagerms-db-schema-erd.png)

## UI Prototype


## Technical Design
- **Backend**:
  - C# with .NET 8.0
  - MySQL for database
- **Frontend**:
  - Blazor for UI
- **Architecture**:
  - MVC pattern
  - Dependency Injection for service management



# Technical Specifications

## API Documentation
- **Endpoints**:
  - `/api/customers`: GET, POST, PUT, DELETE
  - `/api/equipment`: GET, POST, PUT, DELETE
  - `/api/rentals`: GET, POST, PUT, DELETE

<!--
  - **Request/Response Formats**:
  - JSON format for all requests and responses.  
-->

- **Authentication**:
  - Token-based authentication.

## Code Standards
- **Naming Conventions**:
  - PascalCase for class names and method names.
  - camelCase for variable names.
- **Best Practices**:
  - Use async/await for asynchronous operations.
  - Exception handling with try/catch blocks.
  - Code comments for documentation.
 