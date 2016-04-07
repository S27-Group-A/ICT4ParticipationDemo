namespace UI
{
    partial class Hulpvragen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hulpvragen));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.patientsLbl = new System.Windows.Forms.Label();
            this.commentGb = new System.Windows.Forms.GroupBox();
            this.commentBtn = new System.Windows.Forms.Button();
            this.commentLbl = new System.Windows.Forms.Label();
            this.reviewGb = new System.Windows.Forms.GroupBox();
            this.review = new System.Windows.Forms.GroupBox();
            this.reviewContentLbl = new System.Windows.Forms.Label();
            this.reviewerLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.requestContentLbl = new System.Windows.Forms.Label();
            this.profilePb = new System.Windows.Forms.PictureBox();
            this.patientLbl = new System.Windows.Forms.Label();
            this.requestTitleLbl = new System.Windows.Forms.Label();
            this.patientsLbx = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.commentGb.SuspendLayout();
            this.reviewGb.SuspendLayout();
            this.review.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.patientsLbl);
            this.groupBox1.Controls.Add(this.commentGb);
            this.groupBox1.Controls.Add(this.reviewGb);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.patientsLbx);
            this.groupBox1.Location = new System.Drawing.Point(93, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 447);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // patientsLbl
            // 
            this.patientsLbl.AutoSize = true;
            this.patientsLbl.Location = new System.Drawing.Point(6, 16);
            this.patientsLbl.Name = "patientsLbl";
            this.patientsLbl.Size = new System.Drawing.Size(91, 13);
            this.patientsLbl.TabIndex = 14;
            this.patientsLbl.Text = "Lijst van ouderen:";
            // 
            // commentGb
            // 
            this.commentGb.Controls.Add(this.commentBtn);
            this.commentGb.Controls.Add(this.commentLbl);
            this.commentGb.Location = new System.Drawing.Point(138, 184);
            this.commentGb.Name = "commentGb";
            this.commentGb.Size = new System.Drawing.Size(381, 100);
            this.commentGb.TabIndex = 13;
            this.commentGb.TabStop = false;
            // 
            // commentBtn
            // 
            this.commentBtn.Location = new System.Drawing.Point(294, 71);
            this.commentBtn.Name = "commentBtn";
            this.commentBtn.Size = new System.Drawing.Size(81, 23);
            this.commentBtn.TabIndex = 2;
            this.commentBtn.Text = "Plaats reactie";
            this.commentBtn.UseVisualStyleBackColor = true;
            // 
            // commentLbl
            // 
            this.commentLbl.AutoSize = true;
            this.commentLbl.Location = new System.Drawing.Point(9, 16);
            this.commentLbl.Name = "commentLbl";
            this.commentLbl.Size = new System.Drawing.Size(112, 13);
            this.commentLbl.TabIndex = 1;
            this.commentLbl.Text = "Schrijf hier een reactie";
            // 
            // reviewGb
            // 
            this.reviewGb.Controls.Add(this.review);
            this.reviewGb.Location = new System.Drawing.Point(132, 290);
            this.reviewGb.Name = "reviewGb";
            this.reviewGb.Size = new System.Drawing.Size(518, 176);
            this.reviewGb.TabIndex = 13;
            this.reviewGb.TabStop = false;
            this.reviewGb.Text = "Recenties";
            // 
            // review
            // 
            this.review.Controls.Add(this.reviewContentLbl);
            this.review.Controls.Add(this.reviewerLbl);
            this.review.Location = new System.Drawing.Point(6, 13);
            this.review.Name = "review";
            this.review.Size = new System.Drawing.Size(381, 100);
            this.review.TabIndex = 12;
            this.review.TabStop = false;
            // 
            // reviewContentLbl
            // 
            this.reviewContentLbl.AutoSize = true;
            this.reviewContentLbl.Location = new System.Drawing.Point(6, 31);
            this.reviewContentLbl.Name = "reviewContentLbl";
            this.reviewContentLbl.Size = new System.Drawing.Size(367, 52);
            this.reviewContentLbl.TabIndex = 1;
            this.reviewContentLbl.Text = resources.GetString("reviewContentLbl.Text");
            // 
            // reviewerLbl
            // 
            this.reviewerLbl.AutoSize = true;
            this.reviewerLbl.Location = new System.Drawing.Point(6, 16);
            this.reviewerLbl.Name = "reviewerLbl";
            this.reviewerLbl.Size = new System.Drawing.Size(235, 13);
            this.reviewerLbl.TabIndex = 0;
            this.reviewerLbl.Text = "Naam van de persoon die de recentie achterlaat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.requestContentLbl);
            this.groupBox2.Controls.Add(this.profilePb);
            this.groupBox2.Controls.Add(this.patientLbl);
            this.groupBox2.Controls.Add(this.requestTitleLbl);
            this.groupBox2.Location = new System.Drawing.Point(132, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // requestContentLbl
            // 
            this.requestContentLbl.AutoSize = true;
            this.requestContentLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestContentLbl.Location = new System.Drawing.Point(6, 96);
            this.requestContentLbl.Name = "requestContentLbl";
            this.requestContentLbl.Size = new System.Drawing.Size(379, 60);
            this.requestContentLbl.TabIndex = 11;
            this.requestContentLbl.Text = "Text Text Text Text Text Text Text Text Text Text Text\r\nText Text Text Text Text " +
    "Text Text Text Text Text Text\r\nText Text Text Text Text Text Text Text Text Text" +
    " Text\r\n";
            // 
            // profilePb
            // 
            this.profilePb.Location = new System.Drawing.Point(6, 19);
            this.profilePb.Name = "profilePb";
            this.profilePb.Size = new System.Drawing.Size(50, 50);
            this.profilePb.TabIndex = 10;
            this.profilePb.TabStop = false;
            // 
            // patientLbl
            // 
            this.patientLbl.AutoSize = true;
            this.patientLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientLbl.Location = new System.Drawing.Point(62, 19);
            this.patientLbl.Name = "patientLbl";
            this.patientLbl.Size = new System.Drawing.Size(78, 20);
            this.patientLbl.TabIndex = 9;
            this.patientLbl.Text = "John Doe";
            // 
            // requestTitleLbl
            // 
            this.requestTitleLbl.AutoSize = true;
            this.requestTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestTitleLbl.Location = new System.Drawing.Point(6, 72);
            this.requestTitleLbl.Name = "requestTitleLbl";
            this.requestTitleLbl.Size = new System.Drawing.Size(162, 20);
            this.requestTitleLbl.TabIndex = 8;
            this.requestTitleLbl.Text = "Titel van de hulpvraag";
            // 
            // patientsLbx
            // 
            this.patientsLbx.FormattingEnabled = true;
            this.patientsLbx.Location = new System.Drawing.Point(6, 32);
            this.patientsLbx.Name = "patientsLbx";
            this.patientsLbx.Size = new System.Drawing.Size(120, 394);
            this.patientsLbx.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 394);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "Log uit";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 186);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Beheer";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Chat";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Ouderen";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Hulpvragen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Profiel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Hulpvragen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Hulpvragen";
            this.Text = "Hulpvragen";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.commentGb.ResumeLayout(false);
            this.commentGb.PerformLayout();
            this.reviewGb.ResumeLayout(false);
            this.review.ResumeLayout(false);
            this.review.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilePb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox patientsLbx;
        private System.Windows.Forms.Label patientLbl;
        private System.Windows.Forms.Label requestTitleLbl;
        private System.Windows.Forms.Label requestContentLbl;
        private System.Windows.Forms.PictureBox profilePb;
        private System.Windows.Forms.GroupBox reviewGb;
        private System.Windows.Forms.GroupBox review;
        private System.Windows.Forms.Label reviewContentLbl;
        private System.Windows.Forms.Label reviewerLbl;
        private System.Windows.Forms.GroupBox commentGb;
        private System.Windows.Forms.Button commentBtn;
        private System.Windows.Forms.Label commentLbl;
        private System.Windows.Forms.Label patientsLbl;
    }
}