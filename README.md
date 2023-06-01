# Powerplant-coding-challenge

The task at hand was to determine the specific power requirements for numerous distinct power plants.

Prerequisites:
- .Net 6
- Docker (optional)

1. Clone the Repository:
- clone the repository on your local machine


2. Building the Project:

Option 1: Without Docker:
If you prefer running the application without Docker, follow these steps:
- Open the directory containing the API application: `powerplant-coding-challenge/WebAppPowerPlant/WebAppPowerPlant`.
- Launch the command prompt (cmd) within this directory.
- Execute the command `dotnet build` to build the application.
- Execute the command `dotnet run` to run the application.
  - The API will be accessible on port 8888.
  - Ensure that you have the .NET 6SDK installed.
  - Swagger is configured for easy documentation and testing purposes.

Option 2: With Docker:
If you prefer running the application using Docker, you can build and run a Docker container.
Build the Docker image using the following command:
```
docker build -t imageName .
```
Run the Docker container using the following command:
```
docker run -p 8888:8888 imageName
```

The Engie Powerplant Coding Challenge API provides endpoints for managing the production plan. Interact with the API using tools such as Postman or Swagger.

To access the API, utilize the following base URLs:
- Via Swagger: http://0.0.0.0:8888/swagger/index.html
- Via Postman: http://0.0.0.0:8888/ProductionPlan

Conclusion:
You are now ready to use the PowerPlant api endpoint !
