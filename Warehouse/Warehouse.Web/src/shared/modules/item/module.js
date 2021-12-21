import service from "@/shared/modules/item/service";

const state = {
  item: {},
};

const getters = {
  item: (state) => state.item,
};

const actions = {
  async getItem({ commit }, id) {
    const result = await service.getItem(id);
    commit("setItem", result);
  },
  async addItem({ dispatch }, command) {
    await service.addItem(command);
    await dispatch("getItem", command.id);
  },
};

const mutations = {
  setSquad(state, result) {
    state.item = result;
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
