import { set, toggle } from '@/utils/vuex'

const state = {
  drawer: null,
  color: 'third',
  image: '',
  zone: 180,
  lang: localStorage.getItem('lang') || 'ru'
}
const getters = {
}
const mutations = {
  setDrawer: set('drawer'),
  setImage: set('image'),
  setColor: set('color'),
  toggleDrawer: toggle('drawer'),
  setLang: (state, lang) => {
    state.lang = lang
    localStorage.setItem('lang', lang)
  }
}
const actions = {
  setLang: ({ commit, dispatch }, lang) => {
    commit('setLang', lang)
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
