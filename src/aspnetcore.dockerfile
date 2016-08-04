FROM microsoft/dotnet:core
MAINTAINER Stuart Shay

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish /dotnetapp
COPY src/CoreDataStore.Web/wwwroot /dotnetapp/wwwroot

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "/dotnetapp/CoreDataStore.Web.dll"]
