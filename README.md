# VillageRMS

## Description
VillageRMS is a rental management system designed to streamline the process of managing rental equipment, customers, and rental transactions. The system provides functionalities for updating equipment, managing categories, and handling customer information.

## Getting Started

### Prerequisites
- [.NET 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://www.mysql.com/downloads/)
- [Visual Studio](https://visualstudio.microsoft.com/)

### Installation
1. Clone the repository:
    ```
   git clone https://github.com/davidpal3c/eventhub-mgmt-app.git
   ```
    
2. Open the solution in Visual Studio.
3. Set up the MySQL database and update the connection string in `MauiProgram.cs`:
    ```
    string connectionString = "Server=127.0.0.1;Port=3307;Database=RMS;User=group3;Password=$4DpA$sg4p3;";
    ```

  A pem key file is needed to access the ssh tunnel for this db instance. Please contact us for more information. 
    
5. Run the application from Visual Studio.

## Usage
1. Log in to the system. Use test credentials provided in the log in screen.
2. Navigate through the menu to manage rentals, equipment, and customers.
3. Use the forms provided to add, update, or delete records.

## Contributing
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## Contact Information
For any questions, please contact the development team [here](mailto:jose.palacios@edu.sait.ca), or [here](mailto:george.conde@edu.sait.ca), or [here](mailto:stefan.garcia@edu.sait.ca).


## Acknowledgments
- [MySQL Connector](https://www.mysql.com/products/connector/)
- [Microsoft Maui](https://dotnet.microsoft.com/apps/maui)
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)



 
