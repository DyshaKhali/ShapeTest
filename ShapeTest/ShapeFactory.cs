using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTest
{
    public static class ShapeFactory
    {
        public static IShape CreateShape(string shapeType, List<double> parameters)
        {
            switch (shapeType.ToLower())
            {
                case "circle":
                    if (parameters.Count != 1)
                        throw new ArgumentException("Для круга необходим один параметр: радиус.");
                    return new Circle(parameters[0]);

                case "triangle":
                    if (parameters.Count != 3)
                        throw new ArgumentException("Для треугольника необходимы три параметра: длины сторон.");
                    return new Triangle(parameters[0], parameters[1], parameters[2]);

                default:
                    throw new ArgumentException("Неизвестный тип фигуры.");
            }
        }
    }
}
