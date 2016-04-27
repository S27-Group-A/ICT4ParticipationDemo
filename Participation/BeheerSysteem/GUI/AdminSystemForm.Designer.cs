namespace Participation.BeheerSysteem.GUI
{
    partial class AdminSystemForm
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
            this.gb_Form = new System.Windows.Forms.GroupBox();
            this.btnJudgeVolunteer = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.btnChangeRights = new System.Windows.Forms.Button();
            this.btnDeleteReviews = new System.Windows.Forms.Button();
            this.btnDeleteRequest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxReviews = new System.Windows.Forms.ListBox();
            this.lbxRequests = new System.Windows.Forms.ListBox();
            this.gbxBanUser = new System.Windows.Forms.GroupBox();
            this.btnBanUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDaysUntillUnbanned = new System.Windows.Forms.TextBox();
            this.rbtnTemporary = new System.Windows.Forms.RadioButton();
            this.rbtnPermanent = new System.Windows.Forms.RadioButton();
            this.gbxProfileInformation = new System.Windows.Forms.GroupBox();
            this.rtbProfileInformation = new System.Windows.Forms.RichTextBox();
            this.tbxProfileName = new System.Windows.Forms.TextBox();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxUserList = new System.Windows.Forms.ListBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.gb_Form.SuspendLayout();
            this.gbxBanUser.SuspendLayout();
            this.gbxProfileInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Form
            // 
            this.gb_Form.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gb_Form.Controls.Add(this.btnJudgeVolunteer);
            this.gb_Form.Controls.Add(this.btnDeleteAccount);
            this.gb_Form.Controls.Add(this.btnChangeRights);
            this.gb_Form.Controls.Add(this.btnDeleteReviews);
            this.gb_Form.Controls.Add(this.btnDeleteRequest);
            this.gb_Form.Controls.Add(this.label5);
            this.gb_Form.Controls.Add(this.label4);
            this.gb_Form.Controls.Add(this.lbxReviews);
            this.gb_Form.Controls.Add(this.lbxRequests);
            this.gb_Form.Controls.Add(this.gbxBanUser);
            this.gb_Form.Controls.Add(this.gbxProfileInformation);
            this.gb_Form.Controls.Add(this.label1);
            this.gb_Form.Controls.Add(this.lbxUserList);
            this.gb_Form.Location = new System.Drawing.Point(168, -10);
            this.gb_Form.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Form.Name = "gb_Form";
            this.gb_Form.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gb_Form.Size = new System.Drawing.Size(1180, 727);
            this.gb_Form.TabIndex = 0;
            this.gb_Form.TabStop = false;
            // 
            // btnJudgeVolunteer
            // 
            this.btnJudgeVolunteer.Location = new System.Drawing.Point(9, 43);
            this.btnJudgeVolunteer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnJudgeVolunteer.Name = "btnJudgeVolunteer";
            this.btnJudgeVolunteer.Size = new System.Drawing.Size(88, 74);
            this.btnJudgeVolunteer.TabIndex = 12;
            this.btnJudgeVolunteer.Text = "Keur Vrijwilliger";
            this.btnJudgeVolunteer.UseVisualStyleBackColor = true;
            this.btnJudgeVolunteer.Click += new System.EventHandler(this.btnJudgeVolunteer_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Location = new System.Drawing.Point(105, 43);
            this.btnDeleteAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(83, 74);
            this.btnDeleteAccount.TabIndex = 11;
            this.btnDeleteAccount.Text = "Verwijder Account";
            this.btnDeleteAccount.UseVisualStyleBackColor = true;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // btnChangeRights
            // 
            this.btnChangeRights.Location = new System.Drawing.Point(196, 43);
            this.btnChangeRights.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChangeRights.Name = "btnChangeRights";
            this.btnChangeRights.Size = new System.Drawing.Size(79, 74);
            this.btnChangeRights.TabIndex = 10;
            this.btnChangeRights.Text = "Pas Rechten Aan";
            this.btnChangeRights.UseVisualStyleBackColor = true;
            this.btnChangeRights.Click += new System.EventHandler(this.btnChangeRights_Click);
            // 
            // btnDeleteReviews
            // 
            this.btnDeleteReviews.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDeleteReviews.Location = new System.Drawing.Point(615, 657);
            this.btnDeleteReviews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteReviews.Name = "btnDeleteReviews";
            this.btnDeleteReviews.Size = new System.Drawing.Size(123, 42);
            this.btnDeleteReviews.TabIndex = 9;
            this.btnDeleteReviews.Text = "Verwijder Recensies";
            this.btnDeleteReviews.UseVisualStyleBackColor = true;
            this.btnDeleteReviews.Click += new System.EventHandler(this.btn_VerwijderRecensies_Click);
            // 
            // btnDeleteRequest
            // 
            this.btnDeleteRequest.ForeColor = System.Drawing.Color.DarkRed;
            this.btnDeleteRequest.Location = new System.Drawing.Point(375, 656);
            this.btnDeleteRequest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteRequest.Name = "btnDeleteRequest";
            this.btnDeleteRequest.Size = new System.Drawing.Size(123, 42);
            this.btnDeleteRequest.TabIndex = 8;
            this.btnDeleteRequest.Text = "Verwijder Hulpvraag";
            this.btnDeleteRequest.UseVisualStyleBackColor = true;
            this.btnDeleteRequest.Click += new System.EventHandler(this.btn_VerwijderHulpvraag_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(569, 302);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Lijst van Recensies:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(335, 302);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lijst van hullpvragen:";
            // 
            // lbxReviews
            // 
            this.lbxReviews.FormattingEnabled = true;
            this.lbxReviews.ItemHeight = 16;
            this.lbxReviews.Location = new System.Drawing.Point(569, 325);
            this.lbxReviews.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxReviews.Name = "lbxReviews";
            this.lbxReviews.Size = new System.Drawing.Size(197, 324);
            this.lbxReviews.TabIndex = 5;
            // 
            // lbxRequests
            // 
            this.lbxRequests.FormattingEnabled = true;
            this.lbxRequests.ItemHeight = 16;
            this.lbxRequests.Location = new System.Drawing.Point(335, 325);
            this.lbxRequests.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxRequests.Name = "lbxRequests";
            this.lbxRequests.Size = new System.Drawing.Size(203, 324);
            this.lbxRequests.TabIndex = 4;
            // 
            // gbxBanUser
            // 
            this.gbxBanUser.Controls.Add(this.btnBanUser);
            this.gbxBanUser.Controls.Add(this.label3);
            this.gbxBanUser.Controls.Add(this.label2);
            this.gbxBanUser.Controls.Add(this.tbxDaysUntillUnbanned);
            this.gbxBanUser.Controls.Add(this.rbtnTemporary);
            this.gbxBanUser.Controls.Add(this.rbtnPermanent);
            this.gbxBanUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxBanUser.Location = new System.Drawing.Point(747, 26);
            this.gbxBanUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxBanUser.Name = "gbxBanUser";
            this.gbxBanUser.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxBanUser.Size = new System.Drawing.Size(216, 198);
            this.gbxBanUser.TabIndex = 3;
            this.gbxBanUser.TabStop = false;
            this.gbxBanUser.Text = "Gebruiker Bannen";
            // 
            // btnBanUser
            // 
            this.btnBanUser.ForeColor = System.Drawing.Color.DarkRed;
            this.btnBanUser.Location = new System.Drawing.Point(12, 144);
            this.btnBanUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBanUser.Name = "btnBanUser";
            this.btnBanUser.Size = new System.Drawing.Size(131, 28);
            this.btnBanUser.TabIndex = 5;
            this.btnBanUser.Text = "Ban Gebruiker";
            this.btnBanUser.UseVisualStyleBackColor = true;
            this.btnBanUser.Click += new System.EventHandler(this.btn_BanGebruiker_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "dagen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tijd tot onban:";
            // 
            // tbxDaysUntillUnbanned
            // 
            this.tbxDaysUntillUnbanned.Location = new System.Drawing.Point(9, 111);
            this.tbxDaysUntillUnbanned.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDaysUntillUnbanned.Name = "tbxDaysUntillUnbanned";
            this.tbxDaysUntillUnbanned.Size = new System.Drawing.Size(132, 22);
            this.tbxDaysUntillUnbanned.TabIndex = 2;
            this.tbxDaysUntillUnbanned.TextChanged += new System.EventHandler(this.tbxDaysUntillUnbanned_TextChanged);
            // 
            // rbtnTemporary
            // 
            this.rbtnTemporary.AutoSize = true;
            this.rbtnTemporary.Location = new System.Drawing.Point(9, 52);
            this.rbtnTemporary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnTemporary.Name = "rbtnTemporary";
            this.rbtnTemporary.Size = new System.Drawing.Size(76, 21);
            this.rbtnTemporary.TabIndex = 1;
            this.rbtnTemporary.Text = "Tijdelijk";
            this.rbtnTemporary.UseVisualStyleBackColor = true;
            // 
            // rbtnPermanent
            // 
            this.rbtnPermanent.AutoSize = true;
            this.rbtnPermanent.Checked = true;
            this.rbtnPermanent.Location = new System.Drawing.Point(9, 22);
            this.rbtnPermanent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnPermanent.Name = "rbtnPermanent";
            this.rbtnPermanent.Size = new System.Drawing.Size(98, 21);
            this.rbtnPermanent.TabIndex = 0;
            this.rbtnPermanent.TabStop = true;
            this.rbtnPermanent.Text = "Permanent";
            this.rbtnPermanent.UseVisualStyleBackColor = true;
            // 
            // gbxProfileInformation
            // 
            this.gbxProfileInformation.Controls.Add(this.rtbProfileInformation);
            this.gbxProfileInformation.Controls.Add(this.tbxProfileName);
            this.gbxProfileInformation.Controls.Add(this.pbProfilePicture);
            this.gbxProfileInformation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxProfileInformation.Location = new System.Drawing.Point(335, 25);
            this.gbxProfileInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxProfileInformation.Name = "gbxProfileInformation";
            this.gbxProfileInformation.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbxProfileInformation.Size = new System.Drawing.Size(403, 246);
            this.gbxProfileInformation.TabIndex = 2;
            this.gbxProfileInformation.TabStop = false;
            this.gbxProfileInformation.Text = "Profiel Informatie";
            // 
            // rtbProfileInformation
            // 
            this.rtbProfileInformation.Location = new System.Drawing.Point(128, 57);
            this.rtbProfileInformation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbProfileInformation.Name = "rtbProfileInformation";
            this.rtbProfileInformation.Size = new System.Drawing.Size(251, 178);
            this.rtbProfileInformation.TabIndex = 2;
            this.rtbProfileInformation.Text = "";
            // 
            // tbxProfileName
            // 
            this.tbxProfileName.Location = new System.Drawing.Point(128, 25);
            this.tbxProfileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxProfileName.Name = "tbxProfileName";
            this.tbxProfileName.Size = new System.Drawing.Size(251, 22);
            this.tbxProfileName.TabIndex = 1;
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbProfilePicture.Location = new System.Drawing.Point(8, 23);
            this.pbProfilePicture.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(111, 100);
            this.pbProfilePicture.TabIndex = 0;
            this.pbProfilePicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(17, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lijst van Gebruikers:";
            // 
            // lbxUserList
            // 
            this.lbxUserList.FormattingEnabled = true;
            this.lbxUserList.ItemHeight = 16;
            this.lbxUserList.Location = new System.Drawing.Point(21, 165);
            this.lbxUserList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxUserList.Name = "lbxUserList";
            this.lbxUserList.Size = new System.Drawing.Size(248, 532);
            this.lbxUserList.TabIndex = 0;
            this.lbxUserList.SelectedIndexChanged += new System.EventHandler(this.lbx_userList_SelectedIndexChanged);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(35, 608);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 28);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log Uit";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btn_LogUit_Click);
            // 
            // AdminSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1152, 703);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.gb_Form);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminSystemForm";
            this.Text = "BeheerSysteemForm";
            this.gb_Form.ResumeLayout(false);
            this.gb_Form.PerformLayout();
            this.gbxBanUser.ResumeLayout(false);
            this.gbxBanUser.PerformLayout();
            this.gbxProfileInformation.ResumeLayout(false);
            this.gbxProfileInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Form;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxUserList;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnDeleteReviews;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxReviews;
        private System.Windows.Forms.ListBox lbxRequests;
        private System.Windows.Forms.GroupBox gbxBanUser;
        private System.Windows.Forms.Button btnBanUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDaysUntillUnbanned;
        private System.Windows.Forms.RadioButton rbtnTemporary;
        private System.Windows.Forms.RadioButton rbtnPermanent;
        private System.Windows.Forms.GroupBox gbxProfileInformation;
        private System.Windows.Forms.RichTextBox rtbProfileInformation;
        private System.Windows.Forms.TextBox tbxProfileName;
        private System.Windows.Forms.PictureBox pbProfilePicture;
        private System.Windows.Forms.Button btnJudgeVolunteer;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnChangeRights;
    }
}