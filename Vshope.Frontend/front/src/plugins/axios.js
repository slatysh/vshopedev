import Vue from 'vue'
import { setDomain } from '@/services'

// Lib imports
import axios from 'axios'

Vue.prototype.$http = axios

axios.defaults.baseURL = process.env.VUE_APP_SERVER_BASE_URL
setDomain(process.env.VUE_APP_SERVER_BASE_URL)
