using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.Builder_Pattern
{
    public class Product
    {
        private List<string> parts = new List<string>();
        public void Add(string part)
        {
            //Add parts
            parts.Add(part);
        }
        public string Show()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Product components are :");
            foreach (string part in parts)
                result.AppendLine(part);

            return result.ToString();
        }
    }
}