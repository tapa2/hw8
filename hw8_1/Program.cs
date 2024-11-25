// Клас для товару
//клас Order відповідає за надто багато функцій: роботу із замовленням, відображення замовлення, а також операції збереження/завантаження.
//Щоб виправити це порушення, ми можемо розділити відповідальності класу Order на окремі класи

class Item
{
}

// Клас для замовлення: відповідає тільки за управління списком товарів
class Order
{
    private List<Item> itemList = new List<Item>();

    public List<Item> ItemList => itemList; // Тільки для читання, обмежує змінювання зовні

    public void CalculateTotalSum() {/* Реалізація розрахунку загальної суми */}
    public void AddItem(Item item) => itemList.Add(item);
    public void DeleteItem(Item item) => itemList.Remove(item);
    public int GetItemCount() => itemList.Count;
    public List<Item> GetItems() => new List<Item>(itemList); // Копія списку
}

// Сервіс для збереження/завантаження замовлення
class OrderRepository
{
    public void Load(Order order) {/* Реалізація завантаження замовлення */}
    public void Save(Order order) {/* Реалізація збереження замовлення */}
    public void Update(Order order) {/* Реалізація оновлення замовлення */}
    public void Delete(Order order) {/* Реалізація видалення замовлення */}
}

// Сервіс для друку замовлення
class OrderPrinter
{
    public void PrintOrder(Order order) {/* Реалізація друку замовлення */}
    public void ShowOrder(Order order) {/* Реалізація відображення замовлення */}
}


class Program
{
    static void Main()
    {
    }
}
