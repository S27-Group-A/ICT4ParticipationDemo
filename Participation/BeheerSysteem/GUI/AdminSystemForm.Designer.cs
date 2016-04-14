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
            this.btn_DeleteReviews = new System.Windows.Forms.Button();
            this.btn_DeleteRequest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbx_Reviews = new System.Windows.Forms.ListBox();
            this.lbx_Requests = new System.Windows.Forms.ListBox();
            this.gb_BanUser = new System.Windows.Forms.GroupBox();
            this.btn_BanUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_daysUntillUnbanned = new System.Windows.Forms.TextBox();
            this.rbtn_Temporary = new System.Windows.Forms.RadioButton();
            this.rbtn_Permanent = new System.Windows.Forms.RadioButton();
            this.gb_ProfileInformation = new System.Windows.Forms.GroupBox();
            this.rtb_ProfileInformation = new System.Windows.Forms.RichTextBox();
            this.tbx_ProfileName = new System.Windows.Forms.TextBox();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbx_userList = new System.Windows.Forms.ListBox();
            this.btn_Profile = new System.Windows.Forms.Button();
            this.btn_Helprequests = new System.Windows.Forms.Button();
            this.btn_Elderly = new System.Windows.Forms.Button();
            this.btn_Chat = new System.Windows.Forms.Button();
            this.btn_Admin = new System.Windows.Forms.Button();
            this.btn_Volunteers = new System.Windows.Forms.Button();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.gb_Form.SuspendLayout();
            this.gb_BanUser.SuspendLayout();
            this.gb_ProfileInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Form
            // 
            this.gb_Form.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gb_Form.Controls.Add(this.btn_DeleteReviews);
            this.gb_Form.Controls.Add(this.btn_DeleteRequest);
            this.gb_Form.Controls.Add(this.label5);
            this.gb_Form.Controls.Add(this.label4);
            this.gb_Form.Controls.Add(this.lbx_Reviews);
            this.gb_Form.Controls.Add(this.lbx_Requests);
            this.gb_Form.Controls.Add(this.gb_BanUser);
            this.gb_Form.Controls.Add(this.gb_ProfileInformation);
            this.gb_Form.Controls.Add(this.label1);
            this.gb_Form.Controls.Add(this.lbx_userList);
            this.gb_Form.Location = new System.Drawing.Point(126, -8);
            this.gb_Form.Name = "gb_Form";
            this.gb_Form.Size = new System.Drawing.Size(885, 591);
            this.gb_Form.TabIndex = 0;
            this.gb_Form.TabStop = false;
            // 
            // btn_DeleteReviews
            // 
            this.btn_DeleteReviews.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_DeleteReviews.Location = new System.Drawing.Point(461, 534);
            this.btn_DeleteReviews.Name = "btn_DeleteReviews";
            this.btn_DeleteReviews.Size = new System.Drawing.Size(92, 34);
            this.btn_DeleteReviews.TabIndex = 9;
            this.btn_DeleteReviews.Text = "Verwijder Recensies";
            this.btn_DeleteReviews.UseVisualStyleBackColor = true;
            this.btn_DeleteReviews.Click += new System.EventHandler(this.btn_VerwijderRecensies_Click);
            // 
            // btn_DeleteRequest
            // 
            this.btn_DeleteRequest.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_DeleteRequest.Location = new System.Drawing.Point(281, 533);
            this.btn_DeleteRequest.Name = "btn_DeleteRequest";
            this.btn_DeleteRequest.Size = new System.Drawing.Size(92, 34);
            this.btn_DeleteRequest.TabIndex = 8;
            this.btn_DeleteRequest.Text = "Verwijder Hulpvraag";
            this.btn_DeleteRequest.UseVisualStyleBackColor = true;
            this.btn_DeleteRequest.Click += new System.EventHandler(this.btn_VerwijderHulpvraag_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(427, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Lijst van Recensies:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(251, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lijst van hullpvragen:";
            // 
            // lbx_Reviews
            // 
            this.lbx_Reviews.FormattingEnabled = true;
            this.lbx_Reviews.Location = new System.Drawing.Point(427, 264);
            this.lbx_Reviews.Name = "lbx_Reviews";
            this.lbx_Reviews.Size = new System.Drawing.Size(149, 264);
            this.lbx_Reviews.TabIndex = 5;
            // 
            // lbx_Requests
            // 
            this.lbx_Requests.FormattingEnabled = true;
            this.lbx_Requests.Location = new System.Drawing.Point(251, 264);
            this.lbx_Requests.Name = "lbx_Requests";
            this.lbx_Requests.Size = new System.Drawing.Size(153, 264);
            this.lbx_Requests.TabIndex = 4;
            // 
            // gb_BanUser
            // 
            this.gb_BanUser.Controls.Add(this.btn_BanUser);
            this.gb_BanUser.Controls.Add(this.label3);
            this.gb_BanUser.Controls.Add(this.label2);
            this.gb_BanUser.Controls.Add(this.tb_daysUntillUnbanned);
            this.gb_BanUser.Controls.Add(this.rbtn_Temporary);
            this.gb_BanUser.Controls.Add(this.rbtn_Permanent);
            this.gb_BanUser.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gb_BanUser.Location = new System.Drawing.Point(560, 21);
            this.gb_BanUser.Name = "gb_BanUser";
            this.gb_BanUser.Size = new System.Drawing.Size(162, 161);
            this.gb_BanUser.TabIndex = 3;
            this.gb_BanUser.TabStop = false;
            this.gb_BanUser.Text = "Gebruiker Bannen";
            // 
            // btn_BanUser
            // 
            this.btn_BanUser.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_BanUser.Location = new System.Drawing.Point(9, 117);
            this.btn_BanUser.Name = "btn_BanUser";
            this.btn_BanUser.Size = new System.Drawing.Size(98, 23);
            this.btn_BanUser.TabIndex = 5;
            this.btn_BanUser.Text = "Ban Gebruiker";
            this.btn_BanUser.UseVisualStyleBackColor = true;
            this.btn_BanUser.Click += new System.EventHandler(this.btn_BanGebruiker_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "dagen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tijd tot onban:";
            // 
            // tb_daysUntillUnbanned
            // 
            this.tb_daysUntillUnbanned.Location = new System.Drawing.Point(7, 90);
            this.tb_daysUntillUnbanned.Name = "tb_daysUntillUnbanned";
            this.tb_daysUntillUnbanned.Size = new System.Drawing.Size(100, 20);
            this.tb_daysUntillUnbanned.TabIndex = 2;
            // 
            // rbtn_Temporary
            // 
            this.rbtn_Temporary.AutoSize = true;
            this.rbtn_Temporary.Location = new System.Drawing.Point(7, 42);
            this.rbtn_Temporary.Name = "rbtn_Temporary";
            this.rbtn_Temporary.Size = new System.Drawing.Size(60, 17);
            this.rbtn_Temporary.TabIndex = 1;
            this.rbtn_Temporary.TabStop = true;
            this.rbtn_Temporary.Text = "Tijdelijk";
            this.rbtn_Temporary.UseVisualStyleBackColor = true;
            // 
            // rbtn_Permanent
            // 
            this.rbtn_Permanent.AutoSize = true;
            this.rbtn_Permanent.Location = new System.Drawing.Point(7, 18);
            this.rbtn_Permanent.Name = "rbtn_Permanent";
            this.rbtn_Permanent.Size = new System.Drawing.Size(76, 17);
            this.rbtn_Permanent.TabIndex = 0;
            this.rbtn_Permanent.TabStop = true;
            this.rbtn_Permanent.Text = "Permanent";
            this.rbtn_Permanent.UseVisualStyleBackColor = true;
            // 
            // gb_ProfileInformation
            // 
            this.gb_ProfileInformation.Controls.Add(this.rtb_ProfileInformation);
            this.gb_ProfileInformation.Controls.Add(this.tbx_ProfileName);
            this.gb_ProfileInformation.Controls.Add(this.pbProfilePicture);
            this.gb_ProfileInformation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gb_ProfileInformation.Location = new System.Drawing.Point(251, 20);
            this.gb_ProfileInformation.Name = "gb_ProfileInformation";
            this.gb_ProfileInformation.Size = new System.Drawing.Size(302, 200);
            this.gb_ProfileInformation.TabIndex = 2;
            this.gb_ProfileInformation.TabStop = false;
            this.gb_ProfileInformation.Text = "Profiel Informatie";
            // 
            // rtb_ProfileInformation
            // 
            this.rtb_ProfileInformation.Location = new System.Drawing.Point(96, 46);
            this.rtb_ProfileInformation.Name = "rtb_ProfileInformation";
            this.rtb_ProfileInformation.Size = new System.Drawing.Size(189, 145);
            this.rtb_ProfileInformation.TabIndex = 2;
            this.rtb_ProfileInformation.Text = "";
            // 
            // tbx_ProfileName
            // 
            this.tbx_ProfileName.Location = new System.Drawing.Point(96, 20);
            this.tbx_ProfileName.Name = "tbx_ProfileName";
            this.tbx_ProfileName.Size = new System.Drawing.Size(189, 20);
            this.tbx_ProfileName.TabIndex = 1;
            // 
            // pbProfilePicture
            // 
            this.pbProfilePicture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbProfilePicture.Location = new System.Drawing.Point(6, 19);
            this.pbProfilePicture.Name = "pbProfilePicture";
            this.pbProfilePicture.Size = new System.Drawing.Size(83, 81);
            this.pbProfilePicture.TabIndex = 0;
            this.pbProfilePicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lijst van Gebruikers:";
            // 
            // lbx_userList
            // 
            this.lbx_userList.FormattingEnabled = true;
            this.lbx_userList.Location = new System.Drawing.Point(16, 134);
            this.lbx_userList.Name = "lbx_userList";
            this.lbx_userList.Size = new System.Drawing.Size(187, 433);
            this.lbx_userList.TabIndex = 0;
            this.lbx_userList.SelectedIndexChanged += new System.EventHandler(this.lbx_userList_SelectedIndexChanged);
            // 
            // btn_Profile
            // 
            this.btn_Profile.Location = new System.Drawing.Point(26, 35);
            this.btn_Profile.Name = "btn_Profile";
            this.btn_Profile.Size = new System.Drawing.Size(75, 23);
            this.btn_Profile.TabIndex = 1;
            this.btn_Profile.Text = "Profiel";
            this.btn_Profile.UseVisualStyleBackColor = true;
            this.btn_Profile.Click += new System.EventHandler(this.btn_Profiel_Click);
            // 
            // btn_Helprequests
            // 
            this.btn_Helprequests.Location = new System.Drawing.Point(26, 64);
            this.btn_Helprequests.Name = "btn_Helprequests";
            this.btn_Helprequests.Size = new System.Drawing.Size(75, 23);
            this.btn_Helprequests.TabIndex = 2;
            this.btn_Helprequests.Text = "Hulpvragen";
            this.btn_Helprequests.UseVisualStyleBackColor = true;
            this.btn_Helprequests.Click += new System.EventHandler(this.btn_Hulpvragen_Click);
            // 
            // btn_Elderly
            // 
            this.btn_Elderly.Location = new System.Drawing.Point(26, 93);
            this.btn_Elderly.Name = "btn_Elderly";
            this.btn_Elderly.Size = new System.Drawing.Size(75, 23);
            this.btn_Elderly.TabIndex = 3;
            this.btn_Elderly.Text = "Ouderen";
            this.btn_Elderly.UseVisualStyleBackColor = true;
            this.btn_Elderly.Click += new System.EventHandler(this.btn_Ouderen_Click);
            // 
            // btn_Chat
            // 
            this.btn_Chat.Location = new System.Drawing.Point(26, 151);
            this.btn_Chat.Name = "btn_Chat";
            this.btn_Chat.Size = new System.Drawing.Size(75, 23);
            this.btn_Chat.TabIndex = 4;
            this.btn_Chat.Text = "Chat";
            this.btn_Chat.UseVisualStyleBackColor = true;
            this.btn_Chat.Click += new System.EventHandler(this.btn_Chat_Click);
            // 
            // btn_Admin
            // 
            this.btn_Admin.Location = new System.Drawing.Point(26, 180);
            this.btn_Admin.Name = "btn_Admin";
            this.btn_Admin.Size = new System.Drawing.Size(75, 23);
            this.btn_Admin.TabIndex = 5;
            this.btn_Admin.Text = "Beheer";
            this.btn_Admin.UseVisualStyleBackColor = true;
            this.btn_Admin.Click += new System.EventHandler(this.btn_Beheer_Click);
            // 
            // btn_Volunteers
            // 
            this.btn_Volunteers.Location = new System.Drawing.Point(26, 122);
            this.btn_Volunteers.Name = "btn_Volunteers";
            this.btn_Volunteers.Size = new System.Drawing.Size(75, 23);
            this.btn_Volunteers.TabIndex = 6;
            this.btn_Volunteers.Text = "Vrijwiligers";
            this.btn_Volunteers.UseVisualStyleBackColor = true;
            this.btn_Volunteers.Click += new System.EventHandler(this.btn_Vrijwilligers_Click);
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.Location = new System.Drawing.Point(26, 494);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(75, 23);
            this.btn_LogOut.TabIndex = 7;
            this.btn_LogOut.Text = "Log Uit";
            this.btn_LogOut.UseVisualStyleBackColor = true;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogUit_Click);
            // 
            // AdminSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(864, 571);
            this.Controls.Add(this.btn_LogOut);
            this.Controls.Add(this.btn_Volunteers);
            this.Controls.Add(this.btn_Admin);
            this.Controls.Add(this.btn_Chat);
            this.Controls.Add(this.btn_Elderly);
            this.Controls.Add(this.btn_Helprequests);
            this.Controls.Add(this.btn_Profile);
            this.Controls.Add(this.gb_Form);
            this.Name = "AdminSystemForm";
            this.Text = "BeheerSysteemForm";
            this.gb_Form.ResumeLayout(false);
            this.gb_Form.PerformLayout();
            this.gb_BanUser.ResumeLayout(false);
            this.gb_BanUser.PerformLayout();
            this.gb_ProfileInformation.ResumeLayout(false);
            this.gb_ProfileInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Form;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbx_userList;
        private System.Windows.Forms.Button btn_Profile;
        private System.Windows.Forms.Button btn_Helprequests;
        private System.Windows.Forms.Button btn_Elderly;
        private System.Windows.Forms.Button btn_Chat;
        private System.Windows.Forms.Button btn_Admin;
        private System.Windows.Forms.Button btn_Volunteers;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Button btn_DeleteReviews;
        private System.Windows.Forms.Button btn_DeleteRequest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbx_Reviews;
        private System.Windows.Forms.ListBox lbx_Requests;
        private System.Windows.Forms.GroupBox gb_BanUser;
        private System.Windows.Forms.Button btn_BanUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_daysUntillUnbanned;
        private System.Windows.Forms.RadioButton rbtn_Temporary;
        private System.Windows.Forms.RadioButton rbtn_Permanent;
        private System.Windows.Forms.GroupBox gb_ProfileInformation;
        private System.Windows.Forms.RichTextBox rtb_ProfileInformation;
        private System.Windows.Forms.TextBox tbx_ProfileName;
        private System.Windows.Forms.PictureBox pbProfilePicture;
    }
}