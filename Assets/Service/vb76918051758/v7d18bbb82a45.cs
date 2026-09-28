using System;
using System.IO;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Unity.Services.RemoteConfig;
using UnityEngine;

public class v7d18bbb82a45
{
    public static readonly string va856cda6a9a9 = v23df4e5a32a3.vee98f87338a7(0);
    public static readonly string v2a131545e49b = v23df4e5a32a3.vee98f87338a7(1);
    public static readonly string va4a8389f8a3e = v23df4e5a32a3.vee98f87338a7(2);
    private static readonly string vaae1fa1fa6e9 = v23df4e5a32a3.vee98f87338a7(3);

    public string RawPage { get; private set; } = string.Empty;
    public string LessonPage { get; private set; } = string.Empty;
    public string DeskHost { get; private set; } = string.Empty;
    public bool LessonOn { get; private set; } = true;

    public async Task EnsureSignedIn(Action<string> v234858e8cf81 = null)
    {
        await BootServices();
        await SignGuest(v234858e8cf81);
    }

    public async Task PullRemotePage(Action<string> v234858e8cf81 = null)
    {
        await EnsureSignedIn(v234858e8cf81);

        Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(4) + SeatId);
        Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(5));
        await RemoteConfigService.Instance.FetchConfigsAsync(new v254413b67247(), new v61a1633a7838());

        LessonOn = RemoteConfigService.Instance.appConfig.GetBool(v2a131545e49b, true);
        Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(6) + (LessonOn ? v23df4e5a32a3.vee98f87338a7(7) : v23df4e5a32a3.vee98f87338a7(8)));
        if (!LessonOn)
        {
            RawPage = RemoteConfigService.Instance.appConfig.GetString(va856cda6a9a9, string.Empty);
            LessonPage = CutBeforePipe(RawPage);
            DeskHost = string.Empty;
            Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(9) + (string.IsNullOrEmpty(LessonPage) ? v23df4e5a32a3.vee98f87338a7(10) : LessonPage));
            return;
        }

        RawPage = RemoteConfigService.Instance.appConfig.GetString(va856cda6a9a9, string.Empty);
        SplitPage(RawPage);

        Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(11) + (string.IsNullOrEmpty(RawPage) ? v23df4e5a32a3.vee98f87338a7(12) : RawPage));
    }

    private static async Task BootServices()
    {
        if (UnityServices.State == ServicesInitializationState.Initialized)
            return;

        var options = new InitializationOptions().SetEnvironmentName(va4a8389f8a3e);
        await UnityServices.InitializeAsync(options);
    }

    private static async Task SignGuest(Action<string> v234858e8cf81)
    {
        if (WasCacheCleared() && AuthenticationService.Instance.SessionTokenExists)
        {
            AuthenticationService.Instance.ClearSessionToken();
            Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(13));
        }
        else if (AuthenticationService.Instance.SessionTokenExists)
        {
            Trace(v234858e8cf81, v23df4e5a32a3.vee98f87338a7(14));
        }

        if (!AuthenticationService.Instance.IsSignedIn)
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        WriteSeatMarker();
    }

    private static bool WasCacheCleared()
    {
        try
        {
            return !File.Exists(SeatMarkerPath());
        }
        catch
        {
            return false;
        }
    }

    private static void WriteSeatMarker()
    {
        try
        {
            File.WriteAllText(SeatMarkerPath(), v23df4e5a32a3.vee98f87338a7(15));
        }
        catch
        {
        }
    }

    private static string SeatMarkerPath()
    {
        return Path.Combine(Application.temporaryCachePath, vaae1fa1fa6e9);
    }

    public string SeatToken
    {
        get
        {
            try
            {
                return AuthenticationService.Instance.IsSignedIn
                    ? AuthenticationService.Instance.AccessToken
                    : v23df4e5a32a3.vee98f87338a7(16);
            }
            catch
            {
                return v23df4e5a32a3.vee98f87338a7(17);
            }
        }
    }

    public string SeatId
    {
        get
        {
            try
            {
                return AuthenticationService.Instance.IsSignedIn
                    ? AuthenticationService.Instance.PlayerId
                    : v23df4e5a32a3.vee98f87338a7(18);
            }
            catch
            {
                return v23df4e5a32a3.vee98f87338a7(19);
            }
        }
    }

    public string CloudId
    {
        get
        {
            return Application.cloudProjectId ?? v23df4e5a32a3.vee98f87338a7(20);
        }
    }

    private static string CutBeforePipe(string value)
    {
        if (string.IsNullOrEmpty(value))
            return string.Empty;

        int cut = value.IndexOf('|');
        if (cut >= 0)
            value = value.Substring(0, cut);
        return value.Trim();
    }

    private void SplitPage(string value)
    {
        LessonPage = string.Empty;
        DeskHost = string.Empty;

        if (string.IsNullOrEmpty(value))
            return;

        string[] parts = value.Split('|');
        if (parts.Length > 0)
            LessonPage = parts[0].Trim();
        if (parts.Length > 1)
            DeskHost = parts[1].Trim();
    }

    private static void Trace(Action<string> v234858e8cf81, string vad87b7264139)
    {
        v234858e8cf81?.Invoke(v23df4e5a32a3.vee98f87338a7(21) + vad87b7264139);
    }

    private struct v254413b67247 { }

    private struct v61a1633a7838 { }
}

internal static class v23df4e5a32a3
{
    private const byte vbe107e4e3ae5 = 0xF0;

    private const string v58d2941dfeb4 = "A2000000006631e95e8ed47cebfda948d5a9";
    private const string v6925a29bf257 = "A200000001a8123db81720a2620cd814";
    private const string vebb49d3c35dd = "A200000002d8dd426ac70bc53b2cb1c477d473";
    private const string ve787ccc38c0a = "A200000003eea68c43d4ad8e1862db8250843f0d";
    private const string v9c27e9f79203 = "A200000004737f4a41d65f8de011c57e91270bd4a388df28";
    private const string v49a2f59549d2 = "A20000000556e37db7918970d49a9548e2c1a41b2267d07814";
    private const string vfd2b2c56c1df = "A2000000068d4b546e61590c50c598f4";
    private const string v0782f06fc6aa = "A200000007ff1a221dfa78";
    private const string vd16b83f149bc = "A2000000080a9823047cf6f2";
    private const string vd789fa9f8439 = "A2000000099b21c41d704c3f719da7e9d6fd5c53";
    private const string vb993d9f867d0 = "A20000000aa83f2ac81a75e29ab13d13";
    private const string v5cac858e4302 = "A20000000b4c3890372fbe3c637652290b228f2b";
    private const string v234825e89bce = "A20000000cd05a326a53f29162efed23";
    private const string v1d38a053e4e9 = "A20000000d31bb421294fbf8b2ae303d08ce54705efce9962ce60b9bc029ac2c";
    private const string v51eec845a957 = "A20000000e37d2853179f75c34e4c525c8195b";
    private const string v567fc0c0aca8 = "A20000000f88638ece19";
    private const string v79515babb4f3 = "A200000010d1b6870d";
    private const string va5b0676044dd = "A200000011d9e7137c";
    private const string v0cad3bd19312 = "A200000012e2a0586d";
    private const string vb61537fd10a0 = "A200000013d89590f0";
    private const string v0a8b1a1672f8 = "A20000001425ad64d6";
    private const string vea69279c7b87 = "A20000001516aeecdc3891ab21615d00";

    internal static string vee98f87338a7(int id)
    {
        switch (id)
        {
            case 0: return v0d4f0b1b4907(v58d2941dfeb4);
            case 1: return v0d4f0b1b4907(v6925a29bf257);
            case 2: return v0d4f0b1b4907(vebb49d3c35dd);
            case 3: return v0d4f0b1b4907(ve787ccc38c0a);
            case 4: return v0d4f0b1b4907(v9c27e9f79203);
            case 5: return v0d4f0b1b4907(v49a2f59549d2);
            case 6: return v0d4f0b1b4907(vfd2b2c56c1df);
            case 7: return v0d4f0b1b4907(v0782f06fc6aa);
            case 8: return v0d4f0b1b4907(vd16b83f149bc);
            case 9: return v0d4f0b1b4907(vd789fa9f8439);
            case 10: return v0d4f0b1b4907(vb993d9f867d0);
            case 11: return v0d4f0b1b4907(v5cac858e4302);
            case 12: return v0d4f0b1b4907(v234825e89bce);
            case 13: return v0d4f0b1b4907(v1d38a053e4e9);
            case 14: return v0d4f0b1b4907(v51eec845a957);
            case 15: return v0d4f0b1b4907(v567fc0c0aca8);
            case 16: return v0d4f0b1b4907(v79515babb4f3);
            case 17: return v0d4f0b1b4907(va5b0676044dd);
            case 18: return v0d4f0b1b4907(v0cad3bd19312);
            case 19: return v0d4f0b1b4907(vb61537fd10a0);
            case 20: return v0d4f0b1b4907(v0a8b1a1672f8);
            case 21: return v0d4f0b1b4907(vea69279c7b87);
            default: return string.Empty;
        }
    }

    private static string v0d4f0b1b4907(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)vbe107e4e3ae5 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
