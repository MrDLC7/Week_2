﻿using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        // Рядок підключення до MySQL
        string connectionString =
            "Server = localhost; " +
            "Database = Shopdb; " +
            "UserId = root; " +
            "Password = va0wg5_S65m_s5L_f57_gK76;";

        // Створення підключення
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Успішне підключення до бази даних MySQL");

                // Запит SQL
                string query =
                    "SELECT * " +
                    "FROM clients " +
                    "WHERE FirstName = @Name";

                // Створення команди
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Додавання параметра
                    command.Parameters.AddWithValue("@Name", "Jane");

                    // Виконання запиту і отримання даних
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine
                                (
                                $"ID: {reader["Id"],-5}" +
                                $"FirstName: {reader["FirstName"], -15}" +
                                $"LastName: {reader["LastName"], -15}" +
                                $"Email: {reader["Email"], -40}"
                                );
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.ToString());
            }
        }
    }
}