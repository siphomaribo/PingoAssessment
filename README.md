
# Client Management System

## Overview

The Client Management System is a web application built using Blazor and ASP.NET Core Web API. It allows users to manage client information, including creating, editing, and deleting clients. The system also includes functionality to export client data to a CSV file.

## Features

- **Client Management**: Add, edit, and delete client information.
- **Export Functionality**: Export client data to a CSV file.
- **Blazor Frontend**: Responsive UI built with Blazor.
- **ASP.NET Core Web API**: RESTful API for client data management.

## Technologies Used

- **Frontend**: Blazor, Bootstrap
- **Backend**: ASP.NET Core Web API
- **Database**: SQL Server (or specify if another is used)
- **Other**: Dependency Injection, Entity Framework Core (if used), etc.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or compatible database setup

## Setup

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/client-management-system.git
cd client-management-system
```

### 2. Configure the Database

Update the connection string in `appsettings.json` in the API project to point to your SQL Server instance.

### 3. Apply Migrations

If using Entity Framework Core, run the following command to apply database migrations:

```bash
dotnet ef database update
```

### 4. Run the Application

To run both the API and Blazor frontend:

```bash
dotnet run --project Pingo.WebAPI
dotnet run --project Pingo.Blazor
```

## Usage

### API Endpoints

- **Get All Clients**: `GET /api/Client`
- **Get Client By ID**: `GET /api/Client/{id}`
- **Add Client**: `POST /api/Client`
- **Update Client**: `PUT /api/Client`
- **Delete Client**: `DELETE /api/Client/{id}`
- **Export Clients to CSV**: `GET /api/Client/Export`

### Frontend

Navigate to the Blazor frontend (e.g., `https://localhost:5001`) to manage clients through the UI.

### Exporting to CSV

To export client data, use the export functionality available in the UI. The exported file will be saved in the project's root directory.

## Contributing

Contributions are welcome! Please fork this repository and submit a pull request for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Acknowledgements

- [Bootstrap](https://getbootstrap.com/)
- [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)

