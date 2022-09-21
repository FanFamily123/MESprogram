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
    public partial class AutoMes : Form
    {
        public AutoMes()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();

        private void AutoMes_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //将Wait状态的花里料盒全部上料

            string sqlString = " SELECT * FROM RET_BOX  WHERE BOX_SET_CODE = 'UNLC' AND BOX_STAT='WAIT'";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取所有的料盒ID
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var boxId = dt.Rows[i]["BOX_ID"].ToString();
                //执行拆包操作
                var getReturnMsg = ToRelease(boxId,"TEX","TE001");
                if (!getReturnMsg.Contains("SUCCESS"))
                {
                    MessageBox.Show(getReturnMsg);
                    break;
                }

            }
            MessageBox.Show("上料结束"+dt.Rows.Count + "个料盒");



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //自动查询空的料盒来分片拆包
            //先查询空的料盒,再进行分片拆包
            string sqlString = " SELECT * FROM RET_BOX  WHERE BOX_SET_CODE = 'UNLC' AND BOX_STAT='EMPT'";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取所有的料盒ID
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var boxId = dt.Rows[i]["BOX_ID"].ToString();
                //执行拆包操作
                var getReturnMsg=ToFp(boxId);
                if (!getReturnMsg.Contains("SUCCESS"))
                {
                    MessageBox.Show(getReturnMsg);
                    break;
                }
                
            }
            MessageBox.Show("拆包完成" + dt.Rows.Count + "个料盒");



        }



        public String ToFp(String boxId) {
            Ew03New eH02 = new Ew03New();
            eH02.boxId = boxId;
            eH02.lineId = "1";
            eH02.opeId = "FPCB";
            eH02.toolId = "UP001";
            eH02.actionFlg = "H";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "BCTOMES";
            eH02.channelId = "1";
            eH02.transactionId = GetTimeStamp();
            var returnMsg = httpHandler.DoPostDIF1(eH02);
            return returnMsg;          
        }

       public String ToRelease(String boxId,String opeId,String toolId) {
            EH02 eH02 = new EH02();
            eH02.boxId = boxId;
            eH02.lineId = "1";
            eH02.opeId = opeId;
            eH02.toolId = toolId;
            eH02.actionFlg = "R";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "EAPSERVICE";
            eH02.channelId = "1";
            eH02.transactionId = GetTimeStamp();
            var returnMsg = httpHandler.DoPostDIF(eH02);
            return returnMsg;


        }


        public String ToInprTex(String boxId, String opeId, String toolId)
        {
            Ew03New eH02 = new Ew03New();
            eH02.boxId = boxId;
            eH02.lineId = "1";
            eH02.opeId = opeId;
            eH02.toolId = toolId;
            eH02.actionFlg = "I";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "EAPSERVICE";
            eH02.channelId = "1";
            eH02.transactionId = GetTimeStamp();
            eH02.waferCount = "100";

            var returnMsg = httpHandler.DoPostDIF2(eH02);
            return returnMsg;


        }

        public String ToInprTexO(String boxId, String opeId, String toolId)
        {
            Ew03New eH02 = new Ew03New();
            eH02.boxId = boxId;
            eH02.lineId = "1";
            eH02.opeId = opeId;
            eH02.toolId = toolId;
            eH02.actionFlg = "O";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "EAPSERVICE";
            eH02.channelId = "1";
            eH02.transactionId = GetTimeStamp();
           // eH02.waferCount = "100";

            var returnMsg = httpHandler.DoPostDIF2(eH02);
            return returnMsg;


        }







        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //查询空的制绒湿花篮来入站
            //先查询空的制绒湿花篮,再进行入站
            string sqlString = " SELECT * FROM RET_BOX  WHERE BOX_SET_CODE = 'ZRSH' AND BOX_STAT='EMPT'";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取所有的料盒ID
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var boxId = dt.Rows[i]["BOX_ID"].ToString();
                //执行拆包操作
                var getReturnMsg = ToInprTex(boxId, "TEX", "TE001");
                if (!getReturnMsg.Contains("SUCCESS"))
                {
                    MessageBox.Show(getReturnMsg);
                    break;
                }

            }
            MessageBox.Show("入站完成"+dt.Rows.Count+"个花篮");




        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlString1 = " SELECT * FROM RET_BOX  WHERE BOX_SET_CODE = 'ZRSH' AND BOX_STAT='INPR'";

            string sqlString = " select DISTINCT(BOX_ID_FK) from RET_PRD_INFO where CR_OPE_ID_FK='TEX' AND PRD_STAT='INPR'";


            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取所有inpr的花篮
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var boxId = dt.Rows[i]["BOX_ID_FK"].ToString();
                //执行拆包操作
                var getReturnMsg = ToInprTexO(boxId, "TEX", "TE001");
                if (!getReturnMsg.Contains("SUCCESS"))
                {
                    MessageBox.Show(getReturnMsg);
                    break;
                }

            }
            MessageBox.Show("出站站完成" + dt.Rows.Count + "个花篮");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //将Wait状态的花里料盒全部上料

            string sqlString = " select * from RET_BOX where BOX_SET_CODE = 'ZRSH' and NX_OPE_ID_FK='DIF' AND BOX_STAT='WAIT'";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取所有的料盒ID
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var boxId = dt.Rows[i]["BOX_ID"].ToString();
                //执行拆包操作
                var getReturnMsg = ToRelease(boxId, "DIF", "DL001");
                if (!getReturnMsg.Contains("SUCCESS"))
                {
                    MessageBox.Show(getReturnMsg);
                    break;
                }

            }
            MessageBox.Show("上料结束" + dt.Rows.Count + "个花篮");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //扩散入站
            //先查询扩散空的石英舟,for循环插入14次
            string sqlString = " SELECT * FROM RET_BOX  WHERE BOX_SET_CODE = 'SHYZ' AND BOX_STAT='EMPT'";

            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取10个石英舟
            for (int i = 0; i < 10; i++)
            {

                 var boxId = dt.Rows[i]["BOX_ID"].ToString();
               // var boxId = "KT029";
                String boxA = null;
                String boxB = null;
                //执行入站操作
                //查询temp的花篮
                for (int j = 1; j < 15; j++)
                {
                    //往里面插入14次,
                    
                    if (j%2 == 1) //插入奇数区域
                    {             
                            //获取2个花篮
                            string sqlString1 = "select  * from  (select DISTINCT(PV_BOX_ID_FK) from RET_PRD_INFO where TOOL_ID_FK='DL001' AND PRD_STAT='TEMP' ) where ROWNUM < 3";

                            DataTable dt1 = OracleHelper.ExecuteDataTable(sqlString1, new OracleParameter());

                             boxA = dt1.Rows[0]["PV_BOX_ID_FK"].ToString();
                             boxB = dt1.Rows[1]["PV_BOX_ID_FK"].ToString();
                            //执行入站操作
                            var getReturnMsg = ToInprDIF(boxId, "DIF",boxA,boxB,j+"");
                            if (!getReturnMsg.Contains("SUCCESS"))
                            {
                                MessageBox.Show(getReturnMsg);
                                break;
                            }

                        

                    }
                    else {
                        //偶数区域 直接入站
                        //执行入站操作
                        var getReturnMsg = ToInprDIF(boxId, "DIF", boxA, boxB, j + "");
                        if (!getReturnMsg.Contains("SUCCESS"))
                        {
                            MessageBox.Show(getReturnMsg);
                            break;

                        }
                        boxA= null;
                        boxB= null;
                    }
                }
            }
            MessageBox.Show("入站完成" + dt.Rows.Count + "个花篮");
        }

        private String ToInprDIF(String boatId,String opeId,string boxA,string boxB,string blockNo) {
            Ew03New eH02 = new Ew03New();
            eH02.boxId = boatId;
            eH02.lineId = "1";
            eH02.opeId = opeId;
            eH02.boxIdA = boxA;
            eH02.boxIdB = boxB;
            eH02.toolId = "BD001";
            eH02.actionFlg = "I";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "EAPSERVICE";
            eH02.channelId = "1";
            eH02.transactionId = GetTimeStamp();
            eH02.waferCountA = "50";
            eH02.waferCountB = "50";
            eH02.boatblockNo = blockNo;

            var returnMsg = httpHandler.DoPostDIF2(eH02);
            return returnMsg;


        }


        private void button8_Click(object sender, EventArgs e)
        {
            String j=txt.Text.Trim();
            var n=Convert.ToInt32(j);
            var x= (n % 2 == 1) ? true : false;
            MessageBox.Show(x + "");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sqlString = " select * from RET_BOX where BOX_SET_CODE = 'SHYZ' and NX_OPE_ID_FK='BSG' AND BOX_STAT='INPR' ";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter());
            //获取进行状态的舟
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                var boxId = dt.Rows[i]["BOX_ID"].ToString();
                //执行拆包操作
                var getReturnMsg = ToZetmpG(boxId, "DIF");
                if (!getReturnMsg.Contains("SUCCESS"))
                {
                    MessageBox.Show(getReturnMsg);
                    break;
                }

            }
            MessageBox.Show("G结束" + dt.Rows.Count + "个舟");
        }


        private String ToZetmpG(String boatId, String opeId)
        {
            Ew03New eH02 = new Ew03New();
            eH02.boxId = boatId;
            eH02.lineId = "1";
            eH02.opeId = opeId;
            eH02.toolId = "BD001";
            eH02.actionFlg = "G";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "EAPSERVICE";
            eH02.channelId = "1";
            eH02.transactionId = GetTimeStamp();
           
         

            var returnMsg = httpHandler.DoPostDIF2(eH02);
            return returnMsg;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //查询ZTEMP的数据




        }
    }
}
