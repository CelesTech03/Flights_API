# Flights API
Developed a Flights API using .NET and Entity Framework.

## Flights API
### Endpoints that client can use:

| HTTP Method | Endpoint                   | Description                                                       | Request Body  | Response Body    |
|-------------|----------------------------|-------------------------------------------------------------------|---------------|------------------|
| `GET`       | /api/flights               | Get all flights                                                   | None          | Array of flights |
| `POST`      | /api/flights               | Add a new flight                                                  | Flight        | Flight           |
| `PUT`       | /api/flights/{id}          | Update the details of an existing flight with the specified id    | Flight        | None             |
| `DELETE`    | /api/flights/{id}          | Delete the flight specified by id                                 | None          | None             |
| `GET`       | /api/flights/{id}          | Get a flight by ID                                                | None          | Flight           |

## Database Schema 

<img width="1183" alt="Screenshot 2023-04-20 at 3 18 26 PM" src="https://user-images.githubusercontent.com/57969388/233465866-f9514e02-1358-448d-87ab-83559be50027.png">
