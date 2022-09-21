namespace MESprogram.Forms
{
    partial class TempMoveErrorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOpe = new System.Windows.Forms.TextBox();
            this.txtTool = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtMoveTool = new System.Windows.Forms.TextBox();
            this.txtMoveOpe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMoveChannel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtMoveWaferCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "工序";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "设备";
            // 
            // txtOpe
            // 
            this.txtOpe.Location = new System.Drawing.Point(87, 89);
            this.txtOpe.Name = "txtOpe";
            this.txtOpe.Size = new System.Drawing.Size(100, 25);
            this.txtOpe.TabIndex = 3;
            // 
            // txtTool
            // 
            this.txtTool.Location = new System.Drawing.Point(260, 89);
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(100, 25);
            this.txtTool.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 58);
            this.button1.TabIndex = 5;
            this.button1.Text = "查询temp数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(616, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 58);
            this.button2.TabIndex = 10;
            this.button2.Text = "移动temp数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtMoveTool
            // 
            this.txtMoveTool.Location = new System.Drawing.Point(260, 231);
            this.txtMoveTool.Name = "txtMoveTool";
            this.txtMoveTool.Size = new System.Drawing.Size(100, 25);
            this.txtMoveTool.TabIndex = 9;
            // 
            // txtMoveOpe
            // 
            this.txtMoveOpe.Location = new System.Drawing.Point(87, 231);
            this.txtMoveOpe.Name = "txtMoveOpe";
            this.txtMoveOpe.Size = new System.Drawing.Size(100, 25);
            this.txtMoveOpe.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "设备";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "工序";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(26, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "移动temp数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(26, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "查询temp数量";
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(440, 89);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(100, 25);
            this.txtChannel.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(382, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "通道号";
            // 
            // txtMoveChannel
            // 
            this.txtMoveChannel.Location = new System.Drawing.Point(440, 231);
            this.txtMoveChannel.Name = "txtMoveChannel";
            this.txtMoveChannel.Size = new System.Drawing.Size(100, 25);
            this.txtMoveChannel.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "通道号";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(576, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "查询box_error";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(604, 365);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 62);
            this.button3.TabIndex = 18;
            this.button3.Text = "查询boxerror总数";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtMoveWaferCount
            // 
            this.txtMoveWaferCount.Location = new System.Drawing.Point(86, 281);
            this.txtMoveWaferCount.Name = "txtMoveWaferCount";
            this.txtMoveWaferCount.Size = new System.Drawing.Size(100, 25);
            this.txtMoveWaferCount.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "数量";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(31, 352);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 62);
            this.button4.TabIndex = 21;
            this.button4.Text = "查询boxerror总数";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(24, 447);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "获取舟数据";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(188, 433);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 58);
            this.button5.TabIndex = 23;
            this.button5.Text = "获取舟数据";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // TempMoveErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 707);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtMoveWaferCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMoveChannel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMoveTool);
            this.Controls.Add(this.txtMoveOpe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTool);
            this.Controls.Add(this.txtOpe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TempMoveErrorForm";
            this.Text = "TempMoveErrorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOpe;
        private System.Windows.Forms.TextBox txtTool;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtMoveTool;
        private System.Windows.Forms.TextBox txtMoveOpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMoveChannel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtMoveWaferCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
    }
}