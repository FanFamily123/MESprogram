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
    public partial class EMPTBOX : Form
    {
        public EMPTBOX()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id";

           

            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtHL.Text.Trim()));
            this.dataGridView1.DataSource = dt;

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlString = "UPDATE \"MES_PPT\".\"RET_BOX\" SET  \"BOX_STAT\" = 'EMPT', \"VALID_FLG\" = 'Y', \"PRD_QTY\" = '0', \"CHIP_QTY\" = NULL, \"MDL_ID_FK\" = NULL, \"MTRL_PROD_ID_FK\" = NULL, \"NX_PATH_ID_FK\" = NULL, \"NX_PATH_VER_FK\" = NULL, \"NX_OPE_NO_FK\" = NULL, \"NX_OPE_ID_FK\" = NULL, \"NX_OPE_VER_FK\" = NULL, \"NX_PROC_ID_FK\" = NULL, \"NX_TOOLG_ID_FK\" = NULL, \"NX_TOOL_RUN_MODE\" = NULL, \"NX_TOOL_ID_FK\" = NULL, \"TOOL_ID_FK\" = NULL, \"TOOL_PORT_ID_FK\" = NULL, \"ACT_CMP_TIMESTAMP\" = NULL, \"WH_IN_TIMESTAMP\" = NULL WHERE \"BOX_ID\" = :id";

            var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", this.txtHL.Text.Trim()));
            MessageBox.Show("清空成功,影响行数"+a.ToString());
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlString = " SELECT * FROM RET_BOX  WHERE BOX_ID = :id";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtHL.Text.Trim()));
            this.dataGridView1.DataSource = dt;

        }
    }
}
