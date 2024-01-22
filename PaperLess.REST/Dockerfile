# Container we use for final publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

ENV ConnectionStrings__PostgreSQLConnection "Host=paperless-db;Database=paperless;Username=paperless;Password=paperless"

COPY *.sln .
COPY PaperLess.WebApi/*.csproj ./PaperLess.WebApi/
COPY PaperLess.WebApi.Entities/*.csproj ./PaperLess.WebApi.Entities/
COPY PaperLess.BusinessLogic.Interfaces/*.csproj ./PaperLess.BusinessLogic.Interfaces/
COPY PaperLess.BusinessLogic.Entities/*.csproj ./PaperLess.BusinessLogic.Entities/
COPY PaperLess.BusinessLogic/*.csproj ./PaperLess.BusinessLogic/
COPY PaperLess.DataAccess.Interfaces/*.csproj ./PaperLess.DataAccess.Interfaces/
COPY PaperLess.DataAccess.Entities/*.csproj ./PaperLess.DataAccess.Entities/
COPY PaperLess.DataAccess.SQL/*.csproj ./PaperLess.DataAccess.SQL/
COPY PaperLess.Elastic.Interfaces/*.csproj ./PaperLess.Elastic.Interfaces/
COPY PaperLess.Queue.Interfaces/*.csproj ./PaperLess.Queue.Interfaces/

RUN dotnet restore

COPY PaperLess.WebApi/. ./PaperLess.WebApi/
COPY PaperLess.WebApi.Entities/. ./PaperLess.WebApi.Entities/
COPY PaperLess.BusinessLogic.Interfaces/. ./PaperLess.BusinessLogic.Interfaces/
COPY PaperLess.BusinessLogic.Entities/. ./PaperLess.BusinessLogic.Entities/
COPY PaperLess.BusinessLogic/. ./PaperLess.BusinessLogic/
COPY PaperLess.DataAccess.Interfaces/. ./PaperLess.DataAccess.Interfaces/
COPY PaperLess.DataAccess.Entities/. ./PaperLess.DataAccess.Entities/
COPY PaperLess.DataAccess.SQL/. ./PaperLess.DataAccess.SQL/
COPY PaperLess.Elastic.Interfaces/. ./PaperLess.Elastic.Interfaces/
COPY PaperLess.Queue.Interfaces/. ./PaperLess.Queue.Interfaces/

WORKDIR /app/PaperLess.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

COPY --from=build /app/PaperLess.WebApi/out ./

ENTRYPOINT ["dotnet", "PaperLess.WebApi.dll"]
