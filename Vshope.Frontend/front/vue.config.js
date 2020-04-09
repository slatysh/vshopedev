const path = require('path')
module.exports = {
  publicPath: '/frontapp/',
  outputDir: path.resolve(__dirname, '../../Vshope.Web/wwwroot/frontapp'),
  devServer: {
    disableHostCheck: true
  },
  indexPath: (process.env.VUE_APP_TYPE === 'prod') ? 'indexProd.html' : (process.env.VUE_APP_TYPE === 'dev') ? 'indexDev.html' : 'indexDefault.html'
}
