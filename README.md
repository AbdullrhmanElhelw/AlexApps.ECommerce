# AlexApps E-Commerce

## Description
AlexApps E-Commerce is a comprehensive e-commerce platform designed to facilitate online shopping and business management. The project follows Clean Architecture principles and is implemented using .NET Web API. It includes various features like product listing, shopping cart, user authentication, and order management.

Key features:
- User authentication and authorization
- Product listing and categorization
- Shopping cart and checkout
- Order management and tracking

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [Contact](#contact)

## Installation
Follow these steps to set up the project locally:

1. Clone the repository:
    ```sh
    git clone https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce.git
    ```

2. Navigate to the project directory:
    ```sh
    cd AlexApps.ECommerce
    ```

3. Open the solution file (`.sln`) in Visual Studio.

4. Restore the necessary dependencies:
    ```sh
    dotnet restore
    ```

5. Update the `appsettings.json` file with your database connection string and other necessary configurations.

6. Apply database migrations:
    ```sh
    dotnet ef database update
    ```

7. Build the project:
    ```sh
    dotnet build
    ```

8. Run the project:
    ```sh
    dotnet run
    ```

9. Open the application in your browser:
    ```
    http://localhost:5000
    ```

## Usage
Here are some instructions on how to use the application:

1. Register a new account or log in with existing credentials.
2. Browse the product catalog and add items to your shopping cart.
3. Proceed to checkout to place your order.
4. Track your orders in the user dashboard.

For administrative functions:
1. Log in with admin credentials.
2. Access the admin dashboard to manage products, orders, and users.

## Project Structure
The project is structured according to Clean Architecture principles, with the following main layers:

- **Domain**: Contains the business logic and domain entities.
- **Contracts**: Contains all interfaces for all layers.
- **Application**: Contains the application logic and service interfaces.
- **Infrastructure**: Contains the implementations of the service interfaces and data access logic.
- **Persistence**: Contains the database context and repository implementations.
- **WebAPI**: Contains the controllers and the API endpoints.

## Contributing
We welcome contributions to enhance the project. To contribute, follow these steps:

1. Fork the repository:
    ```sh
    git fork https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce.git
    ```

2. Create your feature branch:
    ```sh
    git checkout -b feature/AmazingFeature
    ```

3. Commit your changes:
    ```sh
    git commit -m 'Add some AmazingFeature'
    ```

4. Push to the branch:
    ```sh
    git push origin feature/AmazingFeature
    ```

5. Open a pull request.

## Contact
Abdullrhman Elhelw - [Your Email](mailto:elhelw258@gmail.com)

Project Link: [https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce](https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce)

[![Contributors](https://img.shields.io/github/contributors/AbdullrhmanElhelw/AlexApps.ECommerce.svg)](https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce/graphs/contributors)
[![Forks](https://img.shields.io/github/forks/AbdullrhmanElhelw/AlexApps.ECommerce.svg)](https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce/network/members)
[![Stargazers](https://img.shields.io/github/stars/AbdullrhmanElhelw/AlexApps.ECommerce.svg)](https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce/stargazers)
[![Issues](https://img.shields.io/github/issues/AbdullrhmanElhelw/AlexApps.ECommerce.svg)](https://github.com/AbdullrhmanElhelw/AlexApps.ECommerce/issues)
