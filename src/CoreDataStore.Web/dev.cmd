
set ASPNETCORE_ENVIRONMENT=Development
set ASPNETCORE_URLS=http://*:5000
set NG_ENVIRONMENT=Dev
echo NG_ENVIRONMENT:%NG_ENVIRONMENT% 

set MAPSAPI=http://informationcart.eastus2.cloudapp.azure.com:82/api/
echo MAPSAPI:%MAPSAPI% 

npm install
npm run clean
npm run build

dotnet run
pause
