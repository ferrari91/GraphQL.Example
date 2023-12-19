#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GraphQL.Example/GraphQL.Example.csproj", "GraphQL.Example/"]
COPY ["GraphQL.Example.Core.Application/GraphQL.Example.Core.Application.csproj", "GraphQL.Example.Core.Application/"]
COPY ["GraphQL.Example.Core.Domain/GraphQL.Example.Core.Domain.csproj", "GraphQL.Example.Core.Domain/"]
COPY ["GraphQL.Example.Infrastructure/GraphQL.Example.Infrastructure.csproj", "GraphQL.Example.Infrastructure/"]
RUN dotnet restore "./GraphQL.Example/./GraphQL.Example.csproj"
COPY . .
WORKDIR "/src/GraphQL.Example"
RUN dotnet build "./GraphQL.Example.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GraphQL.Example.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQL.Example.dll"]

# Add the following line to include the SQLite command in the Dockerfile
RUN apt-get update && apt-get install -y sqlite3