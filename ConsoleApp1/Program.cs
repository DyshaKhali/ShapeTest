using System;
using System.Collections.Generic;
using ShapeTest;

namespace GeometryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создаем круг
                IShape circle = ShapeFactory.CreateShape("circle", new List<double> { 5 });
                Console.WriteLine($"Площадь круга: {circle.CalculateArea()}");

                // Создаем треугольник
                IShape triangle = ShapeFactory.CreateShape("triangle", new List<double> { 3, 4, 5 });
                Console.WriteLine($"Площадь треугольника: {triangle.CalculateArea()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}