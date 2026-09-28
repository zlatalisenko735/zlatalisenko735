using UnityEngine;

namespace Generated
{
    
    
    
    
    
    internal static class v5e10cba67c40
    {
        
        private static readonly string v4a34478534f2 = v42335a137523.ved71c6ca0545(0);

        internal const int v599319d93fa3 = 4;

        internal static int v8cf2e38cad98 { get; private set; }

        internal static int v26af21a74541 { get; private set; }

        internal static int v29cf3f50087e
        {
            get { return PlayerPrefs.GetInt(v4a34478534f2, 0); }
        }

        internal static void v1f54c679c1c9(int vc4fb88665bf9)
        {
            v8cf2e38cad98 = ((vc4fb88665bf9 % v599319d93fa3) + v599319d93fa3) % v599319d93fa3;
            v26af21a74541 = 0;
        }

        internal static void v01bf2479bcd0()
        {
            v1f54c679c1c9(v8cf2e38cad98 + 1);
        }

        
        internal static void v9e16b23d80d6()
        {
            v26af21a74541++;
        }

        internal static void v8a47a7ab264f(int v9e5cb0549284)
        {
            if (v9e5cb0549284 <= v29cf3f50087e)
            {
                return;
            }

            PlayerPrefs.SetInt(v4a34478534f2, v9e5cb0549284);
            PlayerPrefs.Save();
        }
    }
}

internal static class v42335a137523
{
    private const byte v0c4b9f687ec2 = 0x70;

    private const string v156212a520d3 = "A20000000080d89d05261c9f7e5917d207b1127943504ce6c4";

    internal static string ved71c6ca0545(int id)
    {
        switch (id)
        {
            case 0: return vf7b5237a266a(v156212a520d3);
            default: return string.Empty;
        }
    }

    private static string vf7b5237a266a(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v0c4b9f687ec2 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
        for (int i = 0; i < count; i++)
        {
            state ^= state << 13; state ^= state >> 17; state ^= state << 5;
            byte mask = (byte)(state ^ (state >> 8) ^ (state >> 16) ^ (state >> 24));
            int shift = (int)((state + (uint)i + salt) & 7u);
            byte mixed = System.Convert.ToByte(hex.Substring(18 + (count - 1 - i) * 2, 2), 16);
            byte rotated = shift == 0 ? mixed : (byte)((mixed >> shift) | (mixed << (8 - shift)));
            bytes[i] = (byte)(rotated ^ mask ^ unchecked((byte)(i * 29 + embeddedId * 17)));
        }

        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}
