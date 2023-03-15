FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/VenueHosting.Api.Host/VenueHosting.Api.Host.csproj", "src/VenueHosting.Api.Host/"]
RUN dotnet restore "src/VenueHosting.Api.Host/VenueHosting.Api.Host.csproj"
COPY . .
WORKDIR "/src/src/VenueHosting.Api.Host"
RUN dotnet build "VenueHosting.Api.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VenueHosting.Api.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VenueHosting.Api.Host.dll"]
