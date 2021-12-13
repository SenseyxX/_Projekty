export class SquadDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.state = data.state;
    // ToDo: Add teams
    // ToDo: Add users
  }
}
