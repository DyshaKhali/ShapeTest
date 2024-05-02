using NUnit.Framework;
using ShapeTest;
using System;

namespace ShapeTestUnitTest
{
    [TestFixture]
    public class ShapeTests
    {
        [Test]
        public void Circle_CalculateArea_ReturnsCorrectResult()
        {
            // Arrange
            var circle = new Circle(5);
            var expected = Math.PI * 25; // πr²

            // Act
            var actual = circle.CalculateArea();

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Площадь круга неверно рассчитана.");
        }

        [Test]
        public void Triangle_CalculateArea_ReturnsCorrectResult()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            var semiPerimeter = (3 + 4 + 5) / 2.0;
            var expected = Math.Sqrt(semiPerimeter * (semiPerimeter - 3) * (semiPerimeter - 4) * (semiPerimeter - 5));

            // Act
            var actual = triangle.CalculateArea();

            // Assert
            Assert.That(actual, Is.EqualTo(expected).Within(0.001), "Площадь треугольника неверно рассчитана.");
        }

        [Test]
        public void ShapeFactory_CreateCircle_WithCorrectParameter_ReturnsCircle()
        {
            // Arrange
            var parameters = new List<double> { 5 };

            // Act
            var shape = ShapeFactory.CreateShape("circle", parameters);

            // Assert
            Assert.IsInstanceOf<Circle>(shape, "Фабрика должна создать экземпляр Circle.");
        }

        [Test]
        public void ShapeFactory_CreateTriangle_WithCorrectParameters_ReturnsTriangle()
        {
            // Arrange
            var parameters = new List<double> { 3, 4, 5 };

            // Act
            var shape = ShapeFactory.CreateShape("triangle", parameters);

            // Assert
            Assert.IsInstanceOf<Triangle>(shape, "Фабрика должна создать экземпляр Triangle.");
        }

        [Test]
        public void ShapeFactory_CreateShape_WithUnknownType_ThrowsArgumentException()
        {
            // Arrange
            var parameters = new List<double> { 1 };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape("hexagon", parameters), "Должно быть вызвано исключение для неизвестного типа фигуры.");
            Assert.That(ex.Message, Is.EqualTo("Неизвестный тип фигуры."));
        }

        [Test]
        public void Triangle_IsRightAngled_ReturnsTrueForRightAngled()
        {
            // Создаем прямоугольный треугольник с сторонами 3, 4, 5.
            var triangle = new Triangle(3, 4, 5);
            Assert.That(triangle.IsRightAngled(), Is.True, "Треугольник должен быть прямоугольным.");
        }

        [Test]
        public void Triangle_IsRightAngled_ReturnsFalseForNotRightAngled()
        {
            // Создаем не прямоугольный треугольник с сторонами 3, 4, 6.
            var triangle = new Triangle(3, 4, 6);
            Assert.That(triangle.IsRightAngled(), Is.False, "Треугольник не должен быть прямоугольным.");
        }
    }
}