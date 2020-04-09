const state = {
  errorTxt: '',
  errorVisible: false,
  errorTxtDefault: 'common.error.somethingWentWrong',
  timeout: 3000,
  timer: null
}
const getters = {
  errorVisible: state => { return state.errorVisible },
  errorTxt: state => { return state.errorTxt }
}
const mutations = {
  showError: (errorState, txt) => {
    if (!errorState.errorVisible) {
      errorState.errorVisible = true
      if (txt) {
        errorState.errorTxt = txt
      } else {
        errorState.errorTxt = errorState.errorTxtDefault
      }
      clearTimeout(errorState.timer)
      errorState.timer = setTimeout(function () { errorState.errorVisible = false }, errorState.timeout)
    }
  },
  hideError: (errorState) => {
    errorState.errorVisible = false
  }
}
const actions = {
  showError: ({ commit, dispatch }, txt) => {
    commit('showError', txt)
  },
  hideError: ({ commit, dispatch }) => {
    commit('hideError')
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
