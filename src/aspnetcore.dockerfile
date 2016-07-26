FROM microsoft/dotnet

COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0/publish /dotnetapp

WORKDIR /dotnetapp

EXPOSE 5000

ENTRYPOINT ["dotnet", "run"]


