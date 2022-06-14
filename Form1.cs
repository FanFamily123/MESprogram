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

namespace MESprogram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string sqlString = "Select * From RET_BOX a Where a.BOX_ID=:id";
      

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = OracleHelper.ExecuteDataTable(sqlString, new OracleParameter(":id", "FPLH006"));
         //   this.dataGridView1.DataSource= dt;
       //     MessageBox.Show(dt.Rows[0].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.DeleteBoxLH deleteBox=new Forms.DeleteBoxLH();
            deleteBox.StartPosition = FormStartPosition.CenterParent;
            deleteBox.Show();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Forms.DeleteThird deleteThird = new Forms.DeleteThird();
            deleteThird.StartPosition = FormStartPosition.CenterParent;

            deleteThird.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.RepaireData repaireData=new Forms.RepaireData();
            repaireData.StartPosition = FormStartPosition.CenterParent;

            repaireData.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Forms.EMPTBOX eMPTBOX=new Forms.EMPTBOX();
            eMPTBOX.StartPosition = FormStartPosition.CenterParent;

            eMPTBOX.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Forms.InterfaceRepaire interfaceRepaire=new Forms.InterfaceRepaire();
            interfaceRepaire.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Forms.PrdStatus prdStatus = new Forms.PrdStatus();
            prdStatus.StartPosition = FormStartPosition.CenterParent;
            prdStatus.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string sqlString1 = "update RET_TOOL_ST set TOOL_STAT = 'IDLE' where TOOL_STAT not in ('RUN','IDLE')";

            var a = OracleHelper.ExecuteNonQuery(sqlString1);
            MessageBox.Show("成功,影响行数"+a.ToString());
       

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Forms.BoatRepaire boatRepaire=new Forms.BoatRepaire();
            boatRepaire.StartPosition = FormStartPosition.CenterParent;
            boatRepaire.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Forms.EditArry edit=new Forms.EditArry();
            edit.ShowDialog();  
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Forms.PRT5 prt=new Forms.PRT5();
            prt.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Forms.MinterFace face=new Forms.MinterFace();   
            face.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Forms.InprWafer inpr=new Forms.InprWafer();
            inpr.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Forms.TempBoatRepaire temp=new Forms.TempBoatRepaire();
            temp.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Forms.BoxStat boxStat =new Forms.BoxStat();
            boxStat.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Forms.EW09Test eW09Test=new Forms.EW09Test();
            eW09Test.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Forms.LHRepaire HRepaire=new Forms.LHRepaire();
            HRepaire.Show();



        }

        private void button15_Click(object sender, EventArgs e)
        {
            Forms.SearchTempsForm se=new Forms.SearchTempsForm();
            se.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Forms.EquStats eq = new Forms.EquStats();
            eq.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Forms.TempMoveErrorForm te=new Forms.TempMoveErrorForm();
            te.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //Forms.WebServiceForm we=new Forms.WebServiceForm();
            //we.Show();
        }
    }
}
