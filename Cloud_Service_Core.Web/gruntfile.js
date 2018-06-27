module.exports = function (grunt) {
    grunt.initConfig({
        copy: {
            build: {
                files: [
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap/dist/css/',
                        src: 'bootstrap.min.css',
                        dest: 'wwwroot/lib/bootstrap/css/',
                        flatten: true
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/bootstrap/dist/js/',
                        src: 'bootstrap.min.js',
                        dest: 'wwwroot/lib/bootstrap/js/',
                        flatten: true
                    },
                    {
                        expand: true,
                        cwd: 'node_modules/jquery/dist/',
                        src: 'jquery.min.js',
                        dest: 'wwwroot/lib/jquery/',
                        flatten: true
                    }
                ]
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-copy");
    
    grunt.registerTask('build', ['copy']);
};
