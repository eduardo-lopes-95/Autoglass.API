#!/bin/bash

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 5433:1433 -d  --name sql-server-db  mcr.microsoft.com/mssql/server:2017-CU17-ubuntu 