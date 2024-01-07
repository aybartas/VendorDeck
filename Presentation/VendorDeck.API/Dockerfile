#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/VendorDeck.API/VendorDeck.API.csproj", "Presentation/VendorDeck.API/"]
COPY ["Core/VendorDeck.Application/VendorDeck.Application.csproj", "Core/VendorDeck.Application/"]
COPY ["Core/VendorDeck.Domain/VendorDeck.Domain.csproj", "Core/VendorDeck.Domain/"]
COPY ["Infrastructure/VendorDeck.Infrastructure/VendorDeck.Infrastructure.csproj", "Infrastructure/VendorDeck.Infrastructure/"]
COPY ["Infrastructure/VendorDeck.Persistence/VendorDeck.Persistence.csproj", "Infrastructure/VendorDeck.Persistence/"]
RUN dotnet restore "./Presentation/VendorDeck.API/./VendorDeck.API.csproj"
COPY . .
WORKDIR "/src/Presentation/VendorDeck.API"
RUN dotnet build "./VendorDeck.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VendorDeck.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VendorDeck.API.dll"]