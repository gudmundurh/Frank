using System.Collections.Generic;

namespace Frank
{
    public class DataStore: Dictionary<string, object>
    {
        public T Get<T>(string key)
        {
            return ContainsKey(key) ? (T) this[key] : default(T);
        }
    }
}