(function(global) {
  // map tells the System loader where to look for things
  var map = {
    'app':                        'app', // 'dist',
    'rxjs':                       'node_modules/rxjs',
    'angular2-in-memory-web-api': 'node_modules/angular2-in-memory-web-api',
    '@angular':                   'node_modules/@angular',
    "@angular/core/src/facade/lang": "node_modules/@angular/core/src/facade/lang.js",
    'moment': 'node_modules/moment/moment.js'
  };
  // packages tells the System loader how to load when no filename and/or no extension
  var packages = {
    'app':                        { main: 'main.js',  defaultExtension: 'js' },
    'rxjs':                       { main: 'bundles/Rx.umd.js', defaultExtension: 'js' },
    'angular2-in-memory-web-api': { defaultExtension: 'js' },
  };
  var packageNames = [
    '@angular/common',
    '@angular/compiler',
    '@angular/core',
    '@angular/http',
    '@angular/platform-browser',
    '@angular/platform-browser-dynamic',
    '@angular/router',
    '@angular/router-deprecated',
    '@angular/testing',
    '@angular/upgrade',
  ];
  // add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
  packageNames.forEach(function(pkgName) {
    packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
  });
  packages['@angular/common']['main'] = 'common.umd.js';
  packages['@angular/compiler']['main'] = 'compiler.umd.js';
  packages['@angular/core']['main'] = 'core.umd.js';
  packages['@angular/http']['main'] = 'http.umd.js';
  packages['@angular/platform-browser']['main'] = 'platform-browser.umd.js';
  packages['@angular/platform-browser-dynamic']['main'] = 'platform-browser-dynamic.umd.js';
  packages['@angular/router']['main'] = 'router.umd.js';
  packages['@angular/router-deprecated']['main'] = 'router-deprecated.umd.js';
  packages['@angular/testing']['main'] = 'testing.umd.js';
  packages['@angular/upgrade']['main'] = 'upgrade.umd.js';
  var config = {
    map: map,
    packages: packages
  }
  System.config(config);
})(this);
