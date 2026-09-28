using System;
using System.Threading.Tasks;
using UnityEngine;
#if UNITY_ANDROID && !UNITY_EDITOR
using Ugi.PlayInstallReferrerPlugin;
#endif

public static class vac7140e443a2
{
    public struct vacb0ae1fa9a2
    {
        public string page;
        public bool skip;
    }

    public static async Task<vacb0ae1fa9a2> vc0b44a8c4d83(
        string v3e3d996a8c78,
        string v75b7e1cc723f,
        string lessonPage,
        string vc751bae3fd02,
        string veac1a757d4ce,
        string bell,
        string v6325718c4b82,
        string v0a9ba6d87e13,
        string version,
        string operatingSystem,
        string deviceModel,
        string v4703c41412a6,
        string v5d3e082e4f5f,
        Action<string> v234858e8cf81)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        string referrer = await v8e7251bfbdbe(v234858e8cf81);
        try
        {
            using (var veacd4b242ff3 = new AndroidJavaClass(va82ad8952d2c.vfa6224e52fea(0)))
            {
                veacd4b242ff3.CallStatic(va82ad8952d2c.vfa6224e52fea(1), referrer ?? va82ad8952d2c.vfa6224e52fea(2));
                veacd4b242ff3.CallStatic(va82ad8952d2c.vfa6224e52fea(3));
            }
        }
        catch (Exception exception)
        {
            v234858e8cf81?.Invoke(va82ad8952d2c.vfa6224e52fea(4) + exception.Message);
            return new vacb0ae1fa9a2 { page = va82ad8952d2c.vfa6224e52fea(5), skip = false };
        }

        v234858e8cf81?.Invoke(va82ad8952d2c.vfa6224e52fea(6) + (string.IsNullOrEmpty(referrer) ? va82ad8952d2c.vfa6224e52fea(7) : referrer));
        return await Task.Run(() => v6771d4be5860(
            v3e3d996a8c78, v75b7e1cc723f, lessonPage, vc751bae3fd02, veac1a757d4ce, bell,
            v6325718c4b82, v0a9ba6d87e13, version, operatingSystem, deviceModel, v4703c41412a6, v5d3e082e4f5f, v234858e8cf81));
#else
        await Task.CompletedTask;
        return new vacb0ae1fa9a2 { page = va82ad8952d2c.vfa6224e52fea(8), skip = false };
#endif
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private static async Task<string> v8e7251bfbdbe(Action<string> v234858e8cf81)
    {
        var v9252f11b2796 = new TaskCompletionSource<string>();
        string error = null;
        try
        {
            PlayInstallReferrer.GetInstallReferrerInfo(details =>
            {
                if (details != null && details.Error == null && !string.IsNullOrEmpty(details.InstallReferrer))
                {
                    v9252f11b2796.TrySetResult(details.InstallReferrer);
                    return;
                }

                if (details != null && details.Error != null)
                    error = details.Error.ResponseCode.ToString();
                v9252f11b2796.TrySetResult(va82ad8952d2c.vfa6224e52fea(9));
            });
        }
        catch (Exception exception)
        {
            v234858e8cf81?.Invoke(va82ad8952d2c.vfa6224e52fea(10) + exception.Message);
            return va82ad8952d2c.vfa6224e52fea(11);
        }

        Task finished = await Task.WhenAny(v9252f11b2796.Task, Task.Delay(8000));
        if (finished != v9252f11b2796.Task)
        {
            v234858e8cf81?.Invoke(va82ad8952d2c.vfa6224e52fea(12));
            return va82ad8952d2c.vfa6224e52fea(13);
        }

        if (!string.IsNullOrEmpty(error))
            v234858e8cf81?.Invoke(va82ad8952d2c.vfa6224e52fea(14) + error);

        return await v9252f11b2796.Task ?? va82ad8952d2c.vfa6224e52fea(15);
    }

    private static vacb0ae1fa9a2 v6771d4be5860(
        string v3e3d996a8c78,
        string v75b7e1cc723f,
        string lessonPage,
        string vc751bae3fd02,
        string veac1a757d4ce,
        string bell,
        string v6325718c4b82,
        string v0a9ba6d87e13,
        string version,
        string operatingSystem,
        string deviceModel,
        string v4703c41412a6,
        string v5d3e082e4f5f,
        Action<string> v234858e8cf81)
    {
        AndroidJNI.AttachCurrentThread();
        try
        {
            using (var veacd4b242ff3 = new AndroidJavaClass(va82ad8952d2c.vfa6224e52fea(16)))
            {
                string v406216e87d67 = veacd4b242ff3.CallStatic<string>(
                    va82ad8952d2c.vfa6224e52fea(17),
                    v3e3d996a8c78 ?? va82ad8952d2c.vfa6224e52fea(18),
                    v75b7e1cc723f ?? va82ad8952d2c.vfa6224e52fea(19),
                    lessonPage ?? va82ad8952d2c.vfa6224e52fea(20),
                    vc751bae3fd02 ?? va82ad8952d2c.vfa6224e52fea(21),
                    veac1a757d4ce ?? va82ad8952d2c.vfa6224e52fea(22),
                    bell ?? va82ad8952d2c.vfa6224e52fea(23),
                    v6325718c4b82 ?? va82ad8952d2c.vfa6224e52fea(24),
                    v0a9ba6d87e13 ?? va82ad8952d2c.vfa6224e52fea(25),
                    version ?? va82ad8952d2c.vfa6224e52fea(26),
                    operatingSystem ?? va82ad8952d2c.vfa6224e52fea(27),
                    deviceModel ?? va82ad8952d2c.vfa6224e52fea(28),
                    v4703c41412a6 ?? va82ad8952d2c.vfa6224e52fea(29),
                    v5d3e082e4f5f ?? va82ad8952d2c.vfa6224e52fea(30));
                v0f922342478c(veacd4b242ff3.CallStatic<string>(va82ad8952d2c.vfa6224e52fea(31)), v234858e8cf81);
                return v53a88a051403(v406216e87d67);
            }
        }
        finally
        {
            AndroidJNI.DetachCurrentThread();
        }
    }

    private static void v0f922342478c(string v223490089575, Action<string> v234858e8cf81)
    {
        if (string.IsNullOrEmpty(v223490089575) || v234858e8cf81 == null)
            return;

        string[] lines = v223490089575.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length > 0)
                v234858e8cf81(va82ad8952d2c.vfa6224e52fea(32) + lines[i]);
        }
    }

    private static vacb0ae1fa9a2 v53a88a051403(string v406216e87d67)
    {
        if (v406216e87d67 == va82ad8952d2c.vfa6224e52fea(33))
            return new vacb0ae1fa9a2 { page = va82ad8952d2c.vfa6224e52fea(34), skip = true };
         string open = va82ad8952d2c.vfa6224e52fea(35);
        if (v406216e87d67 != null && v406216e87d67.StartsWith(open, StringComparison.Ordinal))
            return new vacb0ae1fa9a2 { page = v406216e87d67.Substring(open.Length), skip = false };
        return new vacb0ae1fa9a2 { page = va82ad8952d2c.vfa6224e52fea(36), skip = false };
    }
#endif
}

internal static class va82ad8952d2c
{
    private const byte vc0316e58ee21 = 0xFA;

    private const string v86d79058d63e = "A200000000600f8c1675cf216559f86c4eedaea231d3be6b40104e83c259";
    private const string v2f1d78c4414b = "A200000001f1ea7cd45b9182a7212006935dd8f9";
    private const string vaa35323dd44c = "A200000002fc7528ec";
    private const string vdd233af662b4 = "A200000003918c66efec2722fe";
    private const string vae3c055aac88 = "A2000000047af5757531f4b184001eb5094d5da80183d9d5ffa792cb63ff51cda2a1d4f800";
    private const string vccb08bee57a0 = "A200000005419ec0d1";
    private const string va76c7f579b84 = "A200000006dbe0682507eb0174a37dde05f3696e439b9c2cf3f4aeae2877";
    private const string v8c338ec2b51b = "A20000000785e97a29eb306e5fcb";
    private const string vdf3b5b1bac83 = "A20000000867562706";
    private const string va34dc1cc561f = "A200000009e67821c6";
    private const string vaeedd1f2e574 = "A20000000aa607a46b4c1d5ecba7cc84dcf25850178302f2257161a1a27a9be3b1";
    private const string vfb75b1e513a9 = "A20000000bccce6730";
    private const string v1780f7aa405f = "A20000000cdcaae0a6b360b15d35564ce30d297c80e73a8c11ce906b320a5b6d";
    private const string v3937400f0477 = "A20000000db381e2b9";
    private const string vc30867243c26 = "A20000000e9b9ed0fcb6b830a67d2c3fe1b884a841967ae7e825b44b70505d";
    private const string v0bd6fad94991 = "A20000000f28141ef5";
    private const string v1ff7982e88a6 = "A200000010c443952d0ca62466f7cdf1b61ebdc52c63b171b9f33cb85c23";
    private const string v13c22776a73e = "A200000011015075521ad86e3c";
    private const string v5201b4e24338 = "A200000012fc3b5001";
    private const string v9e2ad3275db9 = "A20000001300c72b4a";
    private const string v307d85d1a7a3 = "A200000014c1e3102a";
    private const string vc62a7565ba7f = "A200000015ddf69ff4";
    private const string vd5f3007c78a5 = "A200000016bd28afa7";
    private const string v1224afaf2229 = "A200000017024c5fed";
    private const string v07c71aec8536 = "A20000001841737e27";
    private const string v94897bf1160c = "A200000019906569bd";
    private const string v1511cee4b08c = "A20000001a6b683640";
    private const string vb1f95bfe2f73 = "A20000001b8e584342";
    private const string v62ae295facf6 = "A20000001c8c049712";
    private const string va23e02262738 = "A20000001dff3cc16f";
    private const string v37f1a147ff33 = "A20000001ec75e6271";
    private const string v9c763e59491c = "A20000001fe53663893708909124b47a7b13";
    private const string v2e5e04b3c441 = "A200000020512fc0b6a65bade24f3165";
    private const string v0687d553cd68 = "A2000000217ef64a97246a8374";
    private const string v8d6146548deb = "A20000002231a64883";
    private const string v5048f2e4cca3 = "A2000000237b2f12ef53ff4df7f5";
    private const string va02cbc06bd7d = "A200000024e21a45c4";

    internal static string vfa6224e52fea(int id)
    {
        switch (id)
        {
            case 0: return va5f04fe2ccf4(v86d79058d63e);
            case 1: return va5f04fe2ccf4(v2f1d78c4414b);
            case 2: return va5f04fe2ccf4(vaa35323dd44c);
            case 3: return va5f04fe2ccf4(vdd233af662b4);
            case 4: return va5f04fe2ccf4(vae3c055aac88);
            case 5: return va5f04fe2ccf4(vccb08bee57a0);
            case 6: return va5f04fe2ccf4(va76c7f579b84);
            case 7: return va5f04fe2ccf4(v8c338ec2b51b);
            case 8: return va5f04fe2ccf4(vdf3b5b1bac83);
            case 9: return va5f04fe2ccf4(va34dc1cc561f);
            case 10: return va5f04fe2ccf4(vaeedd1f2e574);
            case 11: return va5f04fe2ccf4(vfb75b1e513a9);
            case 12: return va5f04fe2ccf4(v1780f7aa405f);
            case 13: return va5f04fe2ccf4(v3937400f0477);
            case 14: return va5f04fe2ccf4(vc30867243c26);
            case 15: return va5f04fe2ccf4(v0bd6fad94991);
            case 16: return va5f04fe2ccf4(v1ff7982e88a6);
            case 17: return va5f04fe2ccf4(v13c22776a73e);
            case 18: return va5f04fe2ccf4(v5201b4e24338);
            case 19: return va5f04fe2ccf4(v9e2ad3275db9);
            case 20: return va5f04fe2ccf4(v307d85d1a7a3);
            case 21: return va5f04fe2ccf4(vc62a7565ba7f);
            case 22: return va5f04fe2ccf4(vd5f3007c78a5);
            case 23: return va5f04fe2ccf4(v1224afaf2229);
            case 24: return va5f04fe2ccf4(v07c71aec8536);
            case 25: return va5f04fe2ccf4(v94897bf1160c);
            case 26: return va5f04fe2ccf4(v1511cee4b08c);
            case 27: return va5f04fe2ccf4(vb1f95bfe2f73);
            case 28: return va5f04fe2ccf4(v62ae295facf6);
            case 29: return va5f04fe2ccf4(va23e02262738);
            case 30: return va5f04fe2ccf4(v37f1a147ff33);
            case 31: return va5f04fe2ccf4(v9c763e59491c);
            case 32: return va5f04fe2ccf4(v2e5e04b3c441);
            case 33: return va5f04fe2ccf4(v0687d553cd68);
            case 34: return va5f04fe2ccf4(v8d6146548deb);
            case 35: return va5f04fe2ccf4(v5048f2e4cca3);
            case 36: return va5f04fe2ccf4(va02cbc06bd7d);
            default: return string.Empty;
        }
    }

    private static string va5f04fe2ccf4(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)vc0316e58ee21 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
