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

namespace CRUDw12
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;


        public Form1()
        {
            InitializeComponent();
        }

        private string getConnection()
        {
            return Properties.Settings.Default.Database1ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.vehicles' table. You can move, or remove it, as needed.
            this.vehiclesTableAdapter.Fill(this.database1DataSet.vehicles);
            
    }

        private void button1_Click(object sender, EventArgs e)
        {
            vehiclesTableAdapter.Update(database1DataSet.vehicles);
            dataGridView1.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int vehicleId = (int) dataGridView1.CurrentRow.Cells["idDataGridViewTextBoxColumn"].Value;
            vehiclesTableAdapter.DeleteQuery(vehicleId);
            vehiclesTableAdapter.Update(database1DataSet.vehicles);
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vname = dataGridView1.CurrentRow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
            int vwheels = (int)dataGridView1.CurrentRow.Cells["wheelsDataGridViewTextBoxColumn"].Value;
            vehiclesTableAdapter.InsertQuery(vname, vwheels);
            
            vehiclesTableAdapter.Update(database1DataSet.vehicles);
            dataGridView1.Refresh();
        }
    }
}
