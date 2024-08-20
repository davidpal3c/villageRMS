# Technical Design

## Class Diagrams

 ![Class Diagram](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112886/villagerms-class-diagram.png)

docs/villagerms-class-diagram.png


## Sequence Diagrams

![Equipment Rental](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112842/villagerms-sd-equipment-rental.png)
docs/villagerms-sd-equipment-rental.png

![Rental Update](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112807/villagerms-sd-update-equipment.png)
docs/villagerms-sd-equipment-rental.png


## Database Schema

![Database Schema](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112874/villagerms-db-schema-erd.png)
docs/villagerms-db-schema-erd.png


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
 