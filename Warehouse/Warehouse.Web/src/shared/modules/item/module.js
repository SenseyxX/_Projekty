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
  async updateItem({ dispatch }, command) {
    await service.updateItem(command);
    await dispatch("getItems", command.id);
  },
  async getItemLoanHistory({ commit }, itemId) {
    const result = await service.getItemLoanHistory(itemId);
    commit("setItem", result);
  },
  async deleteItem({ dispatch }, id) {
    await service.deleteItem(id);
    await dispatch("getItems");
  },
  async loanItem({ dispatch }, itemId) {
    await service.loanItem(itemId);
    await dispatch("getItemLoanHistory", itemId);
  },
  async importItems({ dispatch }, file) {
    await service.importItems(file);
    await dispatch("getItems");
  },
  async exportItems() {
    await service.exportItems();
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
