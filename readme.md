# Right Flight - Individual Project

## Sprint 1

### Review

For this project, the decision was made to follow a database-first approach. This is because the database-first approach affords more flexibility with regards to database design, and only an intermediate knowledge of SQL is required in order to leverage the powerful features of relational databases. Accordingly, the first sprint began with the development of the database schema for the project and the creation of an entity-relationship diagram. Using this, a SQL Server database was created and populated with essential data, such as names of countries, cities and airports. The entity-relationship diagram for the database is shown below.

![](Images/er_diagram.png)

Creation of the database required some research into appropriate representation for time zone information which could be both easily stored in the database, as well as exploited in a C# program. The decision was made to use the Windows time zone database, which is stored in the Windows operating system registry. This database can by interrogated by .NET Core in order to obtain time zone information for a given region, including details of daylight savings time. In order to do this, the key for the time zone must be known. The key is a string describing the database, for example ''Pacific Standard Time". Therefore, it was decided to store the time zone key for each city in the database so that this information could be used at run time.

The database context was then scaffolded and C# entity model classes were created in order to facilitate interoperation with the database.

Following this, the layout and appearance of user interface screens was designed. Below are two examples of UI mock-ups which were created.

![](Images/add_route_screen.png)

![](Images/flight_search_screen.png)

The first user interface screen to be developed was the screen which allows users to add routes to the database. This screen includes a search box with live suggestions. As such a control is not part of WPF as standard, a custom control had to be created. Much of the remainder of the sprint was then dedicated to implementing the user control, and addressing the associated technical challenges. 

Once the user control had been fully implemented, the user interface for adding routes was then partly developed. However, the interface for this particular page was not implemented in its entirety. Features for selecting the airline, origin and destination airports, as well as the aircraft flying the route were implemented. However, the user also needs to be able to enter detailed pricing information, and a form for entering this information still needs to be implemented. This will be done in the following sprint.

### Retrospective

Creation of the database schema was completed efficiently and in good time. This is because the finer details of the database design had been considered in advanced and difficulties had been planned for. However, some difficulties were unforeseen and required additional research. For example, storing time zone information in an appropriate format which could be leveraged at runtime was a difficulty which had not been identified in advance. The second major impediment in this sprint was the requirement for a search box which provides live suggestions. Foresight and prior research into potential technical challenges could have mitigated the time lost to these tasks.

## Sprint 2

### Review

During this sprint, work continued on the feature which had been started during sprint 1, namely the ability to add routes to the database and the development of the associated user interface. This feature was successfully completed by the end of the sprint and passed functional testing criteria.

The application now includes a screen which allows the user (airline or travel agent) to input details of a route flown by an airline. The user is able to select an airline, an origin airport, and a destination airport. The selection of these details is aided by a search suggestion feature so that the user does not have to find their desired option in a long list. They can instead type in a search term and be provided with options which match their search term. This makes the application more user friendly. In addition, when searching for an airport, two features are available to assist the user in their search. Firstly, the user can search using IATA airport codes (eg LAX) instead of the airport name. They can also enter the name of the city served by an airport in order to retrieve it in the search. This is useful when the name of the airport does not include the city, eg "McCarthy International Airport" in Las Vegas.

The user is also able to specify which aircraft fly the route and the expected flight duration for each type of aircraft. This covers the possibility where multiple aircraft fly the same route but have different flight times. The user can also specify the pricing scheme for the route. They are able to specify which travel classes (economy, first, etc) are available on the route, as well as a pricing breakdown by age group for each travel class. This feature has been implemented in this way because not all airlines will offer all travel classes - some may offer economy and business, but not first, for example, and some may only offer first class on certain routes. This feature allows then to specify the pricing scheme of only the travel classes which are available on the given route. If the user makes a mistake and enters incorrect information for either one of the aircraft or one of the travel classes, they are able to remove it from the list by clicking a button.

Data validation and error checking associated with this feature have also been implemented. The user is prevented from entering null values into the database. In addition, they may not add a route where the origin and destination airport are the same. They may not add a combination of airline, origin and destination which already exists in the database. They may not add the same aircraft twice for the same route, or the same travel class twice, and they may not enter a value greater than 59 for the minutes part of the flight duration.

### Retrospective

This sprint was generally considered a success and was completed without any major hurdles. A major feature was successfully implemented and passed functional testing criteria.

It was noted that the development of a user-friendly and modern-looking user interface was a potentially time-consuming endeavour. Although this is not currently an issue, in future sprints, it may become necessary to forego some aspects of the interface in order to ensure that the minimum viable product is delivered.

In addition it was noted that the feature being implemented in this sprint should have been identified as an epic rather than just a single user story. Although the feature represents a single unit of functionality, it encompasses many potential user stories. For example, being able to find an airport by searching for the city it serves could be a whole user city in its own right. It was decided in future to give more focus to breaking down larger user stories into finer-grained ones.