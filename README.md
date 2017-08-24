# CoreDataStore

Build   
[![This image on DockerHub](https://img.shields.io/docker/pulls/stuartshay/coredatastore.svg)](https://hub.docker.com/r/stuartshay/coredatastore/) [![Build status](https://ci.appveyor.com/api/projects/status/4j2ebt69uw0e0wmg/branch/master?svg=true)](https://ci.appveyor.com/project/StuartShay/coredatastore/branch/master)
[![CircleCI](https://circleci.com/gh/stuartshay/CoreDataStore.svg?style=shield)](https://circleci.com/gh/stuartshay/CoreDataStore)
[![Build Status](https://travis-ci.org/stuartshay/CoreDataStore.svg?branch=master)](https://travis-ci.org/stuartshay/CoreDataStore)

Dependencies      
[![dependencies Status](https://david-dm.org/stuartshay/CoreDataStore/status.svg)](https://david-dm.org/stuartshay/CoreDataStore)
[![devDependencies Status](https://david-dm.org/stuartshay/CoreDataStore/dev-status.svg)](https://david-dm.org/stuartshay/CoreDataStore?type=dev) 
[![Dependency Status](https://dependencyci.com/github/stuartshay/CoreDataStore/badge)](https://dependencyci.com/github/stuartshay/CoreDataStore) 
[![Code Climate](https://codeclimate.com/github/stuartshay/CoreDataStore/badges/gpa.svg)](https://codeclimate.com/github/stuartshay/CoreDataStore)

#### Demo
https://coredatastore.com         
http://stuartshay.github.io/CoreDataStore/

New York City Landmarks Reference Data     

- [Landmarks Preservation Commission - NYC.gov](http://www1.nyc.gov/site/lpc/index.page)
- [NYC OpenData](http://opendata.cityofnewyork.us/)   

## Prerequisites:

### .NET Core 
.NET Core Runtime 2.0.0 - August 14, 2017            
.NET Core SDK 2.0.0 - August 14, 2017              
https://www.microsoft.com/net/core/   

### Visual Studio MSBuild

Visual Studio 2017 Preview version 15.3            
https://www.visualstudio.com/vs/preview/    

## Web Application Build Instructions
[Angular/NodeJS Web Client](https://github.com/stuartshay/CoreDataStore/tree/master/src/CoreDataStore.Web)


## Docker   

[Docker Commands](docker/README.md)      

## Postgres Db

Landmarks Reference Database    

```bash
docker pull stuartshay/coredatastore-postgres:staging 
docker run --rm --name postgresdb -p 5432:5432  stuartshay/coredatastore-postgres:staging 
```
