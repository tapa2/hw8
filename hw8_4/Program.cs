using System;
/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.*/
/*
Код порушує принцип розділення інтерфейсів (Interface Segregation Principle, ISP), оскільки інтерфейс IItem змушує реалізовувати методи, які не потрібні кожному класу.
Розділимо інтерфейс IItem на кілька дрібніших інтерфейсів, кожен із яких відповідає окремій функціональності. 
*/
// Інтерфейс для роботи з ціною
interface IPriceable
{
    void SetPrice(double price);
}

// Інтерфейс для роботи зі знижками
interface IDiscountable
{
    void ApplyDiscount(string discount);
    void ApplyPromocode(string promocode);
}

// Інтерфейс для роботи з розміром
interface ISizable
{
    void SetSize(byte size);
}

// Інтерфейс для роботи з кольором
interface IColorable
{
    void SetColor(byte color);
}

// Клас для книг (має лише ціну та знижки)
class Book : IPriceable, IDiscountable
{
    private double price;
    private string discount;
    private string promocode;

    public void SetPrice(double price)
    {
        this.price = price;
        Console.WriteLine($"Book price set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
        Console.WriteLine($"Discount '{discount}' applied to the book.");
    }

    public void ApplyPromocode(string promocode)
    {
        this.promocode = promocode;
        Console.WriteLine($"Promocode '{promocode}' applied to the book.");
    }
}

// Клас для верхнього одягу (має ціну, знижки, розмір та колір)
class Clothing : IPriceable, IDiscountable, ISizable, IColorable
{
    private double price;
    private string discount;
    private string promocode;
    private byte size;
    private byte color;

    public void SetPrice(double price)
    {
        this.price = price;
        Console.WriteLine($"Clothing price set to: {price}");
    }

    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
        Console.WriteLine($"Discount '{discount}' applied to the clothing.");
    }

    public void ApplyPromocode(string promocode)
    {
        this.promocode = promocode;
        Console.WriteLine($"Promocode '{promocode}' applied to the clothing.");
    }

    public void SetSize(byte size)
    {
        this.size = size;
        Console.WriteLine($"Clothing size set to: {size}");
    }

    public void SetColor(byte color)
    {
        this.color = color;
        Console.WriteLine($"Clothing color set to: {color}");
    }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        // Робота з класом Book
        Book book = new Book();
        book.SetPrice(299.99);
        book.ApplyDiscount("10%OFF");
        book.ApplyPromocode("BOOKSALE");

        // Робота з класом Clothing
        Clothing clothing = new Clothing();
        clothing.SetPrice(499.99);
        clothing.ApplyDiscount("20%OFF");
        clothing.ApplyPromocode("WINTER2024");
        clothing.SetSize(42);
        clothing.SetColor(5); // Наприклад, 5 - це код кольору

        Console.ReadKey();
    }
}
