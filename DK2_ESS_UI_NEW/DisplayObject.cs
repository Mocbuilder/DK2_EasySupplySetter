using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK2_ESS_UI_NEW
{
    public class DisplayObject
    {
        public string Name;
        public Type Type;
        public Dictionary<string, string> Properties;

        public DisplayObject(string name, Type type, Dictionary<string, string> properties)
        {
            Name = name;
            Type = type;
            Properties = properties;
        }

        public string GetPropertie(string key)
        {
            return Properties.GetValueOrDefault(key);
        }
    }
}
