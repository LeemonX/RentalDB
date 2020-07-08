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
    public partial class newRent : Form
    {
        public newRent()
        {
            InitializeComponent();
            String conString = "Server=localhost;port=5432;username='postgres';password='root';database=RentalDB";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(conString);
            npgsqlConnection.Open();
            NpgsqlCommand selectClients = new NpgsqlCommand("SELECT clientname FROM clients", npgsqlConnection);
            NpgsqlCommand selectSpaces = new NpgsqlCommand("SELECT spacename FROM spaces s, rentedspaces r WHERE s.spacecode!=r.spacecode", npgsqlConnection);

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            selectClients.ExecuteNonQuery();
            selectSpaces.ExecuteNonQuery();

            DataTable d1 = new DataTable();
            
            foreach (DataRow dr in d1.Rows)
            {
                comboBox1.Items.Add(dr["clientname"].ToString());
            }

            DataTable d2 = new DataTable();

            foreach (DataRow dr in d2.Rows)
            {
                comboBox2.Items.Add(dr["spacename"].ToString());
            }

            npgsqlConnection.Close();
        }

        private void addRent_Click(object sender, EventArgs e)
        {
            String conString = "Server=localhost;port=5432;username='postgres';password='root';database=RentalDB";
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(conString);
            npgsqlConnection.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand("INSERT INTO rentedSpaces (spacecode, clientcode, startdate, findate) VALUES (@sc, @cc, @sd, @fd)", npgsqlConnection);
            npgsqlCommand.Parameters.Add("sc", NpgsqlTypes.NpgsqlDbType.Integer).Value = comboBox1.SelectedItem;
        }
    }
}
