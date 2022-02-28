import client from "@/shared/http-client";

const service = {
  async addUser(command) {
    const resource = "user";
    return await client.post(resource, command);
  },
};

export default service;
