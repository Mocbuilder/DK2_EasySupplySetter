using DK2_ESS_UI_NEW;
using DK2_ESS_UI_NEW.Properties;
using System.IO;

namespace DK2_ESS_UI
{
    public partial class MainForm : Form
    {

        public static string modsFolderPath;
        DialogResult dialogResult;

        public MainForm()
        {
            InitializeComponent();
            this.ActiveControl = modsFolder_label;
            modsFolderPath = Directory.GetCurrentDirectory();
            DirectoryInfo dir = Directory.GetParent(modsFolderPath);
            modsFolderPath = dir.FullName;
            SetFolderFoundUI(CheckModsFolderPath());
        }

        public static bool CheckModsFolderPath()
        {
            if (!modsFolderPath.Contains("steamapps\\workshop\\content\\1239080"))
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
            SetFolderFoundUI(CheckModsFolderPath());
        }

        private void settings_Button_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void confirm_roundedButton_Click(object sender, EventArgs e)
        {

            SupplySetter.SetSupply(modsFolderPath, int.Parse(newValue_textBox.Text));
            MessageBox.Show("Supply values set successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
