import service from "@/shared/modules/category/service";

const state = {
  category: [],
};

const getters = {
  category: (state) => state.category,
};

const actions = {
  async getCategory({ commit }, id) {
    const result = await service.getCategory(id);
    commit("setCategory", result);
  },
  async getCategories({ commit }) {
    const result = await service.getCategories();
    commit("setCategory", result);
  },
  async addCategory(command) {
    await service.addCategory(command);
  },
};

const mutations = {
  setCategory(state, result) {
    state.category = result;
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
