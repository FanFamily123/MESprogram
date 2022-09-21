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
    public partial class InterfaceRepaire : Form
    {
        public InterfaceRepaire()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();



        private void InterfaceRepaire_Load(object sender, EventArgs e)
        {

        }


        public List<WaferInfo> getwaferIds(string waferId, int num)
        {
            //通过数量和waferid批量插入数据                    
            var len1 = waferId.Substring(0, 14);
            var len2 = waferId.Substring(14, 3);
            var waferStartId = int.Parse(len2);
            List<WaferInfo> list = new List<WaferInfo>();
            for (int i = 0; i < num; i++)
            {
                var waferid = waferStartId + i;
                var newWaferId = len1 + waferid + "";
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = newWaferId;
                wafer.slotNo = i;
                list.Add(wafer);

            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var getBox=this.txtBoxId.Text.Trim();
            var getWaferStartId = this.txtWaferStartId.Text.Trim();
            var getNum=this.txtNum.Text.Trim(); 

            //获取硅片数组
            ew07 _ew07=new ew07();
            _ew07.iary = getwaferIds1(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;
            
                _ew07.lineId = "1";
            _ew07.opeId = "TEX";
            _ew07.toolId = "TE001";
            _ew07.actionFlg = "I";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";
            _ew07.waferCount = "100";


            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostTex(_ew07);

            MessageBox.Show(returnMsg);

        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var getBox = this.txtBoxId.Text.Trim();
            var getWaferStartId = this.txtWaferStartId.Text.Trim();
            var getNum = this.txtNum.Text.Trim();

            //获取硅片数组
            ew07 _ew07 = new ew07();
            _ew07.iary = getwaferIds(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;

            _ew07.lineId = "1";
            _ew07.opeId = "TEX";
            _ew07.toolId = "TE001";
            _ew07.actionFlg = "O";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";


            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostTex(_ew07);

            MessageBox.Show(returnMsg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var getLHId=this.txtLH.Text.Trim();
            if (!string.IsNullOrWhiteSpace(getLHId))
            {
                string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";



                DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", this.txtLH.Text.Trim()));
                this.dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var getHLR=this.txtHLR.Text.Trim();
            var getEQU=this.txtEQU.Text.Trim();
            var getRope = this.txtROpe.Text.Trim();
            if (!string.IsNullOrWhiteSpace(getHLR))
            {
                EH02 eH02 = new EH02();
                eH02.boxId = getHLR;

                eH02.lineId = "1";
                eH02.opeId = getRope;
                eH02.toolId = getEQU;
                eH02.actionFlg = "R";
                eH02.evtUsr = "EAP800";
                eH02.trxId = "BCTOMES";
        


                eH02.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostDIF(eH02);

                MessageBox.Show(returnMsg);


            }
          

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var getMoveHL=this.txtMoveHL.Text.Trim(); 
            var getOpeId=this.txtOpeId.Text.Trim();
            if (!string.IsNullOrWhiteSpace(getMoveHL))
            {
                // {"trxId":"BMMOVENOUT","actionFlg":"N","boxIds":"XHL0379","opeId":"ANN","evtUsr":"ADMIN"}

                //不为空,则跳站
                Move move =new Move();
                move.evtUsr = "ADMIN";
                move.opeId= getOpeId;
                move.actionFlg = "N";
                move.boxIds = getMoveHL;
                move.trxId = "BMMOVENOUT";

                var returnMsg = httpHandler.DoPostMove(move);

                MessageBox.Show(returnMsg);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var getBox = this.txtBoxId.Text.Trim();
            var getWaferStartId = this.txtWaferStartId.Text.Trim();
            var getNum = this.txtNum.Text.Trim();

            //获取硅片数组
          
           var getList = getwaferIds1(getWaferStartId, int.Parse(getNum));
            MessageBox.Show(getList.ToArray().ToString());
        }





        public List<WaferInfo> getwaferIds1(string waferId, int num)
        {
            //通过数量和waferid批量插入数据                    
            var len1 = waferId.Substring(0, 9);
            //var len2 = waferId.Substring(14, 3);
            //var waferStartId = int.Parse(len2);
            //List<WaferInfo> list = new List<WaferInfo>();
            //for (int i = 0; i < num; i++)
            //{
            //    var waferid = waferStartId + i;
            //    var newWaferId = len1 + waferid + "";
            //    WaferInfo wafer = new WaferInfo();
            //    wafer.prdSeqId = newWaferId;
            //    wafer.slotNo = i;
            //    list.Add(wafer);

            //}
            //return list;


            //通过数量和waferid批量插入数据                    
            var lenx = waferId.Trim();
            var getID = lenx.Substring(9, 8);
            //将前面第一个不为0的字符串截取
            var startId = getID.TrimStart('0');

            //进入for循环
            var waferStartId = int.Parse(startId);
            List<WaferInfo> list = new List<WaferInfo>();
            for (int i = 0; i < num; i++)
            {
                var waferid = waferStartId + i;
                //判断新增的waferid的位数
                var getNewId=waferid.ToString().PadLeft(8, '0');         
                var newWaferId = len1 + getNewId + "";
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = newWaferId;
                wafer.slotNo = i;
                list.Add(wafer);

            }
            return list;




            MessageBox.Show(startId);














        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            var getBox = this.txtBoxId.Text.Trim();
            var getWaferStartId = this.txtWaferStartId.Text.Trim();
            var getNum = this.txtNum.Text.Trim();
            var getOpe=this.txtOpeCAO.Text.Trim();
            var getTool=this.txtToolCao.Text.Trim();
            var getSub = this.txtSubTool.Text.Trim();
            //获取硅片数组
            ew071 _ew07 = new ew071();
           // _ew07.iary = getwaferIds1(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;
            _ew07.waferCount = getNum;
            _ew07.lineId = "1";
            _ew07.opeId = getOpe;
            _ew07.toolId = getTool;
            _ew07.actionFlg = "I";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";
            _ew07.channelId = "2";
            _ew07.subToolId = getSub;

            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostTex1(_ew07);

            MessageBox.Show(returnMsg);

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var getMHL=this.txtMHL.Text.Trim();
            var getMope=this.txtMope.Text.Trim();
          //  var getMtool=this.txtMTool.Text.Trim();
            var getMcounter=this.txtMcount.Text.Trim();
            var getwoId=this.txtwoId.Text.Trim();
            EWAdd ewAdd = new EWAdd();
           // ewAdd.toolId = getMtool;
            ewAdd.boxId = getMHL;
            ewAdd.opeId = getMope;
            ewAdd.waferCount=getMcounter;
            ewAdd.actionFlg="A";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "BCTOMES";
            ewAdd.transactionId = GetTimeStamp();
         //   ewAdd.woId = getwoId;

            var returnMsg = httpHandler.DoPostAddnew(ewAdd);

            MessageBox.Show(returnMsg);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var getBox = this.txtBoxId.Text.Trim();
            var getWaferStartId = this.txtWaferStartId.Text.Trim();
            var getNum = this.txtNum.Text.Trim();
            var getOpe = this.txtOpeCAO.Text.Trim();
            var getTool = this.txtToolCao.Text.Trim();

            //获取硅片数组
            ew071 _ew07 = new ew071();
            // _ew07.iary = getwaferIds1(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;
          //  _ew07.waferCount = "100";
            _ew07.lineId = "1";
            _ew07.opeId = getOpe;
            _ew07.toolId = getTool;
            _ew07.actionFlg = "O";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";


            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostTex1(_ew07);

            MessageBox.Show(returnMsg);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var getHLR = this.txtBSGHLR.Text.Trim();
            var getEQU = this.txtBSGEQU.Text.Trim();
            var getRope = this.txtBSGROpe.Text.Trim();
            var getChannelId=this.txtBSGChannel.Text.Trim();
            if (!string.IsNullOrWhiteSpace(getHLR))
            {
                EH02 eH02 = new EH02();
                eH02.boxId = getHLR;

                eH02.lineId = "1";
                eH02.opeId = getRope;
                eH02.toolId = getEQU;
                eH02.actionFlg = "R";
                eH02.evtUsr = "EAP800";
                eH02.trxId = "BCTOMES";
                eH02.channelId = getChannelId;

                eH02.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostDIF(eH02);

                MessageBox.Show(returnMsg);


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var getOpeId=this.txtMoveOpe.Text.Trim();
            var getTool=this.txtMoveTool.Text.Trim();
            var getWaferCount=this.txtMoveNum.Text.Trim();
            var getChannel=this.txtMoveChannel.Text.Trim();
            Ew08 ew08 = new Ew08();
          //  ew08.iary = getwaferIdByDB(dt);
            ew08.lineId = "1";
            ew08.opeId = getOpeId;
            ew08.toolId = getTool;
            ew08.actionFlg = "I";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.waferCount = getWaferCount;
            ew08.channelId = getChannel;
            //     ew08.subToolId = "SP1B-4";

            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);
            MessageBox.Show(returnMsg);
        }

        private void button11_Click(object sender, EventArgs e)
        {

            var getBox=this.txtOutBox.Text.Trim();  
            var getOpe=this.txtOutOpe.Text.Trim();
            var getTool=this.txtOutTool.Text.Trim();
            var getWafer=this.txtOutNum.Text.Trim();

            ew07 ew07 = new ew07();
            ew07.lineId = "1";
            ew07.opeId = getOpe;
            ew07.toolId = getTool;
            ew07.actionFlg = "O";
            ew07.evtUsr = "EAP800";
            ew07.trxId = "BCTOMES";
            ew07.waferCount = getWafer;
            ew07.boxId = getBox;
            //     ew08.subToolId = "SP1B-4";

            ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostTex(ew07);
            MessageBox.Show(returnMsg);
        }
    }
}
