import client from "@/shared/http-client";
import { SquadDto } from "@/shared/modules/squad/dto";
import { FullTeamDto } from "@/shared/modules/squad/dto";

const service = {
  async getSquads() {
    const resource = "squad";
    const response = await client.get(resource);
    return response.data.map((squad) => new SquadDto(squad));
  },
  async getSquad(squadOwnerId) {
    const resource = `squad/${squadOwnerId}`;
    const response = await client.get(resource);
    return new SquadDto(response.data);
  },
  async addSquad(command) {
    const resource = "squad";
    return await client.post(resource, command);
  },
  async getSquadTeams(squadId) {
    const resource = `squad/${squadId}/teams`;
    const response = await client.get(resource);
    return response.data.map((team) => new FullTeamDto(team));
  },
};

export default service;
