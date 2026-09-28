using UnityEngine;

namespace Generated
{
    
    
    
    
    
    
    
    
    internal static class v8a29287814e6
    {
        internal const int v34098198e998 = -19;
        internal const int ve1ceca229867 = -1;

        internal const int vccc1ebc9a17f = -19;
        internal const int v852385a3f4a3 = -18;
        internal const int vf14995e756a0 = -13;
        internal const int v4ddf3b247277 = -12;
        internal const int vc79f5cae6e8b = -11;
        internal const int v51130b077348 = -9;
        internal const int vbaeca1c4ead9 = -6;
        internal const int v81e37634330e = -3;

        
        internal static int Ring(int v87c1c391a755)
        {
            return Clamp(v852385a3f4a3 + v87c1c391a755);
        }

        internal static int Clamp(int v2e5e82cd13c5)
        {
            return Mathf.Clamp(v2e5e82cd13c5, v34098198e998, ve1ceca229867);
        }

        internal static void v29234c61c1f5(SpriteRenderer ve1bbc6f4909c, int v2e5e82cd13c5)
        {
            if (ve1bbc6f4909c == null)
            {
                return;
            }

            ve1bbc6f4909c.sortingOrder = Clamp(v2e5e82cd13c5);
        }
    }
}
