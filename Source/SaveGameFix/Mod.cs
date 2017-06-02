using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Verse;

namespace AnimatedBG
{
    public class Mod : Verse.Mod
    {
        public Mod(ModContentPack content) : base(content)
        {
            var harmony = HarmonyInstance.Create("Fumblesneeze.SaveGameFix");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
