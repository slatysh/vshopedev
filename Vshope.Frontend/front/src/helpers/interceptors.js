import axios from 'axios'
import store from '@/store'

export default function setup () {
  axios.interceptors.response.use(function (response) {
    responseHandlePreloader(response)
    return response
  }, function (error) {
    if (!axios.isCancel(error)) {
      responseHandlePreloader(error.response)
      responseHandleError(error)
    }
    return Promise.reject(error) // this is the important part
  })

  axios.interceptors.request.use(function (config) {
    config = requestHandleAuthToken(config)
    config = requestHandleContentType(config)
    config = requestHandlePreloader(config)
    return config
  }, function (err) {
    return Promise.reject(err)
  })

  function requestHandleAuthToken (config) {
    const token = store.state.auth.token
    if (token) {
      config.headers.Authorization = `Bearer ${token}`
    }
    return config
  }
  function requestHandleContentType (config) {
    if (config.headers['Content-Type'] === 'application/x-www-form-urlencoded' || !config.headers['Content-Type']) {
      config.headers['Content-Type'] = 'application/json; charset=utf-8'
    }
    return config
  }
  function requestHandlePreloader (config) {
    var apiPath = makeFullUrl(config.url, config.baseURL)
    if (apiPath.indexOf('create') !== -1 ||
        apiPath.indexOf('update') !== -1) {
      if (store.state.preloader.requestDict.find(x => x === apiPath)) {
        throw new axios.Cancel('Operation canceled because repeated')
      } else {
        store.dispatch('preloader/putRequest', apiPath)
      }
    }
    store.dispatch('preloader/showPreloader')
    return config
  }
  function responseHandlePreloader (response) {
    store.dispatch('preloader/hidePreloader')
    if (response) {
      var apiPath = makeFullUrl(response.config.url, response.config.baseURL)
      if (apiPath.indexOf('create') !== -1 ||
        apiPath.indexOf('update') !== -1) {
        if (store.state.preloader.requestDict.find(x => x === apiPath)) {
          store.dispatch('preloader/removeRequest', apiPath)
        }
      }
    }
  }
  function responseHandleError (error) {
    if (error.response) {
      if (error.response.status === 401 || error.response.status === 403) {
        if (error.response.headers['x-token-expired'] === 'true') {
          store.dispatch('auth/authRefreshToken')
        } else {
          store.dispatch('auth/authLogout')
          store.dispatch('auth/showAuthDialog', 'loginDialog')
        }
      } else if (error.response.status === 404) {
      } else if (error.response.status === 400) {
      }
      // this.router.navigate(['/somethingWentWrong']);
      let errorDesc = ''
      let errorDescInner = ''
      if (error && error.response && error.response.data) {
        errorDesc = error.response.data.message
        if (errorDesc) {
          errorDescInner = error.response.data.innerException
        }
      }
      if (error.response.status >= 500 && error.response.status !== 520) {
        store.dispatch('error/showError')
      }
      console.log(`SERVER ERROR: ${error.message}, STATUS CODE: ${error.response.status}, STATUS TEXT: ${error.response.statusText}, ERROR DESC: ${errorDesc}, ERROR DESC INNER: ${errorDescInner}`)
    } else {
      store.dispatch('error/showError')
      console.log(`CLIENT ERROR: ${error.message}`)
    }
  }

  function makeFullUrl (path, baseUrl) {
    var urlContainsBaseUrl = path.indexOf(baseUrl) >= 0
    if (!urlContainsBaseUrl) {
      return baseUrl + path
    }
    return path
  }
}
