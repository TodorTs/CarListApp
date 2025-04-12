using FormValidation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormValidation
{
    public partial class MainForm : Form
    {
        internal DatabaseHelper dbHelper; // Обект за работа с базата данни

        public MainForm()
        {
            dbHelper = new DatabaseHelper(); // Инициализация на помощен обект за базата данни
            InitializeComponent(); // Инициализиране на компонентите на формата
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Обработка на събитие за добавяне на нов запис
            AddEditForm addEditForm = new AddEditForm(dbHelper); // Създаване на нова форма за добавяне/редактиране
            addEditForm.ShowDialog(); // Отваряне на формата като диалогов прозорец
            LoadData(); // Презареждане на данните след добавяне
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Обработка на събитие за изход от програмата
            string title = "Изход от програмата?"; // Заглавие на диалоговия прозорец
            string message = "Наистина ли искате да излезете от програмата?"; // Съобщение за потребителя
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; // Бутони Да и Не
            MessageBoxIcon icon = MessageBoxIcon.Question; // Икона въпрос

            if (MessageBox.Show(message, title, buttons, icon) == DialogResult.Yes) // Проверка за потвърждение
            {
                Application.Exit(); // Изход от програмата
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Събитие при зареждане на основната форма
            LoadData(); // Зареждане на данните от базата
        }

        private void LoadData()
        {
            // Зареждане на данни в DataGridView
            using (SQLiteConnection connection = dbHelper.GetConnection()) // Създаване на връзка към базата данни
            {
                try
                {
                    dbHelper.OpenConnection(connection); // Отваряне на връзката към базата

                    string query = "SELECT * FROM vehicles"; // SQL заявка за извличане на всички записи

                    using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection)) // Създаване на адаптер за данни
                    {
                        DataTable dataTable = new DataTable(); // Създаване на таблица за данните
                        dataAdapter.Fill(dataTable); // Попълване на таблицата с данни
                        dsEmployees.DataSource = dataTable; // Присвояване на таблицата като източник на данни за DataGridView
                    }
                }
                catch (Exception ex) // Улавяне на грешки
                {
                    MessageBox.Show($"Грешка: {ex.Message}"); // Показване на съобщение за грешка
                }
                finally
                {
                    dbHelper.CloseConnection(connection); // Затваряне на връзката към базата
                }
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            // Обработка на събитие за редактиране на избран запис
            DataGridViewRow row = dsEmployees.SelectedRows[0]; // Взема избрания ред от DataGridView
            int id = int.Parse(row.Cells[0].Value.ToString()); // Извличане на ID на избрания запис

            AddEditForm addEditForm = new AddEditForm(dbHelper, id); // Създаване на нова форма за редактиране с подадено ID
            addEditForm.ShowDialog(); // Отваряне на формата като диалогов прозорец
            LoadData(); // Презареждане на данните след редактиране
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Обработка на събитие за изтриване на избран запис
            DataGridViewRow row = dsEmployees.SelectedRows[0]; // Взема избрания ред от DataGridView
            int id = int.Parse(row.Cells[0].Value.ToString()); // Извличане на ID на избрания запис

            string title = "Изтриване на автомобил?"; // Заглавие на диалоговия прозорец
            string message = "Сигурни ли сте, че желаете да изтриете посоченият автомобил?"; // Съобщение за потребителя
            MessageBoxButtons buttons = MessageBoxButtons.YesNo; // Бутони Да и Не
            MessageBoxIcon icon = MessageBoxIcon.Warning; // Икона предупреждение

            if (DialogResult.Yes == MessageBox.Show(message, title, buttons, icon)) // Проверка за потвърждение
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbHelper.GetConnection())) // Създаване на връзка към базата
                {
                    try
                    {
                        dbHelper.OpenConnection(connection); // Отваряне на връзката към базата

                        string query = "DELETE FROM vehicles WHERE id=@Id LIMIT 1"; // SQL заявка за изтриване на запис

                        SQLiteCommand command = new SQLiteCommand(query, connection); // Създаване на SQL команда
                        command.Parameters.AddWithValue("@Id", id); // Добавяне на ID като параметър

                        command.ExecuteNonQuery(); // Изпълнение на командата за изтриване
                    }
                    catch (Exception ex) // Улавяне на грешки
                    {
                        MessageBox.Show($"Грешка: {ex.Message}"); // Показване на съобщение за грешка
                    }
                    finally
                    {
                        dbHelper.CloseConnection(connection); // Затваряне на връзката към базата
                        LoadData(); // Презареждане на данните след изтриване
                    }
                }
            }
        }
    }
}
