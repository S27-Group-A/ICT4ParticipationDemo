namespace Participation.HulpSysteem.GUI
{
    partial class ReviewForm
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
            this.gbForm = new System.Windows.Forms.GroupBox();
            this.cbxScore = new System.Windows.Forms.ComboBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.tbxText = new System.Windows.Forms.RichTextBox();
            this.tbxTitle = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbxVolunteers = new System.Windows.Forms.ListBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnWriteReview = new System.Windows.Forms.Button();
            this.gbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbForm
            // 
            this.gbForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbForm.Controls.Add(this.cbxScore);
            this.gbForm.Controls.Add(this.lblScore);
            this.gbForm.Controls.Add(this.lblText);
            this.gbForm.Controls.Add(this.lblTitel);
            this.gbForm.Controls.Add(this.tbxText);
            this.gbForm.Controls.Add(this.tbxTitle);
            this.gbForm.Controls.Add(this.btnSend);
            this.gbForm.Controls.Add(this.lbxVolunteers);
            this.gbForm.Location = new System.Drawing.Point(149, -10);
            this.gbForm.Margin = new System.Windows.Forms.Padding(4);
            this.gbForm.Name = "gbForm";
            this.gbForm.Padding = new System.Windows.Forms.Padding(4);
            this.gbForm.Size = new System.Drawing.Size(1199, 727);
            this.gbForm.TabIndex = 0;
            this.gbForm.TabStop = false;
            // 
            // cbxScore
            // 
            this.cbxScore.FormattingEnabled = true;
            this.cbxScore.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxScore.Location = new System.Drawing.Point(438, 605);
            this.cbxScore.Name = "cbxScore";
            this.cbxScore.Size = new System.Drawing.Size(462, 24);
            this.cbxScore.TabIndex = 7;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblScore.Location = new System.Drawing.Point(364, 605);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(58, 20);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score:";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblText.Location = new System.Drawing.Point(364, 79);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(68, 20);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Review:";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitel.Location = new System.Drawing.Point(364, 35);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(46, 20);
            this.lblTitel.TabIndex = 4;
            this.lblTitel.Text = "Titel:";
            // 
            // tbxText
            // 
            this.tbxText.Location = new System.Drawing.Point(438, 79);
            this.tbxText.Name = "tbxText";
            this.tbxText.Size = new System.Drawing.Size(462, 511);
            this.tbxText.TabIndex = 3;
            this.tbxText.Text = "";
            // 
            // tbxTitle
            // 
            this.tbxTitle.Location = new System.Drawing.Point(438, 35);
            this.tbxTitle.Name = "tbxTitle";
            this.tbxTitle.Size = new System.Drawing.Size(462, 22);
            this.tbxTitle.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(438, 650);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(462, 29);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Review versturen";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbxVolunteers
            // 
            this.lbxVolunteers.FormattingEnabled = true;
            this.lbxVolunteers.ItemHeight = 16;
            this.lbxVolunteers.Location = new System.Drawing.Point(26, 35);
            this.lbxVolunteers.Name = "lbxVolunteers";
            this.lbxVolunteers.Size = new System.Drawing.Size(309, 596);
            this.lbxVolunteers.TabIndex = 0;
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(13, 15);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(125, 28);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "Profiel";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnWriteReview
            // 
            this.btnWriteReview.Location = new System.Drawing.Point(13, 51);
            this.btnWriteReview.Margin = new System.Windows.Forms.Padding(4);
            this.btnWriteReview.Name = "btnWriteReview";
            this.btnWriteReview.Size = new System.Drawing.Size(125, 28);
            this.btnWriteReview.TabIndex = 3;
            this.btnWriteReview.Text = "Review Schrijven";
            this.btnWriteReview.UseVisualStyleBackColor = true;
            this.btnWriteReview.Click += new System.EventHandler(this.btnWriteReview_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1075, 703);
            this.Controls.Add(this.btnWriteReview);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.gbForm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReviewForm";
            this.Text = "Review Schrijven";
            this.gbForm.ResumeLayout(false);
            this.gbForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lbxVolunteers;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.RichTextBox tbxText;
        private System.Windows.Forms.TextBox tbxTitle;
        private System.Windows.Forms.Button btnWriteReview;
        private System.Windows.Forms.ComboBox cbxScore;
        private System.Windows.Forms.Label lblScore;
    }
}