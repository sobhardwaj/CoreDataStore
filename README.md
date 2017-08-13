# CoreDataStore

Build   
[![This image on DockerHub](https://img.shields.io/docker/pulls/stuartshay/coredatastore.svg)](https://hub.docker.com/r/stuartshay/coredatastore/) [![Build status](https://ci.appveyor.com/api/projects/status/4j2ebt69uw0e0wmg/branch/master?svg=true)](https://ci.appveyor.com/project/StuartShay/coredatastore/branch/master)
[![CircleCI](https://circleci.com/gh/stuartshay/CoreDataStore.svg?style=shield)](https://circleci.com/gh/stuartshay/CoreDataStore)
[![Build Status](https://travis-ci.org/stuartshay/CoreDataStore.svg?branch=master)](https://travis-ci.org/stuartshay/CoreDataStore)

Dependencies      
[![dependencies Status](https://david-dm.org/stuartshay/CoreDataStore/status.svg)](https://david-dm.org/stuartshay/CoreDataStore)
[![devDependencies Status](https://david-dm.org/stuartshay/CoreDataStore/dev-status.svg)](https://david-dm.org/stuartshay/CoreDataStore?type=dev) [![Dependency Status](https://dependencyci.com/github/stuartshay/CoreDataStore/badge)](https://dependencyci.com/github/stuartshay/CoreDataStore) [![Code Climate](https://codeclimate.com/github/stuartshay/CoreDataStore/badges/gpa.svg)](https://codeclimate.com/github/stuartshay/CoreDataStore)

#### Demo
https://coredatastore.com         
http://stuartshay.github.io/CoreDataStore/

New York City Landmarks Reference Data     

- [Landmarks Preservation Commission - NYC.gov](http://www1.nyc.gov/site/lpc/index.page)
- [NYC OpenData](http://opendata.cityofnewyork.us/)   

## Prerequisites:

### .NET Core 
.NET Core Runtime 2.0.0-preview2-25407-01 - June 27, 2017            
.NET Core SDK 2.0.0-preview2-006497  - June 28, 2017              
https://www.microsoft.com/net/core/preview     

### Visual Studio MSBuild

Visual Studio 2017 Preview version 15.3            
https://www.visualstudio.com/vs/preview/    

### Web Application

```bash
nodejs version: >= 4.x
npm version: >= 3
```

## Build Web Application

Step 1: .NET Core Restore
```bash
cd  CoreDataStore/
dotnet restore
```

Step 2: Build Web Site

```bash
cd src/CoreDataStore.Web/
dotnet build

npm install
npm run clean
npm run build

dotnet run
```

#### Development Mode

Windows   
```bash
set NG_ENVIRONMENT=Dev
```

Linux   
```bash
export NG_ENVIRONMENT Dev
```

### Live reload Typescript ClientSide 
> npm start

Deploy clientside
> npm run build

## Docker   

[Docker Hub](https://hub.docker.com/r/stuartshay/coredatastore/ )       
[Docker Commands](docker/README.md)      


### Run from Docker Hub
```bash
docker pull stuartshay/coredatastore
docker run --rm --name coredatastore  -p 5000:5000  stuartshay/coredatastore
```

## Postgres Db

Landmarks Reference Database    

```bash
docker pull stuartshay/coredatastore-postgres:staging 
docker run --rm --name postgresdb -p 5432:5432  stuartshay/coredatastore-postgres:staging 
```
