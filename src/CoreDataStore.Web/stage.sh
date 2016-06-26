#!/bin/bash

export ASPNETCORE_ENVIRONMENT=Staging
export ASPNETCORE_URLS=http://*:5001
dotnet run
pause