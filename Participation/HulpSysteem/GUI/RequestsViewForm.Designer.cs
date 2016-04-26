namespace Participation.HulpSysteem.GUI
{
    partial class RequestsViewForm
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
            this.btnAddRequest = new System.Windows.Forms.Button();
            this.lbxRequests = new System.Windows.Forms.ListBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnHelprequests = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.gbForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbForm
            // 
            this.gbForm.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gbForm.Controls.Add(this.btnAddRequest);
            this.gbForm.Controls.Add(this.lbxRequests);
            this.gbForm.Location = new System.Drawing.Point(149, -10);
            this.gbForm.Margin = new System.Windows.Forms.Padding(4);
            this.gbForm.Name = "gbForm";
            this.gbForm.Padding = new System.Windows.Forms.Padding(4);
            this.gbForm.Size = new System.Drawing.Size(1199, 727);
            this.gbForm.TabIndex = 0;
            this.gbForm.TabStop = false;
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Location = new System.Drawing.Point(194, 545);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(415, 30);
            this.btnAddRequest.TabIndex = 1;
            this.btnAddRequest.Text = "Hulp Vragen";
            this.btnAddRequest.UseVisualStyleBackColor = true;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // lbxRequests
            // 
            this.lbxRequests.FormattingEnabled = true;
            this.lbxRequests.ItemHeight = 16;
            this.lbxRequests.Location = new System.Drawing.Point(194, 87);
            this.lbxRequests.Name = "lbxRequests";
            this.lbxRequests.Size = new System.Drawing.Size(415, 452);
            this.lbxRequests.TabIndex = 0;
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
            // btnHelprequests
            // 
            this.btnHelprequests.Location = new System.Drawing.Point(13, 49);
            this.btnHelprequests.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelprequests.Name = "btnHelprequests";
            this.btnHelprequests.Size = new System.Drawing.Size(125, 28);
            this.btnHelprequests.TabIndex = 2;
            this.btnHelprequests.Text = "Hulp Vragen";
            this.btnHelprequests.UseVisualStyleBackColor = true;
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
            // 
            // RequestsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1011, 703);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnHelprequests);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.gbForm);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RequestsViewForm";
            this.Text = "Profiel";
            this.gbForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbForm;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnHelprequests;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.ListBox lbxRequests;
    }
}