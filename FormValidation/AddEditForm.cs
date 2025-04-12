using FormValidation.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormValidation
{
    public partial class AddEditForm : Form
    {
        private DatabaseHelper dbHelper; // Обект за помощни операции с базата данни

        public AddEditForm(DatabaseHelper dbHelper, int id = 0)
        {
            this.dbHelper = dbHelper; // Инициализация на dbHelper

            InitializeComponent(); // Инициализиране на компонентите на формата
            buttonOK.Enabled = false; // Деактивиране на бутона OK, докато данните не са валидни

            textBoxBrand.Tag = false; // Задаване на начален статус за полето "Марка"
            textBoxModel.Tag = false; // Задаване на начален статус за полето "Модел"
            textBoxType.Tag = false; // Задаване на начален статус за полето "Категория"
            textBoxYear.Tag = false; // Задаване на начален статус за полето "Година"

            // Добавяне на валидиращи обработчици за събития
            textBoxBrand.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            textBoxModel.Validating += new CancelEventHandler(textBoxEmpty_Validating);
            textBoxType.Validating += new CancelEventHandler(textBoxType_Validating);
            textBoxYear.Validating += new CancelEventHandler(textBoxEmpty_Validating);

            if (id > 0) // Ако id е по-голямо от 0, зареди данни за редакция
            {
                LoadEmployee(id); // Зареждане на данни за конкретен запис
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connection = dbHelper.GetConnection()) // Създаване на връзка към базата данни
            {
                try
                {
                    dbHelper.OpenConnection(connection); // Отваряне на връзката към базата

                    string query = ""; // Декларация на SQL заявката

                    if (this.Tag != null) // Ако има зададен Tag, това е редакция
                    {
                        int id = int.Parse(this.Tag.ToString()); // Извличане на ID от Tag
                        query = $"UPDATE vehicles SET Brand=@brand, Model=@model, Type=@type, Year=@year WHERE id={id}"; // SQL заявка за актуализиране
                    }
                    else // Ако няма Tag, това е нов запис
                    {
                        query = "INSERT INTO vehicles (brand, model, type, year)"; // SQL заявка за добавяне
                        query += " VALUES (@brand, @model, @type, @year)";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(query, connection)) // Създаване на SQL команда
                    {
                        // Добавяне на параметри към командата
                        command.Parameters.AddWithValue("@brand", textBoxBrand.Text);
                        command.Parameters.AddWithValue("@model", textBoxModel.Text);
                        command.Parameters.AddWithValue("@type", textBoxType.Text);
                        command.Parameters.AddWithValue("@year", textBoxYear.Text);

                        command.ExecuteNonQuery(); // Изпълнение на командата
                    }

                    MessageBox.Show("Данните бяха записани успешно!"); // Съобщение за успех
                    this.Close(); // Затваряне на формата
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

        private void LoadEmployee(int id)
        {
            using (SQLiteConnection connection = dbHelper.GetConnection()) // Създаване на връзка към базата данни
            {
                dbHelper.OpenConnection(connection); // Отваряне на връзката

                string query = $"SELECT * FROM vehicles WHERE id=@Id LIMIT 1"; // SQL заявка за извличане на данни

                using (SQLiteCommand command = new SQLiteCommand(query, connection)) // Създаване на SQL команда
                {
                    command.Parameters.AddWithValue("@Id", id); // Задаване на ID като параметър

                    SQLiteDataReader reader = command.ExecuteReader(); // Изпълнение на командата и извличане на резултати

                    while (reader.Read()) // Преглед на редовете от резултата
                    {
                        this.Tag = reader.GetInt32(0); // Задаване на ID като Tag
                        textBoxBrand.Text = reader.GetString(1); // Зареждане на марка
                        textBoxBrand.Tag = true; // Полето "Марка" е валидно
                        textBoxModel.Text = reader.GetString(2); // Зареждане на модел
                        textBoxModel.Tag = true; // Полето "Модел" е валидно
                        textBoxType.Text = reader.GetString(3); // Зареждане на категория
                        textBoxType.Tag = true; // Полето "Категория" е валидно
                        textBoxYear.Text = reader.GetString(4); // Зареждане на година
                        textBoxYear.Tag = true; // Полето "Година" е валидно
                    }
                }

                dbHelper.CloseConnection(connection); // Затваряне на връзката
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            string output; // Стринг за помощния текст

            // Добавяне на помощен текст за полетата
            output = "Помощна информация:\r\n\r\n";
            output += "Марка = Марка на автомобила\r\n";
            output += "Модел = Модел  на автомобила\r\n";
            output += "Категория = Единствените допустими стойности са 'Седан' 'Джип' 'Купе' 'Комби'\r\n";
            output += "Година = Година на производвтво на модела";

            textBoxOutput.Text = output; // Задаване на текста в текстовото поле за изход
        }

        private void ValidateOK()
        {
            buttonOK.Enabled = ( // Активиране на бутона OK, ако всички полета са валидни
                    (bool)textBoxBrand.Tag &&
                    (bool)textBoxModel.Tag &&
                    (bool)textBoxType.Tag &&
                    (bool)textBoxYear.Tag
                );
        }

        private void textBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender; // Кастване на подателя като TextBox

            if (tb.Text.Length == 0) // Ако текстовото поле е празно
            {
                tb.BackColor = Color.Red; // Задаване на червен фон за невалидно поле
                tb.Tag = false; // Задаване на невалидност на полето
            }
            else // Ако текстовото поле не е празно
            {
                tb.BackColor = SystemColors.Window; // Възстановяване на нормалния фон
                tb.Tag = true; // Задаване на валидност на полето
            }
            ValidateOK(); // Проверка за валидност на всички полета
        }

        public void textBoxType_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender; // Кастване на подателя като TextBox

            if (tb.Text.CompareTo("Седан") == 0 || tb.Text.Length == 0) // Проверка за валидна категория или празно поле
            {
                tb.BackColor = SystemColors.Window; // Нормален фон за валидно поле
                tb.Tag = true; // Полето е валидно
            }
            else if (tb.Text.CompareTo("Джип") == 0 || tb.Text.Length == 0) // Проверка за валидна категория
            {
                tb.BackColor = SystemColors.Window; // Нормален фон
                tb.Tag = true; // Полето е валидно
            }
            else if (tb.Text.CompareTo("Купе") == 0 || tb.Text.Length == 0) // Проверка за валидна категория
            {
                tb.BackColor = SystemColors.Window; // Нормален фон
                tb.Tag = true; // Полето е валидно
            }
            else if (tb.Text.CompareTo("Комби") == 0 || tb.Text.Length == 0) // Проверка за валидна категория
            {
                tb.BackColor = SystemColors.Window; // Нормален фон
                tb.Tag = true; // Полето е валидно
            }
            else // Ако категорията не е валидна
            {
                tb.BackColor = Color.Red; // Червен фон за невалидно поле
                tb.Tag = false; // Полето е невалидно
            }
            ValidateOK(); // Проверка за валидност на всички полета
        }

        private void textBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender; // Кастване на подателя като TextBox

            if ((tb.Text.Length == 0 && e.KeyChar == 48) ||  // Проверка за 0 като първа цифра
                ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)) // Проверка за допустими символи
            {
                e.Handled = true; // Отказ на въвеждането на невалидни символи
            }
        }

        private void textBoxYear_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender; // Кастване на подателя като TextBox

            if (tb.Text.Length == 0) // Проверка дали текстовото поле е празно
            {
                tb.Tag = false; // Полето е невалидно
                tb.BackColor = Color.Red; // Задаване на червен фон за невалидно поле
            }

            ValidateOK(); // Проверка за валидност на всички полета
        }

        private void textBoxYear_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender; // Кастване на подателя като TextBox

            if (tb.Text.Length > 0) // Ако полето съдържа текст
            {
                if (Int16.Parse(tb.Text.ToString()) < 18) // Проверка дали стойността е по-малка от 18
                {
                    tb.Tag = false; // Полето е невалидно
                    tb.BackColor = Color.Red; // Задаване на червен фон
                }
                else // Ако стойността е валидна
                {
                    tb.Tag = true; // Полето е валидно
                    tb.BackColor = SystemColors.Window; // Възстановяване на нормалния фон
                }
                ValidateOK(); // Проверка за валидност на всички полета
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)   // Допустими стойности за категория (textBoxType)
        {
            TextBox tb = (TextBox)sender; // Кастване на подателя като TextBox

            if (tb.Text.Length == 0 && tb != textBoxType) // Ако текстовото поле е празно и не е категория
            {
                tb.Tag = false; // Полето е невалидно
                tb.BackColor = Color.Red; // Задаване на червен фон
            }
            else if (tb == textBoxType && // Ако полето е категория
                (tb.Text.Length != 0 && tb.Text.CompareTo("Седан") != 0))
            {
                tb.Tag = false; // Полето е невалидно
                tb.BackColor = Color.Red; // Червен фон
            }
            else if (tb == textBoxType && // Ако полето е категория и съдържа невалидна стойност
                (tb.Text.Length != 0 && tb.Text.CompareTo("Джип") != 0))
            {
                tb.Tag = false; // Полето е невалидно
                tb.BackColor = Color.Red; // Червен фон
            }
            else if (tb == textBoxType && // Проверка за стойност "Купе"
                (tb.Text.Length != 0 && tb.Text.CompareTo("Купе") != 0))
            {
                tb.Tag = false; // Полето е невалидно
                tb.BackColor = Color.Red; // Червен фон
            }
            else if (tb == textBoxType && // Проверка за стойност "Комби"
                (tb.Text.Length != 0 && tb.Text.CompareTo("Комби") != 0))
            {
                tb.Tag = false; // Полето е невалидно
                tb.BackColor = Color.Red; // Червен фон
            }
            else // Ако стойността е валидна
            {
                tb.Tag = true; // Полето е валидно
                tb.BackColor = SystemColors.Window; // Нормален фон
            }
            ValidateOK(); // Проверка за валидност на всички полета
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
        }

        private void labelName_Click(object sender, EventArgs e)
        {
        }

        private void labelAddress_Click(object sender, EventArgs e)
        {
        }
    }
}
