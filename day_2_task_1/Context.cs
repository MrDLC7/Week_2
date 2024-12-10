using Microsoft.EntityFrameworkCore;

namespace day_2_task_1
{
    internal class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }            // Взаємодія з таблицею

        // Підключення до бази даних shopsdb
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server = localhost; " +
                "database = shopsdb; " +
                "user = root; " +
                "password = va0wg5_S65m_s5L_f57_gK76;",
                new MySqlServerVersion(new Version(9, 1, 0)));
        }
    }
}
