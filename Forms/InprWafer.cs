using MESprogram.Pojo;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESprogram.Forms
{
    public partial class InprWafer : Form
    {
        public InprWafer()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();


        private void button1_Click(object sender, EventArgs e)
        {
            var getInprHL = this.txtInprHL.Text.Trim();
            var getOpe = this.txtOpe.Text.Trim();
            var getTool = this.txtTool.Text.Trim();


            //先通过花篮号查询硅片ID
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", getInprHL));
            //获取前100片硅片id,进花篮,入站出站
            if (dt.Rows.Count >= 100)
            {
                //获取硅片数组           
                //获取起始ID,开始出站
                Ew08 ew08 = new Ew08();
                ew08.iary = getwaferIdByDB(dt);
                ew08.lineId = "1";
                ew08.opeId = "BSG";
                ew08.toolId = "BSG01";
                ew08.actionFlg = "I";
                ew08.evtUsr = "EAP800";
                ew08.trxId = "BCTOMES";
                //    ew08.waferCount = "100";
                //     ew08.subToolId = "SP1B-4";

                ew08.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostPRT(ew08);
                MessageBox.Show(returnMsg);
            }



        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }



        public List<WaferInfo> getwaferIdByDB(DataTable dt)
        {

            List<WaferInfo> list = new List<WaferInfo>();
            for (int i = 0; i < 100; i++)
            {
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = dt.Rows[i]["PRD_SEQ_ID"].ToString();
                wafer.slotNo = i;
                list.Add(wafer);

            }
            return list;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var getHLR = this.txtStartBox.Text.Trim();
            string x = getHLR.Substring(3);
            var getStartNum = x.TrimStart('0');

            for (int i = 0; i < 100; i++)
            {
                var newIndex = int.Parse(getStartNum) + i;
                String newIndex1 = newIndex.ToString().PadLeft(3, '0');
                var NEWHL = "XHL" + newIndex1;
                var flag = ToRelease(NEWHL);
              
            }
        }


        public bool ToRelease(String getHLR)
        {


            if (!string.IsNullOrWhiteSpace(getHLR))
            {
                EH02 eH02 = new EH02();
                eH02.boxId = getHLR;

                eH02.lineId = "1";
                eH02.opeId = "TEX";
                eH02.toolId = "TE001";
                eH02.actionFlg = "R";
                eH02.evtUsr = "EAP800";
                eH02.trxId = "BCTOMES";


                eH02.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostDIF(eH02);

                if (returnMsg.Contains("SUCCESS"))
                {
                    return true;
                }


            }
            return false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var getHLR = this.txtStartBox.Text.Trim();
            string x = getHLR.Substring(3);
            var getStartNum = x.TrimStart('0');


            MessageBox.Show(x);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var getHLR = this.txtStartBox.Text.Trim();
            string x = getHLR.Substring(3);
            var getStartNum = x.TrimStart('0');

            for (int i = 0; i < 100; i++)
            {
                var newIndex = int.Parse(getStartNum) + i;
                String newIndex1 = newIndex.ToString().PadLeft(3, '0');
                var NEWHL = "XHL" + newIndex1;
                //先通过花篮号查询硅片ID
                string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";
                DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", NEWHL));
                //获取前100片硅片id,进花篮,入站出站
                if (dt.Rows.Count >= 100)
                {
                    //获取硅片数组           
                    //获取起始ID,开始出站
                    Ew08 ew08 = new Ew08();
                    ew08.iary = getwaferIdByDB(dt);
                    ew08.lineId = "1";
                    ew08.opeId = "BSG";
                    ew08.toolId = "BSG01";
                    ew08.actionFlg = "I";
                    ew08.evtUsr = "EAP800";
                    ew08.trxId = "BCTOMES";
                    //    ew08.waferCount = "100";
                    //     ew08.subToolId = "SP1B-4";

                    ew08.transactionId = GetTimeStamp();


                    var returnMsg = httpHandler.DoPostPRT(ew08);
                    if (!returnMsg.Contains("SUCCESS"))
                    {
                        MessageBox.Show("花篮入站失败" + getHLR);
                    }
                    
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var getHLR = this.txtStartBox.Text.Trim();
            string x = getHLR.Substring(2);
            var getStartNum = x.Trim();

            for (int i = 0; i < 100; i++)
            {
                var newIndex = int.Parse(getStartNum) + i;
                String newIndex1 = newIndex.ToString();
                var NEWHL = "LH" + newIndex1;
                var flag = ToRelease(NEWHL);

            }
        }
    }

}
