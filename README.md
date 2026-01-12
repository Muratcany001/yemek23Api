# ApiYemek23

A small ASP.NET Core Web API for managing users, restaurants and orders. The project uses Entity Framework Core (SQL Server) for persistence and JWT for authentication. The DbContext seeds a set of restaurants on model creation.

Table of contents
- Project overview
- Tech stack & prerequisites
- Configuration (appsettings & secrets)
- Build & run (local)
- Database migrations
- Docker (build & run)
- API Reference & Examples
  - Authentication (register, login, logout, protected endpoint)
  - Users (balances, favorites)
  - Restaurants (list, get, add, delete)
  - Orders (create, get, update, delete)
- Using the ApiYemek23.http (VSCode REST Client)
- Troubleshooting
- Contributing
- License

Project overview
This repository contains ApiYemek23 — an ASP.NET Core 8 Web API project with:
- User management (register/login, balance, favorites)
- Restaurant management (seeded restaurants, add/delete, lookup)
- Order workflow (create, update, get, delete)
- JWT authentication for protected endpoints
- EF Core DbContext with seed data (see ApiYemek23/Entities/Context.cs)

Tech stack & prerequisites
- .NET 8 SDK (dotnet 8.x) — install from https://dotnet.microsoft.com
- SQL Server (local or remote) — connection string in appsettings.json
- (Optional) Docker — for container builds
- (Optional) dotnet-ef tool for EF Core migrations:
  - dotnet tool install --global dotnet-ef

Project files of interest
- ApiYemek23/Program.cs — app startup, DI, JWT configuration, CORS
- ApiYemek23/Entities/Context.cs — EF Core DbContext and seeded restaurants
- ApiYemek23/Controllers/* — API endpoints for Users, Restaurants, Orders
- ApiYemek23/appsettings.json — example connection string
- ApiYemek23/Dockerfile — Docker image build (Windows nanoserver)
- ApiYemek23/ApiYemek23.http — example request(s)

Configuration
appsettings.json contains an example SQL Server connection string:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-KP4MLAD\\MURAT;Database=testApiDB;TrustServerCertificate=True;Trusted_Connection=True;"
  }
}
Update the connection string to point to your SQL Server (local or remote). Example (local SQL Server instance on this machine):
"DefaultConnection": "Server=localhost;Database=ApiYemek23Db;Trusted_Connection=True;TrustServerCertificate=True;"

JWT and secrets
The project currently has placeholder/hardcoded JWT values in Program.cs and UserController (issuer, audience, and a secret key). Do not use hardcoded secrets in production.

Recommended approach:
- Add these to appsettings.json or better use environment variables or dotnet user-secrets:
  - JWT__Issuer
  - JWT__Audience
  - JWT__Secret (a long, high-entropy secret)
- Update Program.cs to read configuration values:
  - builder.Configuration["JWT:Issuer"] etc.

Examples below show environment variables usage when running.

Build & run (local)
1. Clone the repository:
   git clone https://github.com/<your-user>/yemek23Api.git
   cd yemek23Api/ApiYemek23

2. Restore dependencies and build:
   dotnet restore
   dotnet build

3. (Optional) Apply EF Core migrations (see below)

4. Run the API:
   dotnet run

By default Kestrel will start; check the console output for the listening URL (or use the launchSettings.json). The repo contains an ApiYemek23.http with an example host.

Database setup & migrations
If you want to apply migrations / create DB schema:
1. Install EF tools (if not already):
   dotnet tool install --global dotnet-ef

2. From the ApiYemek23 project folder:
   dotnet ef database update

Notes:
- The project already contains a Migrations folder. If you alter the models, create a new migration:
  dotnet ef migrations add YourMigrationName
  dotnet ef database update

Seed data:
- Context.OnModelCreating seeds 20 restaurants. After applying migrations and updating the database, these seeded restaurants will be present.

Docker
The included Dockerfile targets Windows nanoserver images (mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809). This works on Windows containers only; on Linux hosts you'll either run Windows containers or use a Linux-based Dockerfile.

Build (Windows containers):
docker build -t api-yemek23:latest .

Run (map port 8080):
docker run -d -p 8080:8080 --name api-yemek23 api-yemek23:latest

Note: The Dockerfile EXPOSEs 8080 and 8081. Ensure the app listens on the same port (or map accordingly).

Linux-friendly alternate Dockerfile (if you prefer Linux images)
Replace the FROM lines with Linux images (this snippet can replace the top of Dockerfile):
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# ... rest of the Dockerfile unchanged

Then build and run:
docker build -t api-yemek23-linux:latest .
docker run -d -p 8080:80 api-yemek23-linux:latest

API reference & examples
General
- All endpoints are prefixed by their route attribute as defined in controllers (some are absolute). Use the JSON examples below when invoking endpoints.

Authentication / Users
Register
- POST /users/register
- Body: User object (JSON)
Example:
curl -X POST http://localhost:5291/users/register \
  -H "Content-Type: application/json" \
  -d '{
    "User_Name":"Alice",
    "User_Email":"alice@example.com",
    "User_Password":"P@ssw0rd",
    "UserBalance": 100
  }'

Login
- POST /users/login
- Body: { "mail": "alice@example.com", "password": "P@ssw0rd" }
Example:
curl -X POST http://localhost:5291/users/login \
  -H "Content-Type: application/json" \
  -d '{"mail":"alice@example.com","password":"P@ssw0rd"}'

Response:
{
  "token": "<JWT token here>"
}

Using the token
- Include the token in the Authorization header for protected endpoints:
  Authorization: Bearer <token>

Logout
- POST /logout
- Requires Authorization header
Example:
curl -X POST http://localhost:5291/logout -H "Authorization: Bearer <token>"

Protected endpoint example:
GET /protected-endpoint
Requires Authorization header:
curl -H "Authorization: Bearer <token>" http://localhost:5291/protected-endpoint

Users: balance & favorites
- GET /users — list users
- GET /users/{id}/balance — get balance
- PATCH /users/{id}/balance — set balance (body: numeric decimal)
Example:
curl -X PATCH http://localhost:5291/users/1/balance \
  -H "Content-Type: application/json" \
  -d "150.50"

Favorites:
- GET /users/{id}/favorites — get favorite restaurants (returns Restaurant full objects)
- POST /users/{id}/favorites — add favorite
  Body: { "User_Id": 1, "Restaurant_Id": 3 }
Example:
curl -X POST http://localhost:5291/users/1/favorites \
  -H "Content-Type: application/json" \
  -d '{"User_Id":1,"Restaurant_Id":3}'

Restaurants
- GET /restaurants — list all restaurants
curl http://localhost:5291/restaurants

- GET /restaurants/name/{name} — get restaurant by name
curl http://localhost:5291/restaurants/name/%22Pizza%20Pizza%22

- GET /restaurants/id/{id} — get by id
curl http://localhost:5291/restaurants/id/10

- POST /restaurants — add a restaurant
Body example (matching Restaurant model):
{
  "Restaurant_code":"abc123",
  "Restaurant_Name":"New Resto",
  "Restaurant_Location":"Some Address",
  "Restaurant_Phone_Number":"+90...",
  "Restaurant_Coordinates":"38.67,39.22",
  "Restaurant_Rating":4
}
curl -X POST http://localhost:5291/restaurants \
  -H "Content-Type: application/json" \
  -d '{ ... }'

- DELETE /restaurants/{id}
curl -X DELETE http://localhost:5291/restaurants/5

Orders
- POST /orders — create an order
  Body (Order):
  {
    "RestaurantId": 2,
    "UserId": 1,
    "OrderDate": "2025-01-01T12:00:00",
    "TotalAmount": 45.99,
    "Status": "Pending"
  }
Example:
curl -X POST http://localhost:5291/orders \
  -H "Content-Type: application/json" \
  -d '{ "RestaurantId": 2, "UserId": 1, "OrderDate": "2025-01-01T12:00:00", "TotalAmount": 45.99, "Status":"Pending" }'

- GET /orders/{id}
curl http://localhost:5291/orders/3

- PATCH /orders — update an order (pass entire Order object)
curl -X PATCH http://localhost:5291/orders \
  -H "Content-Type: application/json" \
  -d '{ "OrderId":3, "RestaurantId":2, "UserId":1, "OrderDate":"2025-01-01T12:00:00", "TotalAmount":45.99, "Status":"Completed" }'

- DELETE /orders/{id}
curl -X DELETE http://localhost:5291/orders/3

ApiYemek23.http (VSCode REST Client)
The repository includes ApiYemek23/ApiYemek23.http - a single example. You can expand this file with additional requests and use the VSCode REST Client extension to execute them.

Troubleshooting
- Cannot connect to SQL Server:
  - Ensure the connection string is correct, SQL Server is running, and firewall allows connections.
  - For local development use Trusted_Connection or SQL authentication as appropriate.

- Docker build fails due to image platform:
  - The provided Dockerfile uses Windows nanoserver images. On Linux hosts, build will fail. Use the Linux-friendly Dockerfile snippet above or switch Docker to Windows containers if running on Windows with support for Windows containers.

- EF migrations command not found:
  - Install dotnet-ef: dotnet tool install --global dotnet-ef
  - Or run migrations through Visual Studio Package Manager Console.

Security & production notes
- Replace hardcoded JWT secrets and configuration values with environment variables, Azure KeyVault, or dotnet user-secrets.
- Use HTTPS in production and secure your connection strings.
- Review CORS policy in Program.cs (currently configured to allow http://localhost:4200).

Contributing
- Feel free to open issues or submit pull requests.
- Coding style: follow C# conventions and update migrations if data model changes.
- Prefer safe handling of secrets and avoid committing credentials.

License
- No license file in repository. If you plan to share this project, consider adding a LICENSE (MIT, Apache-2.0, etc.).

Contact
- For questions or further guidance, open an issue in the repository.
