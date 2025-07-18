using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DK2_ESS_UI_NEW
{
    public partial class UnitSelectionForm : Form
    {
        List<Mod> Mods = new List<Mod>();
        string ModFolderPath;
        public bool pleaseClose = false;
        public static List<DisplayObject> defaultValues = new List<DisplayObject>();

        public UnitSelectionForm(string modFolderPath)
        {
            InitializeComponent();

            treeView1.NodeMouseClick += treeView1_NodeMouseClick;

            ClearDisplay();
            HideDisplay();
            ModFolderPath = modFolderPath;
            Mods = ModIndexer.IndexMods(ModFolderPath);
            if (Mods == null || Mods.Count == 0)
            {
                MessageBox.Show("No mods found in the specified folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pleaseClose = true;
                return;
            }

            treeView1.Nodes.AddRange(ModsToTreeNodes().ToArray());
            Cursor.Current = Cursors.Default;
        }

        public List<TreeNode> ModsToTreeNodes()
        {
            List<TreeNode> ResultNodes = new List<TreeNode>();
            foreach (Mod _mod in Mods)
            {
                TreeNode newModNode = new TreeNode(ModIndexer.CheckForAlias(_mod.Name, _mod));
                newModNode.Tag = _mod;

                foreach (Unit _unit in _mod.Units)
                {
                    TreeNode newUnitNode = new TreeNode(ModIndexer.CheckForAlias(_unit.Name, _mod));
                    newUnitNode.Tag = _unit;
                    newModNode.Nodes.Add(newUnitNode);

                    foreach (TrooperClass _trooperClass in _unit.TrooperClasses)
                    {
                        TreeNode newTrooperClassNode = new TreeNode(ModIndexer.CheckForAlias(_trooperClass.NameUI, _mod));
                        newTrooperClassNode.Tag = _trooperClass;
                        newUnitNode.Nodes.Add(newTrooperClassNode);
                    }
                }

                ResultNodes.Add(newModNode);
            }

            return ResultNodes;
        }

        public DisplayObject TreeNodeToDisplayObject(TreeNode treeNode)
        {
            var sourceObject = treeNode.Tag;
            DisplayObject result = null;

            if (sourceObject is Mod)
            {
                Mod tempMod = sourceObject as Mod;
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    {"Name", tempMod.Name },
                    { "Author", tempMod.Author },
                    { "FolderPath", tempMod.FolderPath }
                };

                result = new DisplayObject(tempMod.Name, typeof(Mod), properties);
            }
            else if (sourceObject is Unit)
            {
                Unit tempUnit = sourceObject as Unit;
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    {"Name", ModIndexer.CheckForAlias(tempUnit.Name, treeNode.Parent.Tag as Mod) },
                };

                result = new DisplayObject(tempUnit.Name, typeof(Unit), properties);
            }
            else if (sourceObject is TrooperClass)
            {
                TrooperClass tempTrooperClass = sourceObject as TrooperClass;
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    {"Name", tempTrooperClass.Name },
                    {"NameUI", ModIndexer.CheckForAlias(tempTrooperClass.NameUI, treeNode.Parent.Parent.Tag as Mod) },
                    {"NumSlots", tempTrooperClass.NumSlots.ToString() },
                    {"Supply", tempTrooperClass.Supply.ToString() }
                };

                result = new DisplayObject(tempTrooperClass.Name, typeof(TrooperClass), properties);
            }
            else
            {
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    {"Name", "Unknown" },
                    {"Description", $"Object cant be parsed or displayed.\n{sourceObject.ToString()}" }
                };

                result = new DisplayObject("Unknown", typeof(UnknownObject), properties);
            }

            return result;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            HideDisplay();
            DisplayNode(TreeNodeToDisplayObject(e.Node));
        }

        public void DisplayNode(DisplayObject displayObject)
        {
            AddToDefaultValues(displayObject);

            if (displayObject.Type == typeof(Mod))
            {
                Dictionary<Control, string> controls = new Dictionary<Control, string>
                {
                    {name_label, displayObject.GetPropertie("Name")},
                    {desc1_label, displayObject.GetPropertie("Author")},
                    {desc1Title_label, "Author:"},
                    {desc2_label, displayObject.GetPropertie("FolderPath")},
                    {desc2Title_label, "Folder:"}
                };

                ShowControls(controls);
            }
            else if (displayObject.Type == typeof(Unit))
            {
                Dictionary<Control, string> controls = new Dictionary<Control, string>
                {
                    {name_label, displayObject.GetPropertie("Name")},
                };

                ShowControls(controls);
            }
            else if (displayObject.Type == typeof(TrooperClass))
            {
                Dictionary<Control, string> controls = new Dictionary<Control, string>
                {
                    {name_label, displayObject.GetPropertie("NameUI")},
                    {debugName_label, displayObject.GetPropertie("Name")},
                    {debugNameTitle_label, "Debug Name: "},
                    {value1_label, "NumSlots:"},
                    {value2_label, "Supply:"},
                    {value1_textBox, displayObject.GetPropertie("NumSlots")},
                    {value2_textBox, displayObject.GetPropertie("Supply")}
                };

                ShowControls(controls);
            }
            else
            {
                Dictionary<Control, string> controls = new Dictionary<Control, string>
                {
                    {name_label, displayObject.GetPropertie("Name")},
                    {desc1_label, displayObject.GetPropertie("Description")}
                };

                ShowControls(controls);
            }
        }

        public void ClearDisplay()
        {
            name_label.Text = "Unknown";
            debugName_label.Text = "Unknown";
            desc1_label.Text = "No description available.";
            desc2_label.Text = "";
            value1_label.Text = "";
            value2_label.Text = "";
            value1_textBox.Clear();
            value2_textBox.Clear();
        }

        public void HideDisplay()
        {
            debugName_label.Visible = false;
            debugNameTitle_label.Visible = false;
            desc1_label.Visible = false;
            desc2_label.Visible = false;
            desc1Title_label.Visible = false;
            desc2Title_label.Visible = false;
            value1_label.Visible = false;
            value2_label.Visible = false;
            value1_textBox.Visible = false;
            value2_textBox.Visible = false;
        }

        public void ShowControls(Dictionary<Control, string> controls)
        {
            HideDisplay();

            foreach (KeyValuePair<Control, string> item in controls)
            {
                item.Key.Text = item.Value;
                item.Key.Visible = true;
            }
        }

        public void RevealDisplay()
        {
            debugName_label.Visible = true;
            debugNameTitle_label.Visible = true;
            desc1_label.Visible = true;
            desc1Title_label.Visible = true;
            desc2Title_label.Visible = true;
            desc2_label.Visible = true;
            value1_label.Visible = true;
            value2_label.Visible = true;
            value1_textBox.Visible = true;
            value2_textBox.Visible = true;
        }

        private void desc2_label_Click(object sender, EventArgs e)
        {
            //open folder that is displayed
        }

        private void save_roundedButton_Click(object sender, EventArgs e)
        {
            AddToDefaultValues(InputToDisplayObject());
            //set supply/
        }

        public void AddToDefaultValues(DisplayObject displayObject)
        {
            var existing = defaultValues.FirstOrDefault(item => item.Name == displayObject.Name);

            if (existing != null)
            {
                if (!DictionariesAreEqual(existing.Properties, displayObject.Properties))
                {
                    defaultValues.Remove(existing);
                    defaultValues.Add(displayObject);
                }
            }
            else
            {
                defaultValues.Add(displayObject);
            }
        }

        private bool DictionariesAreEqual(Dictionary<string, string> dict1, Dictionary<string, string> dict2)
        {
            if (dict1.Count != dict2.Count)
                return false;

            foreach (var kvp in dict1)
            {
                if (!dict2.TryGetValue(kvp.Key, out var value) || value != kvp.Value)
                    return false;
            }

            return true;
        }


        public DisplayObject InputToDisplayObject()
        {
            DisplayObject result = new DisplayObject("Undefined", null, null);

            if(treeView1.SelectedNode.Tag.GetType() == typeof(TrooperClass))
            {
                result = new DisplayObject(name_label.Text, typeof(TrooperClass), new Dictionary<string, string>
                {
                    {"Name", debugName_label.Text },
                    {"NameUI", name_label.Text },
                    {"NumSlots", value1_textBox.Text },
                    {"Supply", value2_textBox.Text }
                });
            }
            else
            {
                MessageBox.Show("This object type is not supported for modification.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                //add other types when modifying them is implemented
                return result;
        }

        private void reset_roundedButton_Click(object sender, EventArgs e)
        {

        }
    }
}
