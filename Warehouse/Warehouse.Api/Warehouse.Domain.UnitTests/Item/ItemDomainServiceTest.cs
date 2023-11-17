using Moq;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item;
using Warehouse.Domain.Item.Enumeration;
using Warehouse.Domain.User;
using Warehouse.Domain.User.Enumeration;
using Xunit;

namespace Warehouse.Domain.UnitTests.Item;

public sealed class ItemDomainServiceTest
{
    private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
    private readonly Mock<IItemRepository> _itemRepositoryMock = new Mock<IItemRepository>();

    private readonly ItemDomainService _itemDomainService;

    public ItemDomainServiceTest()
    {
        _itemDomainService = new ItemDomainService(_userRepositoryMock.Object, _itemRepositoryMock.Object);
    }

    [Fact]
    public async Task ShouldLoadItemAsync()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var itemId = Guid.NewGuid();

        SetupUserRepositoryMock(userId);
        SetupItemRepositoryMock(itemId);

        // Act
        await _itemDomainService.LoanItemAsync(itemId, userId, CancellationToken.None);

        Domain.Item.Entities.Item verifiedItem = null;
        var validation = (Domain.Item.Entities.Item item) =>
        {
            verifiedItem = item;
            return true;
        };

        // Assert
        _itemRepositoryMock.Verify(repository => repository
            .Update(It.Is<Domain.Item.Entities.Item>(user => validation.Invoke(user))));

        var history = Assert.Single(verifiedItem!.LoanHistories);
        Assert.Equal(userId, history.ReceiverId);
    }

    private void SetupUserRepositoryMock(Guid receiverId)
    {
        _userRepositoryMock
            .Setup(repository => repository.GetAsync(
                It.Is<Guid>(id => id == receiverId),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Domain.User.Entities.User(
                Guid.NewGuid(),
                "Oskar",
                "Backi",
                Array.Empty<byte>(),
                "o.backi@gmail.com",
                "997213769",
                PermissionLevel.User,
                State.Active,
                null,
                null));
    }

    private void SetupItemRepositoryMock(Guid itemId)
    {
        _itemRepositoryMock
            .Setup(repository => repository.GetAsync(
                It.Is<Guid>(id => id == itemId),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(
                new Domain.Item.Entities.Item(
                    Guid.NewGuid(),
                    "Przedmiot",
                    "Boskara",
                    Guid.NewGuid(),
                    QualityLevel.Bad,
                    99,
                    State.Active,
                    Guid.NewGuid(),
                    Guid.NewGuid()));
    }
}