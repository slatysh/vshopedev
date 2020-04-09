const fs = require('fs')
const http = require("http")
const path = require('path')
const swaggerGen = require('swagger-vue')
const iniParser = require('parse-ini')

module.exports = function(grunt) {
  grunt.initConfig({
    'pkg': grunt.file.readJSON('package.json'),
    'swagger-vue-codegen': {
      options: {
        remoteUrl: "<%= pkg.swagger.remoteUrl %>",
        className: "<%= pkg.swagger.className %>",
        moduleName: "<%= pkg.swagger.moduleName %>",
        dest: "<%= pkg.swagger.dest %>",
        envPath: "<%= pkg.swagger.envPath %>"
      },
      dist: {
      }
    }
  })
  grunt.registerMultiTask('swagger-vue-codegen',
    function () {
      var callback = this.async()
      var opt = this.options()
      var env = iniParser.parse(opt.envPath)
      var baseUrl = env.VUE_APP_SERVER_BASE_URL
      var url = path.join(baseUrl, opt.remoteUrl)
      var inputFileName = path.join(opt.dest, opt.moduleName + '.input.json')
      var inputFileStream = fs.createWriteStream(inputFileName)
      var distFileName = path.join(opt.dest, opt.moduleName + '.js')

      http.get(url, response => {
        response.pipe(inputFileStream)
        inputFileStream.on('finish', () => {
          fs.readFile(inputFileName,
            function (err, data) {
              if (err) {
                grunt.log.error(err.toString())
                callback(false)
              } else {
                const parsedData = JSON.parse(data)

                const codeResult = swaggerGen({
                  swagger: parsedData,
                  moduleName: opt.moduleName,
                  className: opt.className
                })

                fs.writeFile(distFileName,
                  codeResult,
                  function (err) {
                    if (err) {
                      grunt.log.error(err.toString())
                      callback(false)
                    } else {
                      grunt.log.writeln(`Generated ${distFileName} from ${url} that saved here ${inputFileName}`)
                    }
                  })
              }
            })
        })
        
      })
     
    })
  grunt.registerTask('vue', ['swagger-vue-codegen'])
}
