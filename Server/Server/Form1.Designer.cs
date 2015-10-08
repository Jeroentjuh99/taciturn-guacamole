namespace Server
{
    partial class Server
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
            this.FolderButton = new System.Windows.Forms.Button();
            this.ServerStatus = new System.Windows.Forms.Label();
            this.IpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FolderButton
            // 
            this.FolderButton.Location = new System.Drawing.Point(55, 74);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(100, 36);
            this.FolderButton.TabIndex = 0;
            this.FolderButton.Text = "Open Folder";
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
            // 
            // ServerStatus
            // 
            this.ServerStatus.AutoSize = true;
            this.ServerStatus.ForeColor = System.Drawing.Color.Red;
            this.ServerStatus.Location = new System.Drawing.Point(87, 22);
            this.ServerStatus.Name = "ServerStatus";
            this.ServerStatus.Size = new System.Drawing.Size(37, 13);
            this.ServerStatus.TabIndex = 1;
            this.ServerStatus.Text = "Offline";
            this.ServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ServerStatus.Click += new System.EventHandler(this.label1_Click);
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(87, 48);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(21, 13);
            this.IpLabel.TabIndex = 2;
            this.IpLabel.Text = "ip: ";
            this.IpLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 122);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.ServerStatus);
            this.Controls.Add(this.FolderButton);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.Label ServerStatus;
        private System.Windows.Forms.Label IpLabel;
    }
}

