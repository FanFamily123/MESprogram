namespace MESprogram.Forms
{
    partial class MinterFace
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
            this.txtHL = new System.Windows.Forms.TextBox();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTool = new System.Windows.Forms.TextBox();
            this.设备号 = new System.Windows.Forms.Label();
            this.txtOpe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "花篮号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "通道号";
            // 
            // txtHL
            // 
            this.txtHL.Location = new System.Drawing.Point(153, 40);
            this.txtHL.Name = "txtHL";
            this.txtHL.Size = new System.Drawing.Size(100, 25);
            this.txtHL.TabIndex = 3;
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(153, 101);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(100, 25);
            this.txtChannel.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTool
            // 
            this.txtTool.Location = new System.Drawing.Point(153, 159);
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(100, 25);
            this.txtTool.TabIndex = 7;
            // 
            // 设备号
            // 
            this.设备号.AutoSize = true;
            this.设备号.Location = new System.Drawing.Point(60, 169);
            this.设备号.Name = "设备号";
            this.设备号.Size = new System.Drawing.Size(52, 15);
            this.设备号.TabIndex = 6;
            this.设备号.Text = "设备号";
            // 
            // txtOpe
            // 
            this.txtOpe.Location = new System.Drawing.Point(153, 209);
            this.txtOpe.Name = "txtOpe";
            this.txtOpe.Size = new System.Drawing.Size(100, 25);
            this.txtOpe.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "工序";
            // 
            // MinterFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 375);
            this.Controls.Add(this.txtOpe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTool);
            this.Controls.Add(this.设备号);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.txtHL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MinterFace";
            this.Text = "MinterFace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHL;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTool;
        private System.Windows.Forms.Label 设备号;
        private System.Windows.Forms.TextBox txtOpe;
        private System.Windows.Forms.Label label3;
    }
}