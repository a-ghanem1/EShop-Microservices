FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

COPY ECommerce.sln ECommerce.sln
COPY src/Services/Basket.API/Basket.API.csproj src/Services/Basket.API/Basket.API.csproj
COPY src/Services/Catalog.API/Catalog.API.csproj src/Services/Catalog.API/Catalog.API.csproj
COPY src/Services/Discount.Grpc/Discount.Grpc.csproj src/Services/Discount.Grpc/Discount.Grpc.csproj
COPY src/Services/Ordering/Ordering.API/Ordering.API.csproj src/Services/Ordering/Ordering.API/Ordering.API.csproj
COPY src/Services/Ordering/Ordering.Application/Ordering.Application.csproj src/Services/Ordering/Ordering.Application/Ordering.Application.csproj
COPY src/Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj src/Services/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj
COPY src/Services/Ordering/Ordering.Domain/Ordering.Domain.csproj src/Services/Ordering/Ordering.Domain/Ordering.Domain.csproj
COPY src/WebApps/Shopping.Web/Shopping.Web.csproj src/WebApps/Shopping.Web/Shopping.Web.csproj
COPY src/ApiGateway/ApiGateway.csproj src/ApiGateway/ApiGateway.csproj
COPY src/BuildingBlocks/BuildingBlocks.csproj src/BuildingBlocks/BuildingBlocks.csproj
COPY src/BuildingBlocks.Messaging/BuildingBlock.Messaging.csproj src/BuildingBlocks.Messaging/BuildingBlock.Messaging.csproj

RUN dotnet restore ECommerce.sln

COPY src/ src/
WORKDIR /app/src/ApiGateway
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]
