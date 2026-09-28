using UnityEngine;

namespace Generated
{
    
    
    
    
    internal static class vc0d78983fe6a
    {
        internal static float vb9b3b3ba8fc5(float t)
        {
            float inverse = 1f - Mathf.Clamp01(t);
            return 1f - (inverse * inverse * inverse);
        }

        internal static float ve269e9eb030b(float t)
        {
            const float Overshoot = 1.70158f;
            float inverse = Mathf.Clamp01(t) - 1f;
            return 1f + ((Overshoot + 1f) * inverse * inverse * inverse) + (Overshoot * inverse * inverse);
        }

        
        internal static float vc58549d3874d(float t)
        {
            return Mathf.Sin(Mathf.Clamp01(t) * Mathf.PI);
        }
    }
}
