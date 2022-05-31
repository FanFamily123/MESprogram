using MESprogram.Pojo;
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
    public partial class BoxStat : Form
    {
        public BoxStat()
        {
            InitializeComponent();
        }


        private HttpHandler httpHandler = new HttpHandler();

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var getBox=this.textBox1.Text.Trim();
            var getOpe=this.textBox2.Text.Trim();
           
            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = getOpe;
        //    mew03waferiobtI.toolId = getTool2;
            mew03waferiobtI.actionFlg = "U";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";
            mew03waferiobtI.boxId = getBox;


            mew03waferiobtI.transactionId = GetTimeStamp();


        



            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            MessageBox.Show(returnMsg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var getOpe = this.textBox3.Text.Trim();
            var getTool =this.textBox5.Text.Trim();
         //   var getChannel = this.textBox5.Text.Trim();

            //插入
            Pojo.Ew03 mew03waferiobtI = new Pojo.Ew03();
            mew03waferiobtI.lineId = "1";
            mew03waferiobtI.opeId = getOpe;
                mew03waferiobtI.toolId = getTool;
            mew03waferiobtI.actionFlg = "D";
            mew03waferiobtI.evtUsr = "EAP800";
            mew03waferiobtI.trxId = "BCTOMES";
      //      mew03waferiobtI.boxId = getBox;
            mew03waferiobtI.channelId = "1";

            mew03waferiobtI.prdSeqId = "1";
            mew03waferiobtI.transactionId = GetTimeStamp();






            var returnMsg = httpHandler.DoPost1(mew03waferiobtI);

            MessageBox.Show(returnMsg);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
