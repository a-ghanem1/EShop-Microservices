FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
EXPOSE 80

# copy all .csproj files and restore as distinct layers.  Use the same COPY
# for every dockerfile in the project to take advantage of Docker caching
COPY ECommerce.sln ECommerce.sln
COPY src/Services/Catalog.API/Catalog.API.csproj src/Services/Catalog.API/Catalog.API.csproj
COPY src/Services/Basket.API/Basket.API.csproj src/Services/Basket.API/Basket.API.csproj
COPY src/Services/Discount.Grpc/Discount.Grpc.csproj src/Services/Discount.Grpc/Discount.Grpc.csproj
COPY src/BuildingBlocks/BuildingBlocks.csproj src/BuildingBlocks/BuildingBlocks.csproj

RUN dotnet restore ECommerce.sln

COPY src/Services/Catalog.API src/Services/Catalog.API
COPY src/Services/Basket.API src/Services/Basket.API
COPY src/Services/Discount.Grpc src/Services/Discount.Grpc
COPY src/BuildingBlocks src/BuildingBlocks

WORKDIR /app/src/Services/Basket.API
RUN dotnet publish -c Release -o /app/src/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "Basket.API.dll" ]