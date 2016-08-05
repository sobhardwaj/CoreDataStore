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

> npm run clean
> npm run build:local
> npm run build:dev
> npm run build:stage
> npm run build:prod

`build` directory should be created during the build

> npm start

The application should be displayed in the browser.

> dotnet run
Start webservice with dotnet