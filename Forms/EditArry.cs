using OpcUaHelper;
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
    public partial class EditArry : Form
    {
        public EditArry()
        {
            InitializeComponent();
        }


        private OpcUaClient opcUaClient = new OpcUaClient();
        private String getUrl = ConfigurationManager.AppSettings["newurl"];
        private int index = 1;
        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void outHL()
        {
            //新的硅片进花篮 将数量和硅片id填写到模拟器后改index
            String txtEW02HLID = this.txtEW02HLID.Text.Trim();
            String txtEW02waf = this.txtEW02waf.Text.Trim(); //硅片起始id
            String txtEW02waferCount = this.txtEW02waferCount.Text.Trim(); //硅片数量
            String WafId = txtEW02waf.Substring(0, txtEW02waf.Length - 2);
            String WafId100 = txtEW02waf.Substring(0, txtEW02waf.Length - 3);
            String WafId1001 = txtEW02waf.Remove(0, 14);
            String index100 = WafId1001.Substring(0, 1);
            int int100 = Convert.ToInt32(index100) + 1;
            String get100 = int100 + "" + "00";


            //读取模拟器起始点位
            string TEX_EW0201waferId = ConfigurationManager.AppSettings["TEX_EW0201waferId"];

            for (int i = 1; i < Convert.ToInt32(txtEW02waferCount) + 1; i++)
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

                else if (i == 100)
                {


                    var pointId = TEX_EW0201waferId + "{" + i + "}";
                    bool IsFlag = opcUaClient.WriteNode(pointId, WafId100 + get100);
                    if (!IsFlag)
                    {
                        MessageBox.Show("写入硅片id" + pointId + "失败");
                    }


                }

            }
            MessageBox.Show("写入数量成功");





        }

        private void button2_Click(object sender, EventArgs e)
        {

            string TEX_EW0201waferId = ConfigurationManager.AppSettings["DIF_arr"];

            var value = opcUaClient.ReadNode(TEX_EW0201waferId);



        }

        private async void EditArry_Load(object sender, EventArgs e)
        {
            await opcUaClient.ConnectServer(getUrl);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
