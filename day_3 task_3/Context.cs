using Microsoft.EntityFrameworkCore;

namespace day_3_task_3
{
    internal class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }            // Взаємодія з таблицею

        // Підключення до бази даних shopsdb
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Запитування назви бази даних, ім'я користувача та пароль  
            // Console.Write("Введіть назву бази даних: ");
            string databaseName = "shopsdb";

            // Console.Write("Введіть ім'я користувача: ");
            string username = "root";

            // Console.Write("Введіть пароль: ");
            string password = "va0wg5_S65m_s5L_f57_gK76";

            // Рядок підключення
            optionsBuilder.UseMySql(
                $"server = localhost; " +
                $"database = {databaseName};" +
                $"user = {username};" +
                $"password = {password};",
                new MySqlServerVersion(new Version(9, 1, 0)));
        }
    }
}
