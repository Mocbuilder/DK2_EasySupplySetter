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

        public List<Mod> IndexMods(string modsFolderPath)
        {

            var mods = new List<Mod>();

            if (!Directory.Exists(modsFolderPath))
            {
                Console.WriteLine("Base directory does not exist.");
                return mods;
            }

            var modFolders = Directory.GetDirectories(modsFolderPath);

            foreach (var modFolder in modFolders)
            {
                string modXmlPath = Path.Combine(modFolder, "mod.xml");
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

        public Mod CreateModFromXML(string modXmlPath)
        {
            string text = File.ReadAllText(modXmlPath);
            string title = "Unknown Mod";
            string author = "Unknown Author";


            var matchTitle = Regex.Match(text, @"title\s*=\s*""([^""]*)""");
            var matchAuthor = Regex.Match(text, @"author\s*=\s*""([^""]*)""");

            if (!matchTitle.Success)
            {
                title = "Untitled Mod";
            }
            else if(!matchAuthor.Success)
            {
                author = "No Author";
            }
            else
            {
                title = matchTitle.Groups[1].Value;
                author = matchAuthor.Groups[1].Value;
            }

            Mod mod = new Mod(title, author);
            return mod;
        }

        public Unit CreateUnitFromXML(string unitXmlPath)
        {
            //first read the xml and get the trooperClasses

            string text = File.ReadAllText(unitXmlPath);
            string unitName = "Unknown Unit";
            List<TrooperClass> trooperClasses = new List<TrooperClass>();

            XElement root = XElement.Parse(text);

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
    }
}
