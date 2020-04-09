import Vue from 'vue'
import 'moment/locale/ru'
import VueMomentLib from 'vue-moment-lib'
import store from '@/store'
import moment from 'moment'
Vue.use(VueMomentLib)
moment.locale(store.state.app.lang)
