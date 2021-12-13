import service from "@/shared/modules/squad/service";

const state = {
  squad: {},
};

const getters = {
  squad: (state) => state.squad,
};

const actions = {
  async getSquad({ commit }, squadOwnerId) {
    const result = await service.getSquad(squadOwnerId);
    commit("setSquad", result);
  },
  async addSquad({ dispatch }, command) {
    await service.addSquad(command);
    await dispatch("getSquad", command.squadOwnerId);
  },
};

const mutations = {
  setSquad(state, result) {
    state.squad = result;
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
