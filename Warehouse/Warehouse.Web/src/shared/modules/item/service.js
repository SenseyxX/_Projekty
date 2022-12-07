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
    const resource = `item/${itemId}`;
    return await client.delete(resource);
  },
  async loanItem(itemId) {
    const resource = `${itemId}/loan`;
    return await client.post(resource, itemId);
  },
  async importItems(file) {
    const resource = "item/import";
    return await client.file(resource, file);
  },
  async exportItems() {
    const resource = "item/export";
    const result = await client.get(resource);
    const currentDate = new Date().toISOString().split("T")[0];
    createDownloadFileUrl(result, `items-${currentDate}.csv`);
  },
};

function createDownloadFileUrl(result, fileName) {
  const blob = new Blob([result.data]);
  const fileUrl = window.URL.createObjectURL(blob);
  const a = document.createElement("a");
  document.body.appendChild(a);
  a.setAttribute("download", "file");
  a.style = "display: none";
  a.href = fileUrl;
  a.download = fileName;
  a.click();
  window.URL.revokeObjectURL(fileUrl);
  document.body.removeChild(a);
}

export default service;
