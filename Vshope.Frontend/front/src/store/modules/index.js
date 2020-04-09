// https://vuex.vuejs.org/en/modules.html

const requireModule = require.context('.', true, /\.js$/)
const modules = {}

requireModule.keys().forEach(fileName => {
  if (fileName === './index.js') return

  // Replace ./ and .js
  const moduleName = fileName.replace(/(\.\/|\.js)/g, '')
  modules[moduleName] = requireModule(fileName).default
  modules[moduleName]['namespaced'] = true
})

export default modules
