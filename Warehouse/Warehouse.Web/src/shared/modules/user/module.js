import service from "@/shared/modules/user/service";

const state = {
  user: {},
  users: [],
};

const getters = {
  user: (state) => state.user,
  users: (state) => state.users,
};

const actions = {
  async getUser({ commit }, userId) {
    const result = await service.getUser(userId);
    commit("setUser", result);
  },
  async getUsers({ commit }) {
    const result = await service.getUsers();
    commit("setUsers", result);
  },
  async addUser({ dispatch }, command) {
    await service.addUser(command);
    await dispatch(command.id);
  },
  async updateUser({ commit }, command){
    commit (command);
  }
}

const mutations = {
  setUser(state, result) {
    state.user = result;
  },
  setUsers(state, result) {
    state.users = result;
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
