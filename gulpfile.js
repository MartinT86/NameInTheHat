/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
  rimraf = require("rimraf"),
  concat = require("gulp-concat"),
  cssmin = require("gulp-cssmin"),
  uglify = require("gulp-uglify"),
  less = require("gulp-less");

var paths = {
  webroot: "./src/Site/wwwroot/"
};

paths.js = paths.webroot + "js/custom/**/*.js";
paths.minJs = paths.webroot + "js/custom/**/*.min.js";
paths.less = paths.webroot + "css/custom/**/*.less";
paths.css = paths.webroot + "css/custom/**/*.css";
paths.cssFolder = paths.webroot + "css/custom";
paths.minCss = paths.webroot + "css/custom/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task("clean:js", function (cb) {
  rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
  rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task('less', function () {
  return gulp.src(paths.less)
    .pipe(less({
      paths: [ ]
    }))
    .pipe(gulp.dest(paths.cssFolder));
});

gulp.task("min:js", function () {
  return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
    .pipe(concat(paths.concatJsDest))
    .pipe(uglify())
    .pipe(gulp.dest("."));
});

gulp.task("min:css", ["less"], function () {
  var stream = gulp.src([paths.css, "!" + paths.minCss])
    .pipe(concat(paths.concatCssDest))
    .pipe(cssmin())
    .pipe(gulp.dest("."));
    return stream;
});

// gulp.task("min:css", function () {
//   return gulp.src([paths.css, "!" + paths.minCss])
//     .pipe(concat(paths.concatCssDest))
//     .pipe(cssmin())
//     .pipe(gulp.dest("."));
// });

gulp.task("test", ["min:css"]);

gulp.task("min", ["less", "min:js", "min:css"]);

gulp.task('watch', ['min'], function () {
   gulp.watch(paths.webroot + "css/custom/**/*.less", ['min']);
});