using System.ComponentModel.DataAnnotations;

namespace day_3_task_3
{
    internal class Product
    {
        [Key]                                   // Анотація вказує, що
        public int Id { get; set; }             // - Первинний ключ
        public string Name { get; set; }        // Назва
        public decimal Price { get; set; }      // Ціна
    }
}
