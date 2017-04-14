#!/bin/bash

export ASPNETCORE_ENVIRONMENT=Staging
export ASPNETCORE_URLS=http://*:5001
export CONNECTION_PostgreSQL="User ID=nyclandmarks;Password=nyclandmarks;Server=database;Port=5432;Database=nyclandmarks;Integrated Security=true;Pooling=true;"

dotnet run
pause


