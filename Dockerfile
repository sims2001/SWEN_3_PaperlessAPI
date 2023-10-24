# Container we use for final publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV ASPNETCORE_URLS=http://*:8081
# ENV ASPNETCORE_ENVIRONMENT=Development

# Copy the code into the container
WORKDIR /app/src
COPY ./src/PaperLessApi .

# NuGet restore
RUN dotnet restore

ENTRYPOINT dotnet watch run
