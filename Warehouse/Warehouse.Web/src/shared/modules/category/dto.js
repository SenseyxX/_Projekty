export class CategoryDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
  }
}
