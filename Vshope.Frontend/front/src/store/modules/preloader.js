const state = {
  loading: false,
  loadingLogical: false,
  timerShowPreloader: null,
  timerHidePreloader: null,
  countRequests: 0,
  requestDict: []
}
const getters = {
  loading: state => { return !!state.loading },
  loadingLogical: state => { return !!state.loadingLogical }
}
const mutations = {
  showPreloader: (preloaderState) => {
    if (preloaderState.countRequests === 0) {
      preloaderState.loadingLogical = true
      preloaderState.timerShowPreloader = setTimeout(() => {
        preloaderState.loading = true
        clearTimeout(preloaderState.timerHidePreloader)
        preloaderState.timerHidePreloader = setTimeout(() => {
          hidePreloaderHandler(preloaderState)
        },
        10000)
      },
      300)
    }
    preloaderState.countRequests++
  },
  hidePreloader: (preloaderState) => {
    hidePreloaderHandler(preloaderState)
  },
  putRequest: (preloaderState, apiPath) => {
    preloaderState.requestDict.push(apiPath)
  },
  removeRequest: (preloaderState, apiPath) => {
    var apiPathInd = preloaderState.requestDict.indexOf(apiPath)
    if (apiPathInd >= 0) {
      preloaderState.requestDict.splice(apiPathInd, 1)
    }
  }
}

const actions = {
  showPreloader: ({ commit, dispatch }) => {
    commit('showPreloader')
  },
  hidePreloader: ({ commit, dispatch }) => {
    commit('hidePreloader')
  },
  putRequest ({ commit, dispatch }, apiPath) {
    commit('putRequest', apiPath)
  },
  removeRequest ({ commit, dispatch }, apiPath) {
    commit('removeRequest', apiPath)
  }
}

const hidePreloaderHandler = (preloaderState) => {
  if (preloaderState.countRequests > 0) {
    preloaderState.countRequests--
  }
  if (preloaderState.countRequests === 0) {
    clearTimeout(preloaderState.timerShowPreloader)
    clearTimeout(preloaderState.timerHidePreloader)
    preloaderState.loading = false
    preloaderState.loadingLogical = false
  }
}

export default {
  state,
  getters,
  mutations,
  actions
}
