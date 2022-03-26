﻿import service from "@/shared/modules/squad/service";

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
  async getSquads({ commit }) {
    const result = await service.getSquads();
    commit("setSquads", result);
  },
  async getSquad({ commit }, squadOwnerId) {
    const result = await service.getSquad(squadOwnerId);
    commit("setSquad", result);
  },
  async addSquad({ dispatch }, command) {
    await service.addSquad(command);
    await dispatch("getSquads");
  },
  async getSquadTeams({ commit }, squadId) {
    const result = await service.getSquadTeams(squadId);
    commit("setTeams", result);
  },
  async addTeam({ dispatch }, command) {
    await service.addTeam(command);
    await dispatch("getSquadTeams");
  },
};

const mutations = {
  setSquad(state, result) {
    state.squad = result;
  },
  setSquads(state, result) {
    state.squads = result;
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
