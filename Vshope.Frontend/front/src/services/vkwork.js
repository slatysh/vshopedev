import router from '@/router'

export const VkworkVkAuthFullUrl = function () {
  var path = router.resolve({ path: 'vkAuth' }).href
  var fullUrl = window.location.origin + path
  return fullUrl
}

export const VkworkAuthorizeUrl = function () {
  var fullUrl = VkworkVkAuthFullUrl()
  return `https://oauth.vk.com/authorize?client_id=${process.env.VUE_APP_VK_CLIENT_ID}&display=popup&redirect_uri=${fullUrl}&scope=market,offline&response_type=code&v=${process.env.VUE_APP_VK_API_VERSION}`
}
