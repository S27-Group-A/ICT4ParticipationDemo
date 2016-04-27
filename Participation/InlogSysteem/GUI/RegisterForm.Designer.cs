namespace Participation.InlogSysteem.GUI
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPhonenumber = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblProfilePicture = new System.Windows.Forms.Label();
            this.lblRepeatPassword = new System.Windows.Forms.Label();
            this.tbxRepeatPassword = new System.Windows.Forms.TextBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.tbxLocation = new System.Windows.Forms.TextBox();
            this.tbxPhonenumber = new System.Windows.Forms.TextBox();
            this.tbxProfilePictureUrl = new System.Windows.Forms.TextBox();
            this.rbtMale = new System.Windows.Forms.RadioButton();
            this.rbtFemale = new System.Windows.Forms.RadioButton();
            this.rbtNeedHelp = new System.Windows.Forms.RadioButton();
            this.rbtCanHelp = new System.Windows.Forms.RadioButton();
            this.lblObliged = new System.Windows.Forms.Label();
            this.btnBrowseProfilePicture = new System.Windows.Forms.Button();
            this.lblAllowedProfilePictureFormats = new System.Windows.Forms.Label();
            this.lblAllowedVOGFormats = new System.Windows.Forms.Label();
            this.btnBrowseVOG = new System.Windows.Forms.Button();
            this.tbxVOGUrl = new System.Windows.Forms.TextBox();
            this.gbxVOG = new System.Windows.Forms.GroupBox();
            this.tbxPerk = new System.Windows.Forms.TextBox();
            this.btnAddPerk = new System.Windows.Forms.Button();
            this.lblPerks = new System.Windows.Forms.Label();
            this.gbxPerks = new System.Windows.Forms.GroupBox();
            this.lblSkills = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.helpGbx = new System.Windows.Forms.GroupBox();
            this.pnlInformation = new System.Windows.Forms.Panel();
            this.pbProfilePic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHasRfid = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxVOG.SuspendLayout();
            this.gbxPerks.SuspendLayout();
            this.helpGbx.SuspendLayout();
            this.pnlInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPassword.Location = new System.Drawing.Point(3, 68);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(123, 20);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Wachtwoord: * ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblEmail.Location = new System.Drawing.Point(3, 34);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(120, 20);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "E-mail adres: *";
            // 
            // tbxEmail
            // 
            this.tbxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmail.Location = new System.Drawing.Point(245, 32);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(208, 27);
            this.tbxEmail.TabIndex = 4;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(245, 65);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(208, 27);
            this.tbxPassword.TabIndex = 5;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRegister.Location = new System.Drawing.Point(181, 674);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(411, 36);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "Registreren";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblBirthdate.Location = new System.Drawing.Point(4, 135);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(140, 20);
            this.lblBirthdate.TabIndex = 13;
            this.lblBirthdate.Text = "Geboortedatum: *";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblLocation.Location = new System.Drawing.Point(4, 164);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(113, 20);
            this.lblLocation.TabIndex = 14;
            this.lblLocation.Text = "Woonplaats: *";
            // 
            // lblPhonenumber
            // 
            this.lblPhonenumber.AutoSize = true;
            this.lblPhonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonenumber.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPhonenumber.Location = new System.Drawing.Point(3, 197);
            this.lblPhonenumber.Name = "lblPhonenumber";
            this.lblPhonenumber.Size = new System.Drawing.Size(139, 20);
            this.lblPhonenumber.TabIndex = 15;
            this.lblPhonenumber.Text = "Telefoonnummer:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblGender.Location = new System.Drawing.Point(4, 226);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(92, 20);
            this.lblGender.TabIndex = 16;
            this.lblGender.Text = "Geslacht: *";
            // 
            // lblProfilePicture
            // 
            this.lblProfilePicture.AutoSize = true;
            this.lblProfilePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfilePicture.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblProfilePicture.Location = new System.Drawing.Point(3, 258);
            this.lblProfilePicture.Name = "lblProfilePicture";
            this.lblProfilePicture.Size = new System.Drawing.Size(101, 20);
            this.lblProfilePicture.TabIndex = 17;
            this.lblProfilePicture.Text = "Profielfoto: *";
            // 
            // lblRepeatPassword
            // 
            this.lblRepeatPassword.AutoSize = true;
            this.lblRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatPassword.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblRepeatPassword.Location = new System.Drawing.Point(3, 103);
            this.lblRepeatPassword.Name = "lblRepeatPassword";
            this.lblRepeatPassword.Size = new System.Drawing.Size(212, 20);
            this.lblRepeatPassword.TabIndex = 18;
            this.lblRepeatPassword.Text = "(Herhaling) Wachtwoord: * ";
            // 
            // tbxRepeatPassword
            // 
            this.tbxRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRepeatPassword.Location = new System.Drawing.Point(245, 98);
            this.tbxRepeatPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxRepeatPassword.Name = "tbxRepeatPassword";
            this.tbxRepeatPassword.PasswordChar = '*';
            this.tbxRepeatPassword.Size = new System.Drawing.Size(208, 27);
            this.tbxRepeatPassword.TabIndex = 6;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.Location = new System.Drawing.Point(245, 133);
            this.dtpBirthdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(208, 22);
            this.dtpBirthdate.TabIndex = 7;
            // 
            // tbxLocation
            // 
            this.tbxLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLocation.Location = new System.Drawing.Point(245, 161);
            this.tbxLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxLocation.Name = "tbxLocation";
            this.tbxLocation.Size = new System.Drawing.Size(208, 27);
            this.tbxLocation.TabIndex = 8;
            // 
            // tbxPhonenumber
            // 
            this.tbxPhonenumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPhonenumber.Location = new System.Drawing.Point(245, 194);
            this.tbxPhonenumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxPhonenumber.Name = "tbxPhonenumber";
            this.tbxPhonenumber.Size = new System.Drawing.Size(208, 27);
            this.tbxPhonenumber.TabIndex = 9;
            // 
            // tbxProfilePictureUrl
            // 
            this.tbxProfilePictureUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxProfilePictureUrl.Location = new System.Drawing.Point(245, 255);
            this.tbxProfilePictureUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxProfilePictureUrl.Name = "tbxProfilePictureUrl";
            this.tbxProfilePictureUrl.Size = new System.Drawing.Size(208, 27);
            this.tbxProfilePictureUrl.TabIndex = 12;
            // 
            // rbtMale
            // 
            this.rbtMale.AutoSize = true;
            this.rbtMale.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbtMale.Location = new System.Drawing.Point(16, 1);
            this.rbtMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtMale.Name = "rbtMale";
            this.rbtMale.Size = new System.Drawing.Size(56, 21);
            this.rbtMale.TabIndex = 10;
            this.rbtMale.TabStop = true;
            this.rbtMale.Text = "Man";
            this.rbtMale.UseVisualStyleBackColor = true;
            // 
            // rbtFemale
            // 
            this.rbtFemale.AutoSize = true;
            this.rbtFemale.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbtFemale.Location = new System.Drawing.Point(77, 2);
            this.rbtFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtFemale.Name = "rbtFemale";
            this.rbtFemale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rbtFemale.Size = new System.Drawing.Size(68, 21);
            this.rbtFemale.TabIndex = 11;
            this.rbtFemale.TabStop = true;
            this.rbtFemale.Text = "Vrouw";
            this.rbtFemale.UseVisualStyleBackColor = true;
            // 
            // rbtNeedHelp
            // 
            this.rbtNeedHelp.AutoSize = true;
            this.rbtNeedHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtNeedHelp.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbtNeedHelp.Location = new System.Drawing.Point(21, 10);
            this.rbtNeedHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtNeedHelp.Name = "rbtNeedHelp";
            this.rbtNeedHelp.Size = new System.Drawing.Size(295, 33);
            this.rbtNeedHelp.TabIndex = 1;
            this.rbtNeedHelp.TabStop = true;
            this.rbtNeedHelp.Text = "Ik ben op zoek naar hulp";
            this.rbtNeedHelp.UseVisualStyleBackColor = true;
            this.rbtNeedHelp.CheckedChanged += new System.EventHandler(this.needHelpRbt_CheckedChanged);
            // 
            // rbtCanHelp
            // 
            this.rbtCanHelp.AutoSize = true;
            this.rbtCanHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtCanHelp.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rbtCanHelp.Location = new System.Drawing.Point(373, 10);
            this.rbtCanHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtCanHelp.Name = "rbtCanHelp";
            this.rbtCanHelp.Size = new System.Drawing.Size(168, 33);
            this.rbtCanHelp.TabIndex = 2;
            this.rbtCanHelp.TabStop = true;
            this.rbtCanHelp.Text = "Ik wil helpen";
            this.rbtCanHelp.UseVisualStyleBackColor = true;
            this.rbtCanHelp.CheckedChanged += new System.EventHandler(this.canHelpRbt_CheckedChanged);
            // 
            // lblObliged
            // 
            this.lblObliged.AutoSize = true;
            this.lblObliged.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObliged.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblObliged.Location = new System.Drawing.Point(29, 9);
            this.lblObliged.Name = "lblObliged";
            this.lblObliged.Size = new System.Drawing.Size(288, 20);
            this.lblObliged.TabIndex = 29;
            this.lblObliged.Text = "Velden met * zijn verplicht in te vullen";
            // 
            // btnBrowseProfilePicture
            // 
            this.btnBrowseProfilePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseProfilePicture.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBrowseProfilePicture.Location = new System.Drawing.Point(460, 256);
            this.btnBrowseProfilePicture.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseProfilePicture.Name = "btnBrowseProfilePicture";
            this.btnBrowseProfilePicture.Size = new System.Drawing.Size(99, 27);
            this.btnBrowseProfilePicture.TabIndex = 13;
            this.btnBrowseProfilePicture.Text = "Bladeren...";
            this.btnBrowseProfilePicture.UseVisualStyleBackColor = true;
            this.btnBrowseProfilePicture.Click += new System.EventHandler(this.browseProfilePictureBtn_Click);
            // 
            // lblAllowedProfilePictureFormats
            // 
            this.lblAllowedProfilePictureFormats.AutoSize = true;
            this.lblAllowedProfilePictureFormats.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowedProfilePictureFormats.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblAllowedProfilePictureFormats.Location = new System.Drawing.Point(243, 287);
            this.lblAllowedProfilePictureFormats.Name = "lblAllowedProfilePictureFormats";
            this.lblAllowedProfilePictureFormats.Size = new System.Drawing.Size(266, 17);
            this.lblAllowedProfilePictureFormats.TabIndex = 31;
            this.lblAllowedProfilePictureFormats.Text = "Toegestaande formaten: .jpeg, png, bmp";
            // 
            // lblAllowedVOGFormats
            // 
            this.lblAllowedVOGFormats.AutoSize = true;
            this.lblAllowedVOGFormats.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllowedVOGFormats.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblAllowedVOGFormats.Location = new System.Drawing.Point(16, 64);
            this.lblAllowedVOGFormats.Name = "lblAllowedVOGFormats";
            this.lblAllowedVOGFormats.Size = new System.Drawing.Size(331, 17);
            this.lblAllowedVOGFormats.TabIndex = 35;
            this.lblAllowedVOGFormats.Text = "Toegestaande formaten: .jpeg, png, bmp, pdf, docx";
            // 
            // btnBrowseVOG
            // 
            this.btnBrowseVOG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseVOG.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBrowseVOG.Location = new System.Drawing.Point(459, 34);
            this.btnBrowseVOG.Margin = new System.Windows.Forms.Padding(4);
            this.btnBrowseVOG.Name = "btnBrowseVOG";
            this.btnBrowseVOG.Size = new System.Drawing.Size(99, 27);
            this.btnBrowseVOG.TabIndex = 15;
            this.btnBrowseVOG.Text = "Bladeren...";
            this.btnBrowseVOG.UseVisualStyleBackColor = true;
            this.btnBrowseVOG.Click += new System.EventHandler(this.browseVogUrlBtn_Click);
            // 
            // tbxVOGUrl
            // 
            this.tbxVOGUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxVOGUrl.Location = new System.Drawing.Point(19, 34);
            this.tbxVOGUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxVOGUrl.Name = "tbxVOGUrl";
            this.tbxVOGUrl.Size = new System.Drawing.Size(432, 27);
            this.tbxVOGUrl.TabIndex = 14;
            // 
            // gbxVOG
            // 
            this.gbxVOG.Controls.Add(this.tbxVOGUrl);
            this.gbxVOG.Controls.Add(this.lblAllowedVOGFormats);
            this.gbxVOG.Controls.Add(this.btnBrowseVOG);
            this.gbxVOG.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxVOG.Location = new System.Drawing.Point(13, 406);
            this.gbxVOG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxVOG.Name = "gbxVOG";
            this.gbxVOG.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxVOG.Size = new System.Drawing.Size(579, 100);
            this.gbxVOG.TabIndex = 36;
            this.gbxVOG.TabStop = false;
            this.gbxVOG.Text = "Verklaring Omtrent het Gedrag (VOG:) *";
            this.gbxVOG.Visible = false;
            // 
            // tbxPerk
            // 
            this.tbxPerk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPerk.Location = new System.Drawing.Point(19, 34);
            this.tbxPerk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxPerk.Name = "tbxPerk";
            this.tbxPerk.Size = new System.Drawing.Size(432, 27);
            this.tbxPerk.TabIndex = 16;
            // 
            // btnAddPerk
            // 
            this.btnAddPerk.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddPerk.Location = new System.Drawing.Point(459, 36);
            this.btnAddPerk.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddPerk.Name = "btnAddPerk";
            this.btnAddPerk.Size = new System.Drawing.Size(99, 27);
            this.btnAddPerk.TabIndex = 17;
            this.btnAddPerk.Text = "Toevoegen";
            this.btnAddPerk.UseVisualStyleBackColor = true;
            this.btnAddPerk.Click += new System.EventHandler(this.addPerkTbx_Click);
            // 
            // lblPerks
            // 
            this.lblPerks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerks.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblPerks.Location = new System.Drawing.Point(19, 91);
            this.lblPerks.Name = "lblPerks";
            this.lblPerks.Size = new System.Drawing.Size(521, 52);
            this.lblPerks.TabIndex = 38;
            // 
            // gbxPerks
            // 
            this.gbxPerks.Controls.Add(this.lblSkills);
            this.gbxPerks.Controls.Add(this.tbxPerk);
            this.gbxPerks.Controls.Add(this.btnAddPerk);
            this.gbxPerks.Controls.Add(this.lblPerks);
            this.gbxPerks.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxPerks.Location = new System.Drawing.Point(13, 512);
            this.gbxPerks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxPerks.Name = "gbxPerks";
            this.gbxPerks.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbxPerks.Size = new System.Drawing.Size(579, 156);
            this.gbxPerks.TabIndex = 39;
            this.gbxPerks.TabStop = false;
            this.gbxPerks.Text = "Extra vaardigheden: ";
            this.gbxPerks.Visible = false;
            // 
            // lblSkills
            // 
            this.lblSkills.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkills.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblSkills.Location = new System.Drawing.Point(16, 66);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(101, 25);
            this.lblSkills.TabIndex = 39;
            this.lblSkills.Text = "Vaardigheden: ";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBack.Location = new System.Drawing.Point(13, 674);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(159, 36);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Terug";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 20);
            this.lblName.TabIndex = 41;
            this.lblName.Text = "Naam: *";
            // 
            // tbxName
            // 
            this.tbxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxName.Location = new System.Drawing.Point(245, -2);
            this.tbxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(208, 27);
            this.tbxName.TabIndex = 3;
            // 
            // helpGbx
            // 
            this.helpGbx.Controls.Add(this.rbtNeedHelp);
            this.helpGbx.Controls.Add(this.rbtCanHelp);
            this.helpGbx.Location = new System.Drawing.Point(13, 32);
            this.helpGbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpGbx.Name = "helpGbx";
            this.helpGbx.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.helpGbx.Size = new System.Drawing.Size(577, 49);
            this.helpGbx.TabIndex = 44;
            this.helpGbx.TabStop = false;
            // 
            // pnlInformation
            // 
            this.pnlInformation.Controls.Add(this.pbProfilePic);
            this.pnlInformation.Controls.Add(this.label1);
            this.pnlInformation.Controls.Add(this.pnlHasRfid);
            this.pnlInformation.Controls.Add(this.panel1);
            this.pnlInformation.Controls.Add(this.lblName);
            this.pnlInformation.Controls.Add(this.tbxPassword);
            this.pnlInformation.Controls.Add(this.tbxName);
            this.pnlInformation.Controls.Add(this.tbxEmail);
            this.pnlInformation.Controls.Add(this.lblEmail);
            this.pnlInformation.Controls.Add(this.lblPassword);
            this.pnlInformation.Controls.Add(this.lblBirthdate);
            this.pnlInformation.Controls.Add(this.lblLocation);
            this.pnlInformation.Controls.Add(this.lblAllowedProfilePictureFormats);
            this.pnlInformation.Controls.Add(this.lblPhonenumber);
            this.pnlInformation.Controls.Add(this.btnBrowseProfilePicture);
            this.pnlInformation.Controls.Add(this.lblGender);
            this.pnlInformation.Controls.Add(this.lblProfilePicture);
            this.pnlInformation.Controls.Add(this.tbxProfilePictureUrl);
            this.pnlInformation.Controls.Add(this.lblRepeatPassword);
            this.pnlInformation.Controls.Add(this.tbxPhonenumber);
            this.pnlInformation.Controls.Add(this.tbxRepeatPassword);
            this.pnlInformation.Controls.Add(this.tbxLocation);
            this.pnlInformation.Controls.Add(this.dtpBirthdate);
            this.pnlInformation.Location = new System.Drawing.Point(13, 87);
            this.pnlInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInformation.Name = "pnlInformation";
            this.pnlInformation.Size = new System.Drawing.Size(577, 313);
            this.pnlInformation.TabIndex = 45;
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Image = ((System.Drawing.Image)(resources.GetObject("pbProfilePic.Image")));
            this.pbProfilePic.Location = new System.Drawing.Point(464, 2);
            this.pbProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.Size = new System.Drawing.Size(100, 100);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilePic.TabIndex = 47;
            this.pbProfilePic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(463, 133);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "RFID";
            this.label1.Visible = false;
            // 
            // pnlHasRfid
            // 
            this.pnlHasRfid.BackColor = System.Drawing.Color.Red;
            this.pnlHasRfid.Enabled = false;
            this.pnlHasRfid.ForeColor = System.Drawing.SystemColors.Menu;
            this.pnlHasRfid.Location = new System.Drawing.Point(464, 161);
            this.pnlHasRfid.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHasRfid.Name = "pnlHasRfid";
            this.pnlHasRfid.Size = new System.Drawing.Size(100, 60);
            this.pnlHasRfid.TabIndex = 45;
            this.pnlHasRfid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtFemale);
            this.panel1.Controls.Add(this.rbtMale);
            this.panel1.Location = new System.Drawing.Point(245, 226);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 20);
            this.panel1.TabIndex = 44;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(619, 726);
            this.Controls.Add(this.pnlInformation);
            this.Controls.Add(this.helpGbx);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbxPerks);
            this.Controls.Add(this.gbxVOG);
            this.Controls.Add(this.lblObliged);
            this.Controls.Add(this.btnRegister);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.Closed += new System.EventHandler(this.RegisterForm_Closed);
            this.gbxVOG.ResumeLayout(false);
            this.gbxVOG.PerformLayout();
            this.gbxPerks.ResumeLayout(false);
            this.gbxPerks.PerformLayout();
            this.helpGbx.ResumeLayout(false);
            this.helpGbx.PerformLayout();
            this.pnlInformation.ResumeLayout(false);
            this.pnlInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPhonenumber;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblProfilePicture;
        private System.Windows.Forms.Label lblRepeatPassword;
        private System.Windows.Forms.TextBox tbxRepeatPassword;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.TextBox tbxLocation;
        private System.Windows.Forms.TextBox tbxPhonenumber;
        private System.Windows.Forms.TextBox tbxProfilePictureUrl;
        private System.Windows.Forms.RadioButton rbtMale;
        private System.Windows.Forms.RadioButton rbtFemale;
        private System.Windows.Forms.RadioButton rbtNeedHelp;
        private System.Windows.Forms.RadioButton rbtCanHelp;
        private System.Windows.Forms.Label lblObliged;
        private System.Windows.Forms.Button btnBrowseProfilePicture;
        private System.Windows.Forms.Label lblAllowedProfilePictureFormats;
        private System.Windows.Forms.Label lblAllowedVOGFormats;
        private System.Windows.Forms.Button btnBrowseVOG;
        private System.Windows.Forms.TextBox tbxVOGUrl;
        private System.Windows.Forms.GroupBox gbxVOG;
        private System.Windows.Forms.TextBox tbxPerk;
        private System.Windows.Forms.Button btnAddPerk;
        private System.Windows.Forms.Label lblPerks;
        private System.Windows.Forms.GroupBox gbxPerks;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.GroupBox helpGbx;
        private System.Windows.Forms.Panel pnlInformation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHasRfid;
        private System.Windows.Forms.PictureBox pbProfilePic;
        private System.Windows.Forms.Label lblSkills;
    }
}