# Container we use for final publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY *.sln .
COPY PaperLess.WebApi/*.csproj ./PaperLess.WebApi/
COPY PaperLess.BusinessLogic.Interfaces/*.csproj ./PaperLess.BusinessLogic.Interfaces/
COPY PaperLess.BusinessLogic.Entities/*.csproj ./PaperLess.BusinessLogic.Entities/
COPY PaperLess.BusinessLogic/*.csproj ./PaperLess.BusinessLogic/

RUN dotnet restore

COPY PaperLess.WebApi/. ./PaperLess.WebApi/
COPY PaperLess.BusinessLogic.Interfaces/. ./PaperLess.BusinessLogic.Interfaces/
COPY PaperLess.BusinessLogic.Entities/. ./PaperLess.BusinessLogic.Entities/
COPY PaperLess.BusinessLogic/. ./PaperLess.BusinessLogic/

WORKDIR /app/PaperLess.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

COPY --from=build /app/PaperLess.WebApi/out ./

ENTRYPOINT ["dotnet", "PaperLess.WebApi.dll"]
