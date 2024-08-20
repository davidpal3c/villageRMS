# Technical Design

## Class Diagram
<br><br>
 ![Class Diagram](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112886/villagerms-class-diagram.png)

docs/villagerms-class-diagram.png


## Sequence Diagrams
<br><br>
### Equipment Rental
![Equipment Rental](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112842/villagerms-sd-equipment-rental.png)
docs/villagerms-sd-equipment-rental.png
<br><br>
### Update Equipment
![Rental Update](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112807/villagerms-sd-update-equipment.png)
docs/villagerms-sd-update-equipment.png


## Database Schema

![Database Schema](https://res.cloudinary.com/duk3olmgh/image/upload/v1724112874/villagerms-db-schema-erd.png)
docs/villagerms-db-schema-erd.png


## UI Prototype

![Login view] (https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_1_h87xts.png)
![Rentals page](https://res.cloudinary.com/duk3olmgh/image/upload/v1724114084/Screenshot_2_hrypzi.png)
![Update Rental modal](https://res.cloudinary.com/duk3olmgh/image/upload/v1724114086/Screenshot_3_vdeekq.png)
![Customers page](https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_6_hfzlgo.png)
![Equipment page - new aquipment modal](https://res.cloudinary.com/duk3olmgh/image/upload/v1724114082/Screenshot_5_p0ozhu.png)
![Reports1](https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_9_klccmh.png)
![Load data from Excel into Database](https://res.cloudinary.com/duk3olmgh/image/upload/v1724114082/Screenshot_7_oiu6hc.png)




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
 