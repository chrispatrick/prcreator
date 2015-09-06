namespace JiraGitHubPRCreator
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtJiraBugId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrTitle = new System.Windows.Forms.TextBox();
            this.txtLongDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.chk8 = new System.Windows.Forms.CheckBox();
            this.chk81 = new System.Windows.Forms.CheckBox();
            this.chkNext = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPersonalAccessToken = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 43);
            this.button1.TabIndex = 9;
            this.button1.Text = "Make Pull Requests!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtJiraBugId
            // 
            this.txtJiraBugId.Location = new System.Drawing.Point(105, 43);
            this.txtJiraBugId.Name = "txtJiraBugId";
            this.txtJiraBugId.Size = new System.Drawing.Size(330, 20);
            this.txtJiraBugId.TabIndex = 1;
            this.txtJiraBugId.Text = "MI-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "JIRA Bug ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "PR Title text";
            // 
            // txtPrTitle
            // 
            this.txtPrTitle.Location = new System.Drawing.Point(105, 69);
            this.txtPrTitle.Name = "txtPrTitle";
            this.txtPrTitle.Size = new System.Drawing.Size(330, 20);
            this.txtPrTitle.TabIndex = 2;
            // 
            // txtLongDescription
            // 
            this.txtLongDescription.Location = new System.Drawing.Point(105, 95);
            this.txtLongDescription.Multiline = true;
            this.txtLongDescription.Name = "txtLongDescription";
            this.txtLongDescription.Size = new System.Drawing.Size(330, 104);
            this.txtLongDescription.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Long description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Your branch";
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(105, 17);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(330, 20);
            this.txtBranchName.TabIndex = 0;
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.Location = new System.Drawing.Point(105, 225);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(56, 17);
            this.chk7.TabIndex = 4;
            this.chk7.Text = "MI 7.0";
            this.chk7.UseVisualStyleBackColor = true;
            // 
            // chk8
            // 
            this.chk8.AutoSize = true;
            this.chk8.Location = new System.Drawing.Point(105, 248);
            this.chk8.Name = "chk8";
            this.chk8.Size = new System.Drawing.Size(56, 17);
            this.chk8.TabIndex = 5;
            this.chk8.Text = "MI 8.0";
            this.chk8.UseVisualStyleBackColor = true;
            // 
            // chk81
            // 
            this.chk81.AutoSize = true;
            this.chk81.Location = new System.Drawing.Point(105, 271);
            this.chk81.Name = "chk81";
            this.chk81.Size = new System.Drawing.Size(56, 17);
            this.chk81.TabIndex = 6;
            this.chk81.Text = "MI 8.1";
            this.chk81.UseVisualStyleBackColor = true;
            // 
            // chkNext
            // 
            this.chkNext.AutoSize = true;
            this.chkNext.Location = new System.Drawing.Point(105, 294);
            this.chkNext.Name = "chkNext";
            this.chkNext.Size = new System.Drawing.Size(61, 17);
            this.chkNext.TabIndex = 7;
            this.chkNext.Text = "MI next";
            this.chkNext.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Your \"Personal access token\"";
            // 
            // txtPersonalAccessToken
            // 
            this.txtPersonalAccessToken.Location = new System.Drawing.Point(671, 20);
            this.txtPersonalAccessToken.Name = "txtPersonalAccessToken";
            this.txtPersonalAccessToken.Size = new System.Drawing.Size(330, 20);
            this.txtPersonalAccessToken.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "(You need to set this up in GitHub in Settings. This will infer your username)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 346);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPersonalAccessToken);
            this.Controls.Add(this.chkNext);
            this.Controls.Add(this.chk81);
            this.Controls.Add(this.chk8);
            this.Controls.Add(this.chk7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLongDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJiraBugId);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtJiraBugId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrTitle;
        private System.Windows.Forms.TextBox txtLongDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.CheckBox chk7;
        private System.Windows.Forms.CheckBox chk8;
        private System.Windows.Forms.CheckBox chk81;
        private System.Windows.Forms.CheckBox chkNext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPersonalAccessToken;
        private System.Windows.Forms.Label label6;
    }
}

