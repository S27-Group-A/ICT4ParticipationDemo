namespace Participation.VrijwilligersSysteem.GUI
{
    partial class MeetingForm
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
            this.btnPlannen = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbVolunteers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnPlannen
            // 
            this.btnPlannen.Location = new System.Drawing.Point(12, 38);
            this.btnPlannen.Name = "btnPlannen";
            this.btnPlannen.Size = new System.Drawing.Size(200, 52);
            this.btnPlannen.TabIndex = 0;
            this.btnPlannen.Text = "Plannen";
            this.btnPlannen.UseVisualStyleBackColor = true;
            this.btnPlannen.Click += new System.EventHandler(this.btnPlannen_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(12, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(12, 124);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(200, 20);
            this.tbLocation.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Locatie";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbVolunteers
            // 
            this.lbVolunteers.FormattingEnabled = true;
            this.lbVolunteers.Location = new System.Drawing.Point(219, 12);
            this.lbVolunteers.Name = "lbVolunteers";
            this.lbVolunteers.Size = new System.Drawing.Size(233, 134);
            this.lbVolunteers.TabIndex = 4;
            // 
            // MeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 150);
            this.Controls.Add(this.lbVolunteers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnPlannen);
            this.Name = "MeetingForm";
            this.Text = "MeetingForm";
            this.Load += new System.EventHandler(this.MeetingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlannen;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbVolunteers;
    }
}