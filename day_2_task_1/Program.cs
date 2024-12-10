using static day_2_task_1.ConsoleUtilities; 

namespace day_2_task_1
{
    class Program
    {
        static void Main()
        {
            SetEncoding();      // Налаштування кодування

            using (var context = new Context())
            {
                while (true)
                {
                    Console.WriteLine(
                        "\nОберіть дію:\n" +
                        "1. Показати список товарів\n" +
                        "2. Додати товар\n" +
                        "3. Вийти\n");
                    Console.Write("Ваш вибір: ");

                    string choice = Console.ReadLine();

                    switch(choice)
                    {
                        case "1":
                            ShowProducts(context);
                            break;
                        case "2":
                            AddProduct(context);
                            break;
                        case "3":
                            return;
                        default:
                            WriteLine_SetTextColor("Неправильний вибір. Спробуйте знову.", ConsoleColor.Red);
                            break;
                    }
                }
            }
        }

        // Показати список товарів
        static void ShowProducts(Context context)
        {
            var products = context.Products.ToList();

            if (products.Any())
            {
                Console.WriteLine("\nСписок товарів:");

                foreach (var product in products)
                {
                    Console.WriteLine(
                        $"ID: {product.Id, -5} " +
                        $"Назва: {product.Name, -15} " +
                        $"Ціна: {product.Price, -15} грн");
                }
            }
            else
            {
                WriteLine_SetTextColor("\nТовари відсутні.", ConsoleColor.Red);
            }
        }

        static void AddProduct(Context context)
        {
            Console.WriteLine("\nВведіть назву товару");
            string name = Console.ReadLine();

            Console.Write("Введіть ціну товару: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                var product = new Product { Name = name, Price = price };

                context.Products.Add(product);
                context.SaveChanges();

                WriteLine_SetTextColor("Товар успішно додано!", ConsoleColor.Green);
            }
            else
            {
                WriteLine_SetTextColor("Невірний формат ціни. Спробуйте ще раз.", ConsoleColor.Red);
            }
        }
    }
}