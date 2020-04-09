import store from '@/store'

export const ThrowErrorByExceptionResponse = (exceptionResponse, status, exceptionCode, message) => {
  var response = exceptionResponse.response
  if (response && response.status === status) {
    if (response.data.message === exceptionCode) {
      if (message) {
        store.dispatch('error/showError', message)
      } else {
        store.dispatch('error/showError')
      }
      return true
    }
  }
  return false
}

export const HandleErrorByExceptionResponse = (exceptionResponse, status, exceptionCode, handler) => {
  var response = exceptionResponse.response
  if (response && response.status === status) {
    if (response.data.message === exceptionCode) {
      handler()
      return true
    }
  }
  return false
}
