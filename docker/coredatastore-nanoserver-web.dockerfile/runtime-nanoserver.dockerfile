FROM microsoft/aspnetcore:2.1.0-preview1-nanoserver-sac2016

WORKDIR /app
COPY src/CoreDataStore.Web/bin/Release/netcoreapp2.1/win10-x64/publish .
COPY src/CoreDataStore.Web/wwwroot ./wwwroot

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]