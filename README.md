Задание выполнил, со всеми условиями, юнит-тесты в ShapeTestUnitTest, Легкость добавления других фигур реализована через интерфейс IShape, Вычисление площади фигуры, без знания типа фигуры в compile-time реализовано с помощью фабричного паттерна, также в библиотеку добавлен функционал проверки треугольника на прямой угол
Задание 3
SELECT p.ProductName, c.CategoryName
FROM Products p
LEFT JOIN ProductCategories pc ON p.ProductID = pc.ProductID
LEFT JOIN Categories c ON pc.CategoryID = c.CategoryID
