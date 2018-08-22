FROM microsoft/aspnetcore:2.1.0-preview1

# Set environment variables
ENV NG_ENVIRONMENT ${NG_ENVIRONMENT}
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

WORKDIR /app
COPY src/CoreDataStore.Web/bin/Release/netcoreapp2.1/debian.9-x64/publish .
COPY src/CoreDataStore.Web/wwwroot ./wwwroot

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]