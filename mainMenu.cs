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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
            String conString = "Server=localhost;port=5432;username='postgres';password='root';database=RentalDB";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(conString);
            npgsqlConnection.Open();
            NpgsqlCommand rentedSelect = new NpgsqlCommand("SELECT s.spacename, s.spacelvl, s.spacearea, s.rentprice, case when s.ac=true then 'Есть' when s.ac=false then 'Нет' else 'Нет информации' end, c.clientname, r.startdate::date, r.findate::date FROM rentedSpaces r, spaces s, clients c WHERE s.spacecode=r.spacecode and c.clientcode=r.clientcode", npgsqlConnection);
            NpgsqlDataReader reader = rentedSelect.ExecuteReader();

            DataTable rentedTable = new DataTable();
            rentedTable.Columns.Add("Название площади");
            rentedTable.Columns.Add("Этаж");
            rentedTable.Columns.Add("Площадь м²");
            rentedTable.Columns.Add("Стоимость");
            rentedTable.Columns.Add("Кондиционер");
            rentedTable.Columns.Add("Компания");
            rentedTable.Columns.Add("Начало аренды");
            rentedTable.Columns.Add("Конец аренды");


            while (reader.Read())
            {
                rentedTable.Rows.Add(new object[] { reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7) });
            }

            dataGridView1.DataSource = rentedTable;

            npgsqlConnection.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newRentMenu_Click(object sender, EventArgs e)
        {
            newRent rent = new newRent();
            rent.ShowDialog();
        }
    }
}
