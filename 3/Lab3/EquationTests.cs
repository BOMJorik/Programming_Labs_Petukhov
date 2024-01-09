namespace Lab3;
using Moq;
using Xunit;

public class EquationTests
{
    [Fact]
    public void Run_ShouldLoadResultsFromDatabase()
    {
        // Arrange
        var modelMock = new Mock<ICalculator>();
        var viewMock = new Mock<IDisplay>();
        var databaseMock = new Mock<IDatabase>();
        var testResults = new List<ICalculator> { /* Ваши тестовые данные */ };
        databaseMock.Setup(db => db.LoadResults(It.IsAny<string>())).Returns(testResults);
        var equation = new Equation(modelMock.Object, viewMock.Object, databaseMock.Object);

        // Act
        equation.Run();

        // Assert
    }
}
