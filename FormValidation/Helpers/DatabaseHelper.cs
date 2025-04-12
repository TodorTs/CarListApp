using System.Data.SQLite;

namespace FormValidation.Helpers
{
    public class DatabaseHelper
    {
        private string connectionString = @"Data Source=DB\database.db;Version=3;"; // Път до базата данни и нейната версия

        public SQLiteConnection GetConnection()
        {
            // Метод за създаване на нова SQLite връзка с използване на connectionString
            return new SQLiteConnection(connectionString);
        }

        public void OpenConnection(SQLiteConnection connection)
        {
            // Метод за отваряне на връзка към базата данни
            if (connection.State != System.Data.ConnectionState.Open) // Проверка дали връзката не е вече отворена
            {
                connection.Open(); // Отваряне на връзката
            }
        }

        public void CloseConnection(SQLiteConnection connection)
        {
            // Метод за затваряне на връзката към базата данни
            if (connection.State != System.Data.ConnectionState.Closed) // Проверка дали връзката не е вече затворена
            {
                connection.Close(); // Затваряне на връзката
            }
        }
    }
}
