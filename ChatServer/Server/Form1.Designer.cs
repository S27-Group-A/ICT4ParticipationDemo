namespace Server
{
    partial class Form1
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lbxVolunteer = new System.Windows.Forms.ListBox();
            this.lbxElder = new System.Windows.Forms.ListBox();
            this.lblVolunteer = new System.Windows.Forms.Label();
            this.lblElder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(13, 15);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(100, 28);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(13, 51);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbxVolunteer
            // 
            this.lbxVolunteer.FormattingEnabled = true;
            this.lbxVolunteer.ItemHeight = 16;
            this.lbxVolunteer.Location = new System.Drawing.Point(123, 30);
            this.lbxVolunteer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxVolunteer.Name = "lbxVolunteer";
            this.lbxVolunteer.Size = new System.Drawing.Size(249, 244);
            this.lbxVolunteer.TabIndex = 3;
            // 
            // lbxElder
            // 
            this.lbxElder.FormattingEnabled = true;
            this.lbxElder.ItemHeight = 16;
            this.lbxElder.Location = new System.Drawing.Point(394, 30);
            this.lbxElder.Margin = new System.Windows.Forms.Padding(4);
            this.lbxElder.Name = "lbxElder";
            this.lbxElder.Size = new System.Drawing.Size(249, 244);
            this.lbxElder.TabIndex = 4;
            // 
            // lblVolunteer
            // 
            this.lblVolunteer.AutoSize = true;
            this.lblVolunteer.Location = new System.Drawing.Point(120, 9);
            this.lblVolunteer.Name = "lblVolunteer";
            this.lblVolunteer.Size = new System.Drawing.Size(80, 17);
            this.lblVolunteer.TabIndex = 5;
            this.lblVolunteer.Text = "Volunteers:";
            // 
            // lblElder
            // 
            this.lblElder.AutoSize = true;
            this.lblElder.Location = new System.Drawing.Point(391, 9);
            this.lblElder.Name = "lblElder";
            this.lblElder.Size = new System.Drawing.Size(52, 17);
            this.lblElder.TabIndex = 6;
            this.lblElder.Text = "Elders:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 314);
            this.Controls.Add(this.lblElder);
            this.Controls.Add(this.lblVolunteer);
            this.Controls.Add(this.lbxElder);
            this.Controls.Add(this.lbxVolunteer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStartStop);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox lbxVolunteer;
        private System.Windows.Forms.ListBox lbxElder;
        private System.Windows.Forms.Label lblVolunteer;
        private System.Windows.Forms.Label lblElder;
    }
}

