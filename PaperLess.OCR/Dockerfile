# Container we use for final publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

ENV ConnectionStrings__PostgreSQLConnection "Host=paperless-db;Database=paperless;Username=paperless;Password=paperless"

COPY PaperLess.OCR/*.sln ./PaperLess.OCR/
COPY PaperLess.OCR/PaperLess.ServiceAgents/*.csproj ./PaperLess.OCR/PaperLess.ServiceAgents/
COPY PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/*.csproj ./PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/
COPY PaperLess.REST/PaperLess.Queue.Interfaces/*.csproj ./PaperLess.REST/PaperLess.Queue.Interfaces/

RUN ls

RUN dotnet restore ./PaperLess.OCR/PaperLess.OCR.sln

COPY PaperLess.OCR/PaperLess.ServiceAgents/. ./PaperLess.OCR/PaperLess.ServiceAgents/
COPY PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/. ./PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/
COPY PaperLess.REST/PaperLess.Queue.Interfaces/. ./PaperLess.REST/PaperLess.Queue.Interfaces/

WORKDIR /app/PaperLess.OCR/PaperLess.ServiceAgents
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

COPY --from=build /app/PaperLess.OCR/PaperLess.ServiceAgents/out ./

ENTRYPOINT [ "dotnet", "PaperLess.ServiceAgents.dll" ]

# COPY PaperLess.WebApi/. ./PaperLess.WebApi/
# COPY PaperLess.WebApi.Entities/. ./PaperLess.WebApi.Entities/
# COPY PaperLess.BusinessLogic.Interfaces/. ./PaperLess.BusinessLogic.Interfaces/
# COPY PaperLess.BusinessLogic.Entities/. ./PaperLess.BusinessLogic.Entities/
# COPY PaperLess.BusinessLogic/. ./PaperLess.BusinessLogic/
# COPY PaperLess.DataAccess.Interfaces/. ./PaperLess.DataAccess.Interfaces/
# COPY PaperLess.DataAccess.Entities/. ./PaperLess.DataAccess.Entities/
# COPY PaperLess.DataAccess.SQL/. ./PaperLess.DataAccess.SQL/
# COPY PaperLess.Queue.Interfaces/. ./PaperLess.Queue.Interfaces/

# WORKDIR /app/PaperLess.WebApi
# RUN dotnet publish -c Release -o out

# FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
# WORKDIR /app

# COPY --from=build /app/PaperLess.WebApi/out ./
#C OPY entrypoint.sh .

# ENTRYPOINT ["dotnet", "PaperLess.WebApi.dll"]
