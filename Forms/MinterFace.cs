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
    public partial class MinterFace : Form
    {
        public MinterFace()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();


        private void button1_Click(object sender, EventArgs e)
        {
            var getHLR = this.txtHL.Text.Trim();
            var getChannel = this.txtChannel.Text.Trim();
            var getOpe=this.txtOpe.Text.Trim();
            var getTool=this.txtTool.Text.Trim();
            
            if (!string.IsNullOrWhiteSpace(getHLR))
            {
                EH08 eH02 = new EH08();
                eH02.boxId = getHLR;

                eH02.lineId = "1";
                eH02.opeId = getOpe;
                eH02.toolId = getTool;
                eH02.channelID = getChannel;
                eH02.actionFlg = "M";
                eH02.evtUsr = "EAP800";
                eH02.trxId = "BCTOMES";


                eH02.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostEH08(eH02);

                MessageBox.Show(returnMsg);


            }
        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }


    }
}
