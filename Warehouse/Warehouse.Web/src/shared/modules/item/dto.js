export class FullItemDto {
  constructor(data = {}) {
    this.id = data.id;
    this.name = data.name;
    this.description = data.description;
    this.categoryId = data.categoryId;
    this.categoryName = data.categoryName;
    this.qualityLevel = data.qualityLevel;
    this.qualityLevelName = data.qualityLevelName;
    this.quantity = data.quantity;
    this.state = data.state;
    this.ownerId = data.ownerId;
    this.ownerName = data.ownerName;
    this.actualOwnerId = data.actualOwnerId;
    this.actualOwnerName = data.actualOwnerName;
  }
}

export class LoanHistoryDto {
  constructor(data = {}) {
    this.id = data.id;
    this.timestamp = data.timestamp;
    this.itemId = data.itemId;
    this.borrowerId = data.borrowerId;
    this.receiverId = data.receiverId;
  }
}
