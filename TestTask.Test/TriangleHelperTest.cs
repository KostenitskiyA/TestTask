using TestTask;

public class TriangleHelperTest
{
    /// <summary>
    /// Определение типа треугольника с неправильными значениями
    /// </summary>
    /// <param name="sideA">Сторона A</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    [Theory]
    [InlineData(0, 5, 4)]
    [InlineData(-1, 5, 4)]
    [InlineData(1, -5, 4)]
    [InlineData(1, 5, -4)]
    [InlineData(2, 2, 5)]
    public void TriangleInvalidValuesTest(
        double sideA,
        double sideB,
        double sideC)
    {
        // Assert
        Assert.Throws<InvalidTriangleSidesException>(() =>
            TriangleHelper.DeterminingTheTypeOfTriangle(sideA, sideB, sideC));
    }

    /// <summary>
    /// Определение типа треугольника
    /// </summary>
    /// <param name="sideA">Сторона A</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    /// <param name="expected">Ожидаемый тип треугольника</param>
    [Theory]
    [InlineData(4, 3, 5, TriangleHelper.TriangleTypes.RightTriangle)]
    [InlineData(5, 2, 5, TriangleHelper.TriangleTypes.AcuteTriangle)]
    [InlineData(2, 2, 3, TriangleHelper.TriangleTypes.ObtuseTriangle)]
    public void TriangleValidValuesTest(
        double sideA,
        double sideB,
        double sideC,
        TriangleHelper.TriangleTypes expected)
    {
        // Arrange & Act
        var triangleType = TriangleHelper.DeterminingTheTypeOfTriangle(sideA, sideB, sideC);

        // Assert
        Assert.Equal(expected, triangleType);
    }
}