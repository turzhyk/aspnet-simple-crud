# Используем официальный .NET 10 SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src
COPY *.sln ./
COPY OrderStore.Application/OrderStore.Application.csproj OrderStore.Application/
COPY OrderStore.Core/OrderStore.Core.csproj OrderStore.Core/
COPY OrderStore.DataAccess/OrderStore.DataAccess.csproj OrderStore.DataAccess/
COPY WebApplication1/WebApplication1.csproj WebApplication1/

RUN dotnet restore

COPY . .
WORKDIR /src/WebApplication1
RUN dotnet publish -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5092
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
