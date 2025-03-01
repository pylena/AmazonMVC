# MVC Architecture Implementation

## Project Overview

This project demonstrates the implementation of the Model-View-Controller (MVC) architecture in a .NET web application. The application includes user, product, and order management functionalities, following structured separation of concerns to ensure maintainability and scalability.

## MVC Architecture Breakdown

* 1. Models

* Models represent the application's core data structures and business logic. The following models are defined:

* User: Represents user details.

* Product: Stores product information.

* Order: Captures order details, including user and product references.

* OrderDetails: Provides additional information about each order, such as quantity and pricing.

2. Views (Razor Views)

## Views are responsible for presenting the user interface. The following views are implemented:

* Product List View: Displays available products.

* Order Form: Allows users to place an order.

* Order History View: Displays users' past orders.

### 3. Controllers

* Controllers handle user interactions, update models, and return appropriate views. The key functionalities include:

* Populating Product Dummy Data: Controllers initialize and manage product data.

* Handling Order Placement: Ensures orders are processed correctly and saved.

### Routing & User Input Handling

1. Attribute-Based Routing

* The application uses attribute-based routing to define endpoints:

#### GET /Products → Fetches and displays all products.

#### GET /Orders/{userId} → Retrieves and displays the order history for a specific user.

### 2. Model Validation

To ensure data integrity and prevent incorrect inputs, model validation techniques are implemented:

Required field validation.

Data type validation (e.g., ensuring numeric values where necessary).

Error handling to guide users towards correct input.



#### Technologies Used

* .NET MVC

* Razor Views

* Entity Framework



### Future Enhancements

* Implement authentication and authorization using ASP.NET Identity pacage .

* Introduce a database for persistent storage.


