# Container we use for final publish
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

ENV ConnectionStrings__PostgreSQLConnection "Host=paperless-db;Database=paperless;Username=paperless;Password=paperless"

COPY PaperLess.OCR/*.sln ./PaperLess.OCR/
COPY PaperLess.OCR/PaperLess.ServiceAgents/*.csproj ./PaperLess.OCR/PaperLess.ServiceAgents/
COPY PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/*.csproj ./PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/
COPY PaperLess.REST/PaperLess.Queue.Interfaces/*.csproj ./PaperLess.REST/PaperLess.Queue.Interfaces/
COPY PaperLess.REST/PaperLess.DataAccess.Entities/*.csproj ./PaperLess.REST/PaperLess.DataAccess.Entities/

RUN dotnet restore ./PaperLess.OCR/PaperLess.OCR.sln

COPY PaperLess.OCR/PaperLess.ServiceAgents/. ./PaperLess.OCR/PaperLess.ServiceAgents/
COPY PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/. ./PaperLess.OCR/PaperLess.ServiceAgents.Interfaces/
COPY PaperLess.REST/PaperLess.Queue.Interfaces/. ./PaperLess.REST/PaperLess.Queue.Interfaces/
COPY PaperLess.REST/PaperLess.DataAccess.Entities/. ./PaperLess.REST/PaperLess.DataAccess.Entities/

WORKDIR /app/PaperLess.OCR/PaperLess.ServiceAgents
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime

RUN apt-get update -y && apt-get install -y libc6-dev libgdiplus libx11-dev libleptonica-dev software-properties-common wget gnupg2 libleptonica-dev ghostscript
RUN apt-get update -y && apt-get install apt-transport-https -y
RUN tee /etc/apt/sources.list.d/notesalexp.list<<EOF
RUN echo "deb https://notesalexp.org/tesseract-ocr5/$(lsb_release -cs)/ $(lsb_release -cs) main" \
    | tee /etc/apt/sources.list.d/notesalexp.list > /dev/null
RUN wget -O - https://notesalexp.org/debian/alexp_key.asc | apt-key add - 
RUN apt-get update -y && apt-get install tesseract-ocr -y    
RUN ls -la /usr/lib/x86_64-linux-gnu

WORKDIR /app
COPY --from=build /app/PaperLess.OCR/PaperLess.ServiceAgents/out ./
COPY --from=build /app/PaperLess.OCR/PaperLess.ServiceAgents/tessdata ./tessdata/


RUN ln -s /usr/lib/x86_64-linux-gnu/liblept.so.5 /app/x64/libleptonica-1.82.0.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.5 /app/x64/libtesseract50.so

ENTRYPOINT [ "dotnet", "PaperLess.ServiceAgents.dll" ]


