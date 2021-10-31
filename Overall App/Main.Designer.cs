
namespace Overall_App
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.IDBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.displayInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.reportBox = new System.Windows.Forms.TextBox();
            this.reportButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.reportNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(24, 36);
            this.IDBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(68, 20);
            this.IDBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter an ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // infoBox
            // 
            this.infoBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.infoBox.Location = new System.Drawing.Point(24, 65);
            this.infoBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(319, 159);
            this.infoBox.TabIndex = 2;
            // 
            // displayInfo
            // 
            this.displayInfo.Location = new System.Drawing.Point(115, 32);
            this.displayInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayInfo.Name = "displayInfo";
            this.displayInfo.Size = new System.Drawing.Size(63, 24);
            this.displayInfo.TabIndex = 3;
            this.displayInfo.Text = "Check";
            this.displayInfo.UseVisualStyleBackColor = true;
            this.displayInfo.Click += new System.EventHandler(this.displayInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.infoBox);
            this.groupBox1.Controls.Add(this.displayInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.IDBox);
            this.groupBox1.Location = new System.Drawing.Point(24, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(364, 250);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Display Info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ageBox);
            this.groupBox2.Controls.Add(this.reportBox);
            this.groupBox2.Controls.Add(this.reportButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.reportNo);
            this.groupBox2.Location = new System.Drawing.Point(24, 298);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(364, 173);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report 2-12";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enter age";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(24, 81);
            this.ageBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(68, 20);
            this.ageBox.TabIndex = 4;
            // 
            // reportBox
            // 
            this.reportBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reportBox.Location = new System.Drawing.Point(113, 32);
            this.reportBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportBox.Multiline = true;
            this.reportBox.Name = "reportBox";
            this.reportBox.ReadOnly = true;
            this.reportBox.Size = new System.Drawing.Size(230, 107);
            this.reportBox.TabIndex = 2;
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(27, 113);
            this.reportButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(63, 24);
            this.reportButton.TabIndex = 3;
            this.reportButton.Text = "Check";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Report Number";
            // 
            // reportNo
            // 
            this.reportNo.Location = new System.Drawing.Point(24, 36);
            this.reportNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportNo.Name = "reportNo";
            this.reportNo.Size = new System.Drawing.Size(68, 20);
            this.reportNo.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(421, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(407, 452);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "1-12";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Report Description";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(22, 53);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(356, 363);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 499);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main";
            this.Text = "Overall App";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox infoBox;
        private System.Windows.Forms.Button displayInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox reportBox;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox reportNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
    }
}

