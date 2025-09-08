
.PHONY: run

run:
	dotnet run --project src/SchoolManagementSystem.API

.PHONY: build

build:
	dotnet build

.PHONY: dev

dev:
	dotnet watch run --project src/SchoolManagementSystem.API
	