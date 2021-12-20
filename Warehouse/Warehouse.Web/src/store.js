﻿import Vue from "vue";
import Vuex from "vuex";

import requestModule from "@/shared/modules/request/module";
import authenticationModule from "@/shared/modules/authentication/module";
import squadModule from "@/shared/modules/squad/module";
import itemModule from "@/shared/modules/item/module";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    requestModule,
    authenticationModule,
    squadModule,
    itemModule,
  },
});
export default store;