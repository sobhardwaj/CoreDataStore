/// <binding BeforeBuild='build' />
"use strict";

const fs = require('fs'),
  del = require('del'),
  path = require('path'),
  args = require('yargs'),
  gulp = require('gulp'),
  iF = require('gulp-if'),
  concat = require('gulp-concat'),
  less = require('gulp-less'),
  cssmin = require('gulp-cssmin'),
  tslint = require('gulp-tslint'),
  tsc = require('gulp-typescript'),
  tsconfig = require('gulp-ts-config'),
  coveralls = require('gulp-coveralls'),
  sourcemaps = require('gulp-sourcemaps'),
  jsMinify = require('gulp-uglify'),
  cssPrefixer = require('gulp-autoprefixer'),
  merge = require('merge-stream');

const SystemBuilder = require('systemjs-builder');
const tsProject = tsc.createProject('tsconfig.json');

const buildDir = "wwwroot";
var build = !!(args.build || args.run);
var BUILD = process.env.BUILD || 'local';
var LANDMARK = process.env.LANDMARK || '/api/';
var ATTRACTION = process.env.ATTRACTION || '/attraction/';

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
 * Compile TypeScript sources in build directory.
 */

gulp.task('shims', () => {
  return gulp.src([
      'node_modules/core-js/client/shim.min.js',
      'node_modules/zone.js/dist/zone.js',
      'node_modules/reflect-metadata/Reflect.js',
      'node_modules/systemjs/dist/system.src.js'
    ])
    .pipe(concat('shims.js'))
    .pipe(iF(build, jsMinify()))
    .pipe(gulp.dest(path.join(buildDir, 'js')));
});

gulp.task('tsc', () => {
  var tsProject = tsc.createProject('tsconfig.json'),
    tsResult = tsProject.src()
    .pipe(tsc(tsProject));

  return tsResult.js
    .pipe(gulp.dest('.tmp'));
});

gulp.task('compile', ['tslint', 'tsc'], () => {
  var builder = new SystemBuilder();

  builder.loadConfig('systemjs.config.js')
    .then(() => builder.buildStatic('app', path.join('.tmp', 'js', 'bundle.js')));

  return gulp.src(path.join('.tmp', 'js', 'bundle.js'))
    .pipe(iF(build, jsMinify()))
    .pipe(gulp.dest(path.join(buildDir, 'js')));
});


/**
 * Copy all resources that are not TypeScript files into build directory.
 */
gulp.task("resources", ['fonts', 'less'], () => {
  return gulp.src(["src/**/*", "!src/styles-less", "!src/styles-less/**/*", "!**/*.ts"])
    .pipe(gulp.dest(buildDir));
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
gulp.task('watch', () => {
  gulp.watch(['src/**/**.ts'], ['compile']).on('change', function(e) {
    console.log('TypeScript file ' + e.path + ' has been changed. Compiling.');
  });
  gulp.watch(['src/**/**.html', 'src/**/*.css', 'src/img/*.*'], ['resources']).on('change', function(e) {
    console.log('Resource file ' + e.path + ' has been changed. Updating.');
  });
  gulp.watch(['src/**/**.less'], ['less']).on('change', function(e) {
    console.log('LESS file ' + e.path + ' has been changed. Updating.');
  });
});

gulp.task('appsettings', function(cb) {
  var build = 'build: ' + BUILD;
  var landmark = '\nApiEndpoint: ' + LANDMARK;
  var attraction = '\nApiAttraction: ' + ATTRACTION;
  fs.writeFile('appsettings.yml', build + landmark + attraction, cb);
});

gulp.task('api', function() {
  gulp.src('appsettings.yml')
    .pipe(tsconfig('AppSettings', JSON.parse('{"parser": "yml"}')))
    .pipe(gulp.dest('./src/app'))
});
/**
 * Build the project.
 */
gulp.task("build", ['appsettings', 'api', 'shims', 'compile', 'less', 'fonts', 'resources'], () => {
  console.log("Building the project ...");
});
