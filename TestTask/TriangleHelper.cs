namespace TestTask;

public static class TriangleHelper
{
    /// <summary>
    /// Определение типа треугольника
    /// </summary>
    /// <param name="sideA">Сторона A</param>
    /// <param name="sideB">Сторона B</param>
    /// <param name="sideC">Сторона C</param>
    /// <returns>Тип треугольника</returns>
    /// <exception cref="InvalidTriangleSidesException">Исключение вызываемое при неправильных значениях сторон треугольника</exception>
    public static TriangleTypes DeterminingTheTypeOfTriangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 ||
            sideB <= 0 ||
            sideC <= 0)
            throw new InvalidTriangleSidesException("Стороны не могут иметь отрицательное или нулевое значение");

        if (sideA + sideB < sideC ||
            sideA + sideC < sideB ||
            sideB + sideC < sideA)
            throw new InvalidTriangleSidesException("Треугольник не может существовать с данными длинами сторон");

        var sides = new List<double>() { sideA, sideB, sideC };
        sides = sides.OrderBy(s => s).Select(s => Math.Pow(s,2)).ToList();

        if (sides[2] < sides[0] + sides[1])
        {
            return TriangleTypes.AcuteTriangle;
        }
        else if (sides[2] > sides[0] + sides[1])
        {
            return TriangleTypes.ObtuseTriangle;
        }
        else
        {
            return TriangleTypes.RightTriangle;
        }
    }

    /// <summary>
    /// Типы треугольников
    /// </summary>
    public enum TriangleTypes
    {
        RightTriangle,
        AcuteTriangle,
        ObtuseTriangle
    }
}

/// <summary>
/// Исключение вызываемое при неправильных значениях сторон треугольника, при которых существование треугольника невозможно
/// </summary>
public class InvalidTriangleSidesException : Exception
{
    public InvalidTriangleSidesException(string message)
        : base(message)
    {
    }
}