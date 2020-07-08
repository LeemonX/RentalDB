using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalDB
{
    
    public partial class LoginPanel : Form
    {
        
        public LoginPanel()
        {
            InitializeComponent();
            
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                
        }

        private void exit_label_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String login = loginField.Text;
            String pass = passwordField.Text;

            String conString = "Server=localhost;port=5432;username='" + login + "';password='" + pass + "';" + "database=RentalDB";
            NpgsqlConnection conDataBase = new NpgsqlConnection(conString);
            try

            {
                conDataBase.Open();
                this.Hide();
                mainMenu menu = new mainMenu();
                menu.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("В подключении отказано. Введите корректные данные.");
            }
        }
    }
}
