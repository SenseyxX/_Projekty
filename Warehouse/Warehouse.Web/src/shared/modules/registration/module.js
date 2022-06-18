import service from "@/shared/modules/registration/service";

const state = {
  user: {},
};

const getters = {
  user: (state) => state.user,
};

const actions = {
  async addUser({ state }, command) {
    await service.addUser(command);
  },
};

const mutations = {};

const module = {
  namespaced: true,
  state,
  mutations,
  getters,
  actions,
};

export default module;
