Angular2 with TypeScript and Gulp
=================================

A basic Angular2 application with Gulp as build system.

Prerequisites
-------------

- nodejs
- gulp and gulp-cli
- typings
- typescript
- ts-node

Running
-------

Install dependencies:

> npm install

`node_modules` and `typings` directories should be created during the install.

Build the project:

```bash
export NG_ENVIRONMENT=Dev
export LANDMARK=http://informationcart.eastus2.cloudapp.azure.com:80/api/
export ATTRACTION=http://informationcart.eastus2.cloudapp.azure.com:82/api/
export MAPSAPI=http://informationcart.eastus2.cloudapp.azure.com:83/api/
export REPORTSAPI=http://informationcart.eastus2.cloudapp.azure.com:84/api/
npm run build
```

`build` directory should be created during the build

> npm start

The application should be displayed in the browser.

> dotnet run
Start webservice with dotnet
