using System.Collections.Generic;

namespace HLP_RKP_LR3.Models
{
    public class TableItem
    {
        public Dictionary<string, TypedItem> Values { get; set; }

        public TableItem(Dictionary<string, ItemTypes> schema, Dictionary<string, string> values = null)
        {
            Values = new Dictionary<string, TypedItem>();
            foreach (KeyValuePair<string, ItemTypes> pair in schema)
            {
                string key = pair.Key;
                ItemTypes type = pair.Value;
                string value = values == null ? "" : values.ContainsKey(key) ? values[key] : "";
                Values.Add(key, new TypedItem(value, type));
            }
        }
    }
}
