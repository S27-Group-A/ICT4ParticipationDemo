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
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(214, 558);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(4);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(100, 28);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "Bevestigen";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // titleTbx
            // 
            this.titleTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTbx.Location = new System.Drawing.Point(214, 18);
            this.titleTbx.Margin = new System.Windows.Forms.Padding(4);
            this.titleTbx.Name = "titleTbx";
            this.titleTbx.Size = new System.Drawing.Size(632, 27);
            this.titleTbx.TabIndex = 1;
            // 
            // descriptionTbx
            // 
            this.descriptionTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTbx.Location = new System.Drawing.Point(214, 60);
            this.descriptionTbx.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionTbx.Name = "descriptionTbx";
            this.descriptionTbx.Size = new System.Drawing.Size(632, 206);
            this.descriptionTbx.TabIndex = 2;
            this.descriptionTbx.Text = "";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.titleLbl.Location = new System.Drawing.Point(16, 18);
            this.titleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(46, 20);
            this.titleLbl.TabIndex = 3;
            this.titleLbl.Text = "Titel:";
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.descriptionLbl.Location = new System.Drawing.Point(16, 60);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Size = new System.Drawing.Size(111, 20);
            this.descriptionLbl.TabIndex = 4;
            this.descriptionLbl.Text = "Beschrijving: ";
            // 
            // perksLbl
            // 
            this.perksLbl.AutoSize = true;
            this.perksLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perksLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.perksLbl.Location = new System.Drawing.Point(16, 281);
            this.perksLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.perksLbl.Name = "perksLbl";
            this.perksLbl.Size = new System.Drawing.Size(53, 20);
            this.perksLbl.TabIndex = 5;
            this.perksLbl.Text = "Extra:";
            // 
            // dateDtp
            // 
            this.dateDtp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDtp.Location = new System.Drawing.Point(214, 394);
            this.dateDtp.Margin = new System.Windows.Forms.Padding(4);
            this.dateDtp.Name = "dateDtp";
            this.dateDtp.Size = new System.Drawing.Size(265, 27);
            this.dateDtp.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(15, 397);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gewenste datum en tijd: ";
            // 
            // urgencyLbl
            // 
            this.urgencyLbl.AutoSize = true;
            this.urgencyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urgencyLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.urgencyLbl.Location = new System.Drawing.Point(15, 467);
            this.urgencyLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.urgencyLbl.Name = "urgencyLbl";
            this.urgencyLbl.Size = new System.Drawing.Size(77, 20);
            this.urgencyLbl.TabIndex = 11;
            this.urgencyLbl.Text = "Urgentie:";
            // 
            // urgencyLbx
            // 
            this.urgencyLbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urgencyLbx.FormattingEnabled = true;
            this.urgencyLbx.ItemHeight = 20;
            this.urgencyLbx.Location = new System.Drawing.Point(214, 468);
            this.urgencyLbx.Margin = new System.Windows.Forms.Padding(4);
            this.urgencyLbx.Name = "urgencyLbx";
            this.urgencyLbx.Size = new System.Drawing.Size(265, 64);
            this.urgencyLbx.TabIndex = 12;
            // 
            // perksClb
            // 
            this.perksClb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perksClb.FormattingEnabled = true;
            this.perksClb.Location = new System.Drawing.Point(214, 284);
            this.perksClb.Margin = new System.Windows.Forms.Padding(4);
            this.perksClb.Name = "perksClb";
            this.perksClb.Size = new System.Drawing.Size(159, 92);
            this.perksClb.TabIndex = 13;
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.ForeColor = System.Drawing.SystemColors.Info;
            this.locationLbl.Location = new System.Drawing.Point(16, 432);
            this.locationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(102, 20);
            this.locationLbl.TabIndex = 14;
            this.locationLbl.Text = "Woonplaats:";
            // 
            // locationTbx
            // 
            this.locationTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTbx.Location = new System.Drawing.Point(214, 430);
            this.locationTbx.Margin = new System.Windows.Forms.Padding(4);
            this.locationTbx.Name = "locationTbx";
            this.locationTbx.Size = new System.Drawing.Size(265, 27);
            this.locationTbx.TabIndex = 15;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(334, 558);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 28);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Terug";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1116, 629);
            this.Controls.Add(this.btnBack);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RequestForm";
            this.Text = "Hulpvraag Maken";
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
        private System.Windows.Forms.Button btnBack;
    }
}