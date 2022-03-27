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
  async getItemLoanHistory(itemId) {
    const resource = `${itemId}/loan-history`;
    const response = await client.get(resource);
    return new LoanHistoryDto(response.data);
  },
  async loanItem(itemId) {
    const resource = `${itemId}/loan`;
    return await client.post(resource, itemId);
  },
};

export default service;
