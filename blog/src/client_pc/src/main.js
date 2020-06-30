import VueBus from 'vue-bus';
import App from './App';
import moduleRouter from './module';
import admin from './module/admin';
import platform from 'sixpence.platform.pc.vue';
import components from './components';
import './assets/icons';
import './style/index.less';
import './directives';

const Vue = require('vue');
const VueRouter = require('vue-router');
const Vuex = require('vuex');
const moment = require('moment');

Vue.config.productionTip = false;

const install = _Vue => {
  components.forEach(item => {
    _Vue.component(item.name, item.component);
  });
};

Vue.use(install);
Vue.use(platform.install);
Vue.prototype.$moment = moment; // 赋值使用
Vue.use(moment);
Vue.use(VueBus);
Vue.use(Vuex);

// 合并平台路由
let routes = platform.router.options.routes;
routes = routes.concat(moduleRouter);
routes.forEach(item => {
  if (item.name === 'admin') {
    item.children = item.children.concat(admin);
  }
});
const router = new VueRouter({
  routes: [
    {
      // 顶层
      path: '/',
      component: App,
      children: routes,
      redirect: 'index'
    }
  ]
});

Vue.use(Vuex);
const store = platform.store;
/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
});
