-- Creates Database
CREATE DATABASE FlightsDataService;

-- Sets the schema active
USE FlightsDataService;

-- Creates a flights table
CREATE TABLE Flights (
    FlightId INT NOT NULL AUTO_INCREMENT,
    Origin VARCHAR(1000) NOT NULL,
    Destination VARCHAR(1000),
    FlightDate DATE,
    DepartureTime TIME,
    ArrivalTime TIME,
    PRIMARY KEY (FlightId)
);

-- Creates a passengers table
CREATE TABLE Passengers (
    PassengerId INT NOT NULL AUTO_INCREMENT,
    FirstName VARCHAR(1000) NOT NULL,
    LastName VARCHAR(1000),
    PhoneNum VARCHAR(1000),
    EmailAddress VARCHAR(1000) NOT NULL,
    DateOfBirth DATE,
    PRIMARY KEY (PassengerId)
);

-- Creates a bookings table
CREATE TABLE Bookings (
    BookingId INT NOT NULL AUTO_INCREMENT,
    PassengerId INT NOT NULL,
    FlightId INT NOT NULL,
    SeatNum VARCHAR(100),
    PRIMARY KEY (BookingID),
    -- PassengerId and FlightId columns are declared as foreign keys
    CONSTRAINT fk_Passenger FOREIGN KEY (PassengerId) REFERENCES Passengers(PassengerId),
    CONSTRAINT fk_Flight FOREIGN KEY (FlightId) REFERENCES Flights(FlightId),
    -- SeatNum column has a unique constraint added to it to ensure that each seat number is unique within the bookings table
    CONSTRAINT SeatNum_Unique UNIQUE (SeatNum)
);
