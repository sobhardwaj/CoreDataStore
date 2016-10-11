(function(global) {
  System.config({
    paths: {
      // paths serve as alias
      'libs:': '/lib/'
    },
    // map tells the System loader where to look for things
    map: {
      // our app is within the app folder
      app: 'app',

      // angular bundles
      '@angular/core': 'libs:@angular/core/bundles/core.umd.js',
      '@angular/common': 'libs:@angular/common/bundles/common.umd.js',
      '@angular/compiler': 'libs:@angular/compiler/bundles/compiler.umd.js',
      '@angular/platform-browser': 'libs:@angular/platform-browser/bundles/platform-browser.umd.js',
      '@angular/platform-browser-dynamic': 'libs:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
      '@angular/http': 'libs:@angular/http/bundles/http.umd.js',
      '@angular/router': 'libs:@angular/router/bundles/router.umd.js',
      '@angular/forms': 'libs:@angular/forms/bundles/forms.umd.js',
      '@angular/upgrade': 'libs:@angular/upgrade/bundles/upgrade.umd.js',
      "@angular/core/src/facade/lang": "libs:@angular/core/src/facade/lang.js",
      // other libraries
      'rxjs': 'libs:rxjs',
      'angular2-in-memory-web-api': 'libs:angular2-in-memory-web-api',

      'moment': 'libs:moment/moment.js',
      'ng2-bootstrap': 'libs:ng2-bootstrap',
      'ng2-select': 'libs:ng2-select'

    },
    // packages tells the System loader how to load when no filename and/or no extension
    packages: {
      app: { main: './main.js', defaultExtension: 'js' },
      rxjs: { defaultExtension: 'js' },
      'ng2-select': { defaultExtension: 'js' },
      'ng2-bootstrap': { defaultExtension: 'js' },
      'angular2-in-memory-web-api': { main: './index.js', defaultExtension: 'js' }
    }
  });
})(this);


// (function(global) {

//   // map tells the System loader where to look for things
//   var map = {
//     'app': 'app', // 'dist',
//     'rxjs': 'lib/rxjs',
//     '@angular': 'lib/@angular',
//     'angular2-in-memory-web-api': 'lib/angular2-in-memory-web-api',
//     "@angular/core/src/facade/lang": "lib/@angular/core/src/facade/lang.js",
//     'ng2-select': 'lib/ng2-select',
//     'ng2-bootstrap': 'lib/ng2-bootstrap',
//     'ng2-pagination': 'lib/ng2-pagination',
//     'moment': 'lib/moment/moment.js',
//     // 'angular2-modal': 'lib/angular2-modal',
//     // 'angular2-modal/plugins/bootstrap': 'lib/angular2-modal/plugins/bootstrap/index.js',
//   };

//   // packages tells the System loader how to load when no filename and/or no extension
//   var packages = {
//     'app': { main: 'main.js', defaultExtension: 'js' },
//     'rxjs': { defaultExtension: 'js' },
//     'angular2-in-memory-web-api': { defaultExtension: 'js' },
//     'ng2-select': { main: 'ng2-select.js', defaultExtension: 'js' },
//     'ng2-bootstrap': { main: 'ng2-bootstrap.js', defaultExtension: 'js' },
//     'ng2-pagination': { main: 'index.js', defaultExtension: 'js' },
//     // 'angular2-modal': { main: 'index.js', defaultExtension: 'js' },


//   };

//   var packageNames = [
//     '@angular/common',
//     '@angular/compiler',
//     '@angular/core',
//     '@angular/http',
//     '@angular/platform-browser',
//     '@angular/platform-browser-dynamic',
//     '@angular/router',
//     '@angular/router-deprecated',
//     '@angular/testing',
//     '@angular/upgrade'
//   ];

//   // add package entries for angular packages in the form '@angular/common': { main: 'index.js', defaultExtension: 'js' }
//   packageNames.forEach(function(pkgName) {
//     packages[pkgName] = { main: 'index.js', defaultExtension: 'js' };
//   });

//   var config = {
//     map: map,
//     packages: packages
//   };

//   // packages['@angular/common']['main'] = 'common.umd.js';
//   // packages['@angular/compiler']['main'] = 'compiler.umd.js';
//   // packages['@angular/core']['main'] = 'core.umd.js';
//   // packages['@angular/http']['main'] = 'http.umd.js';
//   // packages['@angular/platform-browser']['main'] = 'platform-browser.umd.js';
//   // packages['@angular/platform-browser-dynamic']['main'] = 'platform-browser-dynamic.umd.js';
//   // packages['@angular/router']['main'] = 'router.umd.js';
//   packages['@angular/router-deprecated']['main'] = 'router-deprecated.umd.js';
//   // packages['@angular/testing']['main'] = 'testing.umd.js';
//   // packages['@angular/upgrade']['main'] = 'upgrade.umd.js';
//   // filterSystemConfig - index.html's chance to modify config before we register it.
//   // if (global.filterSystemConfig) {
//   //   global.filterSystemConfig(config);
//   // }

//   System.config(config);

// })(this);
