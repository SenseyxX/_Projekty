import client from "@/shared/http-client";
import { FullUserDto } from "@/shared/modules/user/dto";
import { FullItemDto } from "@/shared/modules/item/dto";

const service = {
  async getUsers() {
    const resource = "user";
    const response = await client.get(resource);
    return response.data.map((user) => new FullUserDto(user));
  },
  async getUser(userId) {
    const resource = `user/${userId}`;
    const response = await client.get(resource);
    return new FullUserDto(response.data);
  },
  async addUser(command) {
    const resource = "user";
    return await client.post(resource, command);
  },
  async getUserItems(userId) {
    const resource = `user/${userId}/items`;
    const response = await client.get(resource);
    return response.data.map((user) => new FullItemDto(user));
  },
};

export default service;
