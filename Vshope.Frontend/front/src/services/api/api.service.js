/* eslint-disable */
import axios from 'axios'
import qs from 'qs'
let domain = ''
export const getDomain = () => {
  return domain
}
export const setDomain = ($domain) => {
  domain = $domain
}
export const request = (method, url, body, queryParameters, form, config) => {
  method = method.toLowerCase()
  let keys = Object.keys(queryParameters)
  let queryUrl = url
  if (keys.length > 0) {
    queryUrl = url + '?' + qs.stringify(queryParameters)
  }
  // let queryUrl = url+(keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
  if (body) {
    return axios[method](queryUrl, body, config)
  } else if (method === 'get') {
    return axios[method](queryUrl, {
      params: form
    }, config)
  } else {
    return axios[method](queryUrl, qs.stringify(form), config)
  }
}
/*==========================================================
 *                    
 ==========================================================*/
/**
 * WEB ADMIN_AND_USER Avito xml file download
 * request: AvitoXmlFileDownload
 * url: AvitoXmlFileDownloadURL
 * method: AvitoXmlFileDownload_TYPE
 * raw_url: AvitoXmlFileDownload_RAW_URL
 * @param dto - 
 * @param companyId - 
 */
export const AvitoXmlFileDownload = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/avitoXml/downloadAvitoXml/{companyId}'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['dto'] !== undefined) {
    body = parameters['dto']
  }
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['companyId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: companyId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('post', domain + path, body, queryParameters, form, config)
}
export const AvitoXmlFileDownload_RAW_URL = function() {
  return '/api/avitoXml/downloadAvitoXml/{companyId}'
}
export const AvitoXmlFileDownload_TYPE = function() {
  return 'post'
}
export const AvitoXmlFileDownloadURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/avitoXml/downloadAvitoXml/{companyId}'
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get server version
 * request: CommonGetServerVersion
 * url: CommonGetServerVersionURL
 * method: CommonGetServerVersion_TYPE
 * raw_url: CommonGetServerVersion_RAW_URL
 */
export const CommonGetServerVersion = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/common/version'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const CommonGetServerVersion_RAW_URL = function() {
  return '/api/common/version'
}
export const CommonGetServerVersion_TYPE = function() {
  return 'get'
}
export const CommonGetServerVersionURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/common/version'
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN create company
 * request: CompanyCreate
 * url: CompanyCreateURL
 * method: CompanyCreate_TYPE
 * raw_url: CompanyCreate_RAW_URL
 * @param companyDto - 
 * @param vkToken - 
 */
export const CompanyCreate = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/company/create'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['companyDto'] !== undefined) {
    body = parameters['companyDto']
  }
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('post', domain + path, body, queryParameters, form, config)
}
export const CompanyCreate_RAW_URL = function() {
  return '/api/company/create'
}
export const CompanyCreate_TYPE = function() {
  return 'post'
}
export const CompanyCreateURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/company/create'
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN delete company by id
 * request: CompanyDelete
 * url: CompanyDeleteURL
 * method: CompanyDelete_TYPE
 * raw_url: CompanyDelete_RAW_URL
 * @param companyId - 
 */
export const CompanyDelete = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/company/delete/{companyId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['companyId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: companyId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const CompanyDelete_RAW_URL = function() {
  return '/api/company/delete/{companyId}'
}
export const CompanyDelete_TYPE = function() {
  return 'get'
}
export const CompanyDeleteURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/company/delete/{companyId}'
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN_AND_USER get company by id
 * request: CompanyGet
 * url: CompanyGetURL
 * method: CompanyGet_TYPE
 * raw_url: CompanyGet_RAW_URL
 * @param companyId - 
 */
export const CompanyGet = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/company/get/{companyId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['companyId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: companyId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const CompanyGet_RAW_URL = function() {
  return '/api/company/get/{companyId}'
}
export const CompanyGet_TYPE = function() {
  return 'get'
}
export const CompanyGetURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/company/get/{companyId}'
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN get shop list (paged)
 * request: CompanyGetList
 * url: CompanyGetListURL
 * method: CompanyGetList_TYPE
 * raw_url: CompanyGetList_RAW_URL
 * @param sortBy - 
 * @param descending - 
 * @param page - 
 * @param rowsPerPage - 
 */
export const CompanyGetList = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/company/get/list'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['sortBy'] !== undefined) {
    queryParameters['sortBy'] = parameters['sortBy']
  }
  if (parameters['descending'] !== undefined) {
    queryParameters['descending'] = parameters['descending']
  }
  if (parameters['page'] !== undefined) {
    queryParameters['page'] = parameters['page']
  }
  if (parameters['rowsPerPage'] !== undefined) {
    queryParameters['rowsPerPage'] = parameters['rowsPerPage']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const CompanyGetList_RAW_URL = function() {
  return '/api/company/get/list'
}
export const CompanyGetList_TYPE = function() {
  return 'get'
}
export const CompanyGetListURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/company/get/list'
  if (parameters['sortBy'] !== undefined) {
    queryParameters['sortBy'] = parameters['sortBy']
  }
  if (parameters['descending'] !== undefined) {
    queryParameters['descending'] = parameters['descending']
  }
  if (parameters['page'] !== undefined) {
    queryParameters['page'] = parameters['page']
  }
  if (parameters['rowsPerPage'] !== undefined) {
    queryParameters['rowsPerPage'] = parameters['rowsPerPage']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN update company
 * request: CompanyUpdate
 * url: CompanyUpdateURL
 * method: CompanyUpdate_TYPE
 * raw_url: CompanyUpdate_RAW_URL
 * @param companyDto - 
 * @param vkToken - 
 */
export const CompanyUpdate = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/company/update'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['companyDto'] !== undefined) {
    body = parameters['companyDto']
  }
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('put', domain + path, body, queryParameters, form, config)
}
export const CompanyUpdate_RAW_URL = function() {
  return '/api/company/update'
}
export const CompanyUpdate_TYPE = function() {
  return 'put'
}
export const CompanyUpdateURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/company/update'
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product type dict
 * request: ProductTypeGetDict
 * url: ProductTypeGetDictURL
 * method: ProductTypeGetDict_TYPE
 * raw_url: ProductTypeGetDict_RAW_URL
 */
export const ProductTypeGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/productType'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductTypeGetDict_RAW_URL = function() {
  return '/api/dict/productType'
}
export const ProductTypeGetDict_TYPE = function() {
  return 'get'
}
export const ProductTypeGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/productType'
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product category dict
 * request: ProductCategoryGetDict
 * url: ProductCategoryGetDictURL
 * method: ProductCategoryGetDict_TYPE
 * raw_url: ProductCategoryGetDict_RAW_URL
 * @param productTypeId - 
 */
export const ProductCategoryGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/productCategory/{productTypeId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{productTypeId}', `${parameters['productTypeId']}`)
  if (parameters['productTypeId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: productTypeId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductCategoryGetDict_RAW_URL = function() {
  return '/api/dict/productCategory/{productTypeId}'
}
export const ProductCategoryGetDict_TYPE = function() {
  return 'get'
}
export const ProductCategoryGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/productCategory/{productTypeId}'
  path = path.replace('{productTypeId}', `${parameters['productTypeId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product goods type dict
 * request: ProductGoodsTypeGetDict
 * url: ProductGoodsTypeGetDictURL
 * method: ProductGoodsTypeGetDict_TYPE
 * raw_url: ProductGoodsTypeGetDict_RAW_URL
 * @param productCategoryId - 
 */
export const ProductGoodsTypeGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/productGoodsType/{productCategoryId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{productCategoryId}', `${parameters['productCategoryId']}`)
  if (parameters['productCategoryId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: productCategoryId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductGoodsTypeGetDict_RAW_URL = function() {
  return '/api/dict/productGoodsType/{productCategoryId}'
}
export const ProductGoodsTypeGetDict_TYPE = function() {
  return 'get'
}
export const ProductGoodsTypeGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/productGoodsType/{productCategoryId}'
  path = path.replace('{productCategoryId}', `${parameters['productCategoryId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product apparel dict
 * request: ProductApparelGetDict
 * url: ProductApparelGetDictURL
 * method: ProductApparelGetDict_TYPE
 * raw_url: ProductApparelGetDict_RAW_URL
 * @param productGoodsTypeId - 
 */
export const ProductApparelGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/productApparel/{productGoodsTypeId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{productGoodsTypeId}', `${parameters['productGoodsTypeId']}`)
  if (parameters['productGoodsTypeId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: productGoodsTypeId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductApparelGetDict_RAW_URL = function() {
  return '/api/dict/productApparel/{productGoodsTypeId}'
}
export const ProductApparelGetDict_TYPE = function() {
  return 'get'
}
export const ProductApparelGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/productApparel/{productGoodsTypeId}'
  path = path.replace('{productGoodsTypeId}', `${parameters['productGoodsTypeId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product size dict
 * request: ProductSizeGetDict
 * url: ProductSizeGetDictURL
 * method: ProductSizeGetDict_TYPE
 * raw_url: ProductSizeGetDict_RAW_URL
 * @param productGoodsTypeId - 
 * @param productApparelId - 
 */
export const ProductSizeGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/productSize/{productGoodsTypeId}/{productApparelId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{productGoodsTypeId}', `${parameters['productGoodsTypeId']}`)
  if (parameters['productGoodsTypeId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: productGoodsTypeId'))
  }
  path = path.replace('{productApparelId}', `${parameters['productApparelId']}`)
  if (parameters['productApparelId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: productApparelId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductSizeGetDict_RAW_URL = function() {
  return '/api/dict/productSize/{productGoodsTypeId}/{productApparelId}'
}
export const ProductSizeGetDict_TYPE = function() {
  return 'get'
}
export const ProductSizeGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/productSize/{productGoodsTypeId}/{productApparelId}'
  path = path.replace('{productGoodsTypeId}', `${parameters['productGoodsTypeId']}`)
  path = path.replace('{productApparelId}', `${parameters['productApparelId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product adType dict
 * request: ProductAdTypeGetDict
 * url: ProductAdTypeGetDictURL
 * method: ProductAdTypeGetDict_TYPE
 * raw_url: ProductAdTypeGetDict_RAW_URL
 */
export const ProductAdTypeGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/adType'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductAdTypeGetDict_RAW_URL = function() {
  return '/api/dict/adType'
}
export const ProductAdTypeGetDict_TYPE = function() {
  return 'get'
}
export const ProductAdTypeGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/adType'
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB COMMON get product condition dict
 * request: ProductConditionGetDict
 * url: ProductConditionGetDictURL
 * method: ProductConditionGetDict_TYPE
 * raw_url: ProductConditionGetDict_RAW_URL
 */
export const ProductConditionGetDict = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/dict/condition'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductConditionGetDict_RAW_URL = function() {
  return '/api/dict/condition'
}
export const ProductConditionGetDict_TYPE = function() {
  return 'get'
}
export const ProductConditionGetDictURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/dict/condition'
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN_AND_USER get and save product list
 * request: ProductGetAndSaveListFromVk
 * url: ProductGetAndSaveListFromVkURL
 * method: ProductGetAndSaveListFromVk_TYPE
 * raw_url: ProductGetAndSaveListFromVk_RAW_URL
 * @param companyId - 
 * @param vkToken - 
 */
export const ProductGetAndSaveListFromVk = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/getAndSaveListFromVk/{companyId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['companyId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: companyId'))
  }
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductGetAndSaveListFromVk_RAW_URL = function() {
  return '/getAndSaveListFromVk/{companyId}'
}
export const ProductGetAndSaveListFromVk_TYPE = function() {
  return 'get'
}
export const ProductGetAndSaveListFromVkURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/getAndSaveListFromVk/{companyId}'
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN_AND_USER get product count
 * request: ProductGetCountFromVk
 * url: ProductGetCountFromVkURL
 * method: ProductGetCountFromVk_TYPE
 * raw_url: ProductGetCountFromVk_RAW_URL
 * @param companyId - 
 * @param vkToken - 
 */
export const ProductGetCountFromVk = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/getCountFromVk/{companyId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['companyId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: companyId'))
  }
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductGetCountFromVk_RAW_URL = function() {
  return '/getCountFromVk/{companyId}'
}
export const ProductGetCountFromVk_TYPE = function() {
  return 'get'
}
export const ProductGetCountFromVkURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/getCountFromVk/{companyId}'
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['vkToken'] !== undefined) {
    queryParameters['vkToken'] = parameters['vkToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN_AND_USER get products
 * request: ProductGetList
 * url: ProductGetListURL
 * method: ProductGetList_TYPE
 * raw_url: ProductGetList_RAW_URL
 * @param sortBy - 
 * @param descending - 
 * @param page - 
 * @param rowsPerPage - 
 * @param companyId - 
 */
export const ProductGetList = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/list/{companyId}'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['sortBy'] !== undefined) {
    queryParameters['sortBy'] = parameters['sortBy']
  }
  if (parameters['descending'] !== undefined) {
    queryParameters['descending'] = parameters['descending']
  }
  if (parameters['page'] !== undefined) {
    queryParameters['page'] = parameters['page']
  }
  if (parameters['rowsPerPage'] !== undefined) {
    queryParameters['rowsPerPage'] = parameters['rowsPerPage']
  }
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters['companyId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: companyId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const ProductGetList_RAW_URL = function() {
  return '/list/{companyId}'
}
export const ProductGetList_TYPE = function() {
  return 'get'
}
export const ProductGetListURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/list/{companyId}'
  if (parameters['sortBy'] !== undefined) {
    queryParameters['sortBy'] = parameters['sortBy']
  }
  if (parameters['descending'] !== undefined) {
    queryParameters['descending'] = parameters['descending']
  }
  if (parameters['page'] !== undefined) {
    queryParameters['page'] = parameters['page']
  }
  if (parameters['rowsPerPage'] !== undefined) {
    queryParameters['rowsPerPage'] = parameters['rowsPerPage']
  }
  path = path.replace('{companyId}', `${parameters['companyId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ANONIMOUS confirm email
 * request: UserConfirmEmail
 * url: UserConfirmEmailURL
 * method: UserConfirmEmail_TYPE
 * raw_url: UserConfirmEmail_RAW_URL
 * @param code - 
 */
export const UserConfirmEmail = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/user/confirmEmail'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['code'] !== undefined) {
    queryParameters['code'] = parameters['code']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const UserConfirmEmail_RAW_URL = function() {
  return '/api/user/confirmEmail'
}
export const UserConfirmEmail_TYPE = function() {
  return 'get'
}
export const UserConfirmEmailURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/user/confirmEmail'
  if (parameters['code'] !== undefined) {
    queryParameters['code'] = parameters['code']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ADMIN_AND_USER get user by id
 * request: UserGet
 * url: UserGetURL
 * method: UserGet_TYPE
 * raw_url: UserGet_RAW_URL
 * @param userId - 
 */
export const UserGet = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/user/get/{userId}'
  let body
  let queryParameters = {}
  let form = {}
  path = path.replace('{userId}', `${parameters['userId']}`)
  if (parameters['userId'] === undefined) {
    return Promise.reject(new Error('Missing required  parameter: userId'))
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const UserGet_RAW_URL = function() {
  return '/api/user/get/{userId}'
}
export const UserGet_TYPE = function() {
  return 'get'
}
export const UserGetURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/user/get/{userId}'
  path = path.replace('{userId}', `${parameters['userId']}`)
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ANONIMOUS login user
 * request: UserLogin
 * url: UserLoginURL
 * method: UserLogin_TYPE
 * raw_url: UserLogin_RAW_URL
 * @param userLoginDto - 
 */
export const UserLogin = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/user/login'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['userLoginDto'] !== undefined) {
    body = parameters['userLoginDto']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('post', domain + path, body, queryParameters, form, config)
}
export const UserLogin_RAW_URL = function() {
  return '/api/user/login'
}
export const UserLogin_TYPE = function() {
  return 'post'
}
export const UserLoginURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/user/login'
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ANONIMOUS Vk login user
 * request: UserLoginVkAccessToken
 * url: UserLoginVkAccessTokenURL
 * method: UserLoginVkAccessToken_TYPE
 * raw_url: UserLoginVkAccessToken_RAW_URL
 * @param code - 
 * @param redirectUri - 
 */
export const UserLoginVkAccessToken = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/user/loginVkAccessToken'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['code'] !== undefined) {
    queryParameters['code'] = parameters['code']
  }
  if (parameters['redirectUri'] !== undefined) {
    queryParameters['redirectUri'] = parameters['redirectUri']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const UserLoginVkAccessToken_RAW_URL = function() {
  return '/api/user/loginVkAccessToken'
}
export const UserLoginVkAccessToken_TYPE = function() {
  return 'get'
}
export const UserLoginVkAccessTokenURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/user/loginVkAccessToken'
  if (parameters['code'] !== undefined) {
    queryParameters['code'] = parameters['code']
  }
  if (parameters['redirectUri'] !== undefined) {
    queryParameters['redirectUri'] = parameters['redirectUri']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}
/**
 * WEB ANONIMOUS refresh token
 * request: UserRefreshToken
 * url: UserRefreshTokenURL
 * method: UserRefreshToken_TYPE
 * raw_url: UserRefreshToken_RAW_URL
 * @param jwtToken - 
 * @param refreshToken - 
 */
export const UserRefreshToken = function(parameters = {}) {
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  const config = parameters.$config
  let path = '/api/user/refreshToken'
  let body
  let queryParameters = {}
  let form = {}
  if (parameters['jwtToken'] !== undefined) {
    queryParameters['jwtToken'] = parameters['jwtToken']
  }
  if (parameters['refreshToken'] !== undefined) {
    queryParameters['refreshToken'] = parameters['refreshToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    });
  }
  return request('get', domain + path, body, queryParameters, form, config)
}
export const UserRefreshToken_RAW_URL = function() {
  return '/api/user/refreshToken'
}
export const UserRefreshToken_TYPE = function() {
  return 'get'
}
export const UserRefreshTokenURL = function(parameters = {}) {
  let queryParameters = {}
  const domain = parameters.$domain ? parameters.$domain : getDomain()
  let path = '/api/user/refreshToken'
  if (parameters['jwtToken'] !== undefined) {
    queryParameters['jwtToken'] = parameters['jwtToken']
  }
  if (parameters['refreshToken'] !== undefined) {
    queryParameters['refreshToken'] = parameters['refreshToken']
  }
  if (parameters.$queryParameters) {
    Object.keys(parameters.$queryParameters).forEach(function(parameterName) {
      queryParameters[parameterName] = parameters.$queryParameters[parameterName]
    })
  }
  let keys = Object.keys(queryParameters)
  return domain + path + (keys.length > 0 ? '?' + (keys.map(key => key + '=' + encodeURIComponent(queryParameters[key])).join('&')) : '')
}