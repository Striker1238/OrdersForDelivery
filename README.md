# AcceptingOrdersForDelivery
!!!This work was created for a test task!!!
 A small application on ASP.NET Core for creating and viewing an order from a PostgreSQL DB.

 The application is designed to manage delivery orders. It allows you to:
- Create new delivery orders.
- View a list of all orders.
- Open details of a specific order.

### Technologies:
    Frontend: ASP.NET Core MVC.
    Backend: ASP.NET Core Web API.
    Database: PostgreSQL.
    ORM: Entity Framework Core.

## How to start?
    1) First, you will need to change the database information in the project. To do this, go to AcceptingOrdersForDeliveryWebApi -> appsettings.json and change "DefaultConnection": "Host=localhost;Port=5432;Database=OrdersForDelivery;Username=postgres;Password=1234" to your database data and make sure that you already have such a database.
    2) Launch the backend, for this open and run AcceptingOrdersForDeliveryWebApi.
    3) Launch the frontend, for this open AcceptingOrdersForDeliveryMVC and run it. (You may need to change the port in the project AcceptingOrdersForDeliveryMVC -> OrderService -> apiUrl to the server port).
    4) end

