FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

# Copy all .csproj files separately to leverage Docker cache
COPY ECommerce.sln ECommerce.sln
COPY src/Services/Ordering/Ordering.API/Ordering.API.csproj src/Services/Ordering/Ordering.API/Ordering.API.csproj
COPY src/Services/Ordering/Ordering.Application/Ordering.Application.csproj src/Services/Ordering/Ordering.Application/Ordering.Application.csproj
COPY src/Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj src/Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj
COPY src/Services/Ordering/Ordering.Domain/Ordering.Domain.csproj src/Services/Ordering/Ordering.Domain/Ordering.Domain.csproj
COPY src/Services/Catalog.API/Catalog.API.csproj src/Services/Catalog.API/Catalog.API.csproj
COPY src/Services/Basket.API/Basket.API.csproj src/Services/Basket.API/Basket.API.csproj
COPY src/Services/Discount.Grpc/Discount.Grpc.csproj src/Services/Discount.Grpc/Discount.Grpc.csproj
COPY src/BuildingBlocks/BuildingBlocks.csproj src/BuildingBlocks/BuildingBlocks.csproj

# Restore dependencies for the whole solution
RUN dotnet restore ECommerce.sln

# Copy all source code
COPY src/Services/Ordering/Ordering.API src/Services/Ordering/Ordering.API
COPY src/Services/Ordering/Ordering.Application src/Services/Ordering/Ordering.Application
COPY src/Services/Ordering/Ordering.Infrastructure src/Services/Ordering/Ordering.Infrastructure
COPY src/Services/Ordering/Ordering.Domain src/Services/Ordering/Ordering.Domain
COPY src/Services/Catalog.API src/Services/Catalog.API
COPY src/Services/Basket.API src/Services/Basket.API
COPY src/Services/Discount.Grpc src/Services/Discount.Grpc
COPY src/BuildingBlocks src/BuildingBlocks

# Build and publish only the Ordering.API project
WORKDIR /app/src/Services/Ordering/Ordering.API
RUN dotnet publish -c Release -o /app/src/out

# Final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "Ordering.API.dll" ]
