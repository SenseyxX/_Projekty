﻿export class FullUserDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.lastName = data.lastName;
    this.email = data.email;
    this.phoneNumber = data.phoneNumber;
    this.squadId = data.squadId;
    this.teamId = data.teamId;
    // ToDo: implement IEnumerable ownedItems/storedItems and dues
  }
}

export class UserPasswordDto {
  constructor(data = {}) {
    this.id = data.id;
    this.password = data.password;
  }
}
