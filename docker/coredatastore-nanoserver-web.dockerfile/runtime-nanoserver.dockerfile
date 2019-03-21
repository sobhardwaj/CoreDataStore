FROM microsoft/aspnetcore:2.2.3-nanoserver-1803

WORKDIR /app
COPY src/CoreDataStore.Web/bin/Release/netcoreapp2.2/win10-x64/publish .
COPY src/CoreDataStore.Web/wwwroot ./wwwroot

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]
