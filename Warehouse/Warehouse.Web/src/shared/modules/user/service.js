﻿import client from "@/shared/http-client";
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
    const resource = `user/${command.id}`;
    return await client.put(resource, command);
  },
  async updatePassword(command) {
    const resource = `user/${command.id}/password`;
    return await client.put(resource, command);
  },
  async deleteUser(userId) {
    console.log(3, userId);
    const resource = `user/${userId}`;
    return await client.delete(resource);
  },
};

export default service;
