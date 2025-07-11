namespace DK2_ESS_UI
{
    partial class SettingsForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            save_roundedButton = new RoundedButton();
            gitrepobutton = new Button();
            profilebutton = new Button();
            createLog_checkBox = new CheckBox();
            logFolderSelect_roundedButton = new RoundedButton();
            settings_folderBrowserDialog = new FolderBrowserDialog();
            openSettingsFolder_roundedButton = new RoundedButton();
            saveSettings_checkBox = new CheckBox();
            settings_toolTip = new ToolTip(components);
            SuspendLayout();
            // 
            // save_roundedButton
            // 
            save_roundedButton.BackColor = SystemColors.ControlDarkDark;
            save_roundedButton.FlatStyle = FlatStyle.Flat;
            save_roundedButton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            save_roundedButton.Location = new Point(97, 359);
            save_roundedButton.Name = "save_roundedButton";
            save_roundedButton.Size = new Size(163, 79);
            save_roundedButton.TabIndex = 6;
            save_roundedButton.Text = "SAVE";
            save_roundedButton.UseVisualStyleBackColor = false;
            save_roundedButton.Click += save_roundedButton_Click;
            // 
            // gitrepobutton
            // 
            gitrepobutton.BackColor = SystemColors.ControlDarkDark;
            gitrepobutton.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            gitrepobutton.FlatStyle = FlatStyle.Flat;
            gitrepobutton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gitrepobutton.Location = new Point(97, 289);
            gitrepobutton.Name = "gitrepobutton";
            gitrepobutton.Size = new Size(163, 53);
            gitrepobutton.TabIndex = 7;
            gitrepobutton.Text = "Github Page";
            gitrepobutton.UseVisualStyleBackColor = false;
            gitrepobutton.Click += gitrepo_Button_Click;
            // 
            // profilebutton
            // 
            profilebutton.BackColor = SystemColors.ControlDarkDark;
            profilebutton.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            profilebutton.FlatStyle = FlatStyle.Flat;
            profilebutton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profilebutton.Location = new Point(97, 241);
            profilebutton.Name = "profilebutton";
            profilebutton.Size = new Size(163, 53);
            profilebutton.TabIndex = 8;
            profilebutton.Text = "Made by Mocbuilder";
            profilebutton.UseVisualStyleBackColor = false;
            profilebutton.Click += profile_button_Click;
            // 
            // createLog_checkBox
            // 
            createLog_checkBox.AutoSize = true;
            createLog_checkBox.BackColor = SystemColors.ControlDarkDark;
            createLog_checkBox.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createLog_checkBox.Location = new Point(97, 45);
            createLog_checkBox.Name = "createLog_checkBox";
            createLog_checkBox.Size = new Size(143, 21);
            createLog_checkBox.TabIndex = 9;
            createLog_checkBox.Text = "Create Log";
            settings_toolTip.SetToolTip(createLog_checkBox, "Create a Log of every changed file when editing supply values");
            createLog_checkBox.UseVisualStyleBackColor = false;
            createLog_checkBox.CheckedChanged += createLog_checkBox_CheckedChanged;
            // 
            // logFolderSelect_roundedButton
            // 
            logFolderSelect_roundedButton.BackColor = SystemColors.ControlDarkDark;
            logFolderSelect_roundedButton.FlatStyle = FlatStyle.Flat;
            logFolderSelect_roundedButton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logFolderSelect_roundedButton.Location = new Point(97, 72);
            logFolderSelect_roundedButton.Name = "logFolderSelect_roundedButton";
            logFolderSelect_roundedButton.Size = new Size(163, 51);
            logFolderSelect_roundedButton.TabIndex = 10;
            logFolderSelect_roundedButton.Text = "SET FOLDER";
            logFolderSelect_roundedButton.UseVisualStyleBackColor = false;
            logFolderSelect_roundedButton.Click += logFolderSelect_roundedButton_Click;
            // 
            // openSettingsFolder_roundedButton
            // 
            openSettingsFolder_roundedButton.BackColor = SystemColors.ControlDarkDark;
            openSettingsFolder_roundedButton.FlatStyle = FlatStyle.Flat;
            openSettingsFolder_roundedButton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            openSettingsFolder_roundedButton.Location = new Point(97, 173);
            openSettingsFolder_roundedButton.Name = "openSettingsFolder_roundedButton";
            openSettingsFolder_roundedButton.Size = new Size(163, 51);
            openSettingsFolder_roundedButton.TabIndex = 12;
            openSettingsFolder_roundedButton.Text = "OPEN FOLDER";
            openSettingsFolder_roundedButton.UseVisualStyleBackColor = false;
            openSettingsFolder_roundedButton.Click += openSettingsFolder_roundedButton_Click;
            // 
            // saveSettings_checkBox
            // 
            saveSettings_checkBox.AutoSize = true;
            saveSettings_checkBox.BackColor = SystemColors.ControlDarkDark;
            saveSettings_checkBox.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveSettings_checkBox.Location = new Point(97, 146);
            saveSettings_checkBox.Name = "saveSettings_checkBox";
            saveSettings_checkBox.Size = new Size(176, 21);
            saveSettings_checkBox.TabIndex = 11;
            saveSettings_checkBox.Text = "SAVE SETTINGS";
            settings_toolTip.SetToolTip(saveSettings_checkBox, "Save Settings for when you open the tool again");
            saveSettings_checkBox.UseVisualStyleBackColor = false;
            saveSettings_checkBox.CheckedChanged += saveSettings_checkBox_CheckedChanged;
            // 
            // settings_toolTip
            // 
            settings_toolTip.BackColor = SystemColors.ControlDarkDark;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(349, 450);
            ControlBox = false;
            Controls.Add(openSettingsFolder_roundedButton);
            Controls.Add(saveSettings_checkBox);
            Controls.Add(logFolderSelect_roundedButton);
            Controls.Add(createLog_checkBox);
            Controls.Add(profilebutton);
            Controls.Add(gitrepobutton);
            Controls.Add(save_roundedButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedButton save_roundedButton;
        private Button gitrepobutton;
        private Button profilebutton;
        private CheckBox createLog_checkBox;
        private RoundedButton logFolderSelect_roundedButton;
        private FolderBrowserDialog settings_folderBrowserDialog;
        private RoundedButton openSettingsFolder_roundedButton;
        private CheckBox saveSettings_checkBox;
        private ToolTip settings_toolTip;
    }
}