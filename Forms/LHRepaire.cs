using MESprogram.Pojo;
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
    public partial class LHRepaire : Form
    {
        public LHRepaire()
        {
            InitializeComponent();
        }
        private HttpHandler httpHandler = new HttpHandler();


        private void button1_Click(object sender, EventArgs e)
        {
            var getHLR = this.txtBSGHLR.Text.Trim();

            var getChannelId = this.txtBSGChannel.Text.Trim();
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
                eH02.channelId = getChannelId;

                eH02.transactionId = GetTimeStamp();


                var returnMsg = httpHandler.DoPostDIF(eH02);

                MessageBox.Show(returnMsg);
            }
        }

        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            var getNum=this.txtNum.Text.Trim();
            var boxId = this.txtBSGHLR.Text.Trim();
            var getChannel=this.txtBSGChannel.Text.Trim();
            //先分片拆包
            for (int i = 0; i < int.Parse(getNum); i++)
            {
                var flag = ToFP(boxId);
                Thread.Sleep(2000);
                if (flag)
                {
                    //上料
                    this.lableCreate.Text = "当前成功创建第" + i + "次";
                 //   this.lableCreate.Text = "当前成功创建第" + i + "次";
                    //花篮上料
                    var releaseFlag = ToRelease(boxId, getChannel);
                    if (releaseFlag)
                    {
                        this.lableRelease.Text = "当前成功上料第" + i + "次";
                    }
                }
            }
            MessageBox.Show("成功结束");

        }

        //分片拆包方法

        public bool ToFP(string boxId) {
            EH02 eH02 = new EH02();
            eH02.boxId = boxId;

            eH02.lineId = "1";
            eH02.opeId = "FPCB";
            eH02.toolId = "UP001";
            eH02.actionFlg = "H";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "BCTOMES";

            eH02.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostDIF(eH02);

            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }


            return false;
        
        }
        //上料方法
        public bool ToRelease(string getHLR,string getChannelId) {
            EH02 eH02 = new EH02();
            eH02.boxId = getHLR;

            eH02.lineId = "1";
            eH02.opeId = "TEX";
            eH02.toolId = "TE001";
            eH02.actionFlg = "R";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "BCTOMES";
            eH02.channelId = getChannelId;

            eH02.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostDIF(eH02);
            if (returnMsg.Contains("SUCCESS"))
            {
                return true;
            }
            return false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var boxId=this.txtBSGHLR.Text.Trim();
            EH02 eH02 = new EH02();
            eH02.boxId = boxId;

            eH02.lineId = "1";
            eH02.opeId = "FPCB";
            eH02.toolId = "UP001";
            eH02.actionFlg = "H";
            eH02.evtUsr = "EAP800";
            eH02.trxId = "BCTOMES";

            eH02.transactionId = GetTimeStamp();


            var returnMsg = httpHandler.DoPostDIF(eH02);

            MessageBox.Show(returnMsg);
        }
    }
}