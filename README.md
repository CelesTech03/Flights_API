# Flights API
Developed a Flights API using .NET and Entity Framework.

## Requirements:

The following functionality is completed:

- [x] At least 3 different API endpoints and 3 different HTTP methods
- [x] API follows the MVC (Model-View-Controller) software design pattern
- [x] There must be at least one controller
- [x] Collection of models includes a basic response model that is consistently returned at the end of every request
- [x] Database has at least two tables with two primary keys, one foreign key, and one additional constraint on a column that is not a primary key or a foreign key

## Some endpoints that clients can use:

| HTTP Method | Endpoint                   | Description                                                       | Request Body  | Response Body    |
|-------------|----------------------------|-------------------------------------------------------------------|---------------|------------------|
| `GET`       | /api/flights               | Get all flights                                                   | None          | Array of flights |
| `POST`      | /api/flights               | Add a new flight                                                  | Flight        | Flight           |
| `PUT`       | /api/flights/{id}          | Update the details of an existing flight with the specified id    | Flight        | None             |
| `DELETE`    | /api/flights/{id}          | Delete the flight specified by id                                 | None          | None             |
| `GET`       | /api/passengers/{id}       | Get a passenger by ID                                             | None          | Passenger        |
| `POST`      | /api/passengers            | Add a new passenger                                               | Passenger     | Passenger        |
| `PUT`       | /api/passengers/{id}       | Update the details of an existing passenger with the specified id | Passenger     | None             |
| `DELETE`    | /api/passengers/{id}       | Delete the passenger specified by id                              | None          | None             |
| `GET`       | /api/bookings              | Get all bookings                                                  | None          | Array of bookings|
| `PUT`       | /api/bookings/{id}         | Update the details of an existing booking with the specified id   | Booking       | None             |
| `DELETE`    | /api/bookings/{id}         | Delete the booking specified by id                                | None          | None             |

## Database Diagram 

<img width="1183" alt="Screenshot 2023-04-20 at 3 18 26 PM" src="https://user-images.githubusercontent.com/57969388/233465866-f9514e02-1358-448d-87ab-83559be50027.png">
