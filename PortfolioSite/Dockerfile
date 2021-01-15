#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["PortfolioSite/PortfolioSite.csproj", "PortfolioSite/"]
COPY ["PortfolioSite.Common/PortfolioSite.Common.csproj", "PortfolioSite.Common/"]
COPY ["PortfolioSite.Infrastructure/PortfolioSite.Infrastructure.csproj", "PortfolioSite.Infrastructure/"]
COPY ["PortfolioSite.App/PortfolioSite.App.csproj", "PortfolioSite.App/"]
COPY ["PortfolioSite.Domain/PortfolioSite.Domain.csproj", "PortfolioSite.Domain/"]
COPY ["PortfolioSite.Persistance/PortfolioSite.Persistance.Postgres.csproj", "PortfolioSite.Persistance/"]
RUN dotnet restore "PortfolioSite/PortfolioSite.csproj"
COPY . .
WORKDIR "/src/PortfolioSite"
RUN dotnet build "PortfolioSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortfolioSite.dll"]