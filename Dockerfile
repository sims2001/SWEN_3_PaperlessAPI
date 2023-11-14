FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app
EXPOSE 8081 

# Container we use for final publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

#ENV ASPNETCORE_URLS=http://*:8081
# ENV ASPNETCORE_ENVIRONMENT=Development

# Copy the code into the container
WORKDIR /app/src
COPY PaperLess.sln .
COPY PaperLess.WebApi/PaperLess.WebApi.csproj PaperLess.WebApi/
COPY PaperLess.BusinessLogic.Interfaces/PaperLess.BusinessLogic.Interfaces.csproj PaperLess.BusinessLogic.Interfaces/
COPY PaperLess.BusinessLogic.Entities/PaperLess.BusinessLogic.Entities.csproj PaperLess.BusinessLogic.Entities/
COPY PaperLess.BusinessLogic/PaperLess.BusinessLogic.csproj PaperLess.BusinessLogic/

# NuGet restore
RUN dotnet restore

COPY . .

# Build the application
WORKDIR /src/PaperLess.WebApi
RUN dotnet build -c Release -o /app


# Publish the application
FROM build AS publish
RUN dotnet publish -c Release -o /app

# Build the final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaperLess.WebApi.dll"]
