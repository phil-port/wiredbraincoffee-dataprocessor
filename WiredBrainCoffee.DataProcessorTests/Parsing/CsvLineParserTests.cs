
namespace WiredBrainCoffee.DataProcessor.Parsing;

public class CsvLineParserTests
{
    [Fact]
    public void ShouldParseValidLine()
    {
        //Arrange
        string[] csvLines = { "Cappuccino;10/27/2022 8:06:04 AM" };

        //Act
        var machineDataItems = CsvLineParser.Parse(csvLines);

        //Assert
        Assert.NotNull(machineDataItems);
        Assert.Single(machineDataItems);
        Assert.Equal("Cappuccino", machineDataItems[0].CoffeeType);
        Assert.Equal(new DateTime(2022, 10, 27, 8, 6, 4), machineDataItems[0].CreatedAt);
    }

    [Fact]
    public void ShouldSkipEmptyLines()
    {
        //Arrange
        string[] csvLines = { "", " " };

        //Act
        var machineDataItems = CsvLineParser.Parse(csvLines);

        //Assert
        Assert.NotNull(machineDataItems);
        Assert.Empty(machineDataItems);
    }

    [Theory]
    [InlineData("Cappuccino", "Invalid csv line")]
    [InlineData("Cappuccino;InvalidDateTime", "Invalid datetime in csv line")]
    public void ShouldThrowExceptionForInvalidLine(string csvLine, string expectedMessagePrefix)
    {
        //Arrange
        string[] csvLines = { csvLine };

        //Act and Assert
        var exception = Assert.Throws<Exception>(() => CsvLineParser.Parse(csvLines));
        Assert.Equal($"{expectedMessagePrefix}: {csvLine}", exception.Message);
    }
}
