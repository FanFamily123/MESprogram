using MESprogram.Pojo;
using Newtonsoft.Json;
using OpcUaHelper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESprogram.Forms
{
    public partial class BoatRepaire : Form
    {
        public BoatRepaire()
        {
            InitializeComponent();
        }

        private OpcUaClient opcUaClient = new OpcUaClient();
        private HttpHandler httpHandler = new HttpHandler();

        private String getUrl = ConfigurationManager.AppSettings["url"];
        private int index = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            var BoatId = this.txtBoat.Text.Trim();
            //  var BlockId=this.txtBlock.Text.Trim();

            if (!string.IsNullOrWhiteSpace(BoatId))
            {
                //先查询总数

                string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = '" + BoatId + "' ";

                DataTable dt = OracleHelper.ExecuteDataTable(sqlString);
                //  this.dataGridView1.DataSource = dt;
                string sqlstring1 = "SELECT COUNT(*) FROM RET_PRD_INFO  WHERE BOX_ID_FK = '" + BoatId + "' ";
                DataTable dt1 = OracleHelper.ExecuteDataTable(sqlstring1);
                var txt = dt1.Rows[0][0].ToString();
                this.LableNum.Text = txt;
                if (dt.Rows.Count > 0)
                {

                    this.lableStats.Text = dt.Rows[0]["PRD_STAT"].ToString();
                    this.txtEqt.Text = dt.Rows[0]["CR_TOOL_ID_FK"].ToString();

                }



                //查询所有区域号,按照顺序查询
                for (int i = 0; i < 14; i++)
                {
                    string sqlStringx = " SELECT COUNT(*) FROM RET_PRD_INFO  WHERE BOX_ID_FK = '" + BoatId + "' and AREA_NO= " + (i + 1);

                    DataTable dtx = OracleHelper.ExecuteDataTable(sqlStringx);
                    //     this.FindControl("Label" + (i+12)+"").Text= dt1.Rows[0][0].ToString();
                    try
                    {

                        if (dtx.Rows.Count > 0)
                        {
                            var getNum = dtx.Rows[0][0].ToString();
                            ((Label)this.Controls["Label" + (i + 12)]).Text = "区域" + (i + 1) + "的数量" + getNum;
                        }
                        else
                        {
                            ((Label)this.Controls["Label" + (i + 12)]).Text = "区域" + (i + 1) + "的数量" + 0;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }









                }










            }
        }



        private void BoatRepaire_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //   this.dataGridView1.DataSource = "";
            this.LableNum.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var getBoat = this.txt_boatID.Text.Trim();
            var getBlock = this.txt_blockID.Text.Trim();
            var getStartID = this.txt_StartID.Text.Trim();
            var gettxt_Num = this.txt_Num.Text.Trim();
            var getTool = this.txtTool.Text.Trim();
            var getOpeID = this.txtOpeId.Text.Trim();
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = getOpeID;
            mew03waferiobtI.toolId = getTool;
            mew03waferiobtI.actionFlg = "I";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";


            mew03waferiobtI.transactionId = GetTimeStamp();


            mew03waferiobtI.boxId = getBoat;
            mew03waferiobtI.boatblockNo = getBlock;
            mew03waferiobtI.channelNo = "1";

            mew03waferiobtI.iary = getwaferIds1(getStartID, int.Parse(gettxt_Num));


            //所有参数发给mes
            //     MessageBox.Show(mew03waferiobtI.transactionId);

            //   var jsonobj = JsonConvert.SerializeObject(mew03waferiobtI);

            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            MessageBox.Show(returnMsg);



        }
        public List<WaferInfo> getwaferIds1(string waferId, int num)
        {
            //通过数量和waferid批量插入数据                    
            var len1 = waferId.Substring(0, 9);
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
                var getNewId = waferid.ToString().PadLeft(8, '0');
                var newWaferId = len1 + getNewId + "";
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = newWaferId;
                wafer.slotNo = i;
                list.Add(wafer);

            }
            return list;
            MessageBox.Show(startId);
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



        private void editFront(string str)
        {
            //修改前50片硅片id
            //新的硅片进花篮 将数量和硅片id填写到模拟器后改index


            // String txtEW02waferCount = this.txtEW02waferCount.Text.Trim(); //硅片数量
            String WafId = str.Substring(0, str.Length - 2);
            //  string classtxt = this.comboBox1.SelectedValue.ToString();
            //读取模拟器起始点位
            string TEX_EW0201waferId = ConfigurationManager.AppSettings["_EW0301iary"];

            for (int i = 1; i < 51; i++)
            {

                //修改点位
                if (i < 10)
                {
                    //点位地址
                    var pointId = TEX_EW0201waferId + "{" + i + "}";
                    bool IsFlag = opcUaClient.WriteNode(pointId, WafId + "0" + i);
                    if (!IsFlag)
                    {
                        MessageBox.Show("写入硅片id" + pointId + "失败");
                    }
                }
                else if (i > 9 && i < 100)
                {
                    //点位地址
                    var x = i + 1;
                    var pointId = TEX_EW0201waferId + "{" + i + "}";
                    bool IsFlag = opcUaClient.WriteNode(pointId, WafId + i);
                    if (!IsFlag)
                    {
                        MessageBox.Show("写入硅片id" + pointId + "失败");
                    }

                }

            }
            MessageBox.Show("写入数量成功");

        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mew03ReqMesList temp = new Mew03ReqMesList();
            temp.lineId = "1";
            temp.opeId = "DIF";
            temp.toolId = "BD001";
            temp.actionFlg = "W";
            temp.evtUsr = "EAP800";
            temp.trxId = "BCTOMES";
            temp.transactionId = "20211130143641001";

            temp.boxId = "9-052";
            temp.areaNo = "1";
            temp.channelNo = "1";



            var returnMsg = httpHandler.DoPost(temp);
            //      String rtnMsg = httpHandler.postHttpForMes(uid, opcTransConfig.getTrxId(), JackSonUtil.toJSONStr(temp));



        }

        private void button5_Click(object sender, EventArgs e)
        {
            int num = 100;
            var txt = "T2022030100007401";
            var len1 = txt.Substring(0, 14);
            var len2 = txt.Substring(14, 3);
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



            MessageBox.Show(list.ToArray() + "");
            //  MessageBox.Show(len2);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //先料盒上料,获取硅片id
            var getLH = this.txtNewLh.Text.Trim();
            var getHL = this.txtNewHl.Text.Trim();
            var getBoat = this.txtNewBoat.Text.Trim();
            var getEqu = this.txtnewEqu.Text.Trim();
            if (!string.IsNullOrWhiteSpace(getLH) && !string.IsNullOrWhiteSpace(getHL) && !string.IsNullOrWhiteSpace(getBoat))
            {



                var flag = ToRelese(getLH);
                MessageBox.Show(flag + "");
                if (flag)
                {
                    //硅片进花篮,入站出站
                    for (int i = 0; i < 6; i++)
                    {
                        bool flagBoatWait = getWaferCount(getLH, getHL, getEqu);
                        if (flagBoatWait)
                        {
                            //获取硅片id,判断是否是rels的硅片,插入舟区域小于100的




                        }
                    }




                }
                else
                {

                    MessageBox.Show("料盒上料失败");
                }





            }



            //然后硅片进花篮,入站出站
            //花篮上料
            //补舟,按照区域,一个一个的区域补舟
        }
        #region 料盒上料
        public bool ToRelese(string boxLh)
        {
            Meh02bcreqcsI meh02 = new Meh02bcreqcsI();
            meh02.actionFlg = "R";
            meh02.lineId = "1";
            meh02.toolId = "TE001";
            meh02.boxId = boxLh;
            meh02.opeId = "TEX";
            meh02.trxId = "BCTOMES";

            var returnMsg = httpHandler.DoPostRe(meh02);

            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }
            return false;


        }
        #endregion


        #region 制绒入站出站,扩散上料
        public bool getWaferCount(string lh, string box, string equ)
        {
            //先查询硅片id

            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", lh));
            //获取前100片硅片id,进花篮,入站出站
            if (dt.Rows.Count >= 100)
            {
                //获取硅片数组
                ew07 _ew07 = new ew07();
                _ew07.iary = getwaferIdByDB(dt);
                _ew07.boxId = box;

                _ew07.lineId = "1";
                _ew07.opeId = "TEX";
                _ew07.toolId = "TE001";
                _ew07.actionFlg = "I";
                _ew07.evtUsr = "EAP800";
                _ew07.trxId = "BCTOMES";


                _ew07.transactionId = GetTimeStamp();
                var returnMsg1 = httpHandler.DoPostTex(_ew07);
                Thread.Sleep(300);
                if (returnMsg1.Contains("SUCCESS"))
                {
                    _ew07.actionFlg = "O";
                    _ew07.transactionId = GetTimeStamp();
                    var returnMsg2 = httpHandler.DoPostTex(_ew07);
                    if (returnMsg2.Contains("SUCCESS"))
                    {
                        //直接上料
                        EH02 eH02 = new EH02();
                        eH02.boxId = box;
                        eH02.lineId = "1";
                        eH02.opeId = "DIF";
                        eH02.toolId = equ;
                        eH02.actionFlg = "R";
                        eH02.evtUsr = "EAP800";
                        eH02.trxId = "BCTOMES";


                        eH02.transactionId = GetTimeStamp();


                        var returnMsg3 = httpHandler.DoPostDIF(eH02);
                        if (returnMsg3.Contains("SUCCESS"))
                        {
                            return true;

                        }
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("花篮出站失败");

                    }
                }
                else
                {
                    MessageBox.Show("花篮入站失败");
                }




            }
            else
            {
                MessageBox.Show("该料盒硅片数量不足" + dt.Rows.Count + "片");

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


        #endregion

        #region 获取rels硅片,循环插入舟
        public bool InsertBoat(string boatId, string equ, string box, string block)
        {
            //先获取硅片id
            var wafers = getWafersList(box);
            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = "DIF";
            mew03waferiobtI.toolId = equ;
            mew03waferiobtI.actionFlg = "I";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";


            mew03waferiobtI.transactionId = GetTimeStamp();


            mew03waferiobtI.boxId = boatId;
            mew03waferiobtI.boatblockNo = block;
            mew03waferiobtI.channelNo = "1";

            mew03waferiobtI.iary = wafers;



            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }




            return false;
        }
        public bool InsertBoat1(string boatId, string equ, string box, string block, int num)
        {
            //先获取硅片id
            var wafers = getWafersList1(box, num);
            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = "DIF";
            mew03waferiobtI.toolId = equ;
            mew03waferiobtI.actionFlg = "I";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";


            mew03waferiobtI.transactionId = GetTimeStamp();


            mew03waferiobtI.boxId = boatId;
            mew03waferiobtI.boatblockNo = block;
            mew03waferiobtI.channelNo = "1";

            mew03waferiobtI.iary = wafers;



            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }




            return false;
        }


        public List<WaferInfo> getWafersList(string box)
        {
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", box));
            List<WaferInfo> returnList = new List<WaferInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = dt.Rows[i]["PRD_SEQ_ID"].ToString();
                wafer.slotNo = i;
                returnList.Add(wafer);
            }
            return returnList;

        }

        public List<WaferInfo> getWafersList1(string box, int num)
        {
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", box));
            List<WaferInfo> returnList = new List<WaferInfo>();
            for (int i = 0; i < num; i++)
            {
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = dt.Rows[i]["PRD_SEQ_ID"].ToString();
                wafer.slotNo = i;
                returnList.Add(wafer);
            }
            return returnList;

        }


        private void button6_Click(object sender, EventArgs e)
        {
            var getLH = this.txtNewLh.Text.Trim();
            var getHL = this.txtNewHl.Text.Trim();
            var getBoat = this.txtNewBoat.Text.Trim();
            var getEqu = this.txtnewEqu.Text.Trim();
            //for循环查找不满足100的
            //查询舟区域,那个为空
            for (int i = 1; i < 15; i++)
            {
                //查询<100的区域
                string sqlStringx = " SELECT COUNT(*) FROM RET_PRD_INFO  WHERE BOX_ID_FK = '" + getBoat + "' and AREA_NO= " + (i + 1);

                DataTable dtx = OracleHelper.ExecuteDataTable(sqlStringx);
                var txt = dtx.Rows[0][0].ToString();
                int getCount = int.Parse(txt);
                if (getCount == 0)
                {
                    //补满100
                    var flag = getWaferCount(getLH, getHL, getEqu);
                    if (flag)
                    {
                        //开始补片
                        bool insertFlag = InsertBoat(getBoat, getEqu, getHL, i + "");



                    }

                }
                else if (0 < getCount && getCount < 100)
                {
                    var insertNum = 100 - getCount;
                    //补满100
                    var flag = getWaferCount(getLH, getHL, getEqu);
                    if (flag)
                    {
                        //开始补片
                        bool insertFlag = InsertBoat1(getBoat, getEqu, getHL, i + "", insertNum);
                        if (insertFlag)
                        {
                            //补完就清空这个花篮
                            string sqlString = "UPDATE \"MES_PPT\".\"RET_BOX\" SET  \"BOX_STAT\" = 'EMPT', \"VALID_FLG\" = 'Y', \"PRD_QTY\" = '0', \"CHIP_QTY\" = NULL, \"MDL_ID_FK\" = NULL, \"MTRL_PROD_ID_FK\" = NULL, \"NX_PATH_ID_FK\" = NULL, \"NX_PATH_VER_FK\" = NULL, \"NX_OPE_NO_FK\" = NULL, \"NX_OPE_ID_FK\" = NULL, \"NX_OPE_VER_FK\" = NULL, \"NX_PROC_ID_FK\" = NULL, \"NX_TOOLG_ID_FK\" = NULL, \"NX_TOOL_RUN_MODE\" = NULL, \"NX_TOOL_ID_FK\" = NULL, \"TOOL_ID_FK\" = NULL, \"TOOL_PORT_ID_FK\" = NULL, \"ACT_CMP_TIMESTAMP\" = NULL, \"WH_IN_TIMESTAMP\" = NULL WHERE \"BOX_ID\" = :id";

                            var a = OracleHelper.ExecuteNonQuery(sqlString, new OracleParameter(":id", getHL));

                            string sqlString1 = @"DELETE FROM RET_PRD_INFO where BOX_ID_FK = :id";
                            var b = OracleHelper.ExecuteNonQuery(sqlString1, new OracleParameter(":id", getHL));
                        }


                    }
                    else if (getCount == 100)
                    {
                        break;
                    }








                }



            }
            #endregion



        }

        private void button8_Click(object sender, EventArgs e)
        {

            var getLH = this.txtNewLh.Text.Trim();
            var flag = ToRelese(getLH);


        }

        private void button9_Click(object sender, EventArgs e)
        {
          var getBoat2=this.txtBoat2.Text.Trim();
            var getTool2 = this.txtEqu2.Text.Trim();
            var getBlck2=this.txtBlock2.Text.Trim();
            var getCount2 = this.txtWafer2.Text.Trim();
            var getOpe23=this.txtOpe23.Text.Trim();
            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = getOpe23;
            mew03waferiobtI.toolId = getTool2;
            mew03waferiobtI.actionFlg = "I";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";


            mew03waferiobtI.transactionId = GetTimeStamp();


            mew03waferiobtI.boxId = getBoat2;
            mew03waferiobtI.boatblockNo = getBlck2;
            mew03waferiobtI.channelNo = "1";

            mew03waferiobtI.waferCount = getCount2;

            if (getOpe23.Equals("DIF")|| getOpe23.Equals("ANN"))
            {
                mew03waferiobtI.BoxIdA = this.txtBoxA.Text.Trim();
                mew03waferiobtI.BoxIdB=this.txtBoxB.Text.Trim();
            }

            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            MessageBox.Show(returnMsg);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var getBox = this.txtBoxId.Text.Trim();
            var getOpe=this.txtOpeMo.Text.Trim();
            var getTool=this.txtToolMO.Text.Trim();

            //获取硅片数组
            Ew03New _ew07 = new Ew03New();
            // _ew07.iary = getwaferIds1(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;
            _ew07.waferCount = "100";
            _ew07.lineId = "1";
            _ew07.opeId = getOpe;
            _ew07.toolId = getTool;
            _ew07.actionFlg = "O";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";


            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostDIF2(_ew07);

            MessageBox.Show(returnMsg);
        }


      

        private void button12_Click(object sender, EventArgs e)
        {
            var getBox = this.textBox4.Text.Trim();
            var getOpe=this.textBox2.Text.Trim();
            var getToole=this.textBox1.Text.Trim();
            var getBlock=this.txtBlock.Text.Trim();
            //获取硅片数组
            Ew03 _ew07 = new Ew03();
            // _ew07.iary = getwaferIds1(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;
         //   _ew07.waferCount = "290";
            _ew07.lineId = "1";
            _ew07.opeId = getOpe;
            _ew07.toolId = getToole;
            _ew07.actionFlg = "G";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";
            _ew07.boatblockNo = getBlock;


            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPost3(_ew07);

            MessageBox.Show(returnMsg);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //扩散退火舟转花篮
            var BoxA=this.BoxA.Text.Trim();
            var BoxB=this.BoxB.Text.Trim();
            var Boat=this.Boat.Text.Trim();
            var Ope=this.Ope.Text.Trim();
            var Block=this.Block.Text.Trim();
            var Equ=this.Equ.Text.Trim();

            Ew03New ew03New = new Ew03New();
            ew03New.toolId = Equ;
            ew03New.opeId = Ope;
            ew03New.boxIdA= BoxA;
            ew03New.boxIdB= BoxB;
            ew03New.waferCountA = "50";
            ew03New.waferCountB = "50";
            ew03New.boatId= Boat;
            ew03New.boatblockNo = Block;
            ew03New.transactionId = GetTimeStamp();
            ew03New.lineId = "1";

            ew03New.actionFlg = "O";
            ew03New.evtUsr = "EAP800";
            ew03New.trxId = "BCTOMES";

            var returnMsg = httpHandler.DoPostDIF2(ew03New);

            MessageBox.Show(returnMsg);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            var getBoat2 = this.txtBoat2.Text.Trim();
            var getTool2 = this.txtEqu2.Text.Trim();
            var getBlck2 = this.txtBlock2.Text.Trim();
            var getCount2 = this.txtWafer2.Text.Trim();
            var getOpe23 = this.txtOpe23.Text.Trim();
            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = getOpe23;
            mew03waferiobtI.toolId = getTool2;
            mew03waferiobtI.actionFlg = "I";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";


            mew03waferiobtI.transactionId = GetTimeStamp();


            mew03waferiobtI.boxId = getBoat2;
            mew03waferiobtI.boatblockNo = getBlck2;
            mew03waferiobtI.channelNo = "1";

            mew03waferiobtI.waferCount = getCount2;

           

            var returnMsg = httpHandler.DoPost3(mew03waferiobtI);

            MessageBox.Show(returnMsg);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            var getString = this.txtString.Text.Trim();
            //获取不是wait的index
            var getinDEX= getString.IndexOf("MES Reply NG");
            MessageBox.Show(getinDEX+"");
            var newString=getString.Substring(getinDEX);
            MessageBox.Show(newString);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var getBox = this.txtBoxId.Text.Trim();
            var getOpe = this.txtOpeMo.Text.Trim();
            var getTool = this.txtToolMO.Text.Trim();
            var getBox2=this.textBox3.Text.Trim();
            //获取硅片数组
            ew071 _ew07 = new ew071();
            // _ew07.iary = getwaferIds1(getWaferStartId, int.Parse(getNum));
            _ew07.boxId = getBox;
            _ew07.waferCount = "100";
            _ew07.lineId = "1";
            _ew07.opeId = getOpe;
            _ew07.toolId = getTool;
            _ew07.actionFlg = "O";
            _ew07.evtUsr = "EAP800";
            _ew07.trxId = "BCTOMES";


            _ew07.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostTex1(_ew07);

            _ew07.boxId = getBox2;
            _ew07.transactionId = GetTimeStamp();

            var returnMsg1 = httpHandler.DoPostTex1(_ew07);

            MessageBox.Show(returnMsg1+"////"+returnMsg);
        }
    }
    }
