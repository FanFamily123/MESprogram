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

namespace MESprogram.Forms
{
    public partial class SearchTempsForm : Form
    {
        public SearchTempsForm()
        {
            InitializeComponent();
        }
        String[] starr = new string[] {"TE001","TE002","DL001","DL002","DL003","BSGL1","PE001","PE002" };

        private void SearchTempsForm_Load(object sender, EventArgs e)
        {

          //  InitDgvTextBoxColumn(this.dgv_Demo, DataGridViewContentAlignment.MiddleCenter, "UserID", "设备号", 20, true, true);
          //  InitDgvTextBoxColumn(this.dgv_Demo, DataGridViewContentAlignment.MiddleCenter, "UserName", "temp数据", 20, false, true);
          
            //创建行
       //     DataGridViewRow drRow1 = new DataGridViewRow();
       //     drRow1.CreateCells(this.dgv_Demo);
       //     //设置单元格的值
       //     drRow1.Cells[0].Value = "TE001";
       ////     drRow1.Cells[1].Value = "测试";
       
       //     //将新创建的行添加到DataGridView中
       //     this.dgv_Demo.Rows.Add(drRow1);

            //设置DataGridView的属性
       


        }


        private void InitDgvTextBoxColumn(DataGridView dgv, DataGridViewContentAlignment _alignmeng,
           string _columnName, string _headerText, int _maxInputLength, bool _readOnly, bool _visible)
        {
            //实例化一个DataGridViewTextBoxColumn列
            DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
            //设置对齐方式
            tbc.HeaderCell.Style.Alignment = _alignmeng;
            //设置列名
            tbc.Name = _columnName;
            //设置标题
            tbc.HeaderText = _headerText;
            //设置最大输入长度
            tbc.MaxInputLength = _maxInputLength;
            //设置是否只读
            tbc.ReadOnly = _readOnly;
            //设置是否可见
            tbc.Visible = _visible;
            //将创建的列添加到DataGridView中
            dgv.Columns.Add(tbc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // string sqlString = " SELECT * FROM RET_PRD_INFO  WHERE BOX_ID_FK = :id";

            string sql= "SELECT BOX_ID,PRD_QTY,BOX_STAT,NX_OPE_ID_FK,TOOL_ID_FK,EVT_CATE,EVT_TIMESTAMP from MES_HIS.HIS_RET_BOX where BOX_ID = :id ORDER BY EVT_TIMESTAMP desc";

            DataTable dt = OracleHelper.ExecuteDataTable(sql, new OracleParameter(":id", this.txtBox.Text.Trim()));
            this.dgv_Demo.DataSource = dt;

          //  MessageBox.Show(a.ToString());
        }
    }
}
