FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /parking

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "parking.sln" "parking.sln"

COPY "src/Services/Parking/ParkingLots.API/ParkingLots.API.csproj" "src/Services/Parking/ParkingLots.API/ParkingLots.API.csproj"
COPY "src/Services/Parking/ParkingLots.Domain/ParkingLots.Domain.csproj" "src/Services/Parking/ParkingLots.Domain/ParkingLots.Domain.csproj"
COPY "src/Services/Parking/ParkingLots.Application/ParkingLots.Application.csproj" "src/Services/Parking/ParkingLots.Application/ParkingLots.Application.csproj"
COPY "src/Services/Parking/ParkingLots.Infrastructure/ParkingLots.Infrastructure.csproj" "src/Services/Parking/ParkingLots.Infrastructure/ParkingLots.Infrastructure.csproj"

RUN dotnet restore "parking.sln"

COPY . .
WORKDIR /parking/src/Services/Parking/ParkingLots.API
RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ParkingLots.API.dll"]
