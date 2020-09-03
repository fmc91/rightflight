# Right Flight - Individual Project

## Sprint 1 Review

For this project, the decision was made to follow a database-first approach. This is because the database-first approach affords more flexibility with regards to database design, and only an intermediate knowledge of SQL is required in order to leverage the powerful features of relational databases. Accordingly, the first sprint began with the development of the database schema for the project and the creation of an entity-relationship diagram. Using this, a SQL Server database was created and populated with essential data, such as names of countries, cities and airports. The entity-relationship diagram for the database is shown below.

![](Images/er_diagram.png)

Creation of the database required some research into appropriate representation for time zone information which could be both easily stored in the database, as well as exploited in a C# program.

The database context was then scaffolded and C# entity model classes were created in order to facilitate interoperation with the database.

Following this, the layout and appearance of user interface screens was designed. Below are two examples of UI mock-ups which were created.

![](Images/add_route_screen.png)

![](Images/flight_search_screen.png)

The first user interface screen to be developed was the screen which allows users to add routes to the database. This screen includes a search box with live suggestions. As such a control is not part of WPF as standard, a custom control had to be created. Much of the remainder of the sprint was then dedicated to implementing the user control, and addressing the associated technical challenges. 

Once the user control had been fully implemented, the user interface for adding routes was then partly developed. However, the interface for this particular page was not implemented in its entirety. Features for selecting the airline, origin and destination airports, as well as the aircraft flying the route were implemented. However, the user also needs to be able to enter detailed pricing information, and a form for entering this information still needs to be implemented. This will be done in the following sprint.

## Sprint 1 Retrospective

Creation of the database schema was completed efficiently and in good time. This is because the finer details of the database design had been considered in advanced and difficulties had been planned for. However, some difficulties were unforeseen and required additional research. For example, storing time zone information in an appropriate format which could be leveraged at runtime was a difficulty which had not been identified in advance. It is necessary to store time zone information for destinations, as a flight's time of arrival needs to be calculated at run time. This is because it is preferable not to store information in the database which can be calculated with minimal computational cost. Flight arrival time can be calculated if the flight departure time and duration are known. However, the local time on arrival will also depend on the time zone difference between the two locations. Research revealed that the Windows Time Zone database is stored in the Windows Operating System registry and can be leveraged by .NET Core. The information pertaining to a particular time zone can be accessed if its key is known. The key is a string describing the time zone, such as "Eastern Standard Time". For this reason, it was decided to store the time zone key in the database for each city. This can then be used at runtime to calculate the time difference between two cities.

The second major impediment in this sprint was the requirement for a search box which provides live suggestions. This is a requirement in order to make the user interface user-friendly and intuitive. However, WPF does not provide such a control out of the box. Development of a user control proved challenging, and much time had to be given over to the task. Foresight and prior research into potential technical challenges could have mitigated the time lost to this task. However, the expertise and experience gained from the development of this feature will no doubt be invaluable in future sprints where other aspects of the user interface prove technically challenging.