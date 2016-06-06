FROM microsoft/dotnet

MAINTAINER Stuart Shay

# CoreDataStore.Web Docker File
#
# Reference Dockerfile
# https://github.com/dotnet/dotnet-docker/blob/master/1.0.0-rc2/core/Dockerfile


# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Copy files to app directory
COPY . /app

# Set working directory
WORKDIR /app/CoreDataStore.Web

# Restore NuGet packages
RUN ["dotnet", "restore"]

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "run"]
