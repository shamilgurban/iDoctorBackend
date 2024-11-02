#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentation/iDoctor.Api/iDoctor.Api.csproj", "Presentation/iDoctor.Api/"]
COPY ["Core/iDoctor.Application/iDoctor.Application.csproj", "Core/iDoctor.Application/"]
COPY ["Core/iDoctor.Domain/iDoctor.Domain.csproj", "Core/iDoctor.Domain/"]
COPY ["Infrastructure/iDoctor.Persistence/iDoctor.Persistence.csproj", "Infrastructure/iDoctor.Persistence/"]
RUN dotnet restore "./Presentation/iDoctor.Api/iDoctor.Api.csproj"
COPY . .
WORKDIR "/src/Presentation/iDoctor.Api"
RUN dotnet build "./iDoctor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./iDoctor.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iDoctor.Api.dll", "--server.urls", "http://0.0.0.0:8080;http://0.0.0.0:8081"]