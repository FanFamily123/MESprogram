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
    public partial class DIFaForms : Form
    {
        public DIFaForms()
        {
            InitializeComponent();
        }

        private HttpHandler httpHandler = new HttpHandler();

        private void button1_Click(object sender, EventArgs e)
        {
            var getMHL = this.txtBoxId.Text.Trim();
            var getMope = this.txtOpeId.Text.Trim();
              var getMtool=this.txtToolId.Text.Trim();
     
            EWAdd ewAdd = new EWAdd();
            ewAdd.boxIdA = getMHL;
            ewAdd.opeId = getMope;
           ewAdd.toolId = getMtool;
            ewAdd.actionFlg = "a";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "BCTOMES";
            ewAdd.transactionId = GetTimeStamp();
            //   ewAdd.woId = getwoId;

            var returnMsg = httpHandler.DoPostAddnew(ewAdd);

            MessageBox.Show(returnMsg);
        }


        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var getMHL = this.txtMboatId.Text.Trim();
            var getMope = this.txtMOpeId.Text.Trim();
            var getMtool = this.txtMToolId.Text.Trim();

            EWAdd ewAdd = new EWAdd();
            ewAdd.boxId = getMHL;
            ewAdd.opeId = getMope;
            ewAdd.toolId = getMtool;
            ewAdd.actionFlg = "Z";
            ewAdd.actionType = "1";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "BCTOMES";
            ewAdd.transactionId = GetTimeStamp();
            ewAdd.IaryB = null;

            var returnMsg = httpHandler.DoPostAdd(ewAdd);

            MessageBox.Show(returnMsg);
        }
    }
}
