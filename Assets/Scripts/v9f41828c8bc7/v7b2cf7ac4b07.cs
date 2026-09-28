using UnityEngine;

namespace Generated
{
    
    
    
    
    
    
    
    
    
    internal static class v7b2cf7ac4b07
    {
        internal static float v27238e18d27f(float v0efd8da9aa95)
        {
            float wrapped = v0efd8da9aa95 % 360f;
            return wrapped < 0f ? wrapped + 360f : wrapped;
        }

        
        internal static float ve993486c88dd(float vb91c5555a49b, float to)
        {
            float delta = v27238e18d27f(to - vb91c5555a49b);
            return delta > 180f ? delta - 360f : delta;
        }

        internal static float v313a374550cf(float a, float b)
        {
            return Mathf.Abs(ve993486c88dd(a, b));
        }

        
        internal static float v443e09775cc6(int v87c1c391a755)
        {
            return v2fcef25e0767.v9f44f1c06ea2 *
                   (1f + (v2fcef25e0767.vf303f097da7d * v87c1c391a755));
        }

        
        internal static float v2d1b854d5fdf(int v87c1c391a755, float v20b38f6a2be9)
        {
            return v443e09775cc6(v87c1c391a755) * v20b38f6a2be9;
        }

        
        internal static float v9b8e2f194b5d(int v87c1c391a755)
        {
            return 360f / v443e09775cc6(v87c1c391a755);
        }

        
        internal static float v85ce5523d6d5(float v28b5209fb7fc)
        {
            float multiplier = 1f + (v2fcef25e0767.vcee209280e29 * v28b5209fb7fc);
            return Mathf.Clamp(multiplier, 1f, v2fcef25e0767.v75d72b35cf68);
        }

        
        internal static float vb7fe69f7561b(float ve22da963fbb7)
        {
            float rate = v2fcef25e0767.vcee209280e29;
            float rampEnd = vd5f753ba0776;

            if (ve22da963fbb7 <= rampEnd)
            {
                return ve22da963fbb7 + (rate * ve22da963fbb7 * ve22da963fbb7 * 0.5f);
            }

            return vf3bcc4574d72 + (v2fcef25e0767.v75d72b35cf68 * (ve22da963fbb7 - rampEnd));
        }

        
        internal static float ve339e4c9197b(float v68087183cec7)
        {
            if (v68087183cec7 <= vf3bcc4574d72)
            {
                float rate = v2fcef25e0767.vcee209280e29;
                return (Mathf.Sqrt(1f + (2f * rate * v68087183cec7)) - 1f) / rate;
            }

            return vd5f753ba0776 + ((v68087183cec7 - vf3bcc4574d72) / v2fcef25e0767.v75d72b35cf68);
        }

        internal static bool v2dd74febdf8a(float v75bb14d6312e, float vc0c91c2f5247, float v872572ddadc5)
        {
            return v313a374550cf(v75bb14d6312e, vc0c91c2f5247) <= (v872572ddadc5 * 0.5f);
        }

        
        internal static float v48d349bd7047(float v1eacd018e3a8, float v3f9ff5d24992, float v68087183cec7)
        {
            return v27238e18d27f(v1eacd018e3a8 + (v3f9ff5d24992 * v68087183cec7));
        }

        
        internal static float vc0f8000d3d96(float v703e33af5b4a, int v87c1c391a755, float v08148d9aa3f8, float v68087183cec7)
        {
            return v27238e18d27f(v703e33af5b4a + (v443e09775cc6(v87c1c391a755) * (v68087183cec7 - v08148d9aa3f8)));
        }

        
        
        
        
        
        internal static float v67fcbe7df1ad(float vfd7198f88955, float v3f9ff5d24992, float v68087183cec7)
        {
            return v27238e18d27f(vfd7198f88955 - (v3f9ff5d24992 * v68087183cec7));
        }

        
        
        
        
        internal static float vc3e67a01c7eb(int v87c1c391a755, float vf0964539047d)
        {
            float relative = Mathf.Abs(v443e09775cc6(v87c1c391a755) - vf0964539047d);
            return relative <= Mathf.Epsilon ? float.MaxValue : 360f / relative;
        }

        private static float vd5f753ba0776
        {
            get { return (v2fcef25e0767.v75d72b35cf68 - 1f) / v2fcef25e0767.vcee209280e29; }
        }

        private static float vf3bcc4574d72
        {
            get
            {
                float end = vd5f753ba0776;
                return end + (v2fcef25e0767.vcee209280e29 * end * end * 0.5f);
            }
        }
    }
}
