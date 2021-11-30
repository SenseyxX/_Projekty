import { UserDto } from "@/shared/modules/user/dto";

export class AuthenticationResultDto {
  constructor(data = {}) {
    this.isAuthenticated = data.isAuthenticated;
    this.jwt = data.jwt;
    this.tokenOwner = new UserDto(data.tokenOwner ? data.tokenOwner : {});
  }
}
