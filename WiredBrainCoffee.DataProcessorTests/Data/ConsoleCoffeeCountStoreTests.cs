using WiredBrainCoffee.DataProcessor.Model;

namespace WiredBrainCoffee.DataProcessor.Data;

public class ConsoleCoffeeCountStoreTests
{
    [Fact]
    public void ShouldWriteOutputToConsole()
    {
        //Arrange
        var item = new CoffeeCountItem("Cappuccino", 5);
        var stringWriter = new StringWriter();
        var coffeeConsoleCountStore = new ConsoleCoffeeCountStore(stringWriter);

        //Act
        coffeeConsoleCountStore.Save(item);

        //Assert
        var result = stringWriter.ToString();
        Assert.Equal($"{item.CoffeeType}:{item.count}{Environment.NewLine}", result);
    }
}
