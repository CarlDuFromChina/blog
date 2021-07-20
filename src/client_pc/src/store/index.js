import Vue from 'vue';
import auth from './auth';
import server from './server';
import user from './user';
import persistedState from 'vuex-persistedstate';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
  plugins: [persistedState({ storage: window.sessionStorage })],
  modules: [auth, server, user]
});
