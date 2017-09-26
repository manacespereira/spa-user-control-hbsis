(() => {
    'use strict';

    let gulp = require('gulp'),
        uglify = require('gulp-uglify'),
        concat = require('gulp-concat'),
        ngAnnotate = require('gulp-ng-annotate'),
        cleanCSS = require('gulp-clean-css'),
        processhtml = require('gulp-processhtml'),
        imagemin = require('gulp-imagemin'),
        browserSync = require('browser-sync').create(),
        connectLogger = require("connect-logger"),
        historyApiFallback = require('connect-history-api-fallback');

    let scriptFiles = [
        './public/app_start/startup.js',
        './public/app_start/route.config.js',
        './public/app_start/base.config.js',
        './public/services/*.js',
        './public/controllers/*.js',
        './public/directives/js/*.js',
        './public/filters/*.js'
    ];

    let styleFiles = [
        './public/css/*.css',
        './public/bower_components/font-awesome/css/font-awesome.css',
        './public/bower_components/angular-loading-bar/build/loading-bar.css'
    ];

    let libFiles = [
        './public/bower_components/angular/angular.js',
        './public/bower_components/angular-route/angular-route.js',
        './public/bower_components/angular-local-storage/dist/angular-local-storage.js',
        './public/bower_components/angular-touch/angular-touch.js',
        './public/bower_components/angular-loading-bar/build/loading-bar.js',
        './public/bower_components/angular-input-masks/angular-input-masks-standalone.js',
        './public/bower_components/jquery/dist/jquery.js',
        './public/bower_components/bootstrap/dist/js/bootstrap.js'
    ];

    let imgFiles = [
        './public/img/*.png',
        './public/img/*.jpg',
        './public/img/*.gif'
    ];

    let viewFiles = './public/views/*.html';

    let indexFile = './public/index.html';

    let directivesFiles = './public/directives/templates/*.html';

    gulp.task('default', () => {
        gulp.run('css-dist', 'js-dist', 'lib-dist', 'views-dist', 'index-dist', 'directives-templates-dist', 'img-dist', 'browser-sync', 'fonts-dist');
        gulp.watch(scriptFiles, evt => {
            gulp.run('js-dist');
        });
        gulp.watch(libFiles, evt => {
            gulp.run('lib-dist');
        });
        gulp.watch(styleFiles, evt => {
            gulp.run('css-dist');
        });
        gulp.watch(indexFile, evt => {
            gulp.run('index-dist');
        });
        gulp.watch(viewFiles, evt => {
            gulp.run('views-dist');
        });
        gulp.watch(directivesFiles, evt => {
            gulp.run('directives-templates-dist');
        });
        gulp.watch(imgFiles, evt => {
            gulp.run('img-dist');
        });
    });
    gulp.task('fonts-dist', () => {
        gulp
            .src('./public/bower_components/font-awesome/fonts/*')
            .pipe(gulp.dest('./dist/fonts'));
    });


    gulp.task('views-dist', () => {
        gulp
            .src(viewFiles)
            .pipe(processhtml({}))
            .pipe(gulp.dest('./dist/views'));
    });

    gulp.task('directives-templates-dist', () => {
        gulp
            .src(directivesFiles)
            .pipe(processhtml({}))
            .pipe(gulp.dest('./dist/directives/templates'));
    });

    gulp.task('index-dist', () => {
        gulp
            .src(indexFile)
            .pipe(processhtml({}))
            .pipe(gulp.dest('./dist'));
    });

    gulp.task('js-dist', () =>
        gulp
        .src(scriptFiles)
        .pipe(ngAnnotate())
        .pipe(concat('scripts.min.js'))
        .pipe(uglify().on('error', e => {
            console.log(e);
        }))
        .pipe(gulp.dest('./dist/js/')));

    gulp.task('lib-dist', () =>
        gulp
        .src(libFiles)
        .pipe(ngAnnotate())
        .pipe(concat('libs.min.js'))
        .pipe(uglify().on('error', e => {
            console.log(e);
        }))
        .pipe(gulp.dest('./dist/js/')));


    gulp.task('css-dist', () =>
        gulp
        .src(styleFiles)
        .pipe(concat('styles.min.css'))
        .pipe(cleanCSS())
        .pipe(gulp.dest('./dist/css/')));

    gulp.task('img-dist', () => {
        gulp
            .src(imgFiles)
            .pipe(imagemin({ progressive: true }))
            .pipe(gulp.dest('./dist/img'));
    });

    gulp.task('browser-sync', function() {
        browserSync.init({
            server: {
                baseDir: "./public",
                files: ["./public/*.html", "./public/css/*.css"],
                middleware: [connectLogger(), historyApiFallback()]
            }
        });

        gulp.watch("./public/*").on('change', browserSync.reload);
        gulp.watch("./public/**/*").on('change', browserSync.reload);
    });

})();