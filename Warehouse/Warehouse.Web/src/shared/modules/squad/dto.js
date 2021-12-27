import { UserDto } from "@/shared/modules/user/dto";

export class SquadDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.state = data.state;
    this.teams = data.teams ? data.teams.map((team) => new TeamDto(team)) : [];
    this.users = data.users ? data.users.map((user) => new UserDto(user)) : [];
  }
}

export class TeamDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.squadId = data.squadId;
  }
}
