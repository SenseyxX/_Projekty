import client from "@/shared/http-client";
import { SquadDto } from "@/shared/modules/squad/dto";

const service = {
  async getSquad(squadOwnerId) {
    const resource = `squad/${squadOwnerId}`;
    const response = await client.get(resource);
    return new SquadDto(response.data);
  },
  async addSquad(command) {
    const resource = "squad";
    return await client.post(resource, command);
  },
};

export default service;
