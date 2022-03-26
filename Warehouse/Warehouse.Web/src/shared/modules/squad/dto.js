import { FullUserDto } from "@/shared/modules/user/dto";

export class FullSquadDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.squadOwnerId = data.squadOwnerId;
    this.state = data.state;
    this.teams = data.teams ? data.teams.map((team) => new TeamDto(team)) : [];
    this.users = data.users
      ? data.users.map((user) => new FullUserDto(user))
      : [];
  }
}
export class SquadDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.squadOwnerId = data.squadOwnerId;
  }
}

export class TeamDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.squadId = data.squadId;
  }
}

export class FullTeamDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.squadId = data.squadId;
    this.teamOwnerId = data.teamOwnerId;
    this.points = data.points;
    //ToDo: add Users
  }
}
