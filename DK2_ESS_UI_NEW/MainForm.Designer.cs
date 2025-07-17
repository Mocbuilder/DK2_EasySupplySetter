namespace DK2_ESS_UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            main_folderBrowserDialog = new FolderBrowserDialog();
            newValue_textBox = new TextBox();
            newValue_label = new Label();
            modsFolder_label = new Label();
            modsFolder_pictureBox = new PictureBox();
            modsFolder_roundedButton = new RoundedButton();
            confirm_roundedButton = new RoundedButton();
            settings_Button = new Button();
            button1 = new Button();
            selection_tabControl = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)modsFolder_pictureBox).BeginInit();
            selection_tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // newValue_textBox
            // 
            newValue_textBox.BackColor = SystemColors.ControlDark;
            newValue_textBox.BorderStyle = BorderStyle.None;
            newValue_textBox.Location = new Point(62, 68);
            newValue_textBox.Name = "newValue_textBox";
            newValue_textBox.Size = new Size(118, 18);
            newValue_textBox.TabIndex = 0;
            newValue_textBox.Text = "1";
            // 
            // newValue_label
            // 
            newValue_label.AutoSize = true;
            newValue_label.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newValue_label.Location = new Point(62, 47);
            newValue_label.Name = "newValue_label";
            newValue_label.Size = new Size(118, 18);
            newValue_label.TabIndex = 1;
            newValue_label.Text = "New Value:";
            // 
            // modsFolder_label
            // 
            modsFolder_label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            modsFolder_label.AutoSize = true;
            modsFolder_label.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            modsFolder_label.Location = new Point(43, 30);
            modsFolder_label.Name = "modsFolder_label";
            modsFolder_label.Size = new Size(250, 18);
            modsFolder_label.TabIndex = 2;
            modsFolder_label.Text = "Mods Folder not found!";
            modsFolder_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // modsFolder_pictureBox
            // 
            modsFolder_pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            modsFolder_pictureBox.ErrorImage = DK2_ESS_UI_NEW.Properties.Resources.checkmark_green;
            modsFolder_pictureBox.Image = DK2_ESS_UI_NEW.Properties.Resources.cross_red;
            modsFolder_pictureBox.InitialImage = DK2_ESS_UI_NEW.Properties.Resources.cross_red;
            modsFolder_pictureBox.Location = new Point(43, 62);
            modsFolder_pictureBox.Name = "modsFolder_pictureBox";
            modsFolder_pictureBox.Size = new Size(89, 80);
            modsFolder_pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            modsFolder_pictureBox.TabIndex = 3;
            modsFolder_pictureBox.TabStop = false;
            // 
            // modsFolder_roundedButton
            // 
            modsFolder_roundedButton.BackColor = SystemColors.ControlDarkDark;
            modsFolder_roundedButton.FlatStyle = FlatStyle.Flat;
            modsFolder_roundedButton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modsFolder_roundedButton.Location = new Point(122, 62);
            modsFolder_roundedButton.Name = "modsFolder_roundedButton";
            modsFolder_roundedButton.Size = new Size(171, 80);
            modsFolder_roundedButton.TabIndex = 4;
            modsFolder_roundedButton.Text = "FIND FOLDER";
            modsFolder_roundedButton.UseVisualStyleBackColor = false;
            modsFolder_roundedButton.Click += modsFolder_roundedButton_Click;
            // 
            // confirm_roundedButton
            // 
            confirm_roundedButton.BackColor = SystemColors.ControlDarkDark;
            confirm_roundedButton.FlatStyle = FlatStyle.Flat;
            confirm_roundedButton.Font = new Font("Lucida Console", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            confirm_roundedButton.Location = new Point(43, 322);
            confirm_roundedButton.Name = "confirm_roundedButton";
            confirm_roundedButton.Size = new Size(250, 79);
            confirm_roundedButton.TabIndex = 5;
            confirm_roundedButton.Text = "SET SUPPLY";
            confirm_roundedButton.UseVisualStyleBackColor = false;
            confirm_roundedButton.Click += confirm_roundedButton_Click;
            // 
            // settings_Button
            // 
            settings_Button.BackgroundImage = DK2_ESS_UI_NEW.Properties.Resources.gear;
            settings_Button.BackgroundImageLayout = ImageLayout.Zoom;
            settings_Button.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            settings_Button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            settings_Button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            settings_Button.FlatStyle = FlatStyle.Flat;
            settings_Button.Image = DK2_ESS_UI_NEW.Properties.Resources.gear;
            settings_Button.Location = new Point(2, 407);
            settings_Button.Name = "settings_Button";
            settings_Button.Size = new Size(51, 49);
            settings_Button.TabIndex = 6;
            settings_Button.UseVisualStyleBackColor = true;
            settings_Button.Click += settings_Button_Click;
            // 
            // button1
            // 
            button1.Location = new Point(153, 415);
            button1.Name = "button1";
            button1.Size = new Size(140, 29);
            button1.TabIndex = 7;
            button1.Text = "SelectionForm";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // selection_tabControl
            // 
            selection_tabControl.Controls.Add(tabPage1);
            selection_tabControl.Controls.Add(tabPage2);
            selection_tabControl.Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selection_tabControl.Location = new Point(43, 148);
            selection_tabControl.Name = "selection_tabControl";
            selection_tabControl.SelectedIndex = 0;
            selection_tabControl.Size = new Size(250, 176);
            selection_tabControl.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.ControlDarkDark;
            tabPage1.Controls.Add(newValue_label);
            tabPage1.Controls.Add(newValue_textBox);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(242, 144);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Global";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.ControlDarkDark;
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(242, 144);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Single";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(335, 458);
            Controls.Add(selection_tabControl);
            Controls.Add(button1);
            Controls.Add(settings_Button);
            Controls.Add(confirm_roundedButton);
            Controls.Add(modsFolder_roundedButton);
            Controls.Add(modsFolder_pictureBox);
            Controls.Add(modsFolder_label);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "DK2 EasySupplySetter";
            ((System.ComponentModel.ISupportInitialize)modsFolder_pictureBox).EndInit();
            selection_tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog main_folderBrowserDialog;
        private TextBox newValue_textBox;
        private Label newValue_label;
        private Label modsFolder_label;
        private PictureBox modsFolder_pictureBox;
        private RoundedButton modsFolder_roundedButton;
        private RoundedButton confirm_roundedButton;
        private Button settings_Button;
        private Button button1;
        private TabControl selection_tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
