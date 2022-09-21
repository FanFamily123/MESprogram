using OpcUaHelper;
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
    public partial class RepaireData : Form
    {
        private OpcUaClient opcUaClient = new OpcUaClient();
        private String getUrl = ConfigurationManager.AppSettings["url"];
        private int index = 1;

        public RepaireData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //上料需要修改EH04和req的值

            //获取页面上的值,写入模拟器
            string txtLH = this.txt_EH04.Text.Trim();
            string req = "1";


            string getreq = ConfigurationManager.AppSettings["TEX_reqHandshake"];
            string geteh04box = ConfigurationManager.AppSettings["TEX_binboxId"];




            // 批量写入的代码
            string[] nodes = new string[]
            {
         geteh04box,
         getreq
            };

            try
            {
                object[] data = new object[]
              {
                 txtLH,
                 req
              };
                // 都成功返回True，否则返回False
                bool result = opcUaClient.WriteNodes(nodes, data);
                MessageBox.Show(result + "");
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private async void RepaireData_Load(object sender, EventArgs e)
        {
            await opcUaClient.ConnectServer(getUrl);
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
            try
            {
                string getreq = ConfigurationManager.AppSettings["TEX_reqHandshake"];
                bool IsSuccess = opcUaClient.WriteNode(getreq, "2");
                MessageBox.Show(IsSuccess.ToString()); // 显示True，如果成功的话
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //先修改硅片信息
            this.outHL();
            //修改index,花篮id等值
            string txtEW02HL = this.txtEW02HLID.Text.Trim();
            String txtEW02waferCount = this.txtEW02waferCount.Text.Trim(); //硅片数量

            #region 读取点位
            string TEX_EW0201channelNo = ConfigurationManager.AppSettings["TEX_EW0201channelNo"];
            string TEX_EW0201cassetteId = ConfigurationManager.AppSettings["TEX_EW0201cassetteId"];
            string TEX_EW0201actionType = ConfigurationManager.AppSettings["TEX_EW0201actionType"];
            string TEX_EW0201count = ConfigurationManager.AppSettings["TEX_EW0201waferCount"];

            #endregion

            // 批量写入的代码
            string[] nodes = new string[]
            {
       TEX_EW0201channelNo,
        TEX_EW0201cassetteId,
        TEX_EW0201actionType,
        TEX_EW0201count
            };

            try
            {
                index = index + 1;
                string strIndex = index + "";

                object[] data = new object[]
              {
                 "1",
                 txtEW02HL,
                 "1",
                 txtEW02waferCount

              };
                // 都成功返回True，否则返回False
                bool result = opcUaClient.WriteNodes(nodes, data);
                //   MessageBox.Show(result + "");
                Thread.Sleep(2000);
                string getreq = ConfigurationManager.AppSettings["TEX_EW0201index"];
                bool IsSuccess = opcUaClient.WriteNode(getreq, strIndex);
                //    MessageBox.Show(IsSuccess.ToString()); // 显示True，如果成功的话
                if (result && IsSuccess)
                {
                    MessageBox.Show("写入成功");
                }
                else
                {

                    MessageBox.Show("写入失败");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //获取页面上的值,写入模拟器
            string txtEW02 = this.txtEW07I.Text.Trim();
            string actionType = "1";

            string TEX_EW0701unitId = ConfigurationManager.AppSettings["TEX_EW0701unitId"];
            string TEX_EW0701cassetteId = ConfigurationManager.AppSettings["TEX_EW0701cassetteId"];
            string TEX_EW0701actionType = ConfigurationManager.AppSettings["TEX_EW0701actionType"];
            string TEX_EW0701index = ConfigurationManager.AppSettings["TEX_EW0701index"];


            // 批量写入的代码
            string[] nodes = new string[]
            {
       TEX_EW0701unitId,
       TEX_EW0701cassetteId,
       TEX_EW0701actionType,
      // TEX_EW0701index
            };
            try
            {
                index = index + 1;
                string strIndex = index + "";

                object[] data = new object[]
              {
                 "",
                 txtEW02,
                 actionType,
                // strIndex

              };
                // 都成功返回True，否则返回False
                bool result = opcUaClient.WriteNodes(nodes, data);
                MessageBox.Show(result + "");
                string getreq = ConfigurationManager.AppSettings["TEX_EW0701index"];
                bool IsSuccess = opcUaClient.WriteNode(getreq, strIndex);
                MessageBox.Show(IsSuccess.ToString()); // 显示True，如果成功的话




            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //出站需要修改EH07和index的值
            //入站需要修改EH02和req的值

            //获取页面上的值,写入模拟器
            string txtEW02 = this.txtEW07O.Text.Trim();
            string actionType = "2";

            string TEX_EW0701unitId = ConfigurationManager.AppSettings["TEX_EW0701unitId"];
            string TEX_EW0701cassetteId = ConfigurationManager.AppSettings["TEX_EW0701cassetteId"];
            string TEX_EW0701actionType = ConfigurationManager.AppSettings["TEX_EW0701actionType"];
            string TEX_EW0701index = ConfigurationManager.AppSettings["TEX_EW0701index"];


            // 批量写入的代码
            string[] nodes = new string[]
            {
       TEX_EW0701unitId,
       TEX_EW0701cassetteId,
       TEX_EW0701actionType,
       //TEX_EW0701index
            };
            try
            {
                index = index + 1;
                string strIndex = index + "";

                object[] data = new object[]
              {
                 "",
                 txtEW02,
                 actionType,
                // strIndex

              };
                // 都成功返回True，否则返回False
                bool result = opcUaClient.WriteNodes(nodes, data);
                MessageBox.Show(result + "");
                string getreq = ConfigurationManager.AppSettings["TEX_EW0701index"];
                bool IsSuccess = opcUaClient.WriteNode(getreq, strIndex);
                MessageBox.Show(IsSuccess.ToString()); // 显示True，如果成功的话



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //获取页面上的值,写入模拟器
            string txtLH = this.txt_EH04.Text.Trim();
            string req = "1";


            string getreq = ConfigurationManager.AppSettings["TEX_reqHandshake"];
            string geteh04box = ConfigurationManager.AppSettings["EH02"];

            var typePoint = opcUaClient.ReadNode(geteh04box);
            MessageBox.Show(typePoint + "");
            MessageBox.Show(typePoint.Value.GetType().ToString()); ;


          
        }
    }
}
