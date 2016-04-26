namespace Participation.Unspecified_Profile.GUI
{
    partial class ViewVog
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
            this.pbVog = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbVog)).BeginInit();
            this.SuspendLayout();
            // 
            // pbVog
            // 
            this.pbVog.Location = new System.Drawing.Point(12, 12);
            this.pbVog.Name = "pbVog";
            this.pbVog.Size = new System.Drawing.Size(562, 487);
            this.pbVog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVog.TabIndex = 0;
            this.pbVog.TabStop = false;
            this.pbVog.SizeChanged += new System.EventHandler(this.sizeChanged);
            // 
            // ViewVog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 511);
            this.Controls.Add(this.pbVog);
            this.Name = "ViewVog";
            this.Text = "ViewVog";
            this.Load += new System.EventHandler(this.ViewVog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbVog;
    }
}