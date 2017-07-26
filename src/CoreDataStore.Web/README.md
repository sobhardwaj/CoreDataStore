Angular with TypeScript and Gulp
=================================

Prerequisites
-------------

- nodejs
- gulp and gulp-cli
- typings
- typescript
- ts-node

Development Setup      
-------

Install dependencies:

```bash
cd src/CoreDataStore.Web         
npm install
```
`node_modules` and `typings` directories will be created during install.         

Environment Linux
```bash
export NG_ENVIRONMENT=Dev
export LANDMARK=https://api.coredatastore.com/api/
export MAPSAPI=https://api-maps.navigatorglass.com/api/
export LOCATIONAPI=https://api-location.coredatastore.com/api/
```

Environment Windows
```bash
set NG_ENVIRONMENT=Dev
set LANDMARK=https://api.coredatastore.com/api/
set MAPSAPI=https://api-maps.navigatorglass.com/api/
set LOCATIONAPI=https://api-location.coredatastore.com/api/
```

Build:     

```bash
npm run clean
npm run build
```

Run:      
```bash
npm start
```

