FROM microsoft/dotnet:1.0.0-core


MAINTAINER Stuart Shay

# CoreDataStore.Web Docker File
#
# Reference Dockerfile
# https://github.com/dotnet/dotnet-docker/blob/master/1.0.0-rc2/core/Dockerfile
#
# docker exec -it <ContainerId> /bin/bash
#


# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"


##RUN apt-get update && apt-get install -y \
##        npm \
##&& rm -rf /var/lib/apt/lists/*


# Copy files to app directory
COPY . /app

# Set working directory
WORKDIR /app/CoreDataStore.Web

# Restore & Build
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "run"]
