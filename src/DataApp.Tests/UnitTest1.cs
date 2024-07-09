namespace DataApp.Tests;

public class UnitTest1
{
    [Fact]
    public void DataIdReturnsMinusOne()
    {
        // Arrange
        var manager = new DataManager();
        int invalidDataId = -1;

        // Act
        var result = manager.ConsolidateDataFromSources(invalidDataId);

        // Assert
        Assert.Equal(-1, result);
    }

    [Fact]
    public void DataIdReturnsMinusTwo()
    {
        // Arrange
        var manager = new DataManager();
        int dataIdWithNullOrWhiteSpace = 0;

        // Act
        var result = manager.ConsolidateDataFromSources(dataIdWithNullOrWhiteSpace);

        // Assert
        Assert.Equal(-2, result);
    }

    [Fact]
    public void DataIdReturnsZero()
    {
        // Arrange
        var manager = new DataManager();
        int validDataId = 1;

        // Act
        var result = manager.ConsolidateDataFromSources(validDataId);

        // Assert
        Assert.Equal(0, result);
    }
}

