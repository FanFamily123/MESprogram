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
    public partial class DeleteThird : Form
    {
        public DeleteThird()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            string sqlString1 = "DELETE from RET_PRD_INFO where CR_OPE_ID_FK in ('TEX','DIF','BSG') AND PRD_STAT in ('WAIT','RELS','INPR')";
            string sqlString2 = "UPDATE \"MES_PPT\".\"RET_BOX\" SET  \"BOX_STAT\" = 'EMPT', \"VALID_FLG\" = 'Y', \"PRD_QTY\" = '0', \"CHIP_QTY\" = NULL, \"MDL_ID_FK\" = NULL, \"MTRL_PROD_ID_FK\" = NULL, \"NX_PATH_ID_FK\" = NULL, \"NX_PATH_VER_FK\" = NULL, \"NX_OPE_NO_FK\" = NULL, \"NX_OPE_ID_FK\" = NULL, \"NX_OPE_VER_FK\" = NULL, \"NX_PROC_ID_FK\" = NULL, \"NX_TOOLG_ID_FK\" = NULL, \"NX_TOOL_RUN_MODE\" = NULL, \"NX_TOOL_ID_FK\" = NULL, \"TOOL_ID_FK\" = NULL, \"TOOL_PORT_ID_FK\" = NULL, \"ACT_CMP_TIMESTAMP\" = NULL, \"WH_IN_TIMESTAMP\" = NULL WHERE \"BOX_ID\" in (SELECT BOX_ID_FK from RET_PRD_INFO where CR_OPE_ID_FK in ('TEX','DIF','BSG') AND PRD_STAT in ('WAIT','RELS','INPR') GROUP BY BOX_ID_FK)";
            string sqlString3 = "UPDATE \"MES_PPT\".\"RET_BOX\" SET  \"BOX_STAT\" = 'EMPT', \"VALID_FLG\" = 'Y', \"PRD_QTY\" = '0', \"CHIP_QTY\" = NULL, \"MDL_ID_FK\" = NULL, \"MTRL_PROD_ID_FK\" = NULL, \"NX_PATH_ID_FK\" = NULL, \"NX_PATH_VER_FK\" = NULL, \"NX_OPE_NO_FK\" = NULL, \"NX_OPE_ID_FK\" = NULL, \"NX_OPE_VER_FK\" = NULL, \"NX_PROC_ID_FK\" = NULL, \"NX_TOOLG_ID_FK\" = NULL, \"NX_TOOL_RUN_MODE\" = NULL, \"NX_TOOL_ID_FK\" = NULL, \"TOOL_ID_FK\" = NULL, \"TOOL_PORT_ID_FK\" = NULL, \"ACT_CMP_TIMESTAMP\" = NULL, \"WH_IN_TIMESTAMP\" = NULL WHERE \"BOX_ID\" like '%FPLH%'";
            string sqlString4 = "DELETE from RET_PRD_INFO where BOX_ID_FK like '%FPLH%'";
            try
            {
                var a = OracleHelper.ExecuteNonQuery(sqlString1);
                var b = OracleHelper.ExecuteNonQuery(sqlString2);
                var c = OracleHelper.ExecuteNonQuery(sqlString3);
                var d = OracleHelper.ExecuteNonQuery(sqlString4);
                this.label1.Text = "OK";
                this.label2.Text = "OK";
                this.label3.Text = "OK";
                this.label4.Text = "OK";
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
