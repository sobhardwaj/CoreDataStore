#!/bin/bash

export ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_URLS=http://*:5000

dotnet run
pause
