import client from "@/shared/http-client";
import { AuthenticationResultDto } from "@/shared/modules/authentication/dto";

const service = {
  async authenticate(command) {
    const resource = "authentication";
    const result = await client.post(resource, command);
    return new AuthenticationResultDto(result ? result.data : {});
  },
};

export default service;
