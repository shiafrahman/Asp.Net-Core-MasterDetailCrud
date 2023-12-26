Sale Products Management System

This project is an ASP.NET Core application designed to facilitate the management of sale products, including their details and associated transactions.

Overview

The Sale Products Management System provides functionalities to create, read, update, and delete (CRUD) sale transactions with detailed information about the products sold. The system manages two main entities: SalesMaster and SalesDetails.

SalesMaster

The SalesMaster entity represents the primary sale transaction and includes the following attributes:

SalesMasterId: Unique identifier for each sale transaction.

Invoice Number: Identification number for the invoice related to the sale.

Customer Name: Name of the customer involved in the transaction.

Mobile No: Contact mobile number of the customer.

Address: Address associated with the customer.

SalesDetails

The SalesDetails entity contains details about the products sold within a transaction and includes the following attributes:

SalesDetailsId: Unique identifier for each sale detail.

Product Code: Code identifying the specific product.

Product Name: Name of the product sold.

Price: Price of the product.

Quantity: Quantity of the product sold.

SalesMasterId: Reference to the parent SalesMaster entity.

Project Structure

The project is organized as follows:

Models: Contains the entity classes SalesMaster and SalesDetails.

Controllers: Handles HTTP requests and implements CRUD operations for sales transactions and details.

Views: User interface elements designed using Razor syntax for interacting with the system.

Data Access Layer: Responsible for database operations and interactions using Entity Framework Core.

Getting Started

To run the project locally:

Clone the repository.

Ensure you have the necessary dependencies installed, including .NET Core SDK.

Set up the database connection string in the appsettings.json file.

Run the migration commands to set up the database schema (dotnet ef database update).

Build and run the application (dotnet run).

Contributing

Contributions to enhance features, fix issues, or optimize code are welcome. Please fork the repository, make changes, and submit a pull request detailing your modifications.

License
This project is licensed under the MIT License.


