cd bin\Debug\netcoreapp1.0
IF EXIST blog.db del blog.db
cd ../../../
dotnet ef database update
dotnet run