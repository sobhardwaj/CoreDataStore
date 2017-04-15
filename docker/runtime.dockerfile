FROM microsoft/dotnet:1.1.1-runtime
MAINTAINER Stuart Shay

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"
ENV CONNECTION_PostgreSQL="User ID=nyclandmarks;Password=nyclandmarks;Server=database;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true;"
#ENV MAPSAPI="http://informationcart.eastus2.cloudapp.azure.com:82/api/"

# Open up port
EXPOSE 5000

WORKDIR /app
COPY src/CoreDataStore.Web/bin/Release/netcoreapp1.1/debian.8-x64/publish .
COPY src/CoreDataStore.Web/bin/Release/netcoreapp1.1/debian.8-x64/CoreDataStore.Web.xml .
COPY src/CoreDataStore.Web/wwwroot ./wwwroot

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]
