dotnet ef database update --startup-project WebAPI --project Migrations.Sqlite

dotnet out/WebMVC.dll --urls http://0.0.0.0:8800  &
dotnet out/WebAPI.dll --urls http://0.0.0.0:8801