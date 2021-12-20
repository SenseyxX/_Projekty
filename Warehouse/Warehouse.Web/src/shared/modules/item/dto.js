﻿export class ItemFullDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
    this.categoryId = data.categoryId;
    this.qualityLevel = data.qualityLevel;
    this.quantity = data.quantity;
    this.state = data.state;
    this.ownerId = data.ownerId;
    this.actualOwner = data.actualOwner;
  }
}