using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace AnimatedBG
{
    [HarmonyPatch(typeof(ArrayExposeUtility))]
    [HarmonyPatch(nameof(ArrayExposeUtility.AddLineBreaksToLongString))]
    public static class SaveGameFix
    {
        public static bool Prefix(string str, ref string __result)
        {
            var split = str.SplitBy(100);

            __result = string.Join(Environment.NewLine, split.ToArray());

            return false;
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
