import { UserLogin, UserRefreshToken, VkworkVkAuthFullUrl, UserLoginVkAccessToken } from '@/services'
import router from '@/router'

const state = {
  token: localStorage.getItem('auth-token') || '',
  role: localStorage.getItem('role') || '',
  refreshToken: localStorage.getItem('refresh-token') || '',
  vkToken: localStorage.getItem('vk-token') || '',
  userCompanyId: localStorage.getItem('userCompanyId') || '',
  status: '',
  authDialogState: 'none', // none, loginDialog, registerDialog
  anonimousPathArr: [
    '/user-confirm-email',
    '/'
  ]
}

const getters = {
  isAuthenticated: state => { return !!state.token },
  authDialogState: state => { return state.authDialogState },
  vkTokenLocalStorage: state => () => { return localStorage.getItem('vk-token') }
}

const actions = {
  authRequest: ({ commit, dispatch }, credentials) => {
    return new Promise((resolve, reject) => {
      commit('authRequest')
      UserLogin(credentials)
        .then((result) => {
          var token = result.data.accessToken
          var refreshToken = result.data.refreshToken
          var role = result.data.role
          var userCompanyId = result.data.companyId
          var oldRole = state.role
          setAuthLocalStorage({ token, refreshToken, role, userCompanyId })
          commit('authSuccess', { token, refreshToken, role, userCompanyId })
          resolve()
          var forceReload = oldRole !== role
          if (forceReload) {
            router.push('/home')
            router.go()
          }
        },
        (errors) => {
          commit('authError', errors)
          commit('authLogout')
          cleanAuthLocalStorage()
          reject(errors)
        })
    })
  },
  authRefreshToken: ({ commit, dispatch, state }) => {
    return new Promise((resolve, reject) => {
      if (state.status !== 'attemptingAuthRefreshToken') {
        commit('authRefreshToken')
        var requestModel = {
          jwtToken: state.token,
          refreshToken: state.refreshToken
        }
        UserRefreshToken(requestModel)
          .then((result) => {
            var token = result.data.accessToken
            var refreshToken = result.data.refreshToken
            var role = result.data.role
            var userCompanyId = result.data.companyId
            setAuthLocalStorage({ token, refreshToken, role, userCompanyId })
            commit('authSuccess', { token, refreshToken, role, userCompanyId })
            resolve()
            router.go()
          },
          (errors) => {
            commit('authError', errors)
            commit('authLogout')
            cleanAuthLocalStorage()
            reject(errors)
          })
      } else {
        resolve()
      }
    })
  },
  authLogout: ({ commit, dispatch }) => {
    return new Promise((resolve, reject) => {
      commit('authLogout')
      cleanAuthLocalStorage()
      cleanVkLocalStorage()
      resolve()
    })
  },
  vkRequest: ({ commit, dispatch }, code) => {
    var redirectUrl = VkworkVkAuthFullUrl()
    var requestModel = Object.assign({ code: code, redirectUri: redirectUrl })
    UserLoginVkAccessToken(requestModel).then((result) => {
      var vkToken = result.data
      commit('vkTokenSuccess', vkToken)
      setVkLocalStorage({ vkToken })
    }).catch(() => {
      cleanVkLocalStorage()
    })
  },
  showAuthDialog: ({ commit, dispatch }, dialogType) => {
    commit('changeAuthDialog', dialogType)
  },
  hideAuthDialog: ({ commit, dispatch }) => {
    commit('changeAuthDialog', 'none')
  }
}

const mutations = {
  authRequest: (authState) => {
    authState.status = 'attemptingAuthenticationRequest'
  },
  authRefreshToken: (authState) => {
    authState.status = 'attemptingAuthRefreshToken'
  },
  authSuccess: (authState, payload) => {
    authState.status = 'authenticationSucceeded'
    authState.token = payload.token
    authState.refreshToken = payload.refreshToken
    authState.role = payload.role
    authState.userCompanyId = payload.userCompanyId
  },
  authError: (authState) => {
    authState.status = 'error'
  },
  authLogout: (authState) => {
    authState.token = ''
    authState.refreshToken = ''
    authState.userCompanyId = ''
    authState.status = ''
  },
  changeAuthDialog: (authState, dialogType) => {
    authState.authDialogState = dialogType
  },
  vkTokenSuccess: (authState, vkToken) => {
    authState.vkToken = vkToken
  }
}

const setAuthLocalStorage = (payload) => {
  localStorage.setItem('auth-token', payload.token) // stash the auth token in localStorage
  localStorage.setItem('refresh-token', payload.refreshToken)
  localStorage.setItem('role', payload.role)
  localStorage.setItem('userCompanyId', payload.userCompanyId)
}

const cleanAuthLocalStorage = () => {
  localStorage.removeItem('auth-token')
  localStorage.removeItem('refresh-token')
  localStorage.removeItem('role')
  localStorage.removeItem('userCompanyId')
}

const setVkLocalStorage = (payload) => {
  localStorage.setItem('vk-token', payload.vkToken)
}

const cleanVkLocalStorage = () => {
  localStorage.removeItem('vk-token')
}

export default {
  state,
  getters,
  actions,
  mutations
}
