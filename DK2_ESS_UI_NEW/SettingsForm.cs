using DK2_ESS_UI_NEW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DK2_ESS_UI
{
    public partial class SettingsForm : Form
    {
        DialogResult dialogResult;
        string settingsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DK2 EasySupplySetter");
        bool saveSettings = false;

        public SettingsForm()
        {
            InitializeComponent();
            ReadSettingFromFile();
        }

        public void SaveSettingsToFile()
        {
            if (!Directory.Exists(settingsDir))
            {
                Directory.CreateDirectory(settingsDir);
            }

            string settingsFilePath = Path.Combine(settingsDir, "settings.ini");
            using (StreamWriter writer = new StreamWriter(settingsFilePath))
            {
                writer.WriteLine($"[Door Kickers 2 EasySupplySetter]");
                writer.WriteLine($"[Made by Mocbuilder]");
                writer.WriteLine($"[More: https://github.com/Mocbuilder/Temp_program]");
                writer.WriteLine($"createLog={Temp_program.createLog}");
                writer.WriteLine($"logDir={Temp_program.logDir}");
            }
        }

        public void ReadSettingFromFile()
        {
            string settingsFilePath = Path.Combine(settingsDir, "settings.ini");
            if (File.Exists(settingsFilePath))
            {
                using (StreamReader reader = new StreamReader(settingsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("createLog="))
                        {
                            Temp_program.createLog = bool.Parse(line.Split('=')[1]);
                            createLog_checkBox.Checked = Temp_program.createLog;
                        }
                        else if (line.StartsWith("logDir="))
                        {
                            Temp_program.logDir = line.Split('=')[1];
                        }
                    }
                }

                saveSettings = true;
                saveSettings_checkBox.Checked = saveSettings;
                return;
            }

            createLog_checkBox.Checked = Temp_program.createLog;
            saveSettings = false;
            saveSettings_checkBox.Checked = saveSettings;
            return;
        }

        private void gitrepo_Button_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/Mocbuilder/Temp_program");
        }

        private void profile_button_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/Mocbuilder");
        }

        private void save_roundedButton_Click(object sender, EventArgs e)
        {
            if (saveSettings)
            {
                SaveSettingsToFile();
            }
            else
            {
                File.Delete(Path.Combine(settingsDir, "settings.ini"));
            }
            this.Close();
        }

        private void createLog_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Temp_program.createLog = createLog_checkBox.Checked;
            if (!Directory.Exists(Temp_program.logDir))
            {
                Directory.CreateDirectory(Temp_program.logDir);
            }
        }

        private void logFolderSelect_roundedButton_Click(object sender, EventArgs e)
        {
            settings_folderBrowserDialog.SelectedPath = Temp_program.logDir;
            dialogResult = settings_folderBrowserDialog.ShowDialog();
            Temp_program.logDir = dialogResult == DialogResult.OK ? settings_folderBrowserDialog.SelectedPath : Temp_program.logDir;
        }

        private void saveSettings_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            saveSettings = saveSettings_checkBox.Checked;
            if (!Directory.Exists(settingsDir))
            {
                Directory.CreateDirectory(settingsDir);
            }
        }

        private void openSettingsFolder_roundedButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", settingsDir);
        }
    }
}
