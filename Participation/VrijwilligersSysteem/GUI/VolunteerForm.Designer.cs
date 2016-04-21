namespace Participation.VrijwilligersSysteem.GUI
{
    partial class VolunteerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VolunteerForm));
            this.lbPatients = new System.Windows.Forms.ListBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRequestTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbResponses = new System.Windows.Forms.ListBox();
            this.tbResponse = new System.Windows.Forms.TextBox();
            this.btnPostResponse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMeeting = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPatients
            // 
            this.lbPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPatients.FormattingEnabled = true;
            this.lbPatients.ItemHeight = 20;
            this.lbPatients.Items.AddRange(new object[] {
            "Henk",
            "Jan",
            "Smit"});
            this.lbPatients.Location = new System.Drawing.Point(12, 44);
            this.lbPatients.Name = "lbPatients";
            this.lbPatients.Size = new System.Drawing.Size(196, 384);
            this.lbPatients.TabIndex = 0;
            this.lbPatients.SelectedIndexChanged += new System.EventHandler(this.lbPatients_SelectedIndexChanged_1);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(341, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(158, 29);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name Patient";
            // 
            // lblRequestTitle
            // 
            this.lblRequestTitle.AutoSize = true;
            this.lblRequestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestTitle.Location = new System.Drawing.Point(341, 112);
            this.lblRequestTitle.Name = "lblRequestTitle";
            this.lblRequestTitle.Size = new System.Drawing.Size(128, 24);
            this.lblRequestTitle.TabIndex = 3;
            this.lblRequestTitle.Text = "Hulpvraag titel";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(222, 149);
            this.lblDescription.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(598, 140);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            this.lblDescription.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.lblLocation);
            this.panel2.Controls.Add(this.lblUrgency);
            this.panel2.Location = new System.Drawing.Point(636, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(13, 54);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 22);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            this.lblDate.Click += new System.EventHandler(this.label6_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(13, 32);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(78, 22);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location";
            // 
            // lblUrgency
            // 
            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrgency.Location = new System.Drawing.Point(13, 10);
            this.lblUrgency.Name = "lblUrgency";
            this.lblUrgency.Size = new System.Drawing.Size(77, 22);
            this.lblUrgency.TabIndex = 0;
            this.lblUrgency.Text = "Urgency";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbResponses);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(226, 292);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 132);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reacties";
            // 
            // lbResponses
            // 
            this.lbResponses.FormattingEnabled = true;
            this.lbResponses.ItemHeight = 24;
            this.lbResponses.Location = new System.Drawing.Point(7, 29);
            this.lbResponses.Name = "lbResponses";
            this.lbResponses.Size = new System.Drawing.Size(321, 100);
            this.lbResponses.TabIndex = 0;
            // 
            // tbResponse
            // 
            this.tbResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResponse.Location = new System.Drawing.Point(566, 293);
            this.tbResponse.Multiline = true;
            this.tbResponse.Name = "tbResponse";
            this.tbResponse.Size = new System.Drawing.Size(270, 87);
            this.tbResponse.TabIndex = 7;
            // 
            // btnPostResponse
            // 
            this.btnPostResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostResponse.Location = new System.Drawing.Point(566, 386);
            this.btnPostResponse.Name = "btnPostResponse";
            this.btnPostResponse.Size = new System.Drawing.Size(270, 38);
            this.btnPostResponse.TabIndex = 8;
            this.btnPostResponse.Text = "Plaats Reactie";
            this.btnPostResponse.UseVisualStyleBackColor = true;
            this.btnPostResponse.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Participation.Properties.Resources.Oude_vrouw_met_hoed;
            this.pictureBox1.Location = new System.Drawing.Point(226, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnMeeting
            // 
            this.btnMeeting.Location = new System.Drawing.Point(725, 12);
            this.btnMeeting.Name = "btnMeeting";
            this.btnMeeting.Size = new System.Drawing.Size(111, 26);
            this.btnMeeting.TabIndex = 10;
            this.btnMeeting.Text = "Afspraak maken";
            this.btnMeeting.UseVisualStyleBackColor = true;
            this.btnMeeting.Click += new System.EventHandler(this.btnMeeting_Click);
            // 
            // VolunteerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 436);
            this.Controls.Add(this.btnMeeting);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPostResponse);
            this.Controls.Add(this.tbResponse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblRequestTitle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lbPatients);
            this.Name = "VolunteerForm";
            this.Text = "VolunteerForm";
            this.Load += new System.EventHandler(this.VolunteerForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPatients;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRequestTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbResponse;
        private System.Windows.Forms.Button btnPostResponse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbResponses;
        private System.Windows.Forms.Button btnMeeting;
    }
}