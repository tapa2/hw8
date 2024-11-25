using System;

//Проблема полягає у порушенні принципу підстановки Лісков
//Згідно з цим принципом, підклас повинен мати можливість замінити батьківський клас без порушення функціональності програми.
//У цьому випадку Square не поводиться як Rectangle, оскільки для квадрата ширина і висота завжди повинні бути однаковими, а це порушує поведінкові очікування для прямокутника.
//Зробимо Прямокутник і Квадрат окремими класами.

// Інтерфейс для фігур
interface IShape
{
    int GetArea();
}

// Клас Rectangle реалізує IShape
class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public int GetArea()
    {
        return Width * Height;
    }
}

// Клас Square реалізує IShape
class Square : IShape
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        // Робота з прямокутником
        Rectangle rect = new Rectangle { Width = 5, Height = 10 };
        Console.WriteLine($"Rectangle Area: {rect.GetArea()}");

        // Робота з квадратом
        Square square = new Square { Side = 5 };
        Console.WriteLine($"Square Area: {square.GetArea()}");

        Console.ReadKey();
    }
}
