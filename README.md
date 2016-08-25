# CoreDataStore

[![Build status](https://ci.appveyor.com/api/projects/status/4j2ebt69uw0e0wmg/branch/master?svg=true)](https://ci.appveyor.com/project/StuartShay/coredatastore/branch/master)
[![CircleCI](https://circleci.com/gh/stuartshay/CoreDataStore.svg?style=svg)](https://circleci.com/gh/stuartshay/CoreDataStore)

##Prerequisites:

### .NET Core 
.NET Core SDK 1.0.0 RTM  - June 27, 2016    
https://www.microsoft.com/net/core  

###Visual Studio  

Visual Studio 2015 Update 3 RTM     
Visual Studio 2015 Tooling Preview 2 - Core 1.0.0 

### Packages 

Client Packages 
```bash
npm install -g nodejs
npm install -g gulp gulp-cli
npm install -g typings typescript ts-node
```

Server Development
```bash
npm install -g generator-aspnet
```

### Setup

```bash
git clone https://github.com/stuartshay/CoreDataStore.git
```

```bash
cd src/CoreDataStore.Web/wwwroot/
npm run clean
npm run build

npm start

```

##Website

TODO: Enhance cmd - Use 1 win/bash Script (run.bat/run.sh)    

| Environment   | Database Provider     | Port  | Windows cmd  | Linux/Mac cmd
|---------------| ----------------------|:-----:|--------------|--------------
| Development   | SQLite                | 5000  | dev.cmd      | ./dev.sh   
| Staging       | PostgreSQL            | 5001  | stage.cmd    | ./stage.sh
| Production    | SQL Server            | 5002  | prod.cmd     | TODO


```bash
dotnet restore
dotnet build

dotnet run
```
##Docker   

[Docker Commands](src/docker/README.md)

##Web Container

[Docker Hub](https://hub.docker.com/r/stuartshay/coredatastore/ )

```bash
cd CoreDataStore/src

docker build -f aspnetcore.dockerfile -t coredatastore . 
docker run --rm --name  coredatastore -p 5000:5000 coredatastore
```

##Postgres Db

```bash
docker build -f postgres.dockerfile -t postgresdb .
docker run --rm --name  postgresdb -p 5432:5432 postgresdb
```

##Docker Compose Web & Postgre Db

```bash
cd CoreDataStore/src

docker-compose build 
docker-compose up
```

##Web & NGINX

```bash
 docker-compose --file docker-compose-nginx.yml  build 
 docker-compose --file docker-compose-nginx.yml  up
```

##Entity Framework

```bash
cd /test/CoreDataStore.Data.Postgre.Test

dotnet ef migrations add <MigrationName>
dotnet ef database update
```


