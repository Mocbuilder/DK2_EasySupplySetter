using DK2_ESS_UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DK2_ESS_UI_NEW
{
    public class ModIndexer
    {
        //Index all mod.xml and their associated *unit*.xml files and then group them as a "Mod" class. Then make an interface to display
        //them a list view or smth (maybe a tree view if possible ?) to select a new value for them inividually or select for bulk.

        public static List<string> invalidFiles = new List<string>();

        public static List<Mod> IndexMods(string modsFolderPath)
        {

            var mods = new List<Mod>();

            if (!Directory.Exists(modsFolderPath))
            {
                Console.WriteLine("Base directory does not exist.");
                return mods;
            }

            if (!MainForm.CheckModsFolderPath(modsFolderPath))
            {
                MessageBox.Show("Please select a valid mods folder path first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var modFolders = Directory.GetDirectories(modsFolderPath);

            foreach (var modFolder in modFolders)
            {
                string modXmlPath = Path.Combine(modFolder, "mod.xml");
                if (!File.Exists(modXmlPath))
                    continue;

                Mod newMod = CreateModFromXML(modXmlPath);

                if (File.Exists(modXmlPath))
                {
                    string unitsFolder = Path.Combine(modFolder, "units");
                    if (Directory.Exists(unitsFolder))
                    {
                        var matchingFiles = Directory.GetFiles(unitsFolder, "*.xml")
                            .Where(file => Path.GetFileName(file)
                            .ToLower().Contains("unit"));

                        foreach (var unitXmlPath in matchingFiles)
                        {
                            Unit newUnit = CreateUnitFromXML(unitXmlPath);

                            if (newUnit != null)
                            {
                                newMod.Units.Add(newUnit);
                            }
                        }
                    }
                }

                if (newMod.Units.Count > 0)
                {
                    mods.Add(newMod);
                }
            }

            return mods;
        }

        public static Mod CreateModFromXML(string modXmlPath)
        {
            string text = File.ReadAllText(modXmlPath);
            string title = "Unknown Mod";
            string author = "Unknown Author";


            var matchTitle = Regex.Match(text, @"title\s*=\s*""([^""]*)""");
            var matchAuthor = Regex.Match(text, @"author\s*=\s*""([^""]*)""");

            if (matchTitle.Success)
                title = matchTitle.Groups[1].Value;

            if (matchAuthor.Success)
                author = matchAuthor.Groups[1].Value;
            else
            {
                title = matchTitle.Groups[1].Value;
                author = matchAuthor.Groups[1].Value;
            }

            string modFolderPath = Path.GetDirectoryName(modXmlPath);

            Mod mod = new Mod(title, author, modFolderPath);
            return mod;
        }

        public static Unit CreateUnitFromXML(string unitXmlPath)
        {
            //first read the xml and get the trooperClasses
            if(invalidFiles.Contains(unitXmlPath))
                return null;

            string unitName = "Unknown Unit";
            List<TrooperClass> trooperClasses = new List<TrooperClass>();

            XElement root;
            try
            {
                root = XElement.Load(unitXmlPath);
            }
            catch (Exception exception)
            {
                if (SupplySetter.createLog)
                {
                    bool logDirExists = false;
                    string text = "";

                    string errorLogDir = Path.Combine(SupplySetter.logDir + $"DK2_ESS_Error_Log_{DateTime.Now.ToString("yyyy-mm-dd")}.txt");

                    if (File.Exists(errorLogDir))
                    {
                        logDirExists = true;
                        text = File.ReadAllText(errorLogDir);
                    }
    
                    using (StreamWriter writer = new StreamWriter(errorLogDir))
                    {
                        writer.WriteLine(text);
                        if (!logDirExists)
                        {
                            writer.WriteLine($"[Door Kickers 2 EasySupplySetter]");
                            writer.WriteLine($"[Made by Mocbuilder]");
                            writer.WriteLine($"[More: https://github.com/Mocbuilder/Temp_program]");
                            writer.WriteLine($"[If you contact me about this Error, please also send this file.]");
                            writer.WriteLine($"[Error Log created at: {DateTime.Now}]");
                        }

                        if(logDirExists)
                            writer.WriteLine($"[Error Log created at: {DateTime.Now}]");

                        writer.WriteLine($"Error reading unit XML file: {unitXmlPath}");
                        writer.WriteLine($"[Exception] \n{exception.Message}");
                        writer.WriteLine($"[Stack Trace] \n{exception.StackTrace}");
                        writer.WriteLine($"[Error log finished]");
                    }
                }


                invalidFiles.Add(unitXmlPath);
                //For some reason the error message repeats infinitly for each invalid file, so its just not shown anymore.
                //MessageBox.Show("Error reading unit XML file:\n" + unitXmlPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Extract the Unit element
            var unitElement = root.Element("Unit");

            if (unitElement != null)
            {
                // Get the Unit nameUI
                unitName = unitElement.Attribute("nameUI")?.Value ?? "Untitled Unit";

                // Extract Class elements
                var classElements = unitElement
                    .Element("Classes")?
                    .Elements("Class");

                if (classElements != null)
                {
                    foreach (var cls in classElements)
                    {
                        string className = cls.Attribute("name")?.Value ?? "Unnamed";
                        string classNameUI = cls.Attribute("nameUI")?.Value ?? "Unnamed";
                        string numSlots = cls.Attribute("numslots")?.Value ?? "0";
                        string supply = cls.Attribute("supply")?.Value ?? "100";

                        TrooperClass newTrooperClass = new TrooperClass(
                            className,
                            classNameUI,
                            int.TryParse(numSlots, out int slots) ? slots : 0,
                            int.TryParse(supply, out int supplyValue) ? supplyValue : 100
                        );

                        trooperClasses.Add(newTrooperClass);
                    }
                }
            }

            Unit newUnit = new Unit(unitName, trooperClasses);
            return newUnit;
        }

        public static string CheckForAlias(string name, Mod sourceMod)
        {
            List<Mod> mods = IndexMods(MainForm.modsFolderPath);
            Tuple<bool, string> alias = FindAlias(name, sourceMod);

            if (alias.Item1 == false)
                return name;

            return alias.Item2;
        }

        public static Tuple<bool, string> FindAlias(string name, Mod sourceMod)
        {
            Tuple<bool, string> result = new Tuple<bool, string>(false, name);

            string localizationFolder = Path.Combine(sourceMod.FolderPath, "localization");
            if (Directory.Exists(localizationFolder))
            {
                var matchingFiles = Directory.GetFiles(localizationFolder, "*.txt");
                
                foreach (string file in matchingFiles)
                {
                    foreach (string lineRaw in File.ReadAllLines(file))
                    {
                        string line = lineRaw.Replace("\uFEFF", "").Trim();

                        if (!line.StartsWith("@") || !line.Contains("="))
                            continue;

                        int equalsIndex = line.IndexOf('=');
                        string key = line.Substring(0, equalsIndex).Trim();
                        string value = line.Substring(equalsIndex + 1).Trim();

                        if (key == name.Trim())
                        {
                            return Tuple.Create(true, value);
                        }
                    }
                }
                
            }

            return result;
        }
    }
}
