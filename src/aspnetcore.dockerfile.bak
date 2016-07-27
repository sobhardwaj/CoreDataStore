FROM microsoft/dotnet:core

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish /dotnetapp

EXPOSE 5000

ENTRYPOINT ["dotnet", "/dotnetapp/CoreDataStore.Web.dll"]


