# Stage 1: Build the application
# Use the official .NET 6 SDK image, which contains all the tools needed to build your project.
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Copy all the .csproj files and the .sln file first.
# This leverages Docker's layer caching. If these files don't change,
# Docker won't need to re-run the 'dotnet restore' step on subsequent builds.
COPY ["*.sln", "./"]
COPY ["src/SchoolManagementSystem.API/SchoolManagementSystem.API.csproj", "src/SchoolManagementSystem.API/"]
COPY ["src/SchoolManagementSystem.Domain/SchoolManagementSystem.Domain.csproj", "src/SchoolManagementSystem.Domain/"]
COPY ["src/SchoolManagementSystem.Infrastructure/SchoolManagementSystem.Infrastructure.csproj", "src/SchoolManagementSystem.Infrastructure/"]
COPY ["src/SchoolManagementSystem.Application/BusinessLogic/SchoolManagementSystem.Application.BusinessLogic.csproj", "src/SchoolManagementSystem.Application/BusinessLogic/"]
COPY ["src/SchoolManagementSystem.Application/Authentication/SchoolManagementSystem.Application.Authentication.csproj", "src/SchoolManagementSystem.Application/Authentication/"]

# Restore all the NuGet packages.
RUN dotnet restore "school-management-system.sln"

# Copy the rest of the source code into the container.
COPY . .

# Publish the application, creating a release build.
# The output will be placed in the /app/publish directory.
WORKDIR "/src/src/SchoolManagementSystem.API"
RUN dotnet publish "SchoolManagementSystem.API.csproj" -c Release -o /app/publish

# ---

# Stage 2: Create the final, small production image
# Use the much smaller ASP.NET 6 runtime image, which is optimized for running the application.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

# Copy the published build output from the 'build' stage.
COPY --from=build /app/publish .

# Expose the port the application will run on.
# By default, ASP.NET Core apps run on port 80 inside a container.
EXPOSE 80

# Define the command to run the application when the container starts.
ENTRYPOINT ["dotnet", "SchoolManagementSystem.API.dll"]