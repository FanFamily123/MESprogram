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
    public partial class EquStats : Form
    {
        public EquStats()
        {
            InitializeComponent();
        }

        private void EquStats_Load(object sender, EventArgs e)
        {

        }
        private HttpHandler httpHandler = new HttpHandler();

        private void button1_Click(object sender, EventArgs e)
        {
            var getMHL = this.txtBox.Text.Trim();
            var getOpe=this.txtOpe.Text.Trim();
            EWAdd ewAdd = new EWAdd();
            ewAdd.boxId = getMHL;
            ewAdd.opeId = getOpe;
           // ewAdd.waferCount = getMcounter;
            ewAdd.actionFlg = "e";
            ewAdd.evtUsr = "EAP800";
            ewAdd.trxId = "BCTOMES";
            ewAdd.transactionId = GetTimeStamp();

            var returnMsg = httpHandler.DoPostAdd(ewAdd);

            MessageBox.Show(returnMsg);
        }


        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
    }
}
