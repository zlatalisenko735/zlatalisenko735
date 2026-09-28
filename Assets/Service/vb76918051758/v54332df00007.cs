using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using Firebase.Messaging;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

public class v54332df00007
{
    private const int v910ad76adadc = 15000;
#if UNITY_ANDROID
    private static readonly string v9781dcddabe2 = v7138d5fbb8a0.v6d0a636d7477(0);
#endif

    private Action<string> v6a6359357696;
    private Action<string> v234858e8cf81;
    private bool vce0465cf2951;
    private bool v5d209b8b8793;
    private bool vb6734f685328;
    private string v921551617f7a;
    public string WaitCode { get; private set; } = v7138d5fbb8a0.v6d0a636d7477(1);
    public string WaitPage { get; private set; } = v7138d5fbb8a0.v6d0a636d7477(2);
#if UNITY_ANDROID
    private PermissionCallbacks vfd9a3c2237f4;
#endif

    public void v65429e2f4c09(Action<string> v6a6359357696, Action<string> v234858e8cf81 = null)
    {
        this.v6a6359357696 = v6a6359357696;
        this.v234858e8cf81 = v234858e8cf81;
        v5d209b8b8793 = false;

        if (vce0465cf2951)
        {
            v53b40e148e6f();
            if (v921551617f7a != null)
                this.v6a6359357696?.Invoke(v921551617f7a);
            return;
        }

        vce0465cf2951 = true;
        v53b40e148e6f();
        ve8c6fedd022e();
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(v26a454534e02);
    }

    public async Task<string> PullBellAsync(Action<string> v234858e8cf81, int v80e4fc2b6593)
    {
        var tcs = new TaskCompletionSource<string>();
        v65429e2f4c09(bell =>
        {
            if (!string.IsNullOrEmpty(bell))
                tcs.TrySetResult(bell);
        }, v234858e8cf81);

        Task completed = await Task.WhenAny(tcs.Task, Task.Delay(v80e4fc2b6593));
        if (completed == tcs.Task)
            return tcs.Task.Result;

        return v921551617f7a ?? string.Empty;
    }

    public void vfb50e116aaf8()
    {
        v5d209b8b8793 = true;
        vb6734f685328 = false;

        if (!vce0465cf2951)
            return;

        FirebaseMessaging.TokenReceived -= vb0eaacb66051;
        FirebaseMessaging.MessageReceived -= v6a76df4569d9;
        vce0465cf2951 = false;
    }

    private void ve8c6fedd022e()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (Permission.HasUserAuthorizedPermission(v9781dcddabe2))
            return;

        if (vfd9a3c2237f4 == null)
        {
            vfd9a3c2237f4 = new PermissionCallbacks();
            vfd9a3c2237f4.PermissionGranted += vee833a2bbe32;
            vfd9a3c2237f4.PermissionDenied += v1d606716e0e3;
            vfd9a3c2237f4.PermissionDeniedAndDontAskAgain += v1d606716e0e3;
        }

        Trace(v7138d5fbb8a0.v6d0a636d7477(3));
        Permission.RequestUserPermission(v9781dcddabe2, vfd9a3c2237f4);
#endif
    }

#if UNITY_ANDROID
    private void vee833a2bbe32(string v19204f75f68a)
    {
        vb6734f685328 = false;
        Trace(v7138d5fbb8a0.v6d0a636d7477(4));
    }

    private void v1d606716e0e3(string v19204f75f68a)
    {
        Trace(v7138d5fbb8a0.v6d0a636d7477(5));
        v2a3a0f1f6266();
    }

    private async void v2a3a0f1f6266()
    {
        if (vb6734f685328 || v5d209b8b8793)
            return;

        vb6734f685328 = true;
        await Task.Delay(v910ad76adadc);
        vb6734f685328 = false;

        if (v5d209b8b8793)
            return;

        ve8c6fedd022e();
    }
#endif

    private void v26a454534e02(Task<DependencyStatus> ve393153fac0e)
    {
        if (ve393153fac0e.IsFaulted || ve393153fac0e.IsCanceled || ve393153fac0e.Result != DependencyStatus.Available)
        {
            string reason = ve393153fac0e.IsFaulted
                ? ve393153fac0e.Exception?.GetBaseException().Message
                : ve393153fac0e.Result.ToString();
            Trace(v7138d5fbb8a0.v6d0a636d7477(6) + reason);
            v5d8a7af28702(string.Empty);
            return;
        }

        FirebaseMessaging.TokenReceived += vb0eaacb66051;
        FirebaseMessaging.MessageReceived += v6a76df4569d9;
        FirebaseMessaging.GetTokenAsync().ContinueWithOnMainThread(vce5fa34cf48f);
    }

    private void vce5fa34cf48f(Task<string> ve393153fac0e)
    {
        if (ve393153fac0e.IsFaulted || ve393153fac0e.IsCanceled)
        {
            Trace(v7138d5fbb8a0.v6d0a636d7477(7) + ve393153fac0e.Exception?.GetBaseException().Message);
            v5d8a7af28702(string.Empty);
            return;
        }

        v5d8a7af28702(ve393153fac0e.Result);
    }

    private void vb0eaacb66051(object vca6c136a97d9, TokenReceivedEventArgs vd06799a8fbdf)
    {
        v5d8a7af28702(vd06799a8fbdf.Token);
    }

    private void v6a76df4569d9(object vca6c136a97d9, MessageReceivedEventArgs vd06799a8fbdf)
    {
        if (vd06799a8fbdf?.Message == null)
            return;

        var data = vd06799a8fbdf.Message.Data;
        if (data == null)
            return;

        string page;
        if (data.TryGetValue(v7138d5fbb8a0.v6d0a636d7477(8), out page))
            v0c05c84e997c(page, v7138d5fbb8a0.v6d0a636d7477(9));

        string v35cc37776d16;
        if (!data.TryGetValue(v7138d5fbb8a0.v6d0a636d7477(10), out v35cc37776d16))
            data.TryGetValue(v7138d5fbb8a0.v6d0a636d7477(11), out v35cc37776d16);

        va1e72c07262a(v35cc37776d16, v7138d5fbb8a0.v6d0a636d7477(12));
    }

    public void v53b40e148e6f()
    {
        string page = v630d5d6ff744(v7138d5fbb8a0.v6d0a636d7477(13));
        v0c05c84e997c(page, v7138d5fbb8a0.v6d0a636d7477(14));

        string v35cc37776d16 = v630d5d6ff744(v7138d5fbb8a0.v6d0a636d7477(15));
        if (string.IsNullOrEmpty(v35cc37776d16))
            v35cc37776d16 = v630d5d6ff744(v7138d5fbb8a0.v6d0a636d7477(16));
        va1e72c07262a(v35cc37776d16, v7138d5fbb8a0.v6d0a636d7477(17));
    }

    public static bool IsWebLink(string page)
    {
        if (string.IsNullOrEmpty(page))
            return false;

        page = page.Trim();
        return page.StartsWith(v7138d5fbb8a0.v6d0a636d7477(18), StringComparison.OrdinalIgnoreCase)
            || page.StartsWith(v7138d5fbb8a0.v6d0a636d7477(19), StringComparison.OrdinalIgnoreCase);
    }

    public static string v0ce982b54baa(string page, string v35cc37776d16)
    {
        if (string.IsNullOrEmpty(page) || string.IsNullOrEmpty(v35cc37776d16))
            return page ?? v7138d5fbb8a0.v6d0a636d7477(20);

        if (page.IndexOf(v7138d5fbb8a0.v6d0a636d7477(21), StringComparison.OrdinalIgnoreCase) >= 0)
            return page;

        int hash = page.IndexOf('#');
        string head = hash >= 0 ? page.Substring(0, hash) : page;
        string tail = hash >= 0 ? page.Substring(hash) : v7138d5fbb8a0.v6d0a636d7477(22);
        char sep = head.IndexOf('?') >= 0 ? '&' : '?';
        return head + sep + v7138d5fbb8a0.v6d0a636d7477(23) + Uri.EscapeDataString(v35cc37776d16) + tail;
    }

    private void va1e72c07262a(string v35cc37776d16, string v72b46e3a997c)
    {
        if (string.IsNullOrEmpty(v35cc37776d16) || v35cc37776d16 == WaitCode)
            return;

        WaitCode = v35cc37776d16;
        Trace(v72b46e3a997c + v7138d5fbb8a0.v6d0a636d7477(24) + v35cc37776d16);
    }

    private void v0c05c84e997c(string page, string v72b46e3a997c)
    {
        page = (page ?? v7138d5fbb8a0.v6d0a636d7477(25)).Trim();
        if (!IsWebLink(page) || page == WaitPage)
            return;

        WaitPage = page;
        Trace(v72b46e3a997c + v7138d5fbb8a0.v6d0a636d7477(26) + page);
    }

    private static string v630d5d6ff744(string v6b1ffdf9cd15)
    {
        string extra = v9c9e82976988(v6b1ffdf9cd15);
        if (!string.IsNullOrEmpty(extra))
            return extra;
        return v4ba1ebd75984(v6b1ffdf9cd15);
    }

    private static string v9c9e82976988(string v6b1ffdf9cd15)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (var unityPlayer = new AndroidJavaClass(v7138d5fbb8a0.v6d0a636d7477(27)))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>(v7138d5fbb8a0.v6d0a636d7477(28));
                if (activity == null)
                    return v7138d5fbb8a0.v6d0a636d7477(29);

                using (AndroidJavaObject intent = activity.Call<AndroidJavaObject>(v7138d5fbb8a0.v6d0a636d7477(30)))
                {
                    if (intent == null)
                        return v7138d5fbb8a0.v6d0a636d7477(31);

                    string extra = v7138d5fbb8a0.v6d0a636d7477(32);
                    try
                    {
                        extra = intent.Call<string>(v7138d5fbb8a0.v6d0a636d7477(33), v6b1ffdf9cd15);
                    }
                    catch (Exception)
                    {
                    }

                    if (!string.IsNullOrEmpty(extra))
                        return extra;

                    using (AndroidJavaObject extras = intent.Call<AndroidJavaObject>(v7138d5fbb8a0.v6d0a636d7477(34)))
                    {
                        if (extras == null || !extras.Call<bool>(v7138d5fbb8a0.v6d0a636d7477(35), v6b1ffdf9cd15))
                            return v7138d5fbb8a0.v6d0a636d7477(36);

                        string fromBag = extras.Call<string>(v7138d5fbb8a0.v6d0a636d7477(37), v6b1ffdf9cd15);
                        return fromBag ?? v7138d5fbb8a0.v6d0a636d7477(38);
                    }
                }
            }
        }
        catch (Exception)
        {
            return v7138d5fbb8a0.v6d0a636d7477(39);
        }
#else
        return v7138d5fbb8a0.v6d0a636d7477(40);
#endif
    }

    private static string v4ba1ebd75984(string v6b1ffdf9cd15)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            using (var unityPlayer = new AndroidJavaClass(v7138d5fbb8a0.v6d0a636d7477(41)))
            {
                AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>(v7138d5fbb8a0.v6d0a636d7477(42));
                if (activity == null)
                    return v7138d5fbb8a0.v6d0a636d7477(43);

                using (AndroidJavaObject intent = activity.Call<AndroidJavaObject>(v7138d5fbb8a0.v6d0a636d7477(44)))
                {
                    if (intent == null)
                        return v7138d5fbb8a0.v6d0a636d7477(45);

                    using (AndroidJavaObject data = intent.Call<AndroidJavaObject>(v7138d5fbb8a0.v6d0a636d7477(46)))
                    {
                        if (data == null)
                            return v7138d5fbb8a0.v6d0a636d7477(47);

                        return data.Call<string>(v7138d5fbb8a0.v6d0a636d7477(48), v6b1ffdf9cd15) ?? v7138d5fbb8a0.v6d0a636d7477(49);
                    }
                }
            }
        }
        catch (Exception)
        {
            return v7138d5fbb8a0.v6d0a636d7477(50);
        }
#else
        return v7138d5fbb8a0.v6d0a636d7477(51);
#endif
    }

    private void v5d8a7af28702(string bell)
    {
        bell = bell ?? string.Empty;
        if (bell == v921551617f7a)
            return;

        v921551617f7a = bell;
        v6a6359357696?.Invoke(bell);
    }

    private void Trace(string vad87b7264139)
    {
        v234858e8cf81?.Invoke(v7138d5fbb8a0.v6d0a636d7477(52) + vad87b7264139);
    }
}

internal static class v7138d5fbb8a0
{
    private const byte vd7ec49cd7ca4 = 0x2E;

    private const string v581e8315742e = "A200000000e635da98a318e5db37f7886181750b1fc4029c617f53df747ced97be92bc80629f1a28b7cb1e619976";
    private const string vcbc26ab87536 = "A2000000016465429d";
    private const string v121ad1ea1abe = "A200000002a78f59dd";
    private const string v04862e3bbf1b = "A2000000039aacd7201add281e764afa596872f702a5bf72b990997ea26312b95fc5";
    private const string v5680de7f1f96 = "A200000004c773600d326d9e501aa1f47594450261cd41f3999049470e4ea5b265b3";
    private const string vb4ae1da2095c = "A2000000056629a8b30b84911985c86266f13ffb94d2910491f97e57adb4930d03fba12d2cd9837e23ed9e1b444e71";
    private const string v70288e22d8f3 = "A200000006a6474efaee7a8cf66708a80d578abdb2b99d6779980dec81a58897193e820313fd35ac24350ddb61c0";
    private const string ve6b776a56a34 = "A20000000798e1c17ecde0bd3187e4f97dcc02efa808e7e6bfef";
    private const string vd7bd4fac2320 = "A200000008f22cc0802134d9";
    private const string va005b6e37f8d = "A200000009752febca2340b66259";
    private const string v04e626c789f1 = "A20000000a65256a1a768eeb6a9dfc";
    private const string v6cf0336a709c = "A20000000bb46a8b913d27488f93a4";
    private const string v0ba901e8fc4a = "A20000000cf3c32f146eaed58993";
    private const string vc44339c4c89c = "A20000000dcf31d7dea70ca9";
    private const string v19b3dfc7c68b = "A20000000e9d90b4bcca90736c1de8";
    private const string veb7589ca6eb7 = "A20000000fbb0cba3eec4b145230ae";
    private const string v3e78b6fd6489 = "A200000010b862e133499fde9715cd";
    private const string v6d15307f710f = "A200000011e39d63aed7c1926d3f25";
    private const string v214f936ad89b = "A200000012628b464b52c3ee03892534";
    private const string v1df115f365bf = "A200000013591918e7a97c2299b91cb237";
    private const string vdb0c9b1207d4 = "A2000000146991326e";
    private const string vc94155836891 = "A2000000152b2e606eb591118bb8e154";
    private const string v5009ee217180 = "A20000001660749202";
    private const string v3bb8193e0a46 = "A200000017145f86c29207bcadeb12d9";
    private const string v412e6baa17ff = "A2000000188eef9f7dc683449c66ec";
    private const string v9f7f0124b7d3 = "A200000019c60de7ef";
    private const string vcffc0ca9af36 = "A20000001a2f2e4acec597ade71ab6";
    private const string v822f1ca6987b = "A20000001b78f92bf2380640592b9b5c531c8e65b0dacce7a02d7af419c3d275730a932e307e9d";
    private const string v348edcac8332 = "A20000001c97a209453651faa0bef75d62314f5fbfa31ec1";
    private const string v419e4831f85b = "A20000001d6168270d";
    private const string v4bfd21108b1f = "A20000001e5fec8a806da862e54f614af2d9";
    private const string v2ea0cbb713f1 = "A20000001f15cd1e5a";
    private const string v42e3f344e8ba = "A20000002051732b60";
    private const string vf3e380ff0de9 = "A2000000213e08fafd083e5e58341c20290a9420973b9d";
    private const string v68a796c280b2 = "A200000022c812a00dc73561640d21cd3f58";
    private const string v753d61955b68 = "A200000023a1a3bbfa3ed40d2e74de3361b281a8";
    private const string v8d29f47f2d3c = "A200000024ea3da752";
    private const string v443beaa3e300 = "A200000025ed29ced00392b1c1f1a7ccff6c";
    private const string vd194d8bb1767 = "A200000026426881ab";
    private const string v3baea03ce19b = "A200000027f62827d0";
    private const string vef27d2fcf8db = "A200000028e0a40b52";
    private const string v845d60d200a8 = "A200000029aeb0ae3b4a063a11912fe74dff2ee8cfbaa8e0c991a53fbf2d1261d09b6d4e78edb2";
    private const string vb05f59edb62d = "A20000002a3bc8de1adfb4c768f155223fc5755bfbd28b25";
    private const string v53f823510354 = "A20000002b79923a84";
    private const string v26b5f3b55db2 = "A20000002c5e0639f9ceb92b9bc4e2659e0c";
    private const string vd7c0451e2968 = "A20000002d929b124b";
    private const string v1b55258fe75a = "A20000002ef3553ce3b01a47de956a3b";
    private const string v79fa4d9d3b19 = "A20000002fae8e4583";
    private const string v74063db10c79 = "A2000000302f53b2866dc1680e79e2ca211fdeca3207b1cbcecf";
    private const string vbee70143734e = "A2000000310db08c66";
    private const string v23ae9359a36f = "A200000032aa5d106e";
    private const string veb31b45ea016 = "A2000000338edbd2db";
    private const string v923037edb811 = "A200000034b4f98cb774b4523963bda6";

    internal static string v6d0a636d7477(int id)
    {
        switch (id)
        {
            case 0: return vda4290485d3d(v581e8315742e);
            case 1: return vda4290485d3d(vcbc26ab87536);
            case 2: return vda4290485d3d(v121ad1ea1abe);
            case 3: return vda4290485d3d(v04862e3bbf1b);
            case 4: return vda4290485d3d(v5680de7f1f96);
            case 5: return vda4290485d3d(vb4ae1da2095c);
            case 6: return vda4290485d3d(v70288e22d8f3);
            case 7: return vda4290485d3d(ve6b776a56a34);
            case 8: return vda4290485d3d(vd7bd4fac2320);
            case 9: return vda4290485d3d(va005b6e37f8d);
            case 10: return vda4290485d3d(v04e626c789f1);
            case 11: return vda4290485d3d(v6cf0336a709c);
            case 12: return vda4290485d3d(v0ba901e8fc4a);
            case 13: return vda4290485d3d(vc44339c4c89c);
            case 14: return vda4290485d3d(v19b3dfc7c68b);
            case 15: return vda4290485d3d(veb7589ca6eb7);
            case 16: return vda4290485d3d(v3e78b6fd6489);
            case 17: return vda4290485d3d(v6d15307f710f);
            case 18: return vda4290485d3d(v214f936ad89b);
            case 19: return vda4290485d3d(v1df115f365bf);
            case 20: return vda4290485d3d(vdb0c9b1207d4);
            case 21: return vda4290485d3d(vc94155836891);
            case 22: return vda4290485d3d(v5009ee217180);
            case 23: return vda4290485d3d(v3bb8193e0a46);
            case 24: return vda4290485d3d(v412e6baa17ff);
            case 25: return vda4290485d3d(v9f7f0124b7d3);
            case 26: return vda4290485d3d(vcffc0ca9af36);
            case 27: return vda4290485d3d(v822f1ca6987b);
            case 28: return vda4290485d3d(v348edcac8332);
            case 29: return vda4290485d3d(v419e4831f85b);
            case 30: return vda4290485d3d(v4bfd21108b1f);
            case 31: return vda4290485d3d(v2ea0cbb713f1);
            case 32: return vda4290485d3d(v42e3f344e8ba);
            case 33: return vda4290485d3d(vf3e380ff0de9);
            case 34: return vda4290485d3d(v68a796c280b2);
            case 35: return vda4290485d3d(v753d61955b68);
            case 36: return vda4290485d3d(v8d29f47f2d3c);
            case 37: return vda4290485d3d(v443beaa3e300);
            case 38: return vda4290485d3d(vd194d8bb1767);
            case 39: return vda4290485d3d(v3baea03ce19b);
            case 40: return vda4290485d3d(vef27d2fcf8db);
            case 41: return vda4290485d3d(v845d60d200a8);
            case 42: return vda4290485d3d(vb05f59edb62d);
            case 43: return vda4290485d3d(v53f823510354);
            case 44: return vda4290485d3d(v26b5f3b55db2);
            case 45: return vda4290485d3d(vd7c0451e2968);
            case 46: return vda4290485d3d(v1b55258fe75a);
            case 47: return vda4290485d3d(v79fa4d9d3b19);
            case 48: return vda4290485d3d(v74063db10c79);
            case 49: return vda4290485d3d(vbee70143734e);
            case 50: return vda4290485d3d(v23ae9359a36f);
            case 51: return vda4290485d3d(veb31b45ea016);
            case 52: return vda4290485d3d(v923037edb811);
            default: return string.Empty;
        }
    }

    private static string vda4290485d3d(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)vd7ec49cd7ca4 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
