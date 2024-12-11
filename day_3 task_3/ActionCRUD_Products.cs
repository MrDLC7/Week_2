using static day_3_task_3.ConsoleUtilities;

namespace day_3_task_3
{
    internal class ActionCRUD_Products
    {
        // Операція Create (створення запису) із CRUD
        public static void CreateProducts(Context context)
        {
            Console.Write("Введіть назву товару: ");
            string name = Console.ReadLine();

            Console.Write("Введіть ціну товару: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                var newProduct = new Product { Name = name, Price = price };

                context.Products.Add(newProduct);       // Додавання товару
                context.SaveChanges();

                WriteLine_SetTextColor("Товар успішно додано!", ConsoleColor.Green);
            }
            else
            {
                WriteLine_SetTextColor("Невірний формат ціни. Спробуйте ще раз.", ConsoleColor.Red);
            }
        }

        // Операція Read (читання записів) із CRUD
        public static void ReadProducts(Context context)
        {
            var products = context.Products.ToList();

            if (products.Count != 0)
            {
                Console.WriteLine("Список товарів:");
                // Виведення списку
                foreach (var product in products)
                {
                    Console.WriteLine
                        (
                            $"ID: {product.Id,-5} " +
                            $"Назва: {product.Name,-15} " +
                            $"Ціна: {product.Price,-15:C} грн"
                        );
                }
            }
            else
            {
                WriteLine_SetTextColor("\nТовари відсутні.", ConsoleColor.Red);
            }
        }

        // Операція Update (оновлення запису) із CRUD
        public static void UpdateProducts(Context context)
        {
            Console.Write("Введіть назву товару: ");

            string name = Console.ReadLine();
            // Пошук товару
            var product = context.Products.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                Console.Write("Введіть нову ціну товару: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    product.Price = price;          // Оновлення ціни товару
                    context.SaveChanges();
                    WriteLine_SetTextColor($"Ціна товару {name} оновлена до {price} грн", ConsoleColor.Green);
                }
            }
            else
            {
                WriteLine_SetTextColor("Товар не знайдено.", ConsoleColor.Red);
            }
        }

        // Операція Delete (видалення запису) із CRUD
        public static void DeleteProducts(Context context)
        {
            Console.Write("Введіть назву товару: ");

            string name = Console.ReadLine();
            // Пошук товару
            var product = context.Products.FirstOrDefault(p => p.Name == name);

            if (product != null)
            {
                context.Products.Remove(product);       // Видалення товару
                context.SaveChanges();
                WriteLine_SetTextColor($"Товар {name} видалено.", ConsoleColor.Green);
            }
            else
            {
                WriteLine_SetTextColor("Товар не знайдено.", ConsoleColor.Red);
            }
        }

    }
}
