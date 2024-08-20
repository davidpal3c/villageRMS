# Technical Design

## Class Diagram
<br><br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112886/villagerms-class-diagram.png" alt="Class Diagram" width="600"/>

docs/diagrams/villagerms-class-diagram.png

## Sequence Diagrams
<br><br>

### Equipment Rental
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112842/villagerms-sd-equipment-rental.png" alt="Equipment Rental" width="600"/>

docs/diagrams/villagerms-sd-equipment-rental.png

### Update Equipment
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112807/villagerms-sd-update-equipment.png" alt="Rental Update" width="600"/>

docs/diagrams/villagerms-sd-update-equipment.png


## Database Schema
<br><br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112874/villagerms-db-schema-erd.png" alt="Database Schema" width="600"/>

docs/diagrams/villagerms-db-schema-erd.png


## UI Prototype
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_1_h87xts.png" alt="Login view" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114084/Screenshot_2_hrypzi.png" alt="Rentals page" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114086/Screenshot_3_vdeekq.png" alt="Update Rental modal" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_6_hfzlgo.png" alt="Customers page" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114082/Screenshot_5_p0ozhu.png" alt="Equipment page - new aquipment modal" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_9_klccmh.png" alt="Reports1" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114082/Screenshot_7_oiu6hc.png" alt="Load data from Excel into Database" width="500"/>

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
