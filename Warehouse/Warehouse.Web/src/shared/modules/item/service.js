import client from "@/shared/http-client";
import { UserDto } from "@/shared/modules/user/dto";

const service = {
  async getItem(id) {
    const resource = `user/${id}`;
    const response = await client.get(resource);
    return new UserDto(response.data);
  },
  async addItem(command) {
    const resource = "item";
    return await client.post(resource, command);
  },
};

export default service;
