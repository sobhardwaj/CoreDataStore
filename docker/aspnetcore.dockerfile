FROM microsoft/dotnet:latest
MAINTAINER Stuart Shay

#COPY src/CoreDataStore.Web/bin/Debug/netcoreapp1.0 /dotnetapp
#COPY src/CoreDataStore.Web/wwwroot /dotnetapp/wwwroot

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Open up port
EXPOSE 5000

# Run the app
# ENTRYPOINT ["dotnet", "/dotnetapp/CoreDataStore.Web.dll"]

RUN apt-get install curl -y
RUN curl -sL https://deb.nodesource.com/setup_6.x | bash -
RUN apt-get install -y nodejs
RUN npm install -g gulp gulp-cli typings typescript ts-node

COPY src /app

WORKDIR /app

RUN dotnet restore

WORKDIR /app/CoreDataStore.Web
RUN npm install
RUN npm run clean
RUN npm run build:stage
RUN dotnet build

ENTRYPOINT ["dotnet", "run"]

# Build the image:
# docker build -f aspnetcore.development.dockerfile -t [yourDockerHubID]/dotnet:1.0.0 

# Option 1
# Start PostgreSQL and ASP.NET Core (link ASP.NET core to ProgreSQL container with legacy linking)
 
# docker run -d --name my-postgres -e POSTGRES_PASSWORD=password postgres
# docker run -d -p 5000:5000 --link my-postgres:postgres [yourDockerHubID]/dotnet:1.0.0

# Option 2: Create a custom bridge network and add containers into it

# docker network create --driver bridge isolated_network
# docker run -d --net=isolated_network --name postgres -e POSTGRES_PASSWORD=password postgres
# docker run -d --net=isolated_network --name aspnetcoreapp -p 5000:5000 [yourDockerHubID]/dotnet:1.0.0
