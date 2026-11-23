
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY ["SpeedTestServer.csproj", "./"]
RUN dotnet restore "SpeedTestServer.csproj"

# Copy source files and publish
COPY . .
RUN dotnet publish "SpeedTestServer.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

# Render supplies its own port through PORT
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 10000

ENTRYPOINT ["dotnet", "SpeedTestServer.dll"]
