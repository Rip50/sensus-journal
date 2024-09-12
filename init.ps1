# Create folder structure
Write-Host "Creating folder structure..."
New-Item -Path "./src" -ItemType Directory -Force
New-Item -Path "./tests" -ItemType Directory -Force

# Create the solution
Write-Host "Creating solution..."
dotnet new sln -n SensusJournal

# Create projects
Write-Host "Creating WebAPI project..."
dotnet new webapi -o ./src/SensusJournal.API
Write-Host "Creating Application library..."
dotnet new classlib -o ./src/SensusJournal.Application
Write-Host "Creating Infrastructure library..."
dotnet new classlib -o ./src/SensusJournal.Infra
Write-Host "Creating Core library..."
dotnet new classlib -o ./src/SensusJournal.Core
Write-Host "Creating Application Unit Test project..."
dotnet new xunit -o ./tests/SensusJournal.Application.UnitTests

# Add projects to solution
Write-Host "Adding projects to solution..."
dotnet sln ./SensusJournal.sln add ./src/SensusJournal.API/SensusJournal.API.csproj
dotnet sln ./SensusJournal.sln add ./src/SensusJournal.Application/SensusJournal.Application.csproj
dotnet sln ./SensusJournal.sln add ./src/SensusJournal.Infra/SensusJournal.Infra.csproj
dotnet sln ./SensusJournal.sln add ./src/SensusJournal.Core/SensusJournal.Core.csproj
dotnet sln ./SensusJournal.sln add ./tests/SensusJournal.Application.UnitTests/SensusJournal.Application.UnitTests.csproj

# Display success message
Write-Host "Project structure created successfully!"
