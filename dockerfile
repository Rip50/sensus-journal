# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

# Stage 2: Build the .NET application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/SensusJournal.API/SensusJournal.API.csproj", "src/SensusJournal.API/"]
COPY ["src/SensusJournal.Application/SensusJournal.Application.csproj", "src/SensusJournal.Application/"]
COPY ["src/SensusJournal.Infra/SensusJournal.Infra.csproj", "src/SensusJournal.Infra/"]
COPY ["src/SensusJournal.Core/SensusJournal.Core.csproj", "src/SensusJournal.Core/"]

# Restore dependencies
RUN dotnet restore "src/SensusJournal.API/SensusJournal.API.csproj"

# Copy all source code and build the application
COPY . .
WORKDIR "/src/src/SensusJournal.API"
RUN dotnet build "SensusJournal.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SensusJournal.API.csproj" -c Release -o /app/publish

# Stage 3: Final image
FROM base AS final
ENV ASPNETCORE_URLS="http://+:8080"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SensusJournal.API.dll"]
