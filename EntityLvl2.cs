using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM3Rewrite
{
    public class EntityLvl2 : Entity
    {
        public Dictionary<string, object> Properties;
        public List<string> Properties_GetKeysWithSubstring(string substring)
        {
            List<string> keys = new List<string>();
            foreach (KeyValuePair<string, object> pair in Properties)
                if (pair.Key.Contains(substring))
                    keys.Add(pair.Key);
            return keys;
        }

        public List<string> Properties_GetKeysWithValueOfType<T>()
        {
            List<string> keys = new List<string>();
            foreach (KeyValuePair<string, object> pair in Properties)
                if (pair.Value is T)
                    keys.Add(pair.Key);
            return keys;
        }

        public Dictionary<string, object> Properties_GetOfType<T>()
        {
            Dictionary<string, object> kvp = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> pair in Properties)
                if (pair.Value is T)
                    kvp[pair.Key] = pair.Value;
            return kvp;
        }
    }

}
