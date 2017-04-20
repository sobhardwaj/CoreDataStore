## SQL Server Data-tier

### NycLandmarks.dacpac    
Landmarks Database Schema

### NycLandmarks.bacpac     
Landmarks Database Schema & Data  

#### Importing Database (bacpac)

Click on SQL Server Database Folder in Mangement Studio
Select Import Data-Tier Application          
Except Defaults       

### SQL Database Files 
NycLandmarks.zip => MDF, LOG Files   

## Appveyor

### Running Mangement Studio
SQL Server 2014 => SQL Server Management Studio


Powershell to Load Database
```
C:\Program Files (x86)\Microsoft SQL Server\130\DAC\bin
.\SqlPackage.exe /a:import /sf:C:\projects\coredatastore\data\NycLandmarks.bacpac /tdn:NycLandmarks /tsn:APPVYR-WIN\SQL2016
```