import service from "@/shared/modules/squad/service";

const state = {
  squads: [],
  squad: {},
  teams: [],
  team: {},
};

const getters = {
  squads: (state) => state.squads,
  squad: (state) => state.squad,
  teams: (state) => state.teams,
  team: (state) => state.team,
};

const actions = {
  async getSquad({ commit }, squadOwnerId) {
    const result = await service.getSquad(squadOwnerId);
    commit("setSquad", result);
  },
  async getSquads({ commit }) {
    const result = await service.getSquads();
    commit("setSquads", result);
  },
  async addSquad({ dispatch }, command) {
    await service.addSquad(command);
    await dispatch("getSquads");
  },
  async updateSquad({ dispatch }, command) {
    await service.updateSquad(command);
    await dispatch("getSquads", command.id);
  },
  async getSquadTeams({ commit }, squadId) {
    const result = await service.getSquadTeams(squadId);
    commit("setTeams", result);
  },
  async addTeam({ dispatch }, command) {
    await service.addTeam(command);
    await dispatch("getSquadTeams");
  },
  async updateTeam({ dispatch }, command) {
    await service.updateTeam(command);
    await dispatch("getSquads", command.id);
  },
};

const mutations = {
  setSquad(state, result) {
    state.squad = result;
  },
  setSquads(state, result) {
    state.squads = result;
  },
  setTeam(state, result) {
    state.team = result;
  },
  setTeams(state, result) {
    state.teams = result;
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
