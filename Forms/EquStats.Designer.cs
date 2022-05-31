namespace MESprogram.Forms
{
    partial class EquStats
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
            this.txtBox = new System.Windows.Forms.TextBox();
            this.txtOpe = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "花篮号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "站点";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(120, 35);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(155, 25);
            this.txtBox.TabIndex = 2;
            // 
            // txtOpe
            // 
            this.txtOpe.Location = new System.Drawing.Point(120, 98);
            this.txtOpe.Name = "txtOpe";
            this.txtOpe.Size = new System.Drawing.Size(155, 25);
            this.txtOpe.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 66);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EquStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOpe);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EquStats";
            this.Text = "EquStats";
            this.Load += new System.EventHandler(this.EquStats_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.TextBox txtOpe;
        private System.Windows.Forms.Button button1;
    }
}