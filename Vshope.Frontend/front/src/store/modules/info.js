const state = {
  infoTxt: '',
  infoVisible: false,
  infoTxtDefault: 'common.error.somethingWentWrong',
  timeout: 3000,
  timer: null
}
const getters = {
  infoVisible: state => { return state.infoVisible },
  infoTxt: state => { return state.infoTxt }
}
const mutations = {
  showInfo: (infoState, txt) => {
    if (!infoState.infoVisible) {
      infoState.infoVisible = true
      if (txt) {
        infoState.infoTxt = txt
      } else {
        infoState.infoTxt = infoState.infoTxtDefault
      }
      clearTimeout(infoState.timer)
      infoState.timer = setTimeout(function () { infoState.infoVisible = false }, infoState.timeout)
    }
  },
  hideInfo: (infoState) => {
    infoState.infoVisible = false
  }
}
const actions = {
  showInfo: ({ commit, dispatch }, txt) => {
    commit('showInfo', txt)
  },
  hideInfo: ({ commit, dispatch }) => {
    commit('hideInfo')
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
