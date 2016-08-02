FROM microsoft/dotnet:core

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish /dotnetapp

ENTRYPOINT ["dotnet", "/dotnetapp/CoreDataStore.Web.dll"]


