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
            this.passwordLbl = new System.Windows.Forms.Label();
            this.emailLbl = new System.Windows.Forms.Label();
            this.emailTbx = new System.Windows.Forms.TextBox();
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.birthdateLbl = new System.Windows.Forms.Label();
            this.locationLbl = new System.Windows.Forms.Label();
            this.telephonenumberLbl = new System.Windows.Forms.Label();
            this.genderLbl = new System.Windows.Forms.Label();
            this.profilePictureLbl = new System.Windows.Forms.Label();
            this.repeatPasswordLbl = new System.Windows.Forms.Label();
            this.repeatPasswordTbx = new System.Windows.Forms.TextBox();
            this.birthdateDtp = new System.Windows.Forms.DateTimePicker();
            this.locationTbx = new System.Windows.Forms.TextBox();
            this.phonenumberTbx = new System.Windows.Forms.TextBox();
            this.profilePictureUrlTbx = new System.Windows.Forms.TextBox();
            this.maleRbt = new System.Windows.Forms.RadioButton();
            this.femaleRbt = new System.Windows.Forms.RadioButton();
            this.needHelpRbt = new System.Windows.Forms.RadioButton();
            this.canHelpRbt = new System.Windows.Forms.RadioButton();
            this.obligedLbl = new System.Windows.Forms.Label();
            this.browseProfilePictureBtn = new System.Windows.Forms.Button();
            this.allowedPictureFormatsLbl = new System.Windows.Forms.Label();
            this.allowedVogFormatsLbl = new System.Windows.Forms.Label();
            this.browseVogUrlBtn = new System.Windows.Forms.Button();
            this.vogUrlTbx = new System.Windows.Forms.TextBox();
            this.vogGbx = new System.Windows.Forms.GroupBox();
            this.perkTbx = new System.Windows.Forms.TextBox();
            this.addPerkTbx = new System.Windows.Forms.Button();
            this.listPerksLbl = new System.Windows.Forms.Label();
            this.perksGbx = new System.Windows.Forms.GroupBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTbx = new System.Windows.Forms.TextBox();
            this.vogGbx.SuspendLayout();
            this.perksGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.passwordLbl.Location = new System.Drawing.Point(27, 152);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(123, 20);
            this.passwordLbl.TabIndex = 12;
            this.passwordLbl.Text = "Wachtwoord: * ";
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.emailLbl.Location = new System.Drawing.Point(27, 119);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(120, 20);
            this.emailLbl.TabIndex = 11;
            this.emailLbl.Text = "E-mail adres: *";
            // 
            // emailTbx
            // 
            this.emailTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTbx.Location = new System.Drawing.Point(256, 116);
            this.emailTbx.Name = "emailTbx";
            this.emailTbx.Size = new System.Drawing.Size(208, 27);
            this.emailTbx.TabIndex = 10;
            // 
            // passwordTbx
            // 
            this.passwordTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTbx.Location = new System.Drawing.Point(256, 149);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.Size = new System.Drawing.Size(208, 27);
            this.passwordTbx.TabIndex = 9;
            // 
            // registerBtn
            // 
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.registerBtn.Location = new System.Drawing.Point(180, 667);
            this.registerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(410, 36);
            this.registerBtn.TabIndex = 8;
            this.registerBtn.Text = "Registreren";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // birthdateLbl
            // 
            this.birthdateLbl.AutoSize = true;
            this.birthdateLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthdateLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.birthdateLbl.Location = new System.Drawing.Point(28, 219);
            this.birthdateLbl.Name = "birthdateLbl";
            this.birthdateLbl.Size = new System.Drawing.Size(140, 20);
            this.birthdateLbl.TabIndex = 13;
            this.birthdateLbl.Text = "Geboortedatum: *";
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.locationLbl.Location = new System.Drawing.Point(28, 248);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(113, 20);
            this.locationLbl.TabIndex = 14;
            this.locationLbl.Text = "Woonplaats: *";
            // 
            // telephonenumberLbl
            // 
            this.telephonenumberLbl.AutoSize = true;
            this.telephonenumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephonenumberLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.telephonenumberLbl.Location = new System.Drawing.Point(27, 281);
            this.telephonenumberLbl.Name = "telephonenumberLbl";
            this.telephonenumberLbl.Size = new System.Drawing.Size(139, 20);
            this.telephonenumberLbl.TabIndex = 15;
            this.telephonenumberLbl.Text = "Telefoonnummer:";
            // 
            // genderLbl
            // 
            this.genderLbl.AutoSize = true;
            this.genderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genderLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.genderLbl.Location = new System.Drawing.Point(27, 310);
            this.genderLbl.Name = "genderLbl";
            this.genderLbl.Size = new System.Drawing.Size(86, 20);
            this.genderLbl.TabIndex = 16;
            this.genderLbl.Text = "Geslacht: ";
            // 
            // profilePictureLbl
            // 
            this.profilePictureLbl.AutoSize = true;
            this.profilePictureLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilePictureLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.profilePictureLbl.Location = new System.Drawing.Point(27, 341);
            this.profilePictureLbl.Name = "profilePictureLbl";
            this.profilePictureLbl.Size = new System.Drawing.Size(90, 20);
            this.profilePictureLbl.TabIndex = 17;
            this.profilePictureLbl.Text = "Profielfoto:";
            // 
            // repeatPasswordLbl
            // 
            this.repeatPasswordLbl.AutoSize = true;
            this.repeatPasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.repeatPasswordLbl.Location = new System.Drawing.Point(27, 187);
            this.repeatPasswordLbl.Name = "repeatPasswordLbl";
            this.repeatPasswordLbl.Size = new System.Drawing.Size(212, 20);
            this.repeatPasswordLbl.TabIndex = 18;
            this.repeatPasswordLbl.Text = "(Herhaling) Wachtwoord: * ";
            // 
            // repeatPasswordTbx
            // 
            this.repeatPasswordTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordTbx.Location = new System.Drawing.Point(256, 183);
            this.repeatPasswordTbx.Name = "repeatPasswordTbx";
            this.repeatPasswordTbx.Size = new System.Drawing.Size(208, 27);
            this.repeatPasswordTbx.TabIndex = 19;
            // 
            // birthdateDtp
            // 
            this.birthdateDtp.Location = new System.Drawing.Point(256, 217);
            this.birthdateDtp.Name = "birthdateDtp";
            this.birthdateDtp.Size = new System.Drawing.Size(208, 22);
            this.birthdateDtp.TabIndex = 20;
            // 
            // locationTbx
            // 
            this.locationTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationTbx.Location = new System.Drawing.Point(256, 245);
            this.locationTbx.Name = "locationTbx";
            this.locationTbx.Size = new System.Drawing.Size(208, 27);
            this.locationTbx.TabIndex = 21;
            // 
            // phonenumberTbx
            // 
            this.phonenumberTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phonenumberTbx.Location = new System.Drawing.Point(256, 278);
            this.phonenumberTbx.Name = "phonenumberTbx";
            this.phonenumberTbx.Size = new System.Drawing.Size(208, 27);
            this.phonenumberTbx.TabIndex = 22;
            // 
            // profilePictureUrlTbx
            // 
            this.profilePictureUrlTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilePictureUrlTbx.Location = new System.Drawing.Point(256, 338);
            this.profilePictureUrlTbx.Name = "profilePictureUrlTbx";
            this.profilePictureUrlTbx.Size = new System.Drawing.Size(208, 27);
            this.profilePictureUrlTbx.TabIndex = 24;
            // 
            // maleRbt
            // 
            this.maleRbt.AutoSize = true;
            this.maleRbt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.maleRbt.Location = new System.Drawing.Point(256, 311);
            this.maleRbt.Name = "maleRbt";
            this.maleRbt.Size = new System.Drawing.Size(56, 21);
            this.maleRbt.TabIndex = 25;
            this.maleRbt.TabStop = true;
            this.maleRbt.Text = "Man";
            this.maleRbt.UseVisualStyleBackColor = true;
            // 
            // femaleRbt
            // 
            this.femaleRbt.AutoSize = true;
            this.femaleRbt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.femaleRbt.Location = new System.Drawing.Point(318, 311);
            this.femaleRbt.Name = "femaleRbt";
            this.femaleRbt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.femaleRbt.Size = new System.Drawing.Size(68, 21);
            this.femaleRbt.TabIndex = 26;
            this.femaleRbt.TabStop = true;
            this.femaleRbt.Text = "Vrouw";
            this.femaleRbt.UseVisualStyleBackColor = true;
            // 
            // needHelpRbt
            // 
            this.needHelpRbt.AutoSize = true;
            this.needHelpRbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.needHelpRbt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.needHelpRbt.Location = new System.Drawing.Point(31, 42);
            this.needHelpRbt.Name = "needHelpRbt";
            this.needHelpRbt.Size = new System.Drawing.Size(295, 33);
            this.needHelpRbt.TabIndex = 27;
            this.needHelpRbt.TabStop = true;
            this.needHelpRbt.Text = "Ik ben op zoek naar hulp";
            this.needHelpRbt.UseVisualStyleBackColor = true;
            this.needHelpRbt.CheckedChanged += new System.EventHandler(this.needHelpRbt_CheckedChanged);
            // 
            // canHelpRbt
            // 
            this.canHelpRbt.AutoSize = true;
            this.canHelpRbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canHelpRbt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.canHelpRbt.Location = new System.Drawing.Point(384, 42);
            this.canHelpRbt.Name = "canHelpRbt";
            this.canHelpRbt.Size = new System.Drawing.Size(168, 33);
            this.canHelpRbt.TabIndex = 28;
            this.canHelpRbt.TabStop = true;
            this.canHelpRbt.Text = "Ik wil helpen";
            this.canHelpRbt.UseVisualStyleBackColor = true;
            this.canHelpRbt.CheckedChanged += new System.EventHandler(this.canHelpRbt_CheckedChanged);
            // 
            // obligedLbl
            // 
            this.obligedLbl.AutoSize = true;
            this.obligedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obligedLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.obligedLbl.Location = new System.Drawing.Point(30, 9);
            this.obligedLbl.Name = "obligedLbl";
            this.obligedLbl.Size = new System.Drawing.Size(288, 20);
            this.obligedLbl.TabIndex = 29;
            this.obligedLbl.Text = "Velden met * zijn verplicht in te vullen";
            // 
            // browseProfilePictureBtn
            // 
            this.browseProfilePictureBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseProfilePictureBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.browseProfilePictureBtn.Location = new System.Drawing.Point(470, 339);
            this.browseProfilePictureBtn.Margin = new System.Windows.Forms.Padding(4);
            this.browseProfilePictureBtn.Name = "browseProfilePictureBtn";
            this.browseProfilePictureBtn.Size = new System.Drawing.Size(99, 27);
            this.browseProfilePictureBtn.TabIndex = 30;
            this.browseProfilePictureBtn.Text = "Bladeren...";
            this.browseProfilePictureBtn.UseVisualStyleBackColor = true;
            this.browseProfilePictureBtn.Click += new System.EventHandler(this.browseProfilePictureBtn_Click);
            // 
            // allowedPictureFormatsLbl
            // 
            this.allowedPictureFormatsLbl.AutoSize = true;
            this.allowedPictureFormatsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allowedPictureFormatsLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.allowedPictureFormatsLbl.Location = new System.Drawing.Point(252, 368);
            this.allowedPictureFormatsLbl.Name = "allowedPictureFormatsLbl";
            this.allowedPictureFormatsLbl.Size = new System.Drawing.Size(266, 17);
            this.allowedPictureFormatsLbl.TabIndex = 31;
            this.allowedPictureFormatsLbl.Text = "Toegestaande formaten: .jpeg, png, bmp";
            // 
            // allowedVogFormatsLbl
            // 
            this.allowedVogFormatsLbl.AutoSize = true;
            this.allowedVogFormatsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allowedVogFormatsLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.allowedVogFormatsLbl.Location = new System.Drawing.Point(16, 64);
            this.allowedVogFormatsLbl.Name = "allowedVogFormatsLbl";
            this.allowedVogFormatsLbl.Size = new System.Drawing.Size(331, 17);
            this.allowedVogFormatsLbl.TabIndex = 35;
            this.allowedVogFormatsLbl.Text = "Toegestaande formaten: .jpeg, png, bmp, pdf, docx";
            // 
            // browseVogUrlBtn
            // 
            this.browseVogUrlBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseVogUrlBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.browseVogUrlBtn.Location = new System.Drawing.Point(458, 34);
            this.browseVogUrlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.browseVogUrlBtn.Name = "browseVogUrlBtn";
            this.browseVogUrlBtn.Size = new System.Drawing.Size(99, 27);
            this.browseVogUrlBtn.TabIndex = 34;
            this.browseVogUrlBtn.Text = "Bladeren...";
            this.browseVogUrlBtn.UseVisualStyleBackColor = true;
            this.browseVogUrlBtn.Click += new System.EventHandler(this.browseVogUrlBtn_Click);
            // 
            // vogUrlTbx
            // 
            this.vogUrlTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vogUrlTbx.Location = new System.Drawing.Point(19, 34);
            this.vogUrlTbx.Name = "vogUrlTbx";
            this.vogUrlTbx.Size = new System.Drawing.Size(432, 27);
            this.vogUrlTbx.TabIndex = 33;
            // 
            // vogGbx
            // 
            this.vogGbx.Controls.Add(this.vogUrlTbx);
            this.vogGbx.Controls.Add(this.allowedVogFormatsLbl);
            this.vogGbx.Controls.Add(this.browseVogUrlBtn);
            this.vogGbx.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.vogGbx.Location = new System.Drawing.Point(12, 399);
            this.vogGbx.Name = "vogGbx";
            this.vogGbx.Size = new System.Drawing.Size(578, 100);
            this.vogGbx.TabIndex = 36;
            this.vogGbx.TabStop = false;
            this.vogGbx.Text = "Verklaring Omtrent het Gedrag (VOG:) *";
            this.vogGbx.Visible = false;
            // 
            // perkTbx
            // 
            this.perkTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.perkTbx.Location = new System.Drawing.Point(19, 35);
            this.perkTbx.Name = "perkTbx";
            this.perkTbx.Size = new System.Drawing.Size(432, 27);
            this.perkTbx.TabIndex = 36;
            // 
            // addPerkTbx
            // 
            this.addPerkTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPerkTbx.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addPerkTbx.Location = new System.Drawing.Point(458, 36);
            this.addPerkTbx.Margin = new System.Windows.Forms.Padding(4);
            this.addPerkTbx.Name = "addPerkTbx";
            this.addPerkTbx.Size = new System.Drawing.Size(99, 27);
            this.addPerkTbx.TabIndex = 36;
            this.addPerkTbx.Text = "Toevoegen";
            this.addPerkTbx.UseVisualStyleBackColor = true;
            this.addPerkTbx.Click += new System.EventHandler(this.addPerkTbx_Click);
            // 
            // listPerksLbl
            // 
            this.listPerksLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listPerksLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.listPerksLbl.Location = new System.Drawing.Point(19, 65);
            this.listPerksLbl.Name = "listPerksLbl";
            this.listPerksLbl.Size = new System.Drawing.Size(521, 60);
            this.listPerksLbl.TabIndex = 38;
            this.listPerksLbl.Text = "Vaardigheden: ";
            // 
            // perksGbx
            // 
            this.perksGbx.Controls.Add(this.perkTbx);
            this.perksGbx.Controls.Add(this.addPerkTbx);
            this.perksGbx.Controls.Add(this.listPerksLbl);
            this.perksGbx.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.perksGbx.Location = new System.Drawing.Point(12, 505);
            this.perksGbx.Name = "perksGbx";
            this.perksGbx.Size = new System.Drawing.Size(578, 145);
            this.perksGbx.TabIndex = 39;
            this.perksGbx.TabStop = false;
            this.perksGbx.Text = "Extra vaardigheden: ";
            this.perksGbx.Visible = false;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.backBtn.Location = new System.Drawing.Point(13, 667);
            this.backBtn.Margin = new System.Windows.Forms.Padding(4);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(159, 36);
            this.backBtn.TabIndex = 40;
            this.backBtn.Text = "Terug";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.nameLbl.Location = new System.Drawing.Point(27, 84);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(69, 20);
            this.nameLbl.TabIndex = 41;
            this.nameLbl.Text = "Naam: *";
            // 
            // nameTbx
            // 
            this.nameTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTbx.Location = new System.Drawing.Point(255, 81);
            this.nameTbx.Name = "nameTbx";
            this.nameTbx.Size = new System.Drawing.Size(208, 27);
            this.nameTbx.TabIndex = 42;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(619, 799);
            this.Controls.Add(this.nameTbx);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.perksGbx);
            this.Controls.Add(this.vogGbx);
            this.Controls.Add(this.allowedPictureFormatsLbl);
            this.Controls.Add(this.browseProfilePictureBtn);
            this.Controls.Add(this.obligedLbl);
            this.Controls.Add(this.canHelpRbt);
            this.Controls.Add(this.needHelpRbt);
            this.Controls.Add(this.femaleRbt);
            this.Controls.Add(this.maleRbt);
            this.Controls.Add(this.profilePictureUrlTbx);
            this.Controls.Add(this.phonenumberTbx);
            this.Controls.Add(this.locationTbx);
            this.Controls.Add(this.birthdateDtp);
            this.Controls.Add(this.repeatPasswordTbx);
            this.Controls.Add(this.repeatPasswordLbl);
            this.Controls.Add(this.profilePictureLbl);
            this.Controls.Add(this.genderLbl);
            this.Controls.Add(this.telephonenumberLbl);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.birthdateLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.emailTbx);
            this.Controls.Add(this.passwordTbx);
            this.Controls.Add(this.registerBtn);
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.vogGbx.ResumeLayout(false);
            this.vogGbx.PerformLayout();
            this.perksGbx.ResumeLayout(false);
            this.perksGbx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.TextBox emailTbx;
        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Label birthdateLbl;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.Label telephonenumberLbl;
        private System.Windows.Forms.Label genderLbl;
        private System.Windows.Forms.Label profilePictureLbl;
        private System.Windows.Forms.Label repeatPasswordLbl;
        private System.Windows.Forms.TextBox repeatPasswordTbx;
        private System.Windows.Forms.DateTimePicker birthdateDtp;
        private System.Windows.Forms.TextBox locationTbx;
        private System.Windows.Forms.TextBox phonenumberTbx;
        private System.Windows.Forms.TextBox profilePictureUrlTbx;
        private System.Windows.Forms.RadioButton maleRbt;
        private System.Windows.Forms.RadioButton femaleRbt;
        private System.Windows.Forms.RadioButton needHelpRbt;
        private System.Windows.Forms.RadioButton canHelpRbt;
        private System.Windows.Forms.Label obligedLbl;
        private System.Windows.Forms.Button browseProfilePictureBtn;
        private System.Windows.Forms.Label allowedPictureFormatsLbl;
        private System.Windows.Forms.Label allowedVogFormatsLbl;
        private System.Windows.Forms.Button browseVogUrlBtn;
        private System.Windows.Forms.TextBox vogUrlTbx;
        private System.Windows.Forms.GroupBox vogGbx;
        private System.Windows.Forms.TextBox perkTbx;
        private System.Windows.Forms.Button addPerkTbx;
        private System.Windows.Forms.Label listPerksLbl;
        private System.Windows.Forms.GroupBox perksGbx;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameTbx;
    }
}