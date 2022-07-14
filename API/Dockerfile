#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app/src
COPY *.sln .
COPY ["HelloWorld.API/HelloWorld.API.csproj", "HelloWorld.API/"]
COPY ["HelloWorld.Domain/HelloWorld.Domain.csproj", "HelloWorld.Domain/"]
COPY ["HelloWorld.Infrastructure/HelloWorld.Infrastructure.csproj", "HelloWorld.Infrastructure/"]
COPY ["HelloWorld.Shared/HelloWorld.Shared.csproj", "HelloWorld.Shared/"]
COPY ["HelloWorld.IntegrationTests/HelloWorld.IntegrationTests.csproj", "HelloWorld.IntegrationTests/"]
COPY ["HelloWorld.Tests/HelloWorld.Tests.csproj", "HelloWorld.Tests/"]
COPY *.dcproj .
RUN dotnet restore HelloWorld.sln

COPY . .
WORKDIR /app/src/HelloWorld.API
RUN dotnet build

FROM build AS testrunner
WORKDIR /app/src/HelloWorld.Tests
CMD ["dotnet", "test", "--logger:trx"]

FROM build AS integrationtestrunner
EXPOSE 80
EXPOSE 443
WORKDIR /app/src/HelloWorld.IntegrationTests
CMD ["dotnet", "test", "--logger:trx"]

FROM build AS test
WORKDIR /app/src/HelloWorld.Tests/
RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /app/src/HelloWorld.API/
RUN dotnet publish "HelloWorld.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.API.dll"]