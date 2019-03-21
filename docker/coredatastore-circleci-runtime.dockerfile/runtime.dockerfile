FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

# Set environment variables
ENV NG_ENVIRONMENT ${NG_ENVIRONMENT}
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

WORKDIR /app
COPY src/CoreDataStore.Web/bin/Release/netcoreapp2.2/debian.9-x64/publish .
COPY src/CoreDataStore.Web/wwwroot ./wwwroot

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]
