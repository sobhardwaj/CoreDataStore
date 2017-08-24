FROM microsoft/aspnetcore:2.0.0
MAINTAINER Stuart Shay

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

WORKDIR /app
COPY src/CoreDataStore.Web/bin/Release/netcoreapp2.0/win10-x64/publish .
COPY src/CoreDataStore.Web/wwwroot ./wwwroot

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]
