using MESprogram.Pojo;
using Newtonsoft.Json;
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
    public partial class DeleteBoxLH : Form
    {
        public DeleteBoxLH()
        {
            InitializeComponent();
        }

        private HttpHandler httpHandler = new HttpHandler();
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_step1_Click(object sender, EventArgs e)
        {

            var txt = this.txtLH.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txt))
            {
                string sqlString = "UPDATE \"MES_PPT\".\"RET_BOX\" SET  \"BOX_STAT\" = 'EMPT', \"VALID_FLG\" = 'Y', \"PRD_QTY\" = '0', \"CHIP_QTY\" = NULL, \"MDL_ID_FK\" = NULL, \"MTRL_PROD_ID_FK\" = NULL, \"NX_PATH_ID_FK\" = NULL, \"NX_PATH_VER_FK\" = NULL, \"NX_OPE_NO_FK\" = NULL, \"NX_OPE_ID_FK\" = NULL, \"NX_OPE_VER_FK\" = NULL, \"NX_PROC_ID_FK\" = NULL, \"NX_TOOLG_ID_FK\" = NULL, \"NX_TOOL_RUN_MODE\" = NULL, \"NX_TOOL_ID_FK\" = NULL, \"TOOL_ID_FK\" = NULL, \"TOOL_PORT_ID_FK\" = NULL, \"ACT_CMP_TIMESTAMP\" = NULL, \"WH_IN_TIMESTAMP\" = NULL WHERE \"BOX_ID\" = :id";

                var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
                MessageBox.Show(a.ToString());
                this.label2.Text = "OK";

            }
            else {
                MessageBox.Show("必须输入");
            
            }

           

        }

        private void btn_step2_Click(object sender, EventArgs e)
        {
            var txt = this.txtLH.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txt))
            {
                string sqlString = @"DELETE FROM RET_PRD_INFO where BOX_ID_FK = :id";
                var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
                MessageBox.Show(a.ToString());
                this.label3.Text = "OK";
            }
            else
            {
                MessageBox.Show("必须输入");

            }


        }

        private void DeleteBoxLH_Load(object sender, EventArgs e)
        {
            this.label2.Text = "null";
            this.label3.Text = "null";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
            this.dataGridView1.DataSource = dt;

            string sqlString1 = " SELECT COUNT(*) FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id";



            DataTable dt1 = OracleHelper.ExecuteDataTable(sqlString1, new OracleParameter(":id", this.txtLH.Text.Trim()));
            var woId = dt1.Rows[0]["COUNT(*)"].ToString();
            this.txtNum.Text = woId;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlString = " SELECT * FROM RET_BOX  WHERE BOX_ID = :id";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
            this.dataGridView1.DataSource = dt;
            this.NowStatus.Text = dt.Rows[0].ItemArray[2].ToString();
            //  this.Netxt.Text=dt.Rows[0].ItemArray["NX_OPE_ID_FK"].ToString();
            this.Netxt.Text = dt.Rows[0]["NX_OPE_ID_FK"].ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = "";
            this.Netxt.Text = "";
            this.NowStatus.Text = "";
            this.txtNum.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var txt = this.txtNum.Text.Trim();
                var getStartIndex = txt.IndexOf("inTrx");
                var getEndIndex = txt.IndexOf("outTrx");
                var getNEWtxt = txt.Substring(getStartIndex + 6, getEndIndex - 10).Trim();
                //转换成对象
                Ew08 ew08 = JsonConvert.DeserializeObject<Ew08>(getNEWtxt);
                //获取到花篮和工序,然后删除;

                var updateFlag = updateBox(ew08.boxId);
                if (updateFlag > 0)
                {
                    Console.WriteLine("成功清空花篮" + ew08.boxId);
                    //清空硅片

                    var updateWaferFlag = updateWafer(ew08.boxId);
                    Console.WriteLine("成功清空硅片,其对应花篮为" + ew08.boxId);
                    //创建花篮
                    var flag = AddBoxByOpe(ew08.boxId, ew08.opeId);
                    if (flag)
                    {
                        Console.WriteLine("成功在创建花篮" + ew08.boxId + "工序为" + ew08.opeId);

                    }
                    else
                    {
                        Console.WriteLine("创建花篮失败");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("自动补账报错" + ex.ToString());
            }
           

           




        }


        //清除载具
        public int updateBox(string boxId) {

            if (!string.IsNullOrWhiteSpace(boxId))
            {
                string sqlString = "UPDATE \"MES_PPT\".\"RET_BOX\" SET  \"BOX_STAT\" = 'EMPT', \"VALID_FLG\" = 'Y', \"PRD_QTY\" = '0', \"CHIP_QTY\" = NULL, \"MDL_ID_FK\" = NULL, \"MTRL_PROD_ID_FK\" = NULL, \"NX_PATH_ID_FK\" = NULL, \"NX_PATH_VER_FK\" = NULL, \"NX_OPE_NO_FK\" = NULL, \"NX_OPE_ID_FK\" = NULL, \"NX_OPE_VER_FK\" = NULL, \"NX_PROC_ID_FK\" = NULL, \"NX_TOOLG_ID_FK\" = NULL, \"NX_TOOL_RUN_MODE\" = NULL, \"NX_TOOL_ID_FK\" = NULL, \"TOOL_ID_FK\" = NULL, \"TOOL_PORT_ID_FK\" = NULL, \"ACT_CMP_TIMESTAMP\" = NULL, \"WH_IN_TIMESTAMP\" = NULL WHERE \"BOX_ID\" = :id";

                var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", boxId));
               
                 return a;
              

            }
            else
            {
                Console.WriteLine("清空花篮发现boxId为空");
                return 0;
            }         
        }

        //清除硅片
        public int updateWafer(string boxId)
        {
           
            if (!string.IsNullOrWhiteSpace(boxId))
            {
                string sqlString = @"DELETE FROM RET_PRD_INFO where BOX_ID_FK = :id";
                var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", boxId));
                return a;
            }
            else
            {
                Console.WriteLine("清空单片,发现boxId为空");
                return 0;

            }
        }


        //在某个工序,通过A接口创建花篮
        public bool AddBoxByOpe(string boxId,string opeId) {
            //获取工单,来补账
            var woId = getLastWoid();
            //通过A接口来补账;
           
            var getMcounter = "100";
            var getwoId = woId;
            EWAdd ewAdd = new EWAdd();
            // ewAdd.toolId = getMtool;
            ewAdd.boxId = boxId;
            ewAdd.opeId = opeId;
            ewAdd.waferCount = getMcounter;
            ewAdd.actionFlg = "A";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "BCTOMES";
            ewAdd.transactionId = GetTimeStamp();
            ewAdd.woId = getwoId;

            var returnMsg = httpHandler.DoPostAdd(ewAdd);
            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }
            return false;
        }


        //查询最新的工单
        public string getLastWoid() {

            string sqlString = @"select * from RET_WO where PATH_DSC='一般工艺' and WO_STAT='RLSE' and ROWNUM<2 ORDER BY EVT_TIMESTAMP desc";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString);

            var woId= dt.Rows[0]["WO_ID"].ToString();

            return woId;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var getID = getLastWoid();
            MessageBox.Show(getID);
        }


        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sqlString = " SELECT COUNT(*) FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id";
         //   DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", boxId));

            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
            //this.dataGridView1.DataSource = dt;
            MessageBox.Show(dt.Rows[0]["COUNT(*)"].ToString());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var txt = this.txtLH.Text.Trim();
            if (!string.IsNullOrWhiteSpace(txt))
            {
               // string sqlString = @"DELETE FROM RET_PRD_INFO where BOX_ID_FK = :id";
                string sqlString = @"update RET_PRD_INFO set box_id_fk='BOXERROR',PRD_STAT='ERROR' where box_id_fk=:id";
                var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
                MessageBox.Show(a.ToString());
                this.label3.Text = "OK";
            }
            else
            {
                MessageBox.Show("必须输入");

            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
         
            EWAdd ewAdd = new EWAdd();
            // ewAdd.toolId = getMtool;
            ewAdd.boxId = this.txtLH.Text.Trim();
       
            ewAdd.actionFlg = "m";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "EAPSERVICE";
            ewAdd.transactionId = GetTimeStamp();
            //   ewAdd.woId = getwoId;

            var returnMsg = httpHandler.DoPostAddnew(ewAdd);

            MessageBox.Show(returnMsg);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var getTime= (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            MessageBox.Show(getTime + "");
        }
    }




}
