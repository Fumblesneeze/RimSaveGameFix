using HugsLib.Source.Detour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace AnimatedBG
{
    public class SaveGameFix
    {

        [DetourMethod(typeof(ArrayExposeUtility), nameof(ArrayExposeUtility.AddLineBreaksToLongString))]
        public static string AddLineBreaksToLongString(string str)
        {
            var split = str.SplitBy(100);

            return string.Join(Environment.NewLine, split.ToArray());
        }
    }


    public static class EnumerableEx
    {
        public static IEnumerable<string> SplitBy(this string str, int chunkLength)
        {
            if (String.IsNullOrEmpty(str)) throw new ArgumentException();
            if (chunkLength < 1) throw new ArgumentException();

            for (int i = 0; i < str.Length; i += chunkLength)
            {
                if (chunkLength + i > str.Length)
                    chunkLength = str.Length - i;

                yield return str.Substring(i, chunkLength);
            }
        }
    }
}
