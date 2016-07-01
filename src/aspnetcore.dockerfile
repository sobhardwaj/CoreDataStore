FROM microsoft/dotnet:onbuild

MAINTAINER Stuart Shay

# CoreDataStore.Web Docker File
#
#
# docker exec -it <ContainerId> /bin/bash


# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

WORKDIR /dotnetapp/CoreDataStore.Web

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "run"]
