# Device Management System

A web application for managing devices, including functionalities to create, edit, view, and delete devices, along with managing device categories and properties.

## Technologies Used

- **ASP.NET Core**: Backend framework for building web applications.
- **Entity Framework Core**: ORM for database interactions.
- **SQL Server**: Database management system for storing application data.
- **Razor Pages**: For dynamic web pages.
- **HTML/CSS**: For frontend structure and styling.

## Features

- Create new devices with detailed information.
- Edit existing device details.
- View a list of all devices.
- Delete devices with confirmation.
- Manage device categories and their associated properties.

## Setup Instructions

1. **Clone the repository**:
   git clone https://github.com/mohamedmhares/Linked-Gates-Assignment.git
   cd your BreadcrumbsLinked-Gates-Assignment
- Install dependencies: Ensure you have the latest version of .NET Core SDK installed. Use the following command to restore dependencies:
- dotnet restore
- Set up the database:
  . Create a SQL Server database.
  . Update the connection string in the appsettings.json file to point to your database.
  . Run migrations to set up the database schema:
    -dotnet ef database update
- Run the application:
  . dotnet run

### 5. Usage
```markdown
## Usage

1. Open your web browser and navigate to `http://localhost:5000`.
2. Use the navigation menu to create, view devices.
3. Select a device category to view its properties and add corresponding values when creating a device.

## Code Structure
- Controllers/: Contains the controller classes handling requests and responses.
- Core/: Includes the entity classes and interfaces.
- Infrastructure/: Data access implementations, repositories, and DbContext.
- Application/: Contains service implementations and business logic.

## Contribution Guidelines

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-YourFeature`).
3. Make your changes and commit them (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature-YourFeature`).
5. Open a Pull Request.



