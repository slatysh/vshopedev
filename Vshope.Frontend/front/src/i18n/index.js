/**
 * Vue i18n
 *
 * @library
 *
 * http://kazupon.github.io/vue-i18n/en/
 */

// Lib imports
import Vue from 'vue'
import VueI18n from 'vue-i18n'
import messages from '@/lang'
import store from '@/store'

Vue.use(VueI18n)

const i18n = new VueI18n({
  locale: store.state.app.lang,
  fallbackLocale: 'en',
  messages
})
console.log(messages)

export default i18n
