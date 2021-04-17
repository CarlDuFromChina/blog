// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue';
import App from './App';
import router from './router';
import components from './components';
import MintUI from 'mint-ui';
import 'mint-ui/lib/style.css';
import './style/index.less';
import './assets/icons';
import 'web-core';
import moment from 'vue-moment';
import './lib/extension';
import './directives';

Vue.use(moment);
Vue.use(MintUI);
Vue.use(components);
Vue.prototype.$bus = new Vue();
Vue.prototype.$message = MintUI.MessageBox;
Vue.config.productionTip = false;

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
});