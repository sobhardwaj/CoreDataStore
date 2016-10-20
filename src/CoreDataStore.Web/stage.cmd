set ASPNETCORE_ENVIRONMENT=Staging
set ASPNETCORE_URLS=http://*:5001

set CONNECTION_PostgreSQL="User ID=postgres;Password=password;Server=localhost;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true"

dotnet run
pause
