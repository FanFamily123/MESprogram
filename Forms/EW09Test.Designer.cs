namespace MESprogram.Forms
{
    partial class EW09Test
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
            this.wafer1 = new System.Windows.Forms.TextBox();
            this.wafer2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wafer3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.num = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "硅片Id";
            // 
            // wafer1
            // 
            this.wafer1.Location = new System.Drawing.Point(143, 39);
            this.wafer1.Name = "wafer1";
            this.wafer1.Size = new System.Drawing.Size(100, 25);
            this.wafer1.TabIndex = 1;
            // 
            // wafer2
            // 
            this.wafer2.Location = new System.Drawing.Point(143, 97);
            this.wafer2.Name = "wafer2";
            this.wafer2.Size = new System.Drawing.Size(100, 25);
            this.wafer2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "硅片Id";
            // 
            // wafer3
            // 
            this.wafer3.Location = new System.Drawing.Point(143, 146);
            this.wafer3.Name = "wafer3";
            this.wafer3.Size = new System.Drawing.Size(100, 25);
            this.wafer3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "硅片Id";
            // 
            // bin
            // 
            this.bin.Location = new System.Drawing.Point(143, 192);
            this.bin.Name = "bin";
            this.bin.Size = new System.Drawing.Size(100, 25);
            this.bin.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "bin";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(143, 236);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(100, 25);
            this.num.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "num";
            // 
            // EW09Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.num);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.wafer3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wafer2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wafer1);
            this.Controls.Add(this.label1);
            this.Name = "EW09Test";
            this.Text = "EW09Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox wafer1;
        private System.Windows.Forms.TextBox wafer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wafer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox bin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Label label5;
    }
}