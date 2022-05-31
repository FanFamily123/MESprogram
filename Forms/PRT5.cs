using MESprogram.Pojo;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESprogram.Forms
{
    public partial class PRT5 : Form
    {
        public PRT5()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();
        private ConnectionMultiplexer redis;//连接到redis
        private String redisUrl = ConfigurationManager.AppSettings["redisUrl"];

        private void button1_Click(object sender, EventArgs e)
        {
            var getWaferStartId=this.txtStart.Text.Trim();

            //获取起始ID,开始入站
            Ew08 ew08=new Ew08();
            ew08.iary = getwaferIds1(getWaferStartId, 100) ;          
            ew08.lineId = "1";
            ew08.opeId = "PRT";
            ew08.toolId = "SP002";
            ew08.actionFlg = "O";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            //    ew08.waferCount = "100";
            ew08.subToolId = "SP1A-4";

            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);
            MessageBox.Show(returnMsg);
        }
        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            //dzr获取同样的硅片
            Meh02bcreqcsI meh02 = new Meh02bcreqcsI();
            meh02.actionFlg = "N";
            meh02.lineId = "1";
            meh02.toolId = "SP002";
          //  meh02.boxId = boxLh;
            meh02.opeId = "DZR";
            meh02.trxId = "BCTOMES";

            var returnMsg = httpHandler.DoPostRe(meh02);

            MessageBox.Show(returnMsg);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //通过花篮号获取硅片存入redis
            var txt=this.txtBox.Text.Trim();

            //通过接口查询
            string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id order by PRD_SEQ_ID asc";



            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", txt));
            //  this.dataGridView1.DataSource = dt;
          //  List<String> wafercoint = dt.Columns["PRD_SEQ_ID"].DefaultValue;
            List<String> ids = GetColumnValues<String>(dt, "PRD_SEQ_ID");
            //将ids转换成wafer
            List<WaferInfo> w = new List<WaferInfo>();
       
            for (int i = 0; i < ids.Count; i++)
            {
                WaferInfo wafer = new WaferInfo();
                wafer.prdSeqId = ids[i];
                wafer.slotNo = i;
                w.Add(wafer);
            }


            IDatabase db = redis.GetDatabase();
           
            String getvalue=JsonConvert.SerializeObject(w);

            db.StringSet("111", getvalue);
            MessageBox.Show(getvalue);
            //    MessageBox.Show(value);


        }
        public static List<T> GetColumnValues<T>(DataTable dtSource, string filedName)
        {
            return (from r in dtSource.AsEnumerable() select r.Field<T>("PRD_SEQ_ID")).ToList<T>();
        }


        private void PRT5_Load(object sender, EventArgs e)
        {
            redis = ConnectionMultiplexer.Connect(redisUrl);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IDatabase db = redis.GetDatabase();
            string value = db.StringGet("111");

            //获取到值以后反序列化

            List<WaferInfo> w = JsonConvert.DeserializeObject<List<WaferInfo>>(value);

            var getWaferStartId = this.txtStart.Text.Trim();

            //获取起始ID,开始出站
            Ew08 ew08 = new Ew08();
            ew08.iary = w;
            ew08.lineId = "1";
            ew08.opeId = "PRT";
            ew08.toolId = "SP002";
            ew08.actionFlg = "O";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            //    ew08.waferCount = "100";
            ew08.subToolId = "SP1B-4";

            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);
            MessageBox.Show(returnMsg);

          //  MessageBox.Show(value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //pe碎片接口
            Ew08 ew08 = new Ew08();
        //    ew08.iary = w;
            ew08.lineId = "1";
            ew08.opeId = "ALD";
            ew08.toolId = "PE001";
            ew08.actionFlg = "B";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.waferCount = "1";
            ew08.channelId = "1";

            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            //pe碎片接口
            Ew08 ew08 = new Ew08();
            //    ew08.iary = w;
            ew08.lineId = "1";
            ew08.opeId = "ALD";
            ew08.toolId = "PE001";
            ew08.actionFlg = "B";
            ew08.evtUsr = "EAP800";
            ew08.trxId = "BCTOMES";
            ew08.waferCount = "1";
            ew08.channelId = "2";

            ew08.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostPRT(ew08);
        }
    }
}
