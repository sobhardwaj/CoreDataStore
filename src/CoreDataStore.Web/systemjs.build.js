  System.config({
    defaultExtensions: 'js',
    typescriptOptions: {
      "target": "es2017",
      "lib": [
        "es2017",
        "dom"
      ],
      "module": "commonjs",
      "moduleResolution": "node",
      "sourceMap": true,
      "emitDecoratorMetadata": true,
      "experimentalDecorators": true,
      "removeComments": false,
      "noImplicitAny": false
    },
    paths: {
      // paths serve as alias
      'npm:': 'node_modules/'
    },
    // map tells the System loader where to look for things
    map: {
      // our app is within the app folder
      app: '.tmp',

      // angular bundles
      '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
      '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
      '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
      '@angular/animations': 'npm:@angular/animations/bundles/animations.umd.js',
      '@angular/animations/browser': 'npm:@angular/animations/bundles/animations-browser.umd.js',
      '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
      '@angular/platform-browser/animations': 'npm:@angular/platform-browser/bundles/platform-browser-animations.umd.js',
      '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
      '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
      '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
      '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
      '@angular/upgrade': 'npm:@angular/upgrade/bundles/upgrade.umd.js',
      "@angular/core/src/facade/lang": "npm:@angular/core/src/facade/lang.js",
      // other libraries
      'rxjs': 'npm:rxjs',
      'angular2-in-memory-web-api': 'npm:angular2-in-memory-web-api',

      'moment': 'npm:moment/moment.js',
      'jquery': 'npm:jquery/dist/jquery.js',
      'jquery.browser': 'npm:jquery.browser/dist/jquery.browser.js',
      'screenfull': 'npm:screenfull/dist/screenfull.js',
      'angular2-google-maps/core': 'npm:angular2-google-maps/core/core.umd.js',
      // 'ngx-bootstrap': 'npm:ngx-bootstrap',
      'ngx-bootstrap': 'npm:ngx-bootstrap/bundles/ngx-bootstrap.umd.min.js',
      'ngx-bootstrap/*': 'npm:ngx-bootstrap/bundles/ngx-bootstrap.umd.min.js',
      'ng2-toastr': 'npm:ng2-toastr',
      'ng2-select': 'npm:ng2-select',
      // ag libraries
      'ag-grid-angular': 'npm:ag-grid-angular',
      'ag-grid-ng2': 'npm:ag-grid-ng2',
      'ag-grid': 'npm:ag-grid',
      'ag-grid-enterprise': 'npm:ag-grid-enterprise'

    },
    // packages tells the System loader how to load when no filename and/or no extension
    packages: {
      app: { main: 'main.js', defaultExtension: 'js' },
      rxjs: { defaultExtension: 'js' },
      'ag-grid': { main: 'main.js', defaultExtension: 'js' },
      'ag-grid-ng2': { main: 'main.js', defaultExtension: 'js' },
      'ag-grid-angular': { main: 'main.js', defaultExtension: 'js' },
      'ng2-select': { defaultExtension: 'js' },
      'ng2-toastr': { defaultExtension: 'js' },
      'angular2-in-memory-web-api': { main: './index.js', defaultExtension: 'js' }
    }
  });
