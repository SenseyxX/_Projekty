import service from "@/shared/modules/authentication/service";

const state = {
  authenticationResult: {},
};

const getters = {
  authenticationResult: (state) => state.authenticationResult,
};

const actions = {
  async authenticate({ commit }, command) {
    const result = await service.authenticate(command);
    commit("setAuthenticationResult", result);
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
