import client from "@/shared/http-client";
import { CategoryDto } from "@/shared/modules/category/dto";

const service = {
  async getCategory(categoryId) {
    const resource = `category/${categoryId}`;
    const response = await client.get(resource);
    return new CategoryDto(response.data);
  },
  async getCategories() {
    const resource = "category";
    const response = await client.get(resource);
    return response.data.map((category) => new CategoryDto(category));
  },
  async addCategory(command) {
    const resource = "category";
    return await client.post(resource, command);
  },
};

export default service;
