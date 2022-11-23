import client from "@/shared/http-client";
import { FullSquadDto } from "@/shared/modules/squad/dto";
import { FullTeamDto } from "@/shared/modules/squad/dto";

const service = {
  async getSquad(squadOwnerId) {
    const resource = `squad/${squadOwnerId}`;
    const response = await client.get(resource);
    return new FullSquadDto(response.data);
  },
  async getSquads() {
    const resource = "squad";
    const response = await client.get(resource);
    return response.data.map((squad) => new FullSquadDto(squad));
  },
  async addSquad(command) {
    const resource = "squad";
    return await client.post(resource, command);
  },
  async updateSquad(command) {
    const resource = `squad/${command.id}`;
    return await client.put(resource, command);
  },
  async getSquadTeams(squadId) {
    const resource = `squad/${squadId}/teams`;
    const response = await client.get(resource);
    return response.data.map((team) => new FullTeamDto(team));
  },
  async addTeam(command) {
    const resource = `squad/${command.squadId}/teams`;
    return await client.post(resource, command);
  },
  async updateTeam(command) {
    const resource = `team/${command.id}`;
    return await client.put(resource, command);
  },
};

export default service;
