using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrayForOffer
{
    public static class Parser
    {
        static private bool CompareChars(string str1, string str2)
        {
            if (str1.Length != str2.Length) 
                return false;
            for (int k = 0; k < str1.Length; k++)
            {
                if (str1.Contains(str2[k], StringComparison.OrdinalIgnoreCase))
                {
                    if (k + 1 == str2.Length) return true;
                }
                else break;
            }
            return false;
        }
        public static string[][] ParseStringArray(string[] arr)
        {
            if (arr == null || arr.Length < 1) return new string[][] { };
            var dict = new Dictionary<string, List<string>>();

            foreach (var item in arr)
            {
                if(dict.Count < 1)
                {
                    dict.Add(item, new List<string> { item });
                    continue;
                }
                foreach (var key in dict)
                {
                    if (CompareChars(key.Key, item))
                    {
                        dict[key.Key].Add(item);
                        break;
                    }
                    if(key.Key == dict.Last().Key)
                    {
                        dict.Add(item,new List<string> { item});
                        break;
                    }
                }
            }
            return dict.Values.Select(x => x.ToArray()).ToArray();
        }
    }
}
