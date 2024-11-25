using System;
//У цьому коді порушено принцип єдиного обов’язку. Клас EmailSender виконує дві задачі: Відправляє email таЛогує інформацію про відправлення через консоль.
//Щоб виправити це, необхідно винести логування в окремий клас. Таким чином, клас EmailSender відповідатиме лише за відправлення email.

// Клас для представлення Email
class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

// Інтерфейс для логування
interface ILogger
{
    void Log(string message);
}

// Клас для логування в консоль
class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

// Клас для відправки Email
class EmailSender
{
    private readonly ILogger _logger;

    // Через Dependency Injection передаємо логер
    public EmailSender(ILogger logger)
    {
        _logger = logger;
    }

    public void Send(Email email)
    {
        // Реалізація відправки Email
        // ... sending logic here ...

        // Логування через абстракцію
        _logger.Log($"Email from '{email.From}' to '{email.To}' was sent.");
    }
}

// Головний клас програми
class Program
{
    static void Main(string[] args)
    {
        // Створюємо інстанс логера
        ILogger logger = new ConsoleLogger();

        // Ін'єкція логера в EmailSender
        EmailSender emailSender = new EmailSender(logger);

        // Створення email-ів
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "Vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "Washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        // Відправка email-ів
        emailSender.Send(e1);
        emailSender.Send(e2);
        emailSender.Send(e3);
        emailSender.Send(e4);
        emailSender.Send(e5);
        emailSender.Send(e6);

        Console.ReadKey();
    }
}
