using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Frank
{
    public class RouteValues : Dictionary<string, string>
    {
        public RouteValues(List<string> parameters, Match match)
        {
            foreach (string param in parameters)
            {
                Add(param, match.Groups[param].Value);
            }
        }
    }
}