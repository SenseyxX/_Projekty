import Vue from "vue";
import Vuex from "vuex";

import requestModule from "@/shared/modules/request/module";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    requestModule,
  },
});
export default store;
