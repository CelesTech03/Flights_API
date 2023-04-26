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
| `GET`       | /api/flights               | Get all flights                                                   | None          |![GET :api:flights](https://user-images.githubusercontent.com/57969388/234672672-74993672-664c-49db-a843-ae13b47d1971.png)|
| `DELETE`    | /api/flights/{id}          | Delete the flight specified by id                                 | None          |![DELETE :api:flights:{id}](https://user-images.githubusercontent.com/57969388/234673118-150a321c-ceb6-4cf8-bafb-b37a7219a057.png)|
| `GET`       | /api/passengers/{id}       | Get a passenger by ID                                             | None          |![GET :api:passengers:{id}](https://user-images.githubusercontent.com/57969388/234673892-015641dd-388a-4380-9d7f-6e1f13c83227.png)|
| `POST`      | /api/passengers            | Add a new passenger                                               |![POST :api:passengers request](https://user-images.githubusercontent.com/57969388/234676606-4b6ae8ae-c642-456d-adc4-f6a995d26d81.png)|![POST :api:passengers response](https://user-images.githubusercontent.com/57969388/234676688-4161a5f4-227d-424c-ac52-41b1da2b8f32.png)|
| `PUT`       | /api/passengers/{id}       | Update the details of an existing passenger with the specified id |![PUT :api:passengers:{id} request](https://user-images.githubusercontent.com/57969388/234677405-04dcdff5-e5cf-4e13-ba20-1d270c583e35.png)|![PUT :api:passengers:{id} response](https://user-images.githubusercontent.com/57969388/234677476-5a57adf8-9909-4555-a423-883a656ae174.png)|
| `PUT`       | /api/bookings/{id}         | Update the details of an existing booking with the specified id   |![PUT :api:bookings:{id} request](https://user-images.githubusercontent.com/57969388/234674986-ea9e1b67-f95d-4141-ba0d-3dfea98d998f.png) |![PUT :api:bookings:{id} response](https://user-images.githubusercontent.com/57969388/234675064-bb7cd856-1536-4b41-8522-182a26cac2d2.png)|

## Database Diagram 

<img width="1183" alt="Screenshot 2023-04-20 at 3 18 26 PM" src="https://user-images.githubusercontent.com/57969388/233465866-f9514e02-1358-448d-87ab-83559be50027.png">
