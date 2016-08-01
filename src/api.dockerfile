FROM microsoft/dotnet:core

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish /dotnetapp

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

EXPOSE 5000

ENTRYPOINT ["dotnet", "/dotnetapp/CoreDataStore.Web.dll"]


