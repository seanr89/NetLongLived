FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . .

# Copy csproj and restore as distinct layers
RUN dotnet restore BackgroundConsole.csproj

# Copy everything else and build
COPY . .
RUN dotnet publish BackgroundConsole.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BackgroundConsole.dll"]