namespace DK2_ESS_UI_NEW
{
    partial class UnitSelectionForm
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
            treeView1 = new TreeView();
            name_label = new Label();
            debugName_label = new Label();
            desc1_label = new Label();
            values_label = new Label();
            value1_label = new Label();
            value2_label = new Label();
            desc2_label = new Label();
            value1_textBox = new TextBox();
            value2_textBox = new TextBox();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.BackColor = SystemColors.ControlDarkDark;
            treeView1.Location = new Point(0, 0);
            treeView1.Margin = new Padding(3, 2, 3, 2);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(456, 429);
            treeView1.TabIndex = 0;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("Lucida Console", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name_label.Location = new Point(476, 22);
            name_label.Name = "name_label";
            name_label.Size = new Size(87, 20);
            name_label.TabIndex = 1;
            name_label.Text = "Unkown";
            // 
            // debugName_label
            // 
            debugName_label.AutoSize = true;
            debugName_label.Location = new Point(476, 52);
            debugName_label.Name = "debugName_label";
            debugName_label.Size = new Size(107, 18);
            debugName_label.TabIndex = 2;
            debugName_label.Text = "debugName";
            // 
            // desc1_label
            // 
            desc1_label.AutoSize = true;
            desc1_label.Location = new Point(476, 97);
            desc1_label.Name = "desc1_label";
            desc1_label.Size = new Size(63, 18);
            desc1_label.TabIndex = 3;
            desc1_label.Text = "desc1";
            // 
            // values_label
            // 
            values_label.AutoSize = true;
            values_label.Font = new Font("Lucida Console", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            values_label.Location = new Point(476, 222);
            values_label.Name = "values_label";
            values_label.Size = new Size(87, 20);
            values_label.TabIndex = 4;
            values_label.Text = "Values";
            // 
            // value1_label
            // 
            value1_label.AutoSize = true;
            value1_label.Location = new Point(476, 278);
            value1_label.Name = "value1_label";
            value1_label.Size = new Size(74, 18);
            value1_label.TabIndex = 5;
            value1_label.Text = "value1";
            // 
            // value2_label
            // 
            value2_label.AutoSize = true;
            value2_label.Location = new Point(476, 336);
            value2_label.Name = "value2_label";
            value2_label.Size = new Size(74, 18);
            value2_label.TabIndex = 6;
            value2_label.Text = "value2";
            // 
            // desc2_label
            // 
            desc2_label.AutoSize = true;
            desc2_label.Location = new Point(476, 148);
            desc2_label.Name = "desc2_label";
            desc2_label.Size = new Size(63, 18);
            desc2_label.TabIndex = 7;
            desc2_label.Text = "desc2";
            desc2_label.Click += desc2_label_Click;
            // 
            // value1_textBox
            // 
            value1_textBox.BackColor = SystemColors.ControlDark;
            value1_textBox.BorderStyle = BorderStyle.FixedSingle;
            value1_textBox.Location = new Point(600, 271);
            value1_textBox.Name = "value1_textBox";
            value1_textBox.Size = new Size(206, 25);
            value1_textBox.TabIndex = 8;
            // 
            // value2_textBox
            // 
            value2_textBox.BackColor = SystemColors.ControlDark;
            value2_textBox.BorderStyle = BorderStyle.FixedSingle;
            value2_textBox.Location = new Point(600, 329);
            value2_textBox.Name = "value2_textBox";
            value2_textBox.Size = new Size(206, 25);
            value2_textBox.TabIndex = 9;
            // 
            // UnitSelectionForm
            // 
            AutoScaleDimensions = new SizeF(11F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(880, 429);
            Controls.Add(value2_textBox);
            Controls.Add(value1_textBox);
            Controls.Add(desc2_label);
            Controls.Add(value2_label);
            Controls.Add(value1_label);
            Controls.Add(values_label);
            Controls.Add(desc1_label);
            Controls.Add(debugName_label);
            Controls.Add(name_label);
            Controls.Add(treeView1);
            Font = new Font("Lucida Console", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UnitSelectionForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "UnitSelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Label name_label;
        private Label debugName_label;
        private Label desc1_label;
        private Label values_label;
        private Label value1_label;
        private Label value2_label;
        private Label desc2_label;
        private TextBox value1_textBox;
        private TextBox value2_textBox;
    }
}