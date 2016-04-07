namespace UI
{
    partial class RequestForm
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.titleTbx = new System.Windows.Forms.TextBox();
            this.descriptionTbx = new System.Windows.Forms.RichTextBox();
            this.titleLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.perksLbl = new System.Windows.Forms.Label();
            this.dateDtp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.urgencyLbl = new System.Windows.Forms.Label();
            this.urgencyLbx = new System.Windows.Forms.ListBox();
            this.perksClb = new System.Windows.Forms.CheckedListBox();
            this.locationLbl = new System.Windows.Forms.Label();
            this.locationTbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Location = new System.Drawing.Point(137, 406);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "Bevestigen";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // titleTbx
            // 
            this.titleTbx.Location = new System.Drawing.Point(137, 12);
            this.titleTbx.Name = "titleTbx";
            this.titleTbx.Size = new System.Drawing.Size(475, 20);
            this.titleTbx.TabIndex = 1;
            // 
            // descriptionTbx
            // 
            this.descriptionTbx.Location = new System.Drawing.Point(137, 46);
            this.descriptionTbx.Name = "descriptionTbx";
            this.descriptionTbx.Size = new System.Drawing.Size(475, 168);
            this.descriptionTbx.TabIndex = 2;
            this.descriptionTbx.Text = "";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.titleLbl.Location = new System.Drawing.Point(12, 15);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(30, 13);
            this.titleLbl.TabIndex = 3;
            this.titleLbl.Text = "Titel:";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.descriptionLbl.Location = new System.Drawing.Point(12, 49);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(70, 13);
            this.descriptionLbl.TabIndex = 4;
            this.descriptionLbl.Text = "Beschrijving: ";
            // 
            // perksLbl
            // 
            this.perksLbl.AutoSize = true;
            this.perksLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.perksLbl.Location = new System.Drawing.Point(12, 228);
            this.perksLbl.Name = "perksLbl";
            this.perksLbl.Size = new System.Drawing.Size(34, 13);
            this.perksLbl.TabIndex = 5;
            this.perksLbl.Text = "Extra:";
            // 
            // dateDtp
            // 
            this.dateDtp.Location = new System.Drawing.Point(137, 273);
            this.dateDtp.Name = "dateDtp";
            this.dateDtp.Size = new System.Drawing.Size(200, 20);
            this.dateDtp.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(11, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gewenste datum en tijd: ";
            // 
            // urgencyLbl
            // 
            this.urgencyLbl.AutoSize = true;
            this.urgencyLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.urgencyLbl.Location = new System.Drawing.Point(11, 335);
            this.urgencyLbl.Name = "urgencyLbl";
            this.urgencyLbl.Size = new System.Drawing.Size(50, 13);
            this.urgencyLbl.TabIndex = 11;
            this.urgencyLbl.Text = "Urgentie:";
            // 
            // urgencyLbx
            // 
            this.urgencyLbx.FormattingEnabled = true;
            this.urgencyLbx.Location = new System.Drawing.Point(137, 333);
            this.urgencyLbx.Name = "urgencyLbx";
            this.urgencyLbx.Size = new System.Drawing.Size(200, 56);
            this.urgencyLbx.TabIndex = 12;
            // 
            // perksClb
            // 
            this.perksClb.FormattingEnabled = true;
            this.perksClb.Location = new System.Drawing.Point(137, 228);
            this.perksClb.Name = "perksClb";
            this.perksClb.Size = new System.Drawing.Size(120, 34);
            this.perksClb.TabIndex = 13;
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.locationLbl.Location = new System.Drawing.Point(12, 306);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(67, 13);
            this.locationLbl.TabIndex = 14;
            this.locationLbl.Text = "Woonplaats:";
            // 
            // locationTbx
            // 
            this.locationTbx.Location = new System.Drawing.Point(137, 302);
            this.locationTbx.Name = "locationTbx";
            this.locationTbx.Size = new System.Drawing.Size(200, 20);
            this.locationTbx.TabIndex = 15;
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.locationTbx);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.perksClb);
            this.Controls.Add(this.urgencyLbx);
            this.Controls.Add(this.urgencyLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateDtp);
            this.Controls.Add(this.perksLbl);
            this.Controls.Add(this.descriptionLbl);
            this.Controls.Add(this.titleLbl);
            this.Controls.Add(this.descriptionTbx);
            this.Controls.Add(this.titleTbx);
            this.Controls.Add(this.confirmBtn);
            this.Name = "Request";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTbx;
        private System.Windows.Forms.RichTextBox descriptionTbx;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Label descriptionLbl;
        private System.Windows.Forms.Label perksLbl;
        private System.Windows.Forms.DateTimePicker dateDtp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label urgencyLbl;
        private System.Windows.Forms.ListBox urgencyLbx;
        private System.Windows.Forms.CheckedListBox perksClb;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.TextBox locationTbx;
    }
}