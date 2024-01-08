# PV179 - BookHub
This GitLab repository contains the code and documentation for the PV179 project.

The project's goal is to develop a digital platform for the company called "BookHub", a company that sells 
books of various genres. 

The platform should facilitate easy browsing and purchase of books, letting customers 
sort and filter by authors, publishers, and genres. After customers create accounts, they should be able to review 
their purchase history, rate books, and make wishlists. Administrators should have privileges to update book 
details, manage user accounts, and regulate book prices.

<img src="Resources/Images/logotype.png"  width="130" height="130">

### Authors
- Pavel Kraus (UČO 540455) - *Team Lead*
- Jakub Hlava (UČO 540477)
- Tomáš Kacvinský (UČO 485397)

### Prerequisites

- .NET 7.0 or later
- Visual Studio / Rider
- Node.js 18 or newer with npm

### Installation

1. Clone the repository to your local machine.
    ```
    git clone git@gitlab.fi.muni.cz:xkraus2/pv179-bookhub.git
    ```
2. Open the solution file `BookHub.sln` in editor of your choice.
3. Go to `WebMVC` folder and install frontend development dependencies by running `npm install`.
4. Build the solution to restore NuGet packages and compile the project.

## Usage

#### Important note: WebMVC frontend
MVC part of this project uses Tailwind CSS as frontend library.

Before running `WebMVC` project, you have to navigate into `WebMVC` folder and run `npm install`. This will install Tailwind CSS and other dependencies.
After that, the project will take care of building required CSS files.

If you are running in development environment, you may run `npm run css:watch` to start Tailwind's watch, so it rebuilds CSS files after every change automatically.

Otherwise, you can build CSS files manually by running `npm run css:build`. Note, that during full project build .NET takes care of this part automatically.

### Visual Studio

To run the application from within Visual Studio, follow these steps:

1. Open the `BookHub` project in Visual Studio.
2. In the toolbar, select `Debug` and then `Start Without Debugging`.
3. SwaggerUI should open automatically.

### Rider

To run the application from within Rider, follow these steps:

1. Open the `BookHub` project in Rider.
2. In the toolbar select `Run Bookhub http/https`.
3. SwaggerUI should open automatically.

### Command line

To run the application from within command line, follow these steps:

1. Execute command `dotnet run <path_to_bookhub_project>`.
2. After successful startup, the IP address with port will be outputted to the console.
3. You can connect to SwaggerUI on url `<IP:port_from_output/swagger/index.html>`.

## Configuration

### Logging

By default, BookHub logs incoming requests to standard output in a shortened version:\
`(Timestamp | IP:Port | HTTP method | URL path )`.

Alternatively, the logging can be extended by listing the request headers in the `appsettings.json` file 
in the `Logging:RequestLogging` section by setting `Detailed` to `true`.

### API authenticating

Authentication works by comparing a given Bearer token with a hardcoded Bearer token in the `appsettings.json` file int the 
`APIAuthorization:BearerToken` section.

## Technical overview

Our C# project is structured with a layered architecture, consisting of a Data Access layer, 
Presentation layer and Business Layer. These layers work in tandem to deliver the core functionality of the application.

- We use Entity Framework as our ORM (Object-Relational Mapping) framework to interact with the 
underlying database. 
- Currently, our database is implemented using SQLite, a lightweight, file-based relational 
database management system. 
- Database schema is visualized by a [Entity Relationship Diagram](#erd).

![](Resources/Images/technicalOverview.drawio.png)

## Diagrams

### Use Case

![Use Case](./Resources/Diagrams/UCD.png)

### ERD

![ERD](./Resources/Diagrams/ERD.png)
