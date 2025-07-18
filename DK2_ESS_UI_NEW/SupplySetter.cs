using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DK2_ESS_UI_NEW
{
    public class SupplySetter
    {
        public static bool createLog = false;
        public static string logDir = Directory.GetCurrentDirectory() + "\\DK2 EasySupplySetter Logs\\";

        public static void Main1()
        {
            MessageBox.Show("This, on its own, doesnt do anything anymore. Please use the UI version.");
        }

        public static void SetSupply(string dir, int newSupply)
        {
            List<string> filesChanged = new List<string>();

            foreach (string file in Directory.GetFiles(dir, "*unit*.xml", SearchOption.AllDirectories))
            {
                string[] lines = File.ReadAllLines(file);
                bool fileChanged = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string pattern = @"supply=""[^""]*""";
                    string replacement = $"supply=\"{newSupply}\"";

                    string updatedLine = Regex.Replace(lines[i], pattern, replacement);

                    if (updatedLine != lines[i])
                    {
                        lines[i] = updatedLine;
                        fileChanged = true;
                    }
                }

                if (fileChanged)
                {
                    File.WriteAllLines(file, lines);
                    if (createLog)
                    {
                        filesChanged.Add(file);
                    }
                }
            }

            if (createLog)
            {
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                string settingsFilePath = Path.Combine(logDir, $"DK2_ESS_Log_{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt");
                using (StreamWriter writer = new StreamWriter(settingsFilePath))
                {
                    writer.WriteLine($"[Door Kickers 2 EasySupplySetter]");
                    writer.WriteLine($"[Made by Mocbuilder]");
                    writer.WriteLine($"[More: https://github.com/Mocbuilder/Temp_program]");
                    writer.WriteLine($"Log created at: {DateTime.Now}");
                    writer.WriteLine($"New supply value: {newSupply}");
                    foreach (string changedFile in filesChanged)
                    {
                        writer.WriteLine($"File changed: {changedFile}");
                    }
                    writer.WriteLine($"Total files changed: {filesChanged.Count}");
                    writer.WriteLine($"Log finished.");
                }
            }
        }
    }
}
