# CoreDataStore

[![Build status](https://ci.appveyor.com/api/projects/status/4j2ebt69uw0e0wmg/branch/master?svg=true)](https://ci.appveyor.com/project/StuartShay/coredatastore/branch/master)
[![CircleCI](https://circleci.com/gh/stuartshay/CoreDataStore.svg?style=svg)](https://circleci.com/gh/stuartshay/CoreDataStore)

##Prerequisites:

### .NET Core 
.NET Core SDK 1.0.0 RTM  - June 27, 2016    
https://www.microsoft.com/net/core  

###Visual Studio  

Visual Studio 2015 Update 3 RTM     
Visual Studio 2015 Tools 1.0.0 RC2

### Packages 
```bash
$npm -v # >=2.15
$npm install -g generator-aspnet

$npm install -g npm3
$npm3 install -g typings
$typings -v # >=1.0.4
```

### Setup

```bash
git clone https://github.com/stuartshay/CoreDataStore.git
```

```bash
$cd src/CoreDataStore.Web/wwwroot/
$npm3 install
$typings install
```

```bash
- delete \wwwroot\node_modules\browser-sync\modules
- rename \wwwroot\node_modules\ng2-bootstrap\tsconfig.json to _tsconfig.json
```

```bash
npm3 run tsc
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

Web Container
```bash
cd CoreDataStore/src

docker build -f aspnetcore.dockerfile -t coredatastore . 
docker run --rm --name  coredatastore -p 5000:5000 coredatastore
```

###Docker Hub

https://hub.docker.com/r/stuartshay/coredatastore/      

Publish
```bash
docker tag coredatastore stuartshay/coredatastore
docker push stuartshay/coredatastore:latest
```

Pull
```bash
docker pull stuartshay/coredatastore

#Run Image 
docker run --rm --name <containername> -p 5000:5000 stuartshay/coredatastore

#Verify Created  Date
docker inspect -f '{{ .Created }}' stuartshay/coredatastore 
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


