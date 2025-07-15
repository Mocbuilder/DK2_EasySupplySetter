using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_ESS_UI_NEW
{
    public class Mod
    {
        public string Name;
        public string Author;
        public List<Unit> Units;
        public string FolderPath;

        public Mod(string name, string author, string folderPath)
        {
            Name = name;
            Author = author;
            Units = new List<Unit>();
            FolderPath = folderPath;
        }
    }
}
