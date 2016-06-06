# CoreDataStore

##Prerequisites:

```bash
npm install -g generator-aspnet

npm install -g grunt
npm install -g grunt-cli
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
cd CoreDataStore/CoreDataStore.Data.Sqlite

dotnet ef migration add <MigrationName>
dotnet ef database update
```




