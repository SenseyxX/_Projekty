import { FullUserDto } from "@/shared/modules/user/dto";

export class AuthenticationResultDto {
  constructor(data = {}) {
    this.isAuthenticated = data.isAuthenticated;
    this.jwt = data.jwt;
    this.tokenOwner = data.tokenOwner
      ? new FullUserDto(data.tokenOwner)
      : undefined;
  }
}
