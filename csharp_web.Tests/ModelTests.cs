using csharp_web.Models;
using Xunit;

namespace csharp_web.Tests;

public class ModelTests
{
    [Fact]
    public void Burger_WithValidData_ShouldKeepConfiguredValues()
    {
        var burger = new Burger
        {
            Nom = "Cheeseburger",
            Description = "Burger classique avec fromage",
            Prix = 5000,
            Image = "cheeseburger.jpg"
        };

        Assert.Equal("Cheeseburger", burger.Nom);
        Assert.True(burger.Prix > 0);
    }

    [Fact]
    public void Client_WithValidData_ShouldKeepIdentityFields()
    {
        var client = new Client
        {
            Nom = "Diop",
            Prenom = "Awa",
            Telephone = "771234567"
        };

        Assert.Equal("Awa", client.Prenom);
        Assert.StartsWith("77", client.Telephone);
    }
}
