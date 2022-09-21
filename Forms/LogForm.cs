using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESprogram.Forms
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlString = " SELECT * FROM EAP_LOGS  WHERE EVT_NO = :id";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
            this.dataGridView1.DataSource = dt;

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
        }
    }
}
