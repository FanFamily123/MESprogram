using MESprogram.Pojo;
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
    public partial class EW09Test : Form
    {
        public EW09Test()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();

        private String getUrl = ConfigurationManager.AppSettings["url"];

        private void button1_Click(object sender, EventArgs e)
        {
            var getNum=this.num.Text.Trim();
            var getBox=this.bin.Text.Trim();
            var getwafer1=this.wafer1.Text.Trim(); 
           // var getwafer2 = this.wafer2.Text.Trim();
          //  var getwafer3 = this.wafer3.Text.Trim();

            Ew09 ew09=new Ew09();
            ew09.boxId = getBox;
            ew09.waferCount = getNum;
            List<WaferInfo> list = new List<WaferInfo>();
            WaferInfo waferInfo= new WaferInfo();
            waferInfo.prdSeqId = getwafer1;
            waferInfo.slotNo = 1;
            list.Add(waferInfo);

            ew09.transactionId = GetTimeStamp();
            ew09.lineId = "1";
            ew09.actionFlg = "O";
            ew09.evtUsr = "EAP800";
            ew09.trxId = "BCTOMES";
            ew09.toolId = "TP001";
            ew09.opeId = "IVT";
            ew09.iary = list;
            var returnMsg = httpHandler.DoPostIVT(ew09);

            MessageBox.Show(returnMsg);

        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }


    }
}
