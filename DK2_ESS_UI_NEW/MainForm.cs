using DK2_ESS_UI_NEW;
using DK2_ESS_UI_NEW.Properties;
using System.IO;

namespace DK2_ESS_UI
{
    public partial class MainForm : Form
    {

        public static string modsFolderPath;
        DialogResult dialogResult;
        SettingsForm settingsForm = new SettingsForm();

        public MainForm()
        {
            InitializeComponent();
            this.ActiveControl = modsFolder_label;
            modsFolderPath = Directory.GetCurrentDirectory();
            DirectoryInfo dir = Directory.GetParent(modsFolderPath);
            modsFolderPath = dir.FullName;

            settingsForm.ReadSettingFromFile();
            SetFolderFoundUI(CheckModsFolderPath(modsFolderPath));
        }

        public static bool CheckModsFolderPath(string path)
        {
            if (!path.Contains("steamapps\\workshop\\content\\1239080"))
            {
                return false;
            }
            return true;
        }

        public void SetFolderFoundUI(bool isFound)
        {
            if (isFound)
            {
                modsFolder_label.Text = "Mods folder found!";
                modsFolder_pictureBox.Image = Resources.checkmark_green;
                modsFolder_roundedButton.Enabled = false;
            }
            else
            {
                modsFolder_label.Text = "Mods folder not found!";
                modsFolder_pictureBox.Image = Resources.cross_red;
                modsFolder_roundedButton.Enabled = true;
            }
        }

        private void modsFolder_roundedButton_Click(object sender, EventArgs e)
        {
            main_folderBrowserDialog.SelectedPath = modsFolderPath;
            dialogResult = main_folderBrowserDialog.ShowDialog();
            modsFolderPath = dialogResult == DialogResult.OK ? main_folderBrowserDialog.SelectedPath : modsFolderPath;
            SetFolderFoundUI(CheckModsFolderPath(modsFolderPath));
        }

        private void settings_Button_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void confirm_roundedButton_Click(object sender, EventArgs e)
        {
            if (!CheckModsFolderPath(modsFolderPath))
            {
                MessageBox.Show("Please select a valid mods folder path first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }
                

            SupplySetter.SetSupply(modsFolderPath, int.Parse(newValue_textBox.Text));
            MessageBox.Show("Supply values set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            UnitSelectionForm unitSelectionForm = new UnitSelectionForm(modsFolderPath);
            if (!unitSelectionForm.pleaseClose)
            {
                unitSelectionForm.ShowDialog();
            }
            else
            {
                unitSelectionForm.Close();
            }
            
            Cursor.Current = Cursors.Default;
        }
    }
}
