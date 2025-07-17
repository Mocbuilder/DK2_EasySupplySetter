using System;
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

        public UnitSelectionForm(string modFolderPath)
        {
            InitializeComponent();
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

        public DisplayObject TreeNodeToDisplayableObject(TreeNode treeNode)
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
                    {"Name", tempUnit.Name },
                };

                result = new DisplayObject(tempUnit.Name, typeof(Unit), properties);
            }
            else if (sourceObject is TrooperClass)
            {
                TrooperClass tempTrooperClass = sourceObject as TrooperClass;
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    {"Name", tempTrooperClass.Name },
                    {"NameUI", tempTrooperClass.NameUI },
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

        protected void treeView1_AfterSelect(object sender,TreeViewEventArgs e)
        {
            DisplayNode(TreeNodeToDisplayableObject(e.Node));
        }

        public void DisplayNode(DisplayObject displayObject)
        {

        }
    }
}
