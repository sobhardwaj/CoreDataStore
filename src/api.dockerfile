FROM microsoft/dotnet:core

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish dotnetapp

WORKDIR dotnetapp

ENTRYPOINT ["dotnet", "CoreDataStore.Web.dll"]


