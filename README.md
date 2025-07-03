# innafor-2025
# Cluster Management API
Her burde det stå noe på norsk om in
## Prerequisites

Choose one of the following setup methods:

### Option 1: Docker (Recommended)
- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

### Option 2: Manual Setup
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL 16](https://www.postgresql.org/download/)

## Getting Started

### Option 1: Running with Docker Compose (Recommended)

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd ClusterManagement
   ```

2. **Start the application**
   ```bash
   docker-compose up -d
   ```

   This will:
   - Start a PostgreSQL database container
   - Build and run the ASP.NET Core application
   - Automatically apply database migrations

3. **Access the application**
   - API: http://localhost:5164
   - Swagger Documentation: http://localhost:5164/swagger

4. **Stop the application**
   ```bash
   docker-compose down
   ```

### Option 2: Manual Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd egiClusterManagement
   ```

2. **Setup PostgreSQL Database**
   - Install PostgreSQL 16
   - Create a database named `cluster_management`
   - Update the connection string in `ClusterManagement/appsettings.json` if needed

3. **Install .NET SDK and Entity Framework tools**
   ```bash
   # Install .NET 8.0 SDK (if not already installed)
   # Then install EF Core tools:
   dotnet tool install --create-manifest-if-needed dotnet-ef
   dotnet tool restore
   ```

4. **Install dependencies and run**
   ```bash
   cd ClusterManagement
   dotnet restore
   dotnet run
   ```

5. **Apply database migrations** (if needed)
   ```bash
   dotnet ef database update
   ```

6. **Access the application**
   - API: http://localhost:5164
   - Swagger Documentation: http://localhost:5164/swagger

## Development


### Database Migrations

To create a new migration:
```bash
cd ClusterManagement
dotnet ef migrations add <MigrationName>
```

To apply migrations:
```bash
dotnet ef database update
```

### Environment Configuration

The application uses different configuration files:
- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development overrides

### API Endpoints

The API includes the following main controllers:
- `/api/admin` - Administrative functions
- `/api/cluster` - Cluster management
- `/api/clusteruser` - User management
- `/api/message` - Messaging system
- `/api/onewayinopportunity` - Opportunity management

## Architecture

The project follows clean architecture principles:
- **Controllers**: Handle HTTP requests and responses
- **Services**: Business logic layer
- **Repositories**: Data access layer
- **Models**: Entity definitions and data models

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Database**: PostgreSQL 16
- **ORM**: Entity Framework Core 9.0.6
- **Documentation**: Swagger/OpenAPI
- **Containerization**: Docker & Docker Compose

## Troubleshooting

### Docker Issues
- Ensure Docker is running
- Check port 5164 is not in use by another application
- Run `docker-compose logs` to view application logs

### Database Issues
- Verify PostgreSQL is running (Docker: `docker-compose ps`)
- Check connection string in configuration files
- Ensure database migrations are applied

### Build Issues
- Ensure .NET 8.0 SDK is installed
- Run `dotnet restore` to restore NuGet packages
- Check for any compilation errors with `dotnet build`

---

## Original Notes
dotnet tool install --create-manifest-if-needed dotnet-ef

