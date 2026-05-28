using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace ExamContorol4_New
{
    public partial class LoginForm : Form
    {
        
        string connectionString = "Host = localhost; Port = 5432; Username = postgres; Password = root; Database = control4";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT role_id, fio FROM users WHERE login='{txtLogin.Text}' AND password='{txtPassword.Text}'";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                conn.Open();

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int roleId = Convert.ToInt32(reader["role_id"]);
                        string fio = reader["fio"].ToString();

                        MainForm mainForm = new MainForm(roleId, fio);
                        mainForm.Show();
                        this.Hide();
                    }

                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль", "Ошибка авторизации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(0, "Гость");
            mainForm.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            pictureBoxAuth.Image = Properties.Resources.logo;
        }

    }
}
