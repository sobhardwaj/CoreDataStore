#!/bin/bash
set -e

host="${POSTGRES_HOST:=database}"
port="${POSTGRES_PORT:=5432}"
postgresdb="$host:$port"

echo "Postgres: $postgresdb"

/wait_for_it.sh -h $host -p $port -t 0 --

until /healthcheck.sh
do
    echo healthcheck
    sleep 5
done

exec dotnet CoreDataStore.Web.dll
