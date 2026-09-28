using UnityEngine;

namespace Generated
{
    
    
    
    
    
    
    internal static class va7c9379be56b
    {
        
        internal static readonly Color v2f121a124175 = v148b83358f0d(0x10172A);

        
        internal static readonly Color v4cceb9d3a941 = v148b83358f0d(0x060B1A);

        
        internal static readonly Color va10e8b276e1d = v148b83358f0d(0x22D3EE);

        
        internal static readonly Color v793c5f9ef2be = v148b83358f0d(0xEC4899);

        
        internal static readonly Color vb09e0d1013c6 = v148b83358f0d(0x7C3AED);

        
        internal static readonly Color vdfed27544942 = v148b83358f0d(0xF59E0B);

        
        internal static readonly Color v97a9dfa1067f = v148b83358f0d(0x34D399);

        
        internal static readonly Color v02610b855b7f = v148b83358f0d(0xE8F7FF);

        
        internal static readonly Color v2a89defed705 = v148b83358f0d(0x101A33);

        
        internal static readonly Color v8418cb46b655 = v148b83358f0d(0x0B1226);

        
        internal static readonly Color va9af105d7347 = v148b83358f0d(0x0A0E1C);

        internal static Color vb477f7abc689(Color v72b46e3a997c, float alpha)
        {
            v72b46e3a997c.a = alpha;
            return v72b46e3a997c;
        }

        private static Color v148b83358f0d(int v7799a609407f)
        {
            float r = ((v7799a609407f >> 16) & 0xFF) / 255f;
            float g = ((v7799a609407f >> 8) & 0xFF) / 255f;
            float b = (v7799a609407f & 0xFF) / 255f;
            return new Color(r, g, b, 1f);
        }
    }
}
