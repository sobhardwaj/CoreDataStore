FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709

WORKDIR /app
COPY ../src/CoreDataStore.Web/bin/Release/netcoreapp2.1/win10-x64/publish .
COPY ../src/CoreDataStore.Web/wwwroot ./wwwroot

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]