namespace Participation.ChatSysteem
{
    partial class ChatUsers
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
            this.lbxClients = new System.Windows.Forms.ListBox();
            this.btnStartChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxClients
            // 
            this.lbxClients.FormattingEnabled = true;
            this.lbxClients.ItemHeight = 16;
            this.lbxClients.Location = new System.Drawing.Point(13, 13);
            this.lbxClients.Margin = new System.Windows.Forms.Padding(4);
            this.lbxClients.Name = "lbxClients";
            this.lbxClients.Size = new System.Drawing.Size(199, 420);
            this.lbxClients.TabIndex = 1;
            // 
            // btnStartChat
            // 
            this.btnStartChat.Location = new System.Drawing.Point(234, 194);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(85, 23);
            this.btnStartChat.TabIndex = 2;
            this.btnStartChat.Text = "Start chat";
            this.btnStartChat.UseVisualStyleBackColor = true;
            this.btnStartChat.Click += new System.EventHandler(this.btnStartChat_Click);
            // 
            // ChatUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 450);
            this.Controls.Add(this.btnStartChat);
            this.Controls.Add(this.lbxClients);
            this.Name = "ChatUsers";
            this.Text = "ChatUsers";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxClients;
        private System.Windows.Forms.Button btnStartChat;
    }
}