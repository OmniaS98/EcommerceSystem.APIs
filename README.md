# E-Commerce Backend API

This project is a backend API for an e-commerce platform that provides endpoints for user authorization, cart operations, placing orders, and viewing order history.

## Technologies Used
- **Language:** C#
- **Framework:** ASP.NET Core
- **Database:** SQL Server
- **Other libraries/tools:**
    - JWT Authentication: JSON Web Tokens (JWT) for user authentication and authorization.
    - Microsoft.AspNetCore.Identity: For user authentication and authorization.

## Additional Features Used

- **N-Tier Architecture:** The project follows an N-Tier architecture for better separation of concerns and maintainability.
- **DTOs (Data Transfer Objects):** DTOs are utilized for data transfer between layers, ensuring efficient communication while maintaining encapsulation.
  

## Authorization Endpoints

- **Endpoint:** `Users/login`
  - **Method:** POST
  - **Description:** Logs in the user and generates a JWT token for authentication.
  - **Request Body:** { "email": "example@gmail.com", "password": "password" }
  - **Response:** { "token": "jwt_token_here" }

- **Endpoint:** `Users/register`
  - **Method:** POST
  - **Description:** Registers a new user.
  - **Request Body:** { "userName": "example", "email": "example@gmail.com", password": "password" }

## Retrieve Products Endpoint

- **Endpoint:** `/Products`
  - **Method:** GET
  - **Description:** Retrieves a list of products based on optional parameters (category, name).
  - **Query Parameters:** { "category": "example_category", "name": "example_name" }

## Product Details Endpoint

- **Endpoint:** `/Products/{id}`
  - **Method:** GET
  - **Description:** Retrieves details of a specific product.
  - **Path Parameter:** { "id": "product_id_here" }

## Add to Cart Endpoint

- **Endpoint:** `/Carts/addItem`
  - **Method:** POST
  - **Description:** Adds a product to the user's cart.
  - **Request Body:** { "productId": "product_id_here", "quantity": "quantity_here" }

## Remove Item from Cart Endpoint

- **Endpoint:** `/Carts/removeItem`
  - **Method:** DELETE
  - **Description:** Removes a product from the user's cart.
  - **Query Parameter:** { "productId": "product_id_here" }

## Edit Item Quantity in Cart Endpoint

- **Endpoint:** `/Carts/editItemQuantity`
  - **Method:** PUT
  - **Description:** Edits the quantity of a product in the user's cart.
  - **Request Body:** { "productId": "product_id_here", "quantity": "new_quantity_here" }

## Place Order Endpoint

- **Endpoint:** `/Orders/placeOrder`
  - **Method:** POST
  - **Description:** Places an order with the specified products and quantities.
  - **Request Body:** [ { "productId": 1, "quantity": 5 }, { "productId": 2, "quantity": 10 } ]

## View Orders History Endpoint

- **Endpoint:** `/Orders/history`
  - **Method:** GET
  - **Description:** Retrieves the user's order history.
  - **Response:** 
      ```json
    [
        {
            "orderId": "order_id_here",
            "orderDate": "order_date_here",
            "items": [
                { "productId": "product_id_here", "quantity": "quantity_here" },
                { "productId": "product_id_here", "quantity": "quantity_here" }
            ],
            "totalPrice": "total_price_here"
        },
        ...
    ]
