# Technical Design
<br>

## Class Diagram
<br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112886/villagerms-class-diagram.png" alt="Class Diagram" width="600"/>

docs/diagrams/villagerms-class-diagram.png
<br><br>
## Sequence Diagrams
<br><br>

### Equipment Rental
<br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112842/villagerms-sd-equipment-rental.png" alt="Equipment Rental" width="600"/>

docs/diagrams/villagerms-sd-equipment-rental.png
<br><br>
### Update Equipment
<br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112807/villagerms-sd-update-equipment.png" alt="Rental Update" width="600"/>

docs/diagrams/villagerms-sd-update-equipment.png
<br><br>

## Database Schema
<br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724112874/villagerms-db-schema-erd.png" alt="Database Schema" width="600"/>

docs/diagrams/villagerms-db-schema-erd.png

<br><br>
## UI Prototype
<br>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_1_h87xts.png" alt="Login view" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114084/Screenshot_2_hrypzi.png" alt="Rentals page" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114086/Screenshot_3_vdeekq.png" alt="Update Rental modal" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_6_hfzlgo.png" alt="Customers page" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114082/Screenshot_5_p0ozhu.png" alt="Equipment page - new aquipment modal" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114083/Screenshot_9_klccmh.png" alt="Reports1" width="500"/>
<img src="https://res.cloudinary.com/duk3olmgh/image/upload/v1724114082/Screenshot_7_oiu6hc.png" alt="Load data from Excel into Database" width="500"/>


![Figma design file](https://www.figma.com/proto/ZFKQTzmYdpMOsaZwWJ1Vru/RMS-Prototype?page-id=0%3A1&node-id=23-683&viewport=777%2C651%2C0.12&t=bt7ViXkqFck9lgPP-1&scaling=min-zoom&content-scaling=fixed&starting-point-node-id=1%3A50&show-proto-sidebar=1)
<br><br>
## Technical Design
<br>
- **Backend**:
  - C# with .NET 8.0
  - MySQL for database
- **Frontend**:
  - Blazor for UI
- **Architecture**:
  - MVC pattern
  - Dependency Injection for service management
<br><br>

# Technical Specifications
<br>
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
