import Vue from 'vue'
import camelCase from 'lodash/camelCase'

const requireComponent = require.context(
  '@/directives', true, /\.js$/
)

requireComponent.keys().forEach(fileName => {
  const componentConfig = requireComponent(fileName)

  const componentName = camelCase(fileName.replace(/^\.\//, '').replace(/\.\w+$/, ''))

  Vue.directive(componentName, componentConfig.default || componentConfig)
})
