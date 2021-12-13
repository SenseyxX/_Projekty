import Vue from "vue";
import Vuex from "vuex";

import requestModule from "@/shared/modules/request/module";
import authenticationModule from "@/shared/modules/authentication/module";
import squadModule from "@/shared/modules/squad/module";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    requestModule,
    authenticationModule,
    squadModule,
  },
});
export default store;
