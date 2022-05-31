namespace MESprogram.Forms
{
    partial class LHRepaire
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
            this.txtBSGHLR = new System.Windows.Forms.TextBox();
            this.txtBSGChannel = new System.Windows.Forms.TextBox();
            this.补片次数 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lableRelease = new System.Windows.Forms.Label();
            this.lableCreate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "料盒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "通道";
            // 
            // txtBSGHLR
            // 
            this.txtBSGHLR.Location = new System.Drawing.Point(97, 20);
            this.txtBSGHLR.Name = "txtBSGHLR";
            this.txtBSGHLR.Size = new System.Drawing.Size(129, 25);
            this.txtBSGHLR.TabIndex = 2;
            // 
            // txtBSGChannel
            // 
            this.txtBSGChannel.Location = new System.Drawing.Point(97, 74);
            this.txtBSGChannel.Name = "txtBSGChannel";
            this.txtBSGChannel.Size = new System.Drawing.Size(129, 25);
            this.txtBSGChannel.TabIndex = 3;
            // 
            // 补片次数
            // 
            this.补片次数.AutoSize = true;
            this.补片次数.Location = new System.Drawing.Point(274, 55);
            this.补片次数.Name = "补片次数";
            this.补片次数.Size = new System.Drawing.Size(97, 15);
            this.补片次数.TabIndex = 5;
            this.补片次数.Text = "料盒补片次数";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(377, 45);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(129, 25);
            this.txtNum.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(423, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "上料按钮";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 262);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(527, 15);
            this.label14.TabIndex = 32;
            this.label14.Text = "_________________________________________________________________";
            // 
            // lableRelease
            // 
            this.lableRelease.AutoSize = true;
            this.lableRelease.Location = new System.Drawing.Point(296, 220);
            this.lableRelease.Name = "lableRelease";
            this.lableRelease.Size = new System.Drawing.Size(135, 15);
            this.lableRelease.TabIndex = 31;
            this.lableRelease.Text = "当前上料成功第0次";
            // 
            // lableCreate
            // 
            this.lableCreate.AutoSize = true;
            this.lableCreate.Location = new System.Drawing.Point(27, 220);
            this.lableCreate.Name = "lableCreate";
            this.lableCreate.Size = new System.Drawing.Size(135, 15);
            this.lableCreate.TabIndex = 30;
            this.lableCreate.Text = "当前创建第0个花篮";
            // 
            // LHRepaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lableRelease);
            this.Controls.Add(this.lableCreate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.补片次数);
            this.Controls.Add(this.txtBSGChannel);
            this.Controls.Add(this.txtBSGHLR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LHRepaire";
            this.Text = "LHRepaire";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBSGHLR;
        private System.Windows.Forms.TextBox txtBSGChannel;
        private System.Windows.Forms.Label 补片次数;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lableRelease;
        private System.Windows.Forms.Label lableCreate;
    }
}