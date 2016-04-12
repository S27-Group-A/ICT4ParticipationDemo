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
            this.startMenuLogInBtn = new System.Windows.Forms.Button();
            this.startMenuRegisterBtn = new System.Windows.Forms.Button();
            this.passwordTbx = new System.Windows.Forms.TextBox();
            this.emailTbx = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.instructionsLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startMenuLogInBtn
            // 
            this.startMenuLogInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startMenuLogInBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startMenuLogInBtn.Location = new System.Drawing.Point(30, 96);
            this.startMenuLogInBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startMenuLogInBtn.Name = "startMenuLogInBtn";
            this.startMenuLogInBtn.Size = new System.Drawing.Size(166, 36);
            this.startMenuLogInBtn.TabIndex = 0;
            this.startMenuLogInBtn.Text = "Inloggen";
            this.startMenuLogInBtn.UseVisualStyleBackColor = true;
            this.startMenuLogInBtn.Click += new System.EventHandler(this.startMenuLogInBtn_Click);
            // 
            // startMenuRegisterBtn
            // 
            this.startMenuRegisterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startMenuRegisterBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startMenuRegisterBtn.Location = new System.Drawing.Point(213, 96);
            this.startMenuRegisterBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startMenuRegisterBtn.Name = "startMenuRegisterBtn";
            this.startMenuRegisterBtn.Size = new System.Drawing.Size(159, 36);
            this.startMenuRegisterBtn.TabIndex = 1;
            this.startMenuRegisterBtn.Text = "Registreren";
            this.startMenuRegisterBtn.UseVisualStyleBackColor = true;
            this.startMenuRegisterBtn.Click += new System.EventHandler(this.startMenuRegisterBtn_Click);
            // 
            // passwordTbx
            // 
            this.passwordTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTbx.Location = new System.Drawing.Point(164, 59);
            this.passwordTbx.Name = "passwordTbx";
            this.passwordTbx.Size = new System.Drawing.Size(208, 27);
            this.passwordTbx.TabIndex = 2;
            // 
            // emailTbx
            // 
            this.emailTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTbx.Location = new System.Drawing.Point(164, 12);
            this.emailTbx.Name = "emailTbx";
            this.emailTbx.Size = new System.Drawing.Size(208, 27);
            this.emailTbx.TabIndex = 3;
            // 
            // emailLbl
            // 
            this.emailLbl.AutoSize = true;
            this.emailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.emailLbl.Location = new System.Drawing.Point(40, 15);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(118, 20);
            this.emailLbl.TabIndex = 4;
            this.emailLbl.Text = "E-mail adress:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.passwordLbl.Location = new System.Drawing.Point(40, 62);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(112, 20);
            this.passwordLbl.TabIndex = 5;
            this.passwordLbl.Text = "Wachtwoord: ";
            // 
            // instructionsLbl
            // 
            this.instructionsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.instructionsLbl.Location = new System.Drawing.Point(7, 149);
            this.instructionsLbl.Name = "instructionsLbl";
            this.instructionsLbl.Size = new System.Drawing.Size(385, 89);
            this.instructionsLbl.TabIndex = 6;
            this.instructionsLbl.Text = "Als u nog geen account heeft vul uw e-mail adres boven in en een wachtwoord dat u" +
    " kunt onthouden en klik op de knop registreren.\r\n";
            // 
            // Startmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(396, 232);
            this.Controls.Add(this.instructionsLbl);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.emailLbl);
            this.Controls.Add(this.emailTbx);
            this.Controls.Add(this.passwordTbx);
            this.Controls.Add(this.startMenuRegisterBtn);
            this.Controls.Add(this.startMenuLogInBtn);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "Startmenu";
            this.Text = "Participation4All - Startmenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startMenuLogInBtn;
        private System.Windows.Forms.Button startMenuRegisterBtn;
        private System.Windows.Forms.TextBox passwordTbx;
        private System.Windows.Forms.TextBox emailTbx;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label instructionsLbl;
    }
}

