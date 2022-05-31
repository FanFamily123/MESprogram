using MESprogram.Pojo;
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
    public partial class TempMoveErrorForm : Form
    {
        private HttpHandler httpHandler = new HttpHandler();
        public TempMoveErrorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string getOpe=this.txtOpe.Text;
            string getTool=this.txtTool.Text;
            string getChannel=this.txtChannel.Text;
            if (string.IsNullOrEmpty(getChannel))
            {
                //查询temp的数量
                string sqlString1 = "select COUNT(*) from ret_prd_info where PRD_STAT='TEMP' and TOOL_ID_FK= :toolId and NX_OPE_ID_FK= :opeId  ORDER BY evt_timestamp ASC";



                // DataTable dt1 = OracleHelper.ExecuteDataTable(sqlString1, new OracleParameter(":id", this.txtLH.Text.Trim()));
                OracleParameter[] oracleParameters = new OracleParameter[2];
                oracleParameters[0] = new OracleParameter(":toolId", getTool);
                oracleParameters[1] = new OracleParameter(":opeId", getOpe);
              
                DataTable dt1 = OracleHelper.ExecuteDataTable(sqlString1, oracleParameters);

                var woId = dt1.Rows[0]["COUNT(*)"].ToString();
                MessageBox.Show(woId);



            }
            else
            {
                //查询temp的数量
                string sqlString1 = "select COUNT(*) from ret_prd_info where PRD_STAT='TEMP' and TOOL_ID_FK= :toolId and NX_OPE_ID_FK= :opeId and EXT_18= :channelId ORDER BY evt_timestamp ASC";



                // DataTable dt1 = OracleHelper.ExecuteDataTable(sqlString1, new OracleParameter(":id", this.txtLH.Text.Trim()));
                OracleParameter[] oracleParameters = new OracleParameter[3];
                oracleParameters[0] = new OracleParameter(":toolId", getTool);
                oracleParameters[1] = new OracleParameter(":opeId", getOpe);
                oracleParameters[2] = new OracleParameter(":channelId", getChannel);
                DataTable dt1 = OracleHelper.ExecuteDataTable(sqlString1, oracleParameters);

                var woId = dt1.Rows[0]["COUNT(*)"].ToString();
                MessageBox.Show(woId);
            }
           
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlString = "SELECT COUNT(*) from RET_PRD_INFO where BOX_ID_FK='BOXERROR'";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString);
            var Count = dt.Rows[0]["COUNT(*)"].ToString();
            MessageBox.Show(Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string getOpe = this.txtMoveOpe.Text;
            string getTool = this.txtMoveTool.Text;
            string getChannel = this.txtMoveChannel.Text;
            string getWaferCount=this.txtMoveWaferCount.Text;
            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = getOpe;
            mew03waferiobtI.toolId = getTool;
            mew03waferiobtI.actionFlg = "g";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";


            mew03waferiobtI.transactionId = GetTimeStamp();



            mew03waferiobtI.channelId = getChannel;

            mew03waferiobtI.waferCount = getWaferCount;



            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            MessageBox.Show(returnMsg);

        }


        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pojo.Ew03 m1 = new Pojo.Ew03();
            Pojo.Ew03 m2 = new Pojo.Ew03();
            MessageBox.Show("数据" + m1.GetHashCode() + "数据" + m2.GetHashCode());
        }
    }
}
