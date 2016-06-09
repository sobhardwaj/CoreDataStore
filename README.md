# CoreDataStore

##Prerequisites:

```bash
Check NPM version
npm -v

npm install -g bower
npm install -g gulp

npm install -g grunt
npm install -g grunt-cli

npm install -g typescript
npm install -g tsd
npm install -g typings

npm install -g generator-aspnet
```

##Setup
```bash
git clone https://github.com/stuartshay/CoreDataStore.git
```

##Launch Website

```bash
dotnet restore
dotnet build

dotnet run
```
##Docker   

```bash
cd CoreDataStore/src

docker build -t coredatastore . 
docker run --rm --name  coredatastore -p 5000:5000 coredatastore
```

##Entity Framework

```bash
cd /test/CoreDataStore.Data.Postgre.Test

dotnet ef migrations add <MigrationName>
dotnet ef database update
```




