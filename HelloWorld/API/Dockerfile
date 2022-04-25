FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app/API
COPY API/*.csproj ./
COPY Infrastructure/*.csproj ../Infrastructure/
COPY Domain/*.csproj ../Domain/

RUN dotnet restore

COPY API/. ./
COPY Infrastructure/. ../Infrastructure/
COPY Domain/. ../Domain/

RUN dotnet publish -c Development -o out Api.csproj

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/API/out .
ENTRYPOINT ["dotnet", "Api.dll"]