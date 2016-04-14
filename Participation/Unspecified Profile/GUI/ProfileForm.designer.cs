namespace Participation.BeheerSysteem.GUI
{
    partial class ProfileForm
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
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnHelprequests = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.formPnl = new System.Windows.Forms.Panel();
            this.lblPreName = new System.Windows.Forms.Label();
            this.lblPreEmail = new System.Windows.Forms.Label();
            this.lblPreBirthdate = new System.Windows.Forms.Label();
            this.locationLbl = new System.Windows.Forms.Label();
            this.lblPrePhonenumber = new System.Windows.Forms.Label();
            this.lblPreGender = new System.Windows.Forms.Label();
            this.gbxPerks = new System.Windows.Forms.GroupBox();
            this.tbxPerk = new System.Windows.Forms.TextBox();
            this.btnAddPerk = new System.Windows.Forms.Button();
            this.lblListPerks = new System.Windows.Forms.Label();
            this.gbxVog = new System.Windows.Forms.GroupBox();
            this.lblAllowedVogFormats = new System.Windows.Forms.Label();
            this.btnBrowseVogUrl = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblVogUrl = new System.Windows.Forms.LinkLabel();
            this.gbForm.SuspendLayout();
            this.formPnl.SuspendLayout();
            this.gbxPerks.SuspendLayout();
            this.gbxVog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbForm
            // 
            this.gbForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbForm.Controls.Add(this.pictureBox1);
            this.gbForm.Controls.Add(this.formPnl);
            this.gbForm.Controls.Add(this.gbxPerks);
            this.gbForm.Controls.Add(this.gbxVog);
            this.gbForm.Location = new System.Drawing.Point(149, -10);
            this.gbForm.Margin = new System.Windows.Forms.Padding(4);
            this.gbForm.Name = "gbForm";
            this.gbForm.Padding = new System.Windows.Forms.Padding(4);
            this.gbForm.Size = new System.Drawing.Size(1199, 727);
            this.gbForm.TabIndex = 0;
            this.gbForm.TabStop = false;
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
            this.btnProfile.Click += new System.EventHandler(this.btn_Profiel_Click);
            // 
            // btnHelprequests
            // 
            this.btnHelprequests.Location = new System.Drawing.Point(13, 49);
            this.btnHelprequests.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelprequests.Name = "btnHelprequests";
            this.btnHelprequests.Size = new System.Drawing.Size(125, 28);
            this.btnHelprequests.TabIndex = 2;
            this.btnHelprequests.Text = "Hulp Vragen";
            this.btnHelprequests.UseVisualStyleBackColor = true;
            this.btnHelprequests.Click += new System.EventHandler(this.btn_Hulpvragen_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(13, 662);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(125, 28);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log Uit";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btn_LogUit_Click);
            // 
            // formPnl
            // 
            this.formPnl.Controls.Add(this.lblGender);
            this.formPnl.Controls.Add(this.lblPhonenumber);
            this.formPnl.Controls.Add(this.lblLocation);
            this.formPnl.Controls.Add(this.lblBirthdate);
            this.formPnl.Controls.Add(this.lblEmail);
            this.formPnl.Controls.Add(this.lblName);
            this.formPnl.Controls.Add(this.lblPreName);
            this.formPnl.Controls.Add(this.lblPreEmail);
            this.formPnl.Controls.Add(this.lblPreBirthdate);
            this.formPnl.Controls.Add(this.locationLbl);
            this.formPnl.Controls.Add(this.lblPrePhonenumber);
            this.formPnl.Controls.Add(this.lblPreGender);
            this.formPnl.Location = new System.Drawing.Point(43, 25);
            this.formPnl.Name = "formPnl";
            this.formPnl.Size = new System.Drawing.Size(577, 184);
            this.formPnl.TabIndex = 49;
            // 
            // lblPreName
            // 
            this.lblPreName.AutoSize = true;
            this.lblPreName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPreName.Location = new System.Drawing.Point(4, 3);
            this.lblPreName.Name = "lblPreName";
            this.lblPreName.Size = new System.Drawing.Size(63, 20);
            this.lblPreName.TabIndex = 41;
            this.lblPreName.Text = "Naam: ";
            // 
            // lblPreEmail
            // 
            this.lblPreEmail.AutoSize = true;
            this.lblPreEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreEmail.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPreEmail.Location = new System.Drawing.Point(4, 34);
            this.lblPreEmail.Name = "lblPreEmail";
            this.lblPreEmail.Size = new System.Drawing.Size(114, 20);
            this.lblPreEmail.TabIndex = 11;
            this.lblPreEmail.Text = "E-mail adres: ";
            // 
            // lblPreBirthdate
            // 
            this.lblPreBirthdate.AutoSize = true;
            this.lblPreBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreBirthdate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPreBirthdate.Location = new System.Drawing.Point(4, 66);
            this.lblPreBirthdate.Name = "lblPreBirthdate";
            this.lblPreBirthdate.Size = new System.Drawing.Size(134, 20);
            this.lblPreBirthdate.TabIndex = 13;
            this.lblPreBirthdate.Text = "Geboortedatum: ";
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.locationLbl.Location = new System.Drawing.Point(4, 95);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(107, 20);
            this.locationLbl.TabIndex = 14;
            this.locationLbl.Text = "Woonplaats: ";
            // 
            // lblPrePhonenumber
            // 
            this.lblPrePhonenumber.AutoSize = true;
            this.lblPrePhonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrePhonenumber.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPrePhonenumber.Location = new System.Drawing.Point(4, 128);
            this.lblPrePhonenumber.Name = "lblPrePhonenumber";
            this.lblPrePhonenumber.Size = new System.Drawing.Size(139, 20);
            this.lblPrePhonenumber.TabIndex = 15;
            this.lblPrePhonenumber.Text = "Telefoonnummer:";
            // 
            // lblPreGender
            // 
            this.lblPreGender.AutoSize = true;
            this.lblPreGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreGender.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPreGender.Location = new System.Drawing.Point(4, 157);
            this.lblPreGender.Name = "lblPreGender";
            this.lblPreGender.Size = new System.Drawing.Size(86, 20);
            this.lblPreGender.TabIndex = 16;
            this.lblPreGender.Text = "Geslacht: ";
            // 
            // gbxPerks
            // 
            this.gbxPerks.Controls.Add(this.tbxPerk);
            this.gbxPerks.Controls.Add(this.btnAddPerk);
            this.gbxPerks.Controls.Add(this.lblListPerks);
            this.gbxPerks.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxPerks.Location = new System.Drawing.Point(42, 321);
            this.gbxPerks.Name = "gbxPerks";
            this.gbxPerks.Size = new System.Drawing.Size(578, 379);
            this.gbxPerks.TabIndex = 47;
            this.gbxPerks.TabStop = false;
            this.gbxPerks.Text = "Extra vaardigheden: ";
            this.gbxPerks.Visible = false;
            // 
            // tbxPerk
            // 
            this.tbxPerk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPerk.Location = new System.Drawing.Point(19, 35);
            this.tbxPerk.Name = "tbxPerk";
            this.tbxPerk.Size = new System.Drawing.Size(432, 27);
            this.tbxPerk.TabIndex = 36;
            // 
            // btnAddPerk
            // 
            this.btnAddPerk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddPerk.Location = new System.Drawing.Point(458, 36);
            this.btnAddPerk.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPerk.Name = "btnAddPerk";
            this.btnAddPerk.Size = new System.Drawing.Size(99, 27);
            this.btnAddPerk.TabIndex = 36;
            this.btnAddPerk.Text = "Toevoegen";
            this.btnAddPerk.UseVisualStyleBackColor = true;
            // 
            // lblListPerks
            // 
            this.lblListPerks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListPerks.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblListPerks.Location = new System.Drawing.Point(19, 65);
            this.lblListPerks.Name = "lblListPerks";
            this.lblListPerks.Size = new System.Drawing.Size(521, 277);
            this.lblListPerks.TabIndex = 38;
            this.lblListPerks.Text = "Vaardigheden: ";
            // 
            // gbxVog
            // 
            this.gbxVog.Controls.Add(this.lblVogUrl);
            this.gbxVog.Controls.Add(this.lblAllowedVogFormats);
            this.gbxVog.Controls.Add(this.btnBrowseVogUrl);
            this.gbxVog.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxVog.Location = new System.Drawing.Point(42, 215);
            this.gbxVog.Name = "gbxVog";
            this.gbxVog.Size = new System.Drawing.Size(578, 100);
            this.gbxVog.TabIndex = 46;
            this.gbxVog.TabStop = false;
            this.gbxVog.Text = "Verklaring Omtrent het Gedrag (VOG:) *";
            this.gbxVog.Visible = false;
            // 
            // lblAllowedVogFormats
            // 
            this.lblAllowedVogFormats.AutoSize = true;
            this.lblAllowedVogFormats.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowedVogFormats.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblAllowedVogFormats.Location = new System.Drawing.Point(16, 64);
            this.lblAllowedVogFormats.Name = "lblAllowedVogFormats";
            this.lblAllowedVogFormats.Size = new System.Drawing.Size(331, 17);
            this.lblAllowedVogFormats.TabIndex = 35;
            this.lblAllowedVogFormats.Text = "Toegestaande formaten: .jpeg, png, bmp, pdf, docx";
            // 
            // btnBrowseVogUrl
            // 
            this.btnBrowseVogUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseVogUrl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBrowseVogUrl.Location = new System.Drawing.Point(458, 34);
            this.btnBrowseVogUrl.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseVogUrl.Name = "btnBrowseVogUrl";
            this.btnBrowseVogUrl.Size = new System.Drawing.Size(99, 27);
            this.btnBrowseVogUrl.TabIndex = 34;
            this.btnBrowseVogUrl.Text = "Bladeren...";
            this.btnBrowseVogUrl.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(797, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 184);
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblName.Location = new System.Drawing.Point(226, 3);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 20);
            this.lblName.TabIndex = 42;
            this.lblName.Text = "<naam>";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblEmail.Location = new System.Drawing.Point(226, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(116, 20);
            this.lblEmail.TabIndex = 43;
            this.lblEmail.Text = "<email adres>";
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblBirthdate.Location = new System.Drawing.Point(225, 66);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(140, 20);
            this.lblBirthdate.TabIndex = 44;
            this.lblBirthdate.Text = "<geboortedatum>";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblLocation.Location = new System.Drawing.Point(226, 95);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(113, 20);
            this.lblLocation.TabIndex = 45;
            this.lblLocation.Text = "<woonplaats>";
            // 
            // lblPhonenumber
            // 
            this.lblPhonenumber.AutoSize = true;
            this.lblPhonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonenumber.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPhonenumber.Location = new System.Drawing.Point(226, 128);
            this.lblPhonenumber.Name = "lblPhonenumber";
            this.lblPhonenumber.Size = new System.Drawing.Size(149, 20);
            this.lblPhonenumber.TabIndex = 46;
            this.lblPhonenumber.Text = "<telefoonnummer>";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblGender.Location = new System.Drawing.Point(226, 157);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(92, 20);
            this.lblGender.TabIndex = 47;
            this.lblGender.Text = "<geslacht>";
            // 
            // lblVogUrl
            // 
            this.lblVogUrl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblVogUrl.Location = new System.Drawing.Point(16, 34);
            this.lblVogUrl.Name = "lblVogUrl";
            this.lblVogUrl.Size = new System.Drawing.Size(435, 23);
            this.lblVogUrl.TabIndex = 36;
            this.lblVogUrl.TabStop = true;
            this.lblVogUrl.Text = "<download link van het huidige VOG>";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1152, 703);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnHelprequests);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.gbForm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProfileForm";
            this.Text = "Profiel";
            this.gbForm.ResumeLayout(false);
            this.formPnl.ResumeLayout(false);
            this.formPnl.PerformLayout();
            this.gbxPerks.ResumeLayout(false);
            this.gbxPerks.PerformLayout();
            this.gbxVog.ResumeLayout(false);
            this.gbxVog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnHelprequests;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Panel formPnl;
        private System.Windows.Forms.Label lblPreName;
        private System.Windows.Forms.Label lblPreEmail;
        private System.Windows.Forms.Label lblPreBirthdate;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.Label lblPrePhonenumber;
        private System.Windows.Forms.Label lblPreGender;
        private System.Windows.Forms.GroupBox gbxPerks;
        private System.Windows.Forms.TextBox tbxPerk;
        private System.Windows.Forms.Button btnAddPerk;
        private System.Windows.Forms.Label lblListPerks;
        private System.Windows.Forms.GroupBox gbxVog;
        private System.Windows.Forms.Label lblAllowedVogFormats;
        private System.Windows.Forms.Button btnBrowseVogUrl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.LinkLabel lblVogUrl;
    }
}