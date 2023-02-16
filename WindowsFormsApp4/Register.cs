using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Register : Form
    {
        Classcon1 connect = new Classcon1();  //объект класса (выделили под него память)

        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var name = nameBox.Text;
            var surname = surnameBox.Text;
            var group = groupBox.Text;
            var password = passBox.Text;

            string querystring = $"insert into Logins (nameST, surnameST, groupST, passST)  values ('{name}','{surname}','{group}','{password}')";

            SqlCommand command = new SqlCommand(querystring, connect.getConnection());

            connect.openConnection(); // тут мы уже открываем подключение

            if (command.ExecuteNonQuery() == 1) // метод ExecuteNonQuery() просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE
            {
                MessageBox.Show("Вы успешно зарегестрировались в системе!", "ИНФО", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {     
                MessageBox.Show("Аккаунт не создан!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connect.closeConnection();  // не забываем его закрыть
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            this.Hide();
            back.ShowDialog();
        }
    }
}
