# RoomBookings (WIP!)

### Overview

A basic Proof of Concept (PoC) system that allows users to search for and book rooms that are added by hosts

### Description

Hosts are able to add rooms, which consist of one or more beds (single, double, bunk, king size, queen size) and a number of facilities such as wifi, free parking. Rooms have a check-in by and check-out by time and are available to book by (joined) users 365 days a year. Double and bunk beds can hold 1 or 2 guests and all other beds hold 1 guest.

Hosts can also specify a daily price, (optionally) multiple duration discounts and (optionally) a mimimum and maximum booking duration on rooms.

Bookings can be cancelled by hosts but not created or ammended. Rooms cannot be modified or deleted once created.

Any registered user can (optionally) become a host by adding a room. Hosts are able to view a list of their rooms and view bookings for rooms.

Visitors and users are able to search for available rooms by location, price, date range, number of guests, room facilities and number of beds.

Visitors can join the system to become a User and book a room for their desired dates. Bookings can be cancelled by users but not ammended. Users can view a list of their future and past bookings, including cancelled bookings and view details for each booking. Exact locations of rooms are only provided to the User once a booking has been made.

Users and Hosts should be notified by email where appropriate

Note: This is a basic PoC, so a number of features such as payment and seasonal room rates do not need to be considered.

### Architecture

A [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) approach will be used to separate concerns into distinct layers:

- Domain (enterprise business logic)
- Application (application business logic, use cases),
- Interface (ui, apis, gateways)
- Infrastructure (persistence, external interfaces)

[Domain Driven Design (DDD)](https://martinfowler.com/bliki/DomainDrivenDesign.html) will be used to build a Ubiquitous Language, identify Bounded Contexts and model AggregateRoots in the domain layer

Bounded Contexts will be implemented as [MicroServices](https://microservices.io), to provide a system that is easy to scale and fast to develop.

Use Cases will be implemented using [Command Query Responsibility Segregation (CQRS)](https://www.eventstore.com/cqrs-pattern) to provide a separation of concerns between a businessl logic orientated write model and an efficient and flexible read model.

For system wide asynchronous communications [Integration Events](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/integration-event-based-microservice-communications) on an Event Bus will be used. These will also use an [Inbox/Outbox pattern](https://event-driven.io/en/outbox_inbox_patterns_and_delivery_guarantees_explained/) for reliable message delivery

[Domain Events](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/domain-events-design-implementation) will be used for inter aggregate communication within each microservice

Repository pattern for write side persistence

Unit Testing, Functional Testing and End To End Smoke Testing will be employed

### Technology

`.NET 7` for all application development
`Sql Server` and `Entity Framework` for persistence
`MassTransit` for distributed application development and inbox/outbox pattern implementation
`RabbitMq` for event bus
`MediatR` for CQRS and domain events
`Yarp` for gateways
`Serilog` for logging
`FluentValidation` for validation
`Autofac` for dependency injection (DI)
`AutoMapper` for convention-based object mapping
`xUnit` for testing

### Domain Analysis

#### Definitions (Ubiquitous Language)

**Visitor** - A person interacting with the system that has not joined

**User** - A person that has registered to join the system

**Host** - A User that can add Rooms to the system

**Room** - A room that has a Location, Facilities, check-in/check-out times and contains 1 or more Beds

**Location** - A propery name and address

**Guest** - A person staying in a Room

**Facility** - Facilities that a room has to offer. These are Free Wifi, Free Parking, Air Con, Satellite Tv

**Booking** - A reservation on a Room by a User between 2 dates

**Bed** - A bed of type Single, Double, Bunk, King Size or Queen Size.

**Notification** - An email to a User or Host providing information on an action

#### Use Cases

**Search Rooms**

**View Room**

**Join User**

**Create User Booking**

**Cancel User Booking**

**List User Bookings**

**View User Booking**

**Become Host**

**Add Host Room**

**List Host Rooms**

**List Host Bookings**

**View Host Room**

**View Host Booking**

**Cancel Host Booking**

### Domain Design

#### Room Service (Bounded Context)

Room - AggregateRoot

- Beds - List<ValueObject>
  - BedType - Enum
    - Single
    - Double
    - Bunk
    - King
    - Queen
- Facilities - ValueObject
  - HasFreeWifi - bool
  - HasFreeParking - bool
  - HasAirCon - bool
  - HasSatelliteTv - bool
- Bookings - List<Entity>
  - UserId - int
  - StartDate - DateTime
  - EndDate - DateTime
  - GuestCount - int
  - IsCancelled - bool
- BookingDurationDiscounts - List<ValueObject>
  - DurationDays - int
  - DiscountPercentage - int
- Address - ValueObject
  - Address1 - string
  - Address2 - string (optional)
  - City - string
  - Region - string
  - Country - Enum
  - PostalCode - string
- MinimumBookingDurationDays - int (default = 1)
- MaximumBookingDurationDays - int (optional)
- DailyPrice - double

#### User Service (Bounded Context)

User - AggregateRoot

- FirstName - string
- LastName - string
- EmailAddress - string
- IsHost - bool
