/// <binding BeforeBuild='build' />
"use strict";

const del = require("del");
const path = require("path");
const gulp = require("gulp");
const less = require('gulp-less');
const cssmin = require("gulp-cssmin");
const tslint = require('gulp-tslint');
const tsc = require("gulp-typescript");
const sourcemaps = require('gulp-sourcemaps');
const tsProject = tsc.createProject("tsconfig.json");

const buildDir = "wwwroot"
  /**
   * Remove build directory.
   */
gulp.task('clean', (cb) => {
  return del([buildDir], cb);
});


/**
 * Compile all Less files.
 */
gulp.task("less", function() {
  return gulp
    .src("src/styles-less/app.less")
    .pipe(less())
    .pipe(cssmin())
    .pipe(gulp.dest(path.join(buildDir, "css")));
});

/**
 * Lint all custom TypeScript files.
 */
gulp.task('tslint', () => {
  return gulp.src("src/**/*.ts")
    .pipe(tslint())
    .pipe(tslint.report('prose'));
});

/**
 * Compile TypeScript sources and create sourcemaps in build directory.
 */
gulp.task("compile", ["tslint"], () => {
  let tsResult = gulp.src("src/**/*.ts")
    .pipe(sourcemaps.init())
    .pipe(tsc(tsProject));
  return tsResult.js
    .pipe(sourcemaps.write("."))
    .pipe(gulp.dest(buildDir));
});

/**
 * Copy all resources that are not TypeScript files into build directory.
 */
gulp.task("resources", ['fonts', 'less'], () => {
  return gulp.src(["src/**/*", "!src/styles-less", "!src/styles-less/**/*", "!**/*.ts"])
    .pipe(gulp.dest(buildDir));
});

/**
 * Copy all required libraries into build directory.
 */
gulp.task("libs", () => {
  return gulp.src([
      'es6-shim/es6-shim.min.js',
      'es6-shim/es6-shim.map',
      'systemjs/dist/system-polyfills.js',
      'systemjs/dist/system.src.js',
      'reflect-metadata/Reflect.js',
      'reflect-metadata/Reflect.map',
      'rxjs/**',
      'zone.js/dist/**',
      'ng2-select/**',
      'ng2-bootstrap/**',
      'ng2-pagination/**',
      'moment/moment.js',
      'angular2-modal/**',
      '@angular/**'
    ], { cwd: "node_modules/**" }) /* Glob required here. */
    .pipe(gulp.dest(path.join(buildDir, "lib")));
});

/**
 * Copy all required fonts into build directory.
 */
gulp.task("fonts", () => {
  return gulp.src(['fonts/**'], { cwd: "node_modules/bootstrap" })
    .pipe(gulp.dest(path.join(buildDir, "fonts")));
});

/**
 * Watch for changes in TypeScript, HTML and CSS files.
 */
gulp.task('watch', function() {
  gulp.watch(["src/**/*.ts"], ['compile']).on('change', function(e) {
    console.log('TypeScript file ' + e.path + ' has been changed. Compiling.');
  });
  gulp.watch(["src/**/*.html", "src/**/*.css"], ['resources']).on('change', function(e) {
    console.log('Resource file ' + e.path + ' has been changed. Updating.');
  });
  gulp.watch(["src/**/*.less"], ['less']).on('change', function(e) {
    console.log('LESS file ' + e.path + ' has been changed. Updating.');
  });
});

/**
 * Build the project.
 */
gulp.task("build", ['compile', 'resources', 'libs'], () => {
  console.log("Building the project ...");
});
