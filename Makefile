build:
	dotnet build
clean:
	dotnet clean
restore:
	dotnet restore
watch:
	# dotnet watch run --project Bulky.Web/Bulky.Web.csproj
	dotnet watch run --project Bulky.WebRazor_Temp/Bulky.WebRazor_Temp.csproj
run:
	# dotnet run --project Bulky.Web/Bulky.Web.csproj
	dotnet run --project Bulky.WebRazor_Temp/Bulky.WebRazor_Temp.csproj
