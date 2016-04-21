namespace Participation.BeheerSysteem.GUI
{
    partial class AdministratorRights
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
            this.rbtHasRights = new System.Windows.Forms.RadioButton();
            this.rbtnDoesntHaveRights = new System.Windows.Forms.RadioButton();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblRightsDescription = new System.Windows.Forms.Label();
            this.btnCommitAdminRights = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtHasRights
            // 
            this.rbtHasRights.AutoSize = true;
            this.rbtHasRights.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtHasRights.Location = new System.Drawing.Point(13, 13);
            this.rbtHasRights.Name = "rbtHasRights";
            this.rbtHasRights.Size = new System.Drawing.Size(180, 17);
            this.rbtHasRights.TabIndex = 0;
            this.rbtHasRights.TabStop = true;
            this.rbtHasRights.Text = "Heeft geen Administratorrechten.";
            this.rbtHasRights.UseVisualStyleBackColor = true;
            // 
            // rbtnDoesntHaveRights
            // 
            this.rbtnDoesntHaveRights.AutoSize = true;
            this.rbtnDoesntHaveRights.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rbtnDoesntHaveRights.Location = new System.Drawing.Point(13, 37);
            this.rbtnDoesntHaveRights.Name = "rbtnDoesntHaveRights";
            this.rbtnDoesntHaveRights.Size = new System.Drawing.Size(153, 17);
            this.rbtnDoesntHaveRights.TabIndex = 1;
            this.rbtnDoesntHaveRights.TabStop = true;
            this.rbtnDoesntHaveRights.Text = "Heeft Administratorrechten.";
            this.rbtnDoesntHaveRights.UseVisualStyleBackColor = true;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUserName.Location = new System.Drawing.Point(13, 75);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Naam Naamsen";
            // 
            // lblRightsDescription
            // 
            this.lblRightsDescription.AutoSize = true;
            this.lblRightsDescription.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRightsDescription.Location = new System.Drawing.Point(13, 92);
            this.lblRightsDescription.Name = "lblRightsDescription";
            this.lblRightsDescription.Size = new System.Drawing.Size(313, 13);
            this.lblRightsDescription.TabIndex = 3;
            this.lblRightsDescription.Text = "Deze gebruiker heeft momenteen wel/geen administratorrechten!";
            // 
            // btnCommitAdminRights
            // 
            this.btnCommitAdminRights.Location = new System.Drawing.Point(226, 13);
            this.btnCommitAdminRights.Name = "btnCommitAdminRights";
            this.btnCommitAdminRights.Size = new System.Drawing.Size(87, 58);
            this.btnCommitAdminRights.TabIndex = 4;
            this.btnCommitAdminRights.Text = "Bevestig";
            this.btnCommitAdminRights.UseVisualStyleBackColor = true;
            this.btnCommitAdminRights.Click += new System.EventHandler(this.btnCommitAdminRights_Click);
            // 
            // AdministratorRights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(357, 113);
            this.Controls.Add(this.btnCommitAdminRights);
            this.Controls.Add(this.lblRightsDescription);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.rbtnDoesntHaveRights);
            this.Controls.Add(this.rbtHasRights);
            this.Name = "AdministratorRights";
            this.Text = "Verander rechten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtHasRights;
        private System.Windows.Forms.RadioButton rbtnDoesntHaveRights;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRightsDescription;
        private System.Windows.Forms.Button btnCommitAdminRights;
    }
}