export class UserDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.lastName = data.lastName;
    this.email = data.email;
    this.phoneNumber = data.phoneNumber;
    this.squadId = data.squadId;

    // ToDo: implement IEnumerable ownedItems and storedItems
  }
}
