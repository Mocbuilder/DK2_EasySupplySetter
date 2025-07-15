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
        }

        public List<TreeNode> ModsToTreeNodes()
        {
            List<TreeNode> ResultNodes = new List<TreeNode>();
            foreach (Mod _mod in Mods)
            {
                TreeNode newModNode = new TreeNode(AliasFinder(_mod.Name));
                newModNode.Tag = _mod;

                foreach (Unit _unit in _mod.Units)
                {
                    TreeNode newUnitNode = new TreeNode(_unit.Name);
                    newUnitNode.Tag = _unit;
                    newModNode.Nodes.Add(newUnitNode);

                    foreach (TrooperClass _trooperClass in _unit.TrooperClasses)
                    {
                        TreeNode newTrooperClassNode = new TreeNode(_trooperClass.NameUI);
                        newTrooperClassNode.Tag = _trooperClass;
                        newUnitNode.Nodes.Add(newTrooperClassNode);
                    }
                }

                ResultNodes.Add(newModNode);
            }

            return ResultNodes;
        }
    }
}
