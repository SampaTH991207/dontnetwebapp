# Use the official .NET image as a base
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["dotnetwebapi.csproj", "./"]
RUN dotnet restore "./dotnetwebapi.csproj"

# Copy the rest of the files and build the project
COPY . .
WORKDIR "/src"
RUN dotnet build "dotnetwebapi.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "dotnetwebapi.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetwebapi.dll"]
