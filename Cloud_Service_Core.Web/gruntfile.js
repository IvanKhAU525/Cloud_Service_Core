module.exports = function (grunt) {
    grunt.initConfig({
        copy: {
            build: {
                files: [
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap/dist/css/',
                        src: 'bootstrap.min.css',
                        dest: 'wwwroot/lib/bootstrap/css/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap/dist/js/',
                        src: 'bootstrap.min.js',
                        dest: 'wwwroot/lib/bootstrap/js/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery/dist/',
                        src: 'jquery.min.js',
                        dest: 'wwwroot/lib/jquery/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery-ajax-unobtrusive/',
                        src: 'jquery.unobtrusive-ajax.js',
                        dest: 'wwwroot/lib/jquery/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery-validation/dist/',
                        src: 'jquery.validate.min.js',
                        dest: 'wwwroot/lib/jquery/'
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery-validation-unobtrusive/dist/',
                        src: 'jquery.validate.unobtrusive.min.js',
                        dest: 'wwwroot/lib/jquery/'
                    },
                    {
                        expand: true,
                        cwd: 'Icons/',
                        src: '**',
                        dest: 'wwwroot/Icons/'
                    }
                ]
            }
        },
        cssmin: {
            build:{
                files:{
                    'wwwroot/css/app.css' : 'Content/*'
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-contrib-cssmin");

    grunt.registerTask('build', ['copy', 'cssmin']);
};
