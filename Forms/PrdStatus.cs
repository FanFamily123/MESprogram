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
    public partial class PrdStatus : Form
    {
        public PrdStatus()
        {
            InitializeComponent();
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            var txtPrdInfo=this.txtPrd.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txtPrdInfo))
            {
                string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE PRD_SEQ_ID = :id";
                DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", txtPrdInfo));
                if (dt!=null)
                {
                    this.dataGridView1.DataSource = dt;
                    this.txtStatus.Text = dt.Rows[0]["PRD_STAT"].ToString();
                    this.txtNow.Text = dt.Rows[0]["CR_OPE_ID_FK"].ToString();
                    this.txtNext.Text = dt.Rows[0]["NX_OPE_ID_FK"].ToString();
                }
                else
                {
                    MessageBox.Show("查询数据为空");
                }

            }
            else
            {
                MessageBox.Show("不可为空");
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = "";
            this.txtStatus.Text = "";
            this.txtNow.Text ="";
            this.txtNext.Text ="";
        }
    }
}
