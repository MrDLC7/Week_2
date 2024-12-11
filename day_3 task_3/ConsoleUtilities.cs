using System.Text;

namespace day_3_task_3
{
    internal class ConsoleUtilities
    {
        //  Відображення  помилок червоним кольором
        public static void WriteLine_SetTextColor(string input, ConsoleColor color)
        {
            // Встановлюємо червоний колір тексту  
            Console.ForegroundColor = color;

            // Виводимо текст у червоному кольорі  
            Console.WriteLine(input);

            // Повертаємо початковий колір  
            Console.ResetColor();
        }

        // Налаштування кодування для вводу та виводу
        public static void SetEncoding()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
        }
    }
}
