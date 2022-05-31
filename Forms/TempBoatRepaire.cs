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
    public partial class TempBoatRepaire : Form
    {
        public TempBoatRepaire()
        {
            InitializeComponent();
        }

        private HttpHandler httpHandler = new HttpHandler();

        private void button1_Click(object sender, EventArgs e)
        {
            //先创建根据输入框创建花篮
            //花篮上料
            //再根据花篮号取单片入站
            var getBsgBox=this.txtBsgBox.Text.Trim();
            var getBsgOpeId=this.txtBSGOpeId.Text.Trim();
            var getBsgTool=this.txtBSGTool.Text.Trim();
            var getWoId=this.txtBsgWoId.Text.Trim();
            var getNum=this.txtBsgRepaireCount.Text.Trim();

            for (int i = 0; i < int.Parse(getNum); i++)
            {
                //创建花篮
                var createFlag = CreateBox(getBsgBox, getBsgOpeId, getWoId);
                Thread.Sleep(2000);
                if (createFlag)
                {
                    this.lableCreate.Text = "当前成功创建第" + i + "次";
                    //花篮上料
                    var releaseFlag = ReleaseBox(getBsgBox, getBsgOpeId, getBsgTool);
                    Thread.Sleep(2000);
                    if (releaseFlag)
                    {
                        this.lableRelease.Text = "当前成功上料第" + i + "次";

                        //花篮入站
                        var moveFlag = NewMoveBsgWafer(getBsgBox, getBsgOpeId, getBsgTool);
                        if (moveFlag)
                        {
                            this.lableMoveIn.Text = "当前成功入站第" + i + "次";

                        }
                        else
                        {
                            MessageBox.Show("第" + i +"次入站失败");

                        }
                    }
                    else
                    {
                        MessageBox.Show("花篮上料失败,第" + i + "次");
                        break;
                    }
                }
                else {

                    MessageBox.Show("创建花篮失败,第" + i + "次");
                    break;
                }
            }

            MessageBox.Show("入站成功");


        }

        //根据花篮号.工序,订单号创建花篮
        public bool CreateBox(string boxId,string opeId,string woId) {
            EWAdd ewAdd = new EWAdd();
            // ewAdd.toolId = getMtool;
            ewAdd.boxId = boxId;
            ewAdd.opeId = opeId;
            ewAdd.waferCount = "100";
            ewAdd.actionFlg = "A";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "BCTOMES";
            ewAdd.transactionId = GetTimeStamp();
            ewAdd.woId = woId;

            var returnMsg = httpHandler.DoPostAdd(ewAdd);
            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }

            return false;
        }
        //花篮上料

        public bool ReleaseBox(string boxId, string opeId, string toolId)
        {

            EH02 eH02 = new EH02();
            eH02.boxId = boxId;

            eH02.lineId = "1";
            eH02.opeId = opeId;
            eH02.toolId = toolId;
            eH02.actionFlg = "R";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "BCTOMES";
            eH02.channelId = "1";

            eH02.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostDIF(eH02);
            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }

            return false;

        }

        //BSG硅片入站

        public bool NewMoveBsgWafer(string boxId, string opeId, string toolId)
        {
          
                //获取硅片数组           
                //获取起始ID,开始出站
                Ew08 ew08 = new Ew08();
            //List<WaferInfo> list = new List<WaferInfo>();
          
            //    WaferInfo wafer = new WaferInfo();
            //    wafer.prdSeqId = "T2021";
         //       wafer.slotNo = 1;
            //    list.Add(wafer);


                 //   ew08.iary = list;
                ew08.lineId = "1";
                ew08.opeId = opeId;
                ew08.toolId = toolId;
                ew08.actionFlg = "I";
                ew08.evtUsr = "EAP800";
                ew08.trxId = "BCTOMES";
                ew08.channelId = "1";
                ew08.waferCount = "100";
         //       ew08.subToolId = "SP1A-1";

                ew08.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostPRT(ew08);
                if (returnMsg.Contains("SUCCESS"))
                {
                    return true;
                }


           
            return false;


        }

            public bool MoveBsgWafer(string boxId,string opeId,string toolId) {

            //先通过花篮号查询硅片ID
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", boxId));
            //获取前100片硅片id,进花篮,入站出站
            if (dt.Rows.Count >= 100)
            {
                //获取硅片数组           
                //获取起始ID,开始出站
                Ew08 ew08 = new Ew08();
                ew08.iary = getwaferIdByDB(dt);
                ew08.lineId = "1";
                ew08.opeId = opeId;
                ew08.toolId = toolId;
                ew08.actionFlg = "I";
                ew08.evtUsr = "EAP800";
                ew08.trxId = "BCTOMES";
                ew08.channelId = "1";
                //    ew08.waferCount = "100";
                //     ew08.subToolId = "SP1B-4";

                ew08.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostPRT(ew08);
                if (returnMsg.Contains("SUCCESS"))
                {
                    return true;
                }

           
            }
            return false;


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

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //先创建根据输入框创建花篮
            //花篮上料
            //再根据花篮号取单片入站
            var getBsgBox = this.txtGBox.Text.Trim();
            var getBsgOpeId = this.txtGOpe.Text.Trim();
            var getBsgTool = this.txGTool.Text.Trim();
            var getWoId = this.txtGWoId.Text.Trim();
            var getNum = this.txtGCount.Text.Trim();

            for (int i = 0; i < int.Parse(getNum); i++)
            {
                //创建花篮
                var createFlag = CreateBox(getBsgBox, getBsgOpeId, getWoId);
                Thread.Sleep(2000);
                if (createFlag)
                {
                   this.lableGCreate.Text = "当前成功创建第" + i + "次";
                  
                    //花篮上料
                    var releaseFlag = ReleaseBox(getBsgBox, getBsgOpeId, getBsgTool);
                    Thread.Sleep(2000);
                    if (releaseFlag)
                    {
                        this.lableGRelease.Text = "当前成功上料第" + i + "次";

                      
                    }
                    else
                    {
                        MessageBox.Show("花篮上料失败,第" + i + "次");
                        break;
                    }
                }
                else
                {

                    MessageBox.Show("创建花篮失败,第" + i + "次");
                    break;
                }
            }

            MessageBox.Show("入站成功");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //虚拟花篮转虚拟舟
            //第一步:虚拟花篮进实体空舟
            //第二步:实体舟进虚拟舟




        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var flag=   Prtshangliao();
              
            }
            MessageBox.Show("完成");
            // var getWaferCount = this.txtPrtWaferCount.Text.Trim();
            // var getTool=this.txtPrtTool.Text.Trim();
            // var getSubtool=this.txtSubTool.Text.Trim();
            //var   getLastSubTool=this.txtLastSubToolId.Text.Trim();
            // var  getOpe=this.txtOpe.Text.Trim();

            // //获取硅片数组           
            // //获取起始ID,开始出站
            // Ew08 ew08 = new Ew08();
            // List<WaferInfo> list = new List<WaferInfo>();

            // WaferInfo wafer = new WaferInfo();
            // wafer.prdSeqId = "T2021";
            // wafer.slotNo = 1;
            // list.Add(wafer);


            // ew08.iary = list;
            // ew08.lineId = "1";
            // ew08.opeId = getOpe;
            // ew08.toolId = getTool;
            // ew08.actionFlg = "I";
            // ew08.evtUsr = "EAP800";
            // ew08.trxId = "BCTOMES";
            // ew08.channelId = "1";
            // ew08.waferCount = getWaferCount;
            // ew08.subToolId = getSubtool;
            // ew08.lastSubToolId = getLastSubTool;
            // ew08.transactionId = GetTimeStamp();


            // var returnMsg = httpHandler.DoPostPRT(ew08);
            //MessageBox.Show(returnMsg);

        }

        public bool Prtshangliao() {
            var getWaferCount = this.txtPrtWaferCount.Text.Trim();
            var getTool = this.txtPrtTool.Text.Trim();
            var getSubtool = this.txtSubTool.Text.Trim();
            var getLastSubTool = this.txtLastSubToolId.Text.Trim();
            var getOpe = this.txtOpe.Text.Trim();

            //获取硅片数组           
            //获取起始ID,开始出站
            Ew08 ew08 = new Ew08();
            List<WaferInfo> list = new List<WaferInfo>();

            WaferInfo wafer = new WaferInfo();
            wafer.prdSeqId = "T2021";
            wafer.slotNo = 1;
            list.Add(wafer);


            ew08.iary = list;
            ew08.lineId = "1";
            ew08.opeId = getOpe;
            ew08.toolId = getTool;
            ew08.actionFlg = "I";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.channelId = "1";
            ew08.waferCount = getWaferCount;
            ew08.subToolId = getSubtool;
            ew08.lastSubToolId = getLastSubTool;
            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);
            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }
            return false;


        }

        public bool Prtxialiao()
        {
            var getWaferCount = this.txtPrtWaferCount.Text.Trim();
            var getTool = this.txtPrtTool.Text.Trim();
            var getSubtool = this.txtSubTool.Text.Trim();
            var getLastSubTool = this.txtLastSubToolId.Text.Trim();
            var getOpe = this.txtOpe.Text.Trim();

            //获取硅片数组           
            //获取起始ID,开始出站
            Ew08 ew08 = new Ew08();
            List<WaferInfo> list = new List<WaferInfo>();

            WaferInfo wafer = new WaferInfo();
            wafer.prdSeqId = "T2021";
            wafer.slotNo = 1;
            list.Add(wafer);


            ew08.iary = list;
            ew08.lineId = "1";
            ew08.opeId = getOpe;
            ew08.toolId = getTool;
            ew08.actionFlg = "O";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.channelId = "1";
            ew08.waferCount = getWaferCount;
            ew08.subToolId = getSubtool;
            //   ew08.lastSubToolId = getLastSubTool;
            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);
          

            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }
            return false;


        }



        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var flag = Prtxialiao();
               
            }
            MessageBox.Show("完成");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                var getWaferCount = this.txtNCount.Text.Trim();

                var getTool = this.txtNtool.Text.Trim();

                var getOpe = this.txtNOpe.Text.Trim();


                //获取硅片数组           
                //获取起始ID,开始出站
                Ew08 ew08 = new Ew08();

                ew08.lineId = "1";
                ew08.opeId = getOpe;
                ew08.toolId = "SP001";
                ew08.actionFlg = "N";
                ew08.evtUsr = "EAP800";
                ew08.trxId = "BCTOMES";
                ew08.channelId = "1";
                ew08.waferCount = getWaferCount;
                ew08.transactionId = GetTimeStamp();
                var returnMsg = httpHandler.DoPostPRT(ew08);
               
            }
            MessageBox.Show("完成");



        }

        private void button7_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 10; i++)
            {
                var getWaferCount = this.txtNCount.Text.Trim();

                var getTool = this.txtNtool.Text.Trim();

                var getOpe = this.txtNOpe.Text.Trim();
                var getCsi = this.txtCsi.Text.Trim();


                //获取硅片数组           
                //获取起始ID,开始出站
                Ew08 ew08 = new Ew08();




                ew08.lineId = "1";
                ew08.opeId = getOpe;
                ew08.toolId = "EI001";
                ew08.actionFlg = "I";
                ew08.evtUsr = "EAP800";
                ew08.trxId = "BCTOMES";
                ew08.channelId = "1";
                ew08.waferCount = getWaferCount;
                ew08.transactionId = GetTimeStamp();
                ew08.boxId = getCsi;


                var returnMsg = httpHandler.DoPostPRT(ew08);
                MessageBox.Show(returnMsg);
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //actionFlag="N"

            var getWaferCount = this.txtNCount.Text.Trim();

            var getTool = this.txtNtool.Text.Trim();

            var getOpe = this.txtNOpe.Text.Trim();
            var getCsi = this.txtCsi.Text.Trim();


            //获取硅片数组           
            //获取起始ID,开始出站
            Ew08 ew08 = new Ew08();
            //List<WaferInfo> list = new List<WaferInfo>();

            //WaferInfo wafer = new WaferInfo();
            //wafer.prdSeqId = "T2021";
            //wafer.slotNo = 1;
            //list.Add(wafer);


            //   ew08.iary = list;
            ew08.lineId = "1";
            ew08.opeId = getOpe;
            ew08.toolId = getTool;
            ew08.actionFlg = "O";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.channelId = "1";
            ew08.waferCount = getWaferCount;
            //     ew08.subToolId = getSubtool;
            //   ew08.lastSubToolId = getLastSubTool;
            ew08.transactionId = GetTimeStamp();
            ew08.boxId = getCsi;

            var returnMsg = httpHandler.DoPostPRT(ew08);
            MessageBox.Show(returnMsg);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //先创建根据输入框创建花篮
            //花篮上料
            //再根据花篮号取单片入站
            var getBsgBox = this.txtBsgBox.Text.Trim();
            var getBsgOpeId = this.txtBSGOpeId.Text.Trim();
            var getBsgTool = this.txtBSGTool.Text.Trim();
            var getWoId = this.txtBsgWoId.Text.Trim();
            var getNum = this.txtBsgRepaireCount.Text.Trim();

            for (int i = 0; i < int.Parse(getNum); i++)
            {
                //创建花篮
                var createFlag = CreateBox(getBsgBox, getBsgOpeId, getWoId);
                Thread.Sleep(2000);
                if (createFlag)
                {
                    this.lableCreate.Text = "当前成功创建第" + i + "次";
                    //花篮上料
                    var releaseFlag = ReleaseBox(getBsgBox, getBsgOpeId, getBsgTool);
                
                  
                }
                else
                {

                    MessageBox.Show("创建花篮失败,第" + i + "次");
                    break;
                }
            }

            MessageBox.Show("上料成功");
        }

        private void button10_Click(object sender, EventArgs e)
        {
      
           //获取硅片数组           
            //获取起始ID,开始出站
            Ew08 ew08 = new Ew08();
            ew08.lineId = "1";
            ew08.opeId = "IVT";
            ew08.toolId = "TP001";
            ew08.actionFlg = "W";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.channelId = "1";
            ew08.waferCount = "5";
            ew08.transactionId = GetTimeStamp();
            ew08.boxId = "A";


            var returnMsg = httpHandler.DoPostPRT(ew08);
            MessageBox.Show(returnMsg);
        }
    }
}
