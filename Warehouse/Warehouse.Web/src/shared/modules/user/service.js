import client from "@/shared/http-client";
import { FullUserDto } from "@/shared/modules/user/dto";

const service = {
  async getUser(userId) {
    const resource = `user/${userId}`;
    const response = await client.get(resource);
    return new FullUserDto(response.data);
  },
  async getUsers() {
    const resource = "user";
    const response = await client.get(resource);
    return response.data.map((user) => new FullUserDto(user));
  },
  async addUser(command) {
    const resource = "user";
    return await client.post(resource, command);
  },
  async updateUser(command) {
    const resource = "user"; // ToDo: check endpoint
    return await client.put(resource, command);
  }
};

export default service;
