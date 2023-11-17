using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.User.Enumeration;
using Warehouse.Domain.User.Factories;
using Xunit;

namespace Warehouse.Domain.UnitTests.User;

public sealed class UserTest
{
    [Fact]
    public void ShouldCreateUser()
    {
        // Arrange
        var expectedName = "Oskar";
        var expectedLastName = "Backi";
        var expectedPasswordHash = new byte[] { 0, 22, 34, 252, 232 };
        var expectedEmail = "o.backi@gmail.com";
        var expectedPhoneNumber = "997213769";
        var expectedPermissionLevel = PermissionLevel.User;
        var expectedState = State.Active;

        // Act
        var result = UserFactory.Create(
            expectedName,
            expectedLastName,
            expectedPasswordHash,
            expectedEmail,
            expectedPhoneNumber,
            expectedPermissionLevel,
            null,
            null);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedName, result.Name);
        Assert.Equal(expectedLastName, result.LastName);
        Assert.Equal(expectedPasswordHash, result.PasswordHash);
        Assert.Equal(expectedEmail, result.Email);
        Assert.Equal(expectedPhoneNumber, result.PhoneNumber);
        Assert.Equal(expectedPermissionLevel, result.PermissionLevel);
        Assert.Equal(expectedState, result.State);
        Assert.Null(result.SquadId);
        Assert.Null(result.TeamId);
    }

    [Fact]
    public void ShouldUpdateName()
    {
        // Arrange
        var expectedChangedName = "Judyta";
        var user = GetDefault();

        // Act
        var result = user.UpdateName(expectedChangedName);

        // Assert
        Assert.True(result);
        Assert.Equal(expectedChangedName, user.Name);
    }

    [Fact]
    public void ShouldThrowNullReferenceObjectWhenPayingNotExistentDue()
    {
        // Arrange
        var user = GetDefault();
        var invalidId = Guid.NewGuid();

        // Act
        var payDue = () => user.PayDue(invalidId);

        // Assert
        Assert.Throws<NullReferenceException>(payDue);
    }

    [Fact]
    private Domain.User.Entities.User GetDefault()
    {
        var expectedName = "Oskar";
        var expectedLastName = "Backi";
        var expectedPasswordHash = new byte[] { 0, 22, 34, 252, 232 };
        var expectedEmail = "o.backi@gmail.com";
        var expectedPhoneNumber = "997213769";
        var expectedPermissionLevel = PermissionLevel.User;
        var expectedState = State.Active;

        var result = UserFactory.Create(
            expectedName,
            expectedLastName,
            expectedPasswordHash,
            expectedEmail,
            expectedPhoneNumber,
            expectedPermissionLevel,
            null,
            null);

        return result;
    }
}