using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_ESS_UI_NEW
{
    public class Unit
    {
        public string Name;
        public List<TrooperClass> TrooperClasses;

        public Unit(string name, List<TrooperClass> trooperClasses)
        {
            Name = name;
            TrooperClasses = new List<TrooperClass>();
        }
    }
}
