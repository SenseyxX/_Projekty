﻿import Vue from "vue";
import Vuex from "vuex";

import requestModule from "@/shared/modules/request/module";
import authenticationModule from "@/shared/modules/authentication/module";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    requestModule,
    authenticationModule,
  },
});
export default store;
