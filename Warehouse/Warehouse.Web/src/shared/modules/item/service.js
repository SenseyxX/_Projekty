import client from "@/shared/http-client";
import { ItemDto } from "@/shared/modules/item/dto";

const service = {
  async getItem(id) {
    const resource = `user/${id}`;
    const response = await client.get(resource);
    return new ItemDto(response.data);
  },
  async addItem(command) {
    const resource = "item";
    return await client.post(resource, command);
  },
};

export default service;
