import client from "@/shared/http-client";
import { FullUserDto } from "@/shared/modules/user/dto";
import {FullItemDto} from "@/shared/modules/item/dto";

const service = {
  async getUsers() {
    const resource = "user";
    const response = await client.get(resource);
    return response.data.map((team) => new FullUserDto(team));
  },
  async getUser(userId) {
    const resource = `user/${userId}`;
    const response = await client.get(resource);
    return new FullUserDto(response.data);
  },
  async addUser(command) {
    const resource = "team";
    return await client.post(resource, command);
  },
  async getUserItems(userId) {
    const resource = `user/${userId}/items`;
    const response = await client.get(resource);
    return response.data.map((team) => new FullItemDto(team));
  },
};

export default service;
