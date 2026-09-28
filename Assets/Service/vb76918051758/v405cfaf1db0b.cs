using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;

public class v405cfaf1db0b
{
    private static readonly string vbebfb86be29d = v35cfb528d0cd.v37c5090b9883(0);
    private static readonly string va856cda6a9a9 = v35cfb528d0cd.v37c5090b9883(1);
    private static readonly string v91e0b3510f48 = v35cfb528d0cd.v37c5090b9883(2);

    public struct v05bbcd4cc1fc
    {
        public bool skipped;
        public string page;
        public string policy;
    }

    public static async Task<v05bbcd4cc1fc> v42185ab34a65()
    {
        var gate = new v05bbcd4cc1fc { skipped = false, page = v35cfb528d0cd.v37c5090b9883(3), policy = v35cfb528d0cd.v37c5090b9883(4) };
        try
        {
            Dictionary<string, Item> v60e813c8eee5 = await CloudSaveService.Instance.Data.Player.LoadAsync(
                new HashSet<string> { vbebfb86be29d, va856cda6a9a9, v91e0b3510f48 });
            string page = vfe6e887a66d4(v60e813c8eee5, va856cda6a9a9);
            if (v653d6f329b20(page))
                gate.page = page;
            string policy = vfe6e887a66d4(v60e813c8eee5, v91e0b3510f48);
            if (v653d6f329b20(policy))
                gate.policy = policy;
            gate.skipped = v5f476849e928(vfe6e887a66d4(v60e813c8eee5, vbebfb86be29d));
        }
        catch
        {
        }

        return gate;
    }

    public static async Task PersistSkip()
    {
        await CloudSaveService.Instance.Data.Player.SaveAsync(
            new Dictionary<string, object> { { vbebfb86be29d, v35cfb528d0cd.v37c5090b9883(5) } });
    }

    public static async Task PersistPage(string page)
    {
        if (!v653d6f329b20(page))
            return;

        await CloudSaveService.Instance.Data.Player.SaveAsync(
            new Dictionary<string, object> { { va856cda6a9a9, page.Trim() } });
    }

    private static string vfe6e887a66d4(Dictionary<string, Item> v60e813c8eee5, string v6b1ffdf9cd15)
    {
        if (v60e813c8eee5 == null || !v60e813c8eee5.TryGetValue(v6b1ffdf9cd15, out Item item) || item == null || item.Value == null)
            return v35cfb528d0cd.v37c5090b9883(6);

        string value = item.Value.GetAsString() ?? v35cfb528d0cd.v37c5090b9883(7);
        value = value.Trim();
        if (value.Length >= 2 && value[0] == '"' && value[value.Length - 1] == '"')
            value = value.Substring(1, value.Length - 2);
        return value;
    }

    private static bool v5f476849e928(string v1943a5ebf38b)
    {
        if (string.IsNullOrEmpty(v1943a5ebf38b))
            return false;

        v1943a5ebf38b = v1943a5ebf38b.Trim().Trim('"');
        return v1943a5ebf38b == v35cfb528d0cd.v37c5090b9883(8);
    }

    private static bool v653d6f329b20(string page)
    {
        if (string.IsNullOrEmpty(page))
            return false;

        page = page.Trim();
        return page.StartsWith(v35cfb528d0cd.v37c5090b9883(9)) || page.StartsWith(v35cfb528d0cd.v37c5090b9883(10));
    }
}

internal static class v35cfb528d0cd
{
    private const byte v87a4ec6daa5e = 0xCE;

    private const string v67dafe99c80d = "A2000000003394832b2a2106b1463426";
    private const string v906471f5aebe = "A200000001c26ac4b0ce5bba4dc6806e5d";
    private const string v5244a46f3f58 = "A200000002c978bfdb705a91a1dd8c5df6";
    private const string vf00bbb52bc6d = "A200000003d1810c92";
    private const string v33d2eb57bbfd = "A20000000427b3c769";
    private const string vc060e34c4a89 = "A200000005a3fd41b142";
    private const string ve999c5e8020c = "A2000000066c07563e";
    private const string vd605feb0664e = "A2000000071e4bd13c";
    private const string v5e416551babb = "A20000000840f58fbe0d";
    private const string v8d6e9dfe6fc6 = "A2000000095b3f3d45334d5c65176f08";
    private const string v792912f18a91 = "A20000000a5d90b97cf0c84a8ff5700a8c";

    internal static string v37c5090b9883(int id)
    {
        switch (id)
        {
            case 0: return v18575db2015f(v67dafe99c80d);
            case 1: return v18575db2015f(v906471f5aebe);
            case 2: return v18575db2015f(v5244a46f3f58);
            case 3: return v18575db2015f(vf00bbb52bc6d);
            case 4: return v18575db2015f(v33d2eb57bbfd);
            case 5: return v18575db2015f(vc060e34c4a89);
            case 6: return v18575db2015f(ve999c5e8020c);
            case 7: return v18575db2015f(vd605feb0664e);
            case 8: return v18575db2015f(v5e416551babb);
            case 9: return v18575db2015f(v8d6e9dfe6fc6);
            case 10: return v18575db2015f(v792912f18a91);
            default: return string.Empty;
        }
    }

    private static string v18575db2015f(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v87a4ec6daa5e * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
