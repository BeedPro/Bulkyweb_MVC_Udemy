# Default target
.DEFAULT_GOAL := help

# Variables
DataAccess_Project := Bulky.DataAccess
WebApp_Project := Bulky.Web

# Help message
help:
	@echo "Usage: make [target]"
	@echo ""
	@echo "Available targets:"
	@echo "  build     			: Build the project"
	@echo "  clean     			: Clean the project"
	@echo "  restore   			: Restore project dependencies"
	@echo "  watch     			: Run the project with watch mode"
	@echo "  run       			: Run the project"
	@echo "  db        			: Update the database"
	@echo "  add_migration 	: Add a new EF Core migration"
	@echo "  rm_migration 	: Remove a previous EF Core migration"
	@echo ""
	@echo "Usage: add_make migration MIGRATION_NAME"
	@echo "Example: add_make migration InitialMigration"

# Targets
build:
	dotnet build

clean:
	dotnet clean

restore:
	dotnet restore

watch:
	dotnet watch run --project Bulky.Web/Bulky.Web.csproj

run:
	dotnet run --project Bulky.Web/Bulky.Web.csproj

db:
	dotnet ef database update --project $(DataAccess_Project) --startup-project $(WebApp_Project)

add_migration:
ifdef MIGRATION_NAME
	dotnet ef migrations add $(MIGRATION_NAME) --project $(DataAccess_Project) --startup-project $(WebApp_Project)
else
	@echo "Error: Please provide a migration name."
	@echo "Example: make migration MIGRATION_NAME"
endif

rm_migration:
	dotnet ef migrations remove --project $(DataAccess_Project) --startup-project $(WebApp_Project)
