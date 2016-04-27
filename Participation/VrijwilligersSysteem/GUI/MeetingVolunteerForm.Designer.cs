namespace Participation.VrijwilligersSysteem.GUI
{
    partial class MeetingVolunteerForm
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
            this.lbNotAccepted = new System.Windows.Forms.ListBox();
            this.lbAccepted = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lbNotAccepted
            // 
            this.lbNotAccepted.FormattingEnabled = true;
            this.lbNotAccepted.Location = new System.Drawing.Point(13, 27);
            this.lbNotAccepted.Name = "lbNotAccepted";
            this.lbNotAccepted.Size = new System.Drawing.Size(172, 108);
            this.lbNotAccepted.TabIndex = 0;
            // 
            // lbAccepted
            // 
            this.lbAccepted.FormattingEnabled = true;
            this.lbAccepted.Location = new System.Drawing.Point(13, 154);
            this.lbAccepted.Name = "lbAccepted";
            this.lbAccepted.Size = new System.Drawing.Size(172, 134);
            this.lbAccepted.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Niet geaccepteerde gesprekken";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Geaccepteerde gesprekken";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(200, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gesprek";
            // 
            // MeetingVolunteerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 295);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAccepted);
            this.Controls.Add(this.lbNotAccepted);
            this.Name = "MeetingVolunteerForm";
            this.Text = "MeetingVolunteerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbNotAccepted;
        private System.Windows.Forms.ListBox lbAccepted;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}