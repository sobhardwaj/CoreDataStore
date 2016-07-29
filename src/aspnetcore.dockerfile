FROM microsoft/dotnet:core

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish /dotnetapp
COPY src/CoreDataStore.Web/wwwroot /dotnetapp/wwwroot

EXPOSE 5000

ENTRYPOINT ["dotnet", "/dotnetapp/CoreDataStore.Web.dll"]


