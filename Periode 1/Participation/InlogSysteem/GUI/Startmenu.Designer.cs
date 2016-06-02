namespace Participation
{
    partial class Startmenu
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
            this.logInBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.emailTbx = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.instructionsLbl = new System.Windows.Forms.Label();
            this.rfidBtn = new System.Windows.Forms.Button();
            this.rfidGbx = new System.Windows.Forms.GroupBox();
            this.rfidTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rfidGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // logInBtn
            // 
            this.logInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logInBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logInBtn.Location = new System.Drawing.Point(26, 71);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(124, 29);
            this.logInBtn.TabIndex = 3;
            this.logInBtn.Text = "Inloggen";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.startMenuLogInBtn_Click);
            // 
            // registerBtn
            // 
            this.registerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.registerBtn.Location = new System.Drawing.Point(163, 71);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(119, 29);
            this.registerBtn.TabIndex = 4;
            this.registerBtn.Text = "Registreren";
            this.registerBtn.UseVisualStyleBackColor = true;
            this.registerBtn.Click += new System.EventHandler(this.startMenuRegisterBtn_Click);
            // 
            // passwordTbx
            // 
            this.passwordTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTbx.Location = new System.Drawing.Point(122, 43);
            this.passwordTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.PasswordChar = '*';
            this.passwordTbx.Size = new System.Drawing.Size(161, 23);
            this.passwordTbx.TabIndex = 2;
            // 
            // emailTbx
            // 
            this.emailTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTbx.Location = new System.Drawing.Point(123, 10);
            this.emailTbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailTbx.Name = "emailTbx";
            this.emailTbx.Size = new System.Drawing.Size(160, 23);
            this.emailTbx.TabIndex = 1;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.emailLbl.Location = new System.Drawing.Point(30, 12);
            this.emailLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(91, 17);
            this.emailLbl.TabIndex = 4;
            this.emailLbl.Text = "E-mail adres:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.passwordLbl.Location = new System.Drawing.Point(29, 46);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(94, 17);
            this.passwordLbl.TabIndex = 5;
            this.passwordLbl.Text = "Wachtwoord: ";
            // 
            // instructionsLbl
            // 
            this.instructionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.instructionsLbl.Location = new System.Drawing.Point(26, 114);
            this.instructionsLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.instructionsLbl.Name = "instructionsLbl";
            this.instructionsLbl.Size = new System.Drawing.Size(256, 60);
            this.instructionsLbl.TabIndex = 10;
            this.instructionsLbl.Text = "Als u nog geen account heeft klik op de \"Registreren\"-knop.";
            // 
            // rfidBtn
            // 
            this.rfidBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rfidBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rfidBtn.Location = new System.Drawing.Point(310, 71);
            this.rfidBtn.Name = "rfidBtn";
            this.rfidBtn.Size = new System.Drawing.Size(310, 29);
            this.rfidBtn.TabIndex = 6;
            this.rfidBtn.Text = "Ik heb een RFID!";
            this.rfidBtn.UseVisualStyleBackColor = true;
            this.rfidBtn.Click += new System.EventHandler(this.rfidBtn_Click);
            // 
            // rfidGbx
            // 
            this.rfidGbx.Controls.Add(this.rfidTbx);
            this.rfidGbx.Location = new System.Drawing.Point(310, 2);
            this.rfidGbx.Name = "rfidGbx";
            this.rfidGbx.Size = new System.Drawing.Size(310, 63);
            this.rfidGbx.TabIndex = 18;
            this.rfidGbx.TabStop = false;
            this.rfidGbx.Text = "RFID Code";
            // 
            // rfidTbx
            // 
            this.rfidTbx.Location = new System.Drawing.Point(20, 25);
            this.rfidTbx.Name = "rfidTbx";
            this.rfidTbx.Size = new System.Drawing.Size(278, 20);
            this.rfidTbx.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(307, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 60);
            this.label1.TabIndex = 11;
            this.label1.Text = "U kunt ook inloggen met uw pasje. Houdt u pasje voor de scanner en klik op de \"Ik" +
    " heb een RFID!\"-knop als het rfid code veld eenmaal is ingevuld.";
            // 
            // Startmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(628, 175);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rfidGbx);
            this.Controls.Add(this.rfidBtn);
            this.Controls.Add(this.instructionsLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.emailTbx);
            this.Controls.Add(this.passwordTbx);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.logInBtn);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(1444, 885);
            this.Name = "Startmenu";
            this.Text = "Participation4All - Startmenu";
            this.Load += new System.EventHandler(this.Startmenu_Load);
            this.rfidGbx.ResumeLayout(false);
            this.rfidGbx.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.TextBox emailTbx;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label instructionsLbl;
        private System.Windows.Forms.Button rfidBtn;
        private System.Windows.Forms.GroupBox rfidGbx;
        private System.Windows.Forms.TextBox rfidTbx;
        private System.Windows.Forms.Label label1;
    }
}

