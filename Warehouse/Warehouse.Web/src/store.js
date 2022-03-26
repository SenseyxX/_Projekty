import Vue from "vue";
import Vuex from "vuex";

import requestModule from "@/shared/modules/request/module";
import authenticationModule from "@/shared/modules/authentication/module";
import squadModule from "@/shared/modules/squad/module";
import itemModule from "@/shared/modules/item/module";
import registrationModule from "@/shared/modules/registration/module";
import userModule from "@/shared/modules/user/module";

Vue.use(Vuex);

const store = new Vuex.Store({
  modules: {
    requestModule,
    authenticationModule,
    squadModule,
    userModule,
    itemModule,
    registrationModule,
  },
});

export default store;
