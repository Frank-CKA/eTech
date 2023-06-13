## eTech ecommerce system

Welcome to the eTech eCommerce project! This is an ASP.NET web application built using C# that aims to provide a platform for online shopping. It includes features such as product listings, shopping cart functionality & user authentication.

## Installation

To run this project locally, follow these steps:

1. Clone the repository: `git clone https://github.com/Frank-CKA/eTech.git`
2. Open the solution file (`Proyecto1.sln`) in Visual Studio.
3. Restore NuGet packages.
4. Update the database connection string in the `appsettings.json` file to point to your local database server.
5. Run database migrations using the Entity Framework Core CLI or Package Manager Console.
6. Build and run the application.

## Usage

Once the application is running, you can access it in your browser at `http://localhost:5000`. Here are some key features and functionalities:

- **User Registration and Authentication:** Users can create an account, log in, and manage their profile.
- **Product Listings:** Browse and search for products, view their details, and add them to the shopping cart.
- **Shopping Cart:** Add and remove items from the shopping cart, update quantities, and proceed to checkout.

## Configuration

The project uses the following configuration options:

- **Database Connection String:** Update the `DefaultConnection` connection string in the `appsettings.json` file with your local database server details.
- **Email Settings:** If you wish to enable email notifications, configure the SMTP settings in the `appsettings.json` file.
- **Payment Gateway Integration:** If you want to enable online payments, configure the payment gateway credentials in the `appsettings.json` file.
