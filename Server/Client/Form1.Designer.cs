namespace Client
{
    partial class Client
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
            this.LaunchButton = new System.Windows.Forms.Button();
            this.AdressBox = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Selector1 = new System.Windows.Forms.ComboBox();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.ProgramLaunchCheckBox = new System.Windows.Forms.CheckBox();
            this.ProgramName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(344, 246);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(131, 53);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // AdressBox
            // 
            this.AdressBox.Location = new System.Drawing.Point(267, 54);
            this.AdressBox.Name = "AdressBox";
            this.AdressBox.Size = new System.Drawing.Size(276, 20);
            this.AdressBox.TabIndex = 1;
            this.AdressBox.Text = "IP or DNS";
            this.AdressBox.TextChanged += new System.EventHandler(this.AdressBox_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 309);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(794, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Selector1
            // 
            this.Selector1.FormattingEnabled = true;
            this.Selector1.Location = new System.Drawing.Point(267, 98);
            this.Selector1.Name = "Selector1";
            this.Selector1.Size = new System.Drawing.Size(276, 21);
            this.Selector1.TabIndex = 3;
            this.Selector1.SelectedIndexChanged += new System.EventHandler(this.Selector1_SelectedIndexChanged);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(391, 203);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(42, 13);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Version";
            // 
            // ProgramLaunchCheckBox
            // 
            this.ProgramLaunchCheckBox.AutoSize = true;
            this.ProgramLaunchCheckBox.Checked = true;
            this.ProgramLaunchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ProgramLaunchCheckBox.Location = new System.Drawing.Point(267, 148);
            this.ProgramLaunchCheckBox.Name = "ProgramLaunchCheckBox";
            this.ProgramLaunchCheckBox.Size = new System.Drawing.Size(109, 17);
            this.ProgramLaunchCheckBox.TabIndex = 5;
            this.ProgramLaunchCheckBox.Text = "Launch program?";
            this.ProgramLaunchCheckBox.UseVisualStyleBackColor = true;
            this.ProgramLaunchCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ProgramName
            // 
            this.ProgramName.Location = new System.Drawing.Point(382, 148);
            this.ProgramName.Name = "ProgramName";
            this.ProgramName.Size = new System.Drawing.Size(161, 20);
            this.ProgramName.TabIndex = 6;
            this.ProgramName.Text = "Program name to launch";
            this.ProgramName.TextChanged += new System.EventHandler(this.ProgramName_TextChanged);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 346);
            this.Controls.Add(this.ProgramName);
            this.Controls.Add(this.ProgramLaunchCheckBox);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.Selector1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.AdressBox);
            this.Controls.Add(this.LaunchButton);
            this.Name = "Client";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.TextBox AdressBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox Selector1;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.CheckBox ProgramLaunchCheckBox;
        private System.Windows.Forms.TextBox ProgramName;
    }
}

