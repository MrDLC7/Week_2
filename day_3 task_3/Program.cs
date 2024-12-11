using static day_3_task_3.ConsoleUtilities;
using static day_3_task_3.ActionCRUD_Products;

namespace day_3_task_3
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
                        "1. Операція Create\n" +
                        "2. Операція Read\n" +
                        "3. Операція Update\n" +
                        "4. Операція Delete\n" +
                        "5. Вийти\n");
                    Console.Write("Ваш вибір: ");

                    string choice = Console.ReadLine();

                    switch(choice)
                    {
                        case "1":
                            WriteLine_SetTextColor("\nДодавання запису в базу даних (операція Create)", ConsoleColor.DarkBlue);
                            CreateProducts(context);        // Додати товар
                            break;
                        case "2":
                            WriteLine_SetTextColor("\nЧитання записів з бази даних (операція Read)", ConsoleColor.DarkBlue);
                            ReadProducts(context);          // Показати список товарів
                            break;
                        case "3":
                            WriteLine_SetTextColor("\nОновлення запису в базі даних (операція Update)", ConsoleColor.DarkBlue);
                            UpdateProducts(context);        // Оновити ціну товару
                            break;
                        case "4":
                            WriteLine_SetTextColor("\nВидалення запису із бази даних (операція Delete)", ConsoleColor.DarkBlue);
                            DeleteProducts(context);        // Видалити товар
                            break;
                        case "5":
                            return;                         // Вийти з програми
                        default:
                            WriteLine_SetTextColor("Неправильний вибір. Спробуйте знову.", ConsoleColor.Red);
                            break;
                    }
                }
            }
        }
    }
}