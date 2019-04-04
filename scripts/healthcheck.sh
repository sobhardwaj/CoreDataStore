#!/bin/bash
set -eo pipefail

host="${POSTGRES_HOST:=database}"
port="${POSTGRES_PORT:=5432}"
postgresdb="$host:$port"


echo "Postgres: $postgresdb"
healthUser=$HEALTH_USER
healthPassword=$HEALTH_USER_PASSWORD
database=$DATABASE
postgresdb="$host:$port"

echo "$postgresdb"
echo "HEALTH_USER:$healthUser"
echo "HEALTH_PASSWORD:$healthPassword"
echo "DATABASE:$database"



#args=(
        # force sqlserver to not use the local unix socket (test "external" connectivity)
#        -S $host
#        -U $user
#        -P $password
#        -d master
#        -Q "set nocount on; select [Available] from [UtilityDB].[dbo].[Configuration] where Db = 'ImageGalleryDB';"
#        -h -1

#)

## dotnet dbinfo mongodb localhost:27017 my_database my_user password123

#if select="$(sqlcmd "${args[@]}")" && [ $select > 1 ]; then
	exit 0
#fi
#exit 1

