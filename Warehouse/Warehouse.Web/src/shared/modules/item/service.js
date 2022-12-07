import client from "@/shared/http-client";
import { FullItemDto } from "@/shared/modules/item/dto";
import { LoanHistoryDto } from "@/shared/modules/item/dto";

const service = {
  async getItem(itemId) {
    const resource = `user/${itemId}`;
    const response = await client.get(resource);
    return new FullItemDto(response.data);
  },
  async getItems() {
    const resource = "item";
    const response = await client.get(resource);
    return response.data.map((item) => new FullItemDto(item));
  },
  async addItem(command) {
    const resource = "item";
    return await client.post(resource, command);
  },
  async updateItem(command) {
    const resource = `item/${command.id}`;
    return await client.put(resource, command);
  },
  async getItemLoanHistory(itemId) {
    const resource = `${itemId}/loan-history`;
    const response = await client.get(resource);
    return new LoanHistoryDto(response.data);
  },
  async deleteItem(itemId) {
    console.log(3, itemId);
    const resource = `item/${itemId}`;
    return await client.delete(resource);
  },
  async loanItem(itemId) {
    const resource = `${itemId}/loan`;
    return await client.post(resource, itemId);
  },
};

export default service;
