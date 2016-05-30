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

##Entity Framework

```bash
cd CoreDataStore/CoreDataStore.Data.Sqlite

dotnet ef migration add <MigrationName>
dotnet ef database update
```




