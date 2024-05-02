namespace ShapeTest
{
    public class Circle : IShape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Triangle : IShape
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Стороны треугольника должны быть положительными числами.");

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new ArgumentException("Указанные стороны не образуют треугольник.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double CalculateArea()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        public bool IsRightAngled()
        {
            // Проверяем теорему Пифагора для каждой комбинации сторон
            return Math.Abs(SideA * SideA + SideB * SideB - SideC * SideC) < 1E-10 ||
                   Math.Abs(SideA * SideA + SideC * SideC - SideB * SideB) < 1E-10 ||
                   Math.Abs(SideB * SideB + SideC * SideC - SideA * SideA) < 1E-10;
        }
    }

    // С помощью интерфейса реализуем легкость добавления других фигур
}
