import service from "@/shared/modules/item/service";

const state = {
  item: {},
  items: [],
};

const getters = {
  item: (state) => state.item,
  items: (state) => state.items,
};

const actions = {
  async getItem({ commit }, id) {
    const result = await service.getItem(id);
    commit("setItem", result);
  },
  async getItems({ commit }) {
    const result = await service.getItems();
    commit("setItems", result);
  },
  async addItem({ dispatch }, command) {
    await service.addItem(command);
    await dispatch("getItems");
  },
  async editItem({ dispatch }, command) {
    await service.editItem(command);
    await dispatch("getItems");
  },
  async getItemLoanHistory({ commit }, itemId) {
    const result = await service.getItemLoanHistory(itemId);
    commit("setItem", result);
  },
  async loanItem({ dispatch }, itemId) {
    await service.loanItem(itemId);
    await dispatch("getItemLoanHistory", itemId);
  },
};

const mutations = {
  setItem(state, result) {
    state.item = result;
  },
  setItems(state, result) {
    state.items = result;
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
