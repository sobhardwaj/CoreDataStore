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

##Run

```bash
dotnet restore

dotnet run
```

##Entity Framework


```bash
cd CoreDataStore/CoreDataStore.Data.Sqlite

dnx ef migration add <MigrationName>
dnx ef database update
```




