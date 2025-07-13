using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_ESS_UI_NEW
{
    public class TrooperClass
    {
        public string Name;
        public string NameUI;
        public int NumSlots;
        public int Supply;

        public TrooperClass(string name, string nameUI, int numSlots, int supply)
        {
            Name = name;
            NameUI = nameUI;
            NumSlots = numSlots;
            Supply = supply;
        }
    }
}
