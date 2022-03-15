import service from "@/shared/modules/user/service";

const state = {
  user: {},
};

const getters = {
  user: (state) => state.user,
};

const actions = {
  async getUser({ commit }, id) {
    const result = await service.getUser(id);
    commit("setUser", result);
  },
  async addUser({ dispatch }, command) {
    await service.addUser(command);
    await dispatch("getUser", command.id);
  },
};

const mutations = {
  setUser(state, result) {
    state.user = result;
  },
};

const module = {
  namespaced: true,
  state,
  mutations,
  getters,
  actions,
};

export default module;
