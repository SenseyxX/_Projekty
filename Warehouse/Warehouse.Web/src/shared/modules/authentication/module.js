import service from "@/shared/modules/authentication/service";
import { AuthenticationResultStorageKey } from "@/shared/constants";

const state = {
  authenticationResult: {},
};

const getters = {
  authenticationResult: (state) => state.authenticationResult,
};

const actions = {
  async authenticate({ commit, dispatch }, command) {
    const result = await service.authenticate(command);
    commit("setAuthenticationResult", result);
    dispatch("pushAuthenticationResult");
  },
  logout({ commit, dispatch }) {
    commit("setAuthenticationResult", {});
    dispatch("removeAuthenticationResult");
  },
  pushAuthenticationResult({ state }) {
    localStorage.setItem(
      AuthenticationResultStorageKey,
      JSON.stringify(state.authenticationResult)
    );
  },
  recallAuthenticationResult({ commit }) {
    const authenticationResult = JSON.parse(
      localStorage.getItem(AuthenticationResultStorageKey)
    );

    if (authenticationResult) {
      commit("setAuthenticationResult", authenticationResult);
    }
  },
  removeAuthenticationResult() {
    localStorage.removeItem(AuthenticationResultStorageKey);
  },
};

const mutations = {
  setAuthenticationResult(state, result) {
    state.authenticationResult = result;
  },
};

const module = {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};

export default module;
