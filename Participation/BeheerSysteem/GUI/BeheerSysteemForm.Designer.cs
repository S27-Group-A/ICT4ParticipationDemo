namespace Participation.BeheerSysteem.GUI
{
    partial class BeheerSysteemForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_VerwijderRecensies = new System.Windows.Forms.Button();
            this.btn_VerwijderHulpvraag = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbx_Reviews = new System.Windows.Forms.ListBox();
            this.lbx_requests = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_BanGebruiker = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_daysUntillUnbanned = new System.Windows.Forms.TextBox();
            this.rbtn_Temporary = new System.Windows.Forms.RadioButton();
            this.rbtn_Permanent = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_ProfileInformation = new System.Windows.Forms.RichTextBox();
            this.tbx_ProfileName = new System.Windows.Forms.TextBox();
            this.pbProfilePicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbx_userList = new System.Windows.Forms.ListBox();
            this.btn_Profiel = new System.Windows.Forms.Button();
            this.btn_Hulpvragen = new System.Windows.Forms.Button();
            this.btn_Ouderen = new System.Windows.Forms.Button();
            this.btn_Chat = new System.Windows.Forms.Button();
            this.btn_Beheer = new System.Windows.Forms.Button();
            this.btn_Vrijwilligers = new System.Windows.Forms.Button();
            this.btn_LogUit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Controls.Add(this.btn_VerwijderRecensies);
            this.groupBox1.Controls.Add(this.btn_VerwijderHulpvraag);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbx_Reviews);
            this.groupBox1.Controls.Add(this.lbx_requests);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbx_userList);
            this.groupBox1.Location = new System.Drawing.Point(126, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 591);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_VerwijderRecensies
            // 
            this.btn_VerwijderRecensies.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_VerwijderRecensies.Location = new System.Drawing.Point(461, 534);
            this.btn_VerwijderRecensies.Name = "btn_VerwijderRecensies";
            this.btn_VerwijderRecensies.Size = new System.Drawing.Size(92, 34);
            this.btn_VerwijderRecensies.TabIndex = 9;
            this.btn_VerwijderRecensies.Text = "Verwijder Recensies";
            this.btn_VerwijderRecensies.UseVisualStyleBackColor = true;
            this.btn_VerwijderRecensies.Click += new System.EventHandler(this.btn_VerwijderRecensies_Click);
            // 
            // btn_VerwijderHulpvraag
            // 
            this.btn_VerwijderHulpvraag.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_VerwijderHulpvraag.Location = new System.Drawing.Point(281, 533);
            this.btn_VerwijderHulpvraag.Name = "btn_VerwijderHulpvraag";
            this.btn_VerwijderHulpvraag.Size = new System.Drawing.Size(92, 34);
            this.btn_VerwijderHulpvraag.TabIndex = 8;
            this.btn_VerwijderHulpvraag.Text = "Verwijder Hulpvraag";
            this.btn_VerwijderHulpvraag.UseVisualStyleBackColor = true;
            this.btn_VerwijderHulpvraag.Click += new System.EventHandler(this.btn_VerwijderHulpvraag_Click);
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
            // lbx_requests
            // 
            this.lbx_requests.FormattingEnabled = true;
            this.lbx_requests.Location = new System.Drawing.Point(251, 264);
            this.lbx_requests.Name = "lbx_requests";
            this.lbx_requests.Size = new System.Drawing.Size(153, 264);
            this.lbx_requests.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_BanGebruiker);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tb_daysUntillUnbanned);
            this.groupBox3.Controls.Add(this.rbtn_Temporary);
            this.groupBox3.Controls.Add(this.rbtn_Permanent);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(560, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 161);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gebruiker Bannen";
            // 
            // btn_BanGebruiker
            // 
            this.btn_BanGebruiker.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_BanGebruiker.Location = new System.Drawing.Point(9, 117);
            this.btn_BanGebruiker.Name = "btn_BanGebruiker";
            this.btn_BanGebruiker.Size = new System.Drawing.Size(98, 23);
            this.btn_BanGebruiker.TabIndex = 5;
            this.btn_BanGebruiker.Text = "Ban Gebruiker";
            this.btn_BanGebruiker.UseVisualStyleBackColor = true;
            this.btn_BanGebruiker.Click += new System.EventHandler(this.btn_BanGebruiker_Click);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_ProfileInformation);
            this.groupBox2.Controls.Add(this.tbx_ProfileName);
            this.groupBox2.Controls.Add(this.pbProfilePicture);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(251, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 200);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profiel Informatie";
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
            // btn_Profiel
            // 
            this.btn_Profiel.Location = new System.Drawing.Point(26, 35);
            this.btn_Profiel.Name = "btn_Profiel";
            this.btn_Profiel.Size = new System.Drawing.Size(75, 23);
            this.btn_Profiel.TabIndex = 1;
            this.btn_Profiel.Text = "Profiel";
            this.btn_Profiel.UseVisualStyleBackColor = true;
            this.btn_Profiel.Click += new System.EventHandler(this.btn_Profiel_Click);
            // 
            // btn_Hulpvragen
            // 
            this.btn_Hulpvragen.Location = new System.Drawing.Point(26, 64);
            this.btn_Hulpvragen.Name = "btn_Hulpvragen";
            this.btn_Hulpvragen.Size = new System.Drawing.Size(75, 23);
            this.btn_Hulpvragen.TabIndex = 2;
            this.btn_Hulpvragen.Text = "Hulpvragen";
            this.btn_Hulpvragen.UseVisualStyleBackColor = true;
            this.btn_Hulpvragen.Click += new System.EventHandler(this.btn_Hulpvragen_Click);
            // 
            // btn_Ouderen
            // 
            this.btn_Ouderen.Location = new System.Drawing.Point(26, 93);
            this.btn_Ouderen.Name = "btn_Ouderen";
            this.btn_Ouderen.Size = new System.Drawing.Size(75, 23);
            this.btn_Ouderen.TabIndex = 3;
            this.btn_Ouderen.Text = "Ouderen";
            this.btn_Ouderen.UseVisualStyleBackColor = true;
            this.btn_Ouderen.Click += new System.EventHandler(this.btn_Ouderen_Click);
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
            // btn_Beheer
            // 
            this.btn_Beheer.Location = new System.Drawing.Point(26, 180);
            this.btn_Beheer.Name = "btn_Beheer";
            this.btn_Beheer.Size = new System.Drawing.Size(75, 23);
            this.btn_Beheer.TabIndex = 5;
            this.btn_Beheer.Text = "Beheer";
            this.btn_Beheer.UseVisualStyleBackColor = true;
            this.btn_Beheer.Click += new System.EventHandler(this.btn_Beheer_Click);
            // 
            // btn_Vrijwilligers
            // 
            this.btn_Vrijwilligers.Location = new System.Drawing.Point(26, 122);
            this.btn_Vrijwilligers.Name = "btn_Vrijwilligers";
            this.btn_Vrijwilligers.Size = new System.Drawing.Size(75, 23);
            this.btn_Vrijwilligers.TabIndex = 6;
            this.btn_Vrijwilligers.Text = "Vrijwiligers";
            this.btn_Vrijwilligers.UseVisualStyleBackColor = true;
            this.btn_Vrijwilligers.Click += new System.EventHandler(this.btn_Vrijwilligers_Click);
            // 
            // btn_LogUit
            // 
            this.btn_LogUit.Location = new System.Drawing.Point(26, 494);
            this.btn_LogUit.Name = "btn_LogUit";
            this.btn_LogUit.Size = new System.Drawing.Size(75, 23);
            this.btn_LogUit.TabIndex = 7;
            this.btn_LogUit.Text = "Log Uit";
            this.btn_LogUit.UseVisualStyleBackColor = true;
            this.btn_LogUit.Click += new System.EventHandler(this.btn_LogUit_Click);
            // 
            // BeheerSysteemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(864, 571);
            this.Controls.Add(this.btn_LogUit);
            this.Controls.Add(this.btn_Vrijwilligers);
            this.Controls.Add(this.btn_Beheer);
            this.Controls.Add(this.btn_Chat);
            this.Controls.Add(this.btn_Ouderen);
            this.Controls.Add(this.btn_Hulpvragen);
            this.Controls.Add(this.btn_Profiel);
            this.Controls.Add(this.groupBox1);
            this.Name = "BeheerSysteemForm";
            this.Text = "BeheerSysteemForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbx_userList;
        private System.Windows.Forms.Button btn_Profiel;
        private System.Windows.Forms.Button btn_Hulpvragen;
        private System.Windows.Forms.Button btn_Ouderen;
        private System.Windows.Forms.Button btn_Chat;
        private System.Windows.Forms.Button btn_Beheer;
        private System.Windows.Forms.Button btn_Vrijwilligers;
        private System.Windows.Forms.Button btn_LogUit;
        private System.Windows.Forms.Button btn_VerwijderRecensies;
        private System.Windows.Forms.Button btn_VerwijderHulpvraag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbx_Reviews;
        private System.Windows.Forms.ListBox lbx_requests;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_BanGebruiker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_daysUntillUnbanned;
        private System.Windows.Forms.RadioButton rbtn_Temporary;
        private System.Windows.Forms.RadioButton rbtn_Permanent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtb_ProfileInformation;
        private System.Windows.Forms.TextBox tbx_ProfileName;
        private System.Windows.Forms.PictureBox pbProfilePicture;
    }
}