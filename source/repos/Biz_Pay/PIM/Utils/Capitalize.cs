using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Utils
{
    static public class Capitalize
    {

        public static string tranformCapitalize(string str)
        {

            str = str.Trim();

            string[] words = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }

            return string.Join(" ", words);

        }
        
    }
}
