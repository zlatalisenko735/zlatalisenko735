using System;
using UnityEngine;

public class v84aacb7e185f
{
    public bool Ready { get { return veacd4b242ff3 != null && !v5050e8446b1f; } }

    public Func<string, bool, bool, bool> HandleRequest;
    public Func<string, int> AllowCapture;

    public event Action<string> vbae5af4a28ee;
    public event Action<string> v6763ebe839c3;
    public event Action<float> v053e3da2061e;
    public event Action<int, string> v3f6189a064b3;
    public event Action<string> v4a48fffc0b17;
    public event Action<string> vbb241c2d823c;
    public event Action<string> v33106a151e4b;
    public event Action<string, string> ve1a7896654e9;
    public event Action<string, string> vf7e6c4a03628;

    private AndroidJavaObject veacd4b242ff3;
    private vd48f5e20f6f0 v1e5e14863981;
    private bool v5050e8446b1f;

    public v84aacb7e185f()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            Attach();
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(0) + exception.Message);
        }
#endif
    }

    public void Load(string v0d13595f0079)
    {
        Call(vd16a86946a68.v823907a15f37(1), v0d13595f0079 ?? string.Empty);
    }

    public void Show()
    {
        Call(vd16a86946a68.v823907a15f37(2));
    }

    public void Hide()
    {
        Call(vd16a86946a68.v823907a15f37(3));
    }

    public void vfb50e116aaf8()
    {
        Call(vd16a86946a68.v823907a15f37(4));
    }

    public void GoBack()
    {
        Call(vd16a86946a68.v823907a15f37(5));
    }

    public bool CanGoBack
    {
        get { return CallBool(vd16a86946a68.v823907a15f37(6)); }
    }

    public bool CloseTopPopup()
    {
        return CallBool(vd16a86946a68.v823907a15f37(7));
    }

    public string BackUrl()
    {
        return CallString(vd16a86946a68.v823907a15f37(8));
    }

    public void SetUserAgent(string userAgent)
    {
        Call(vd16a86946a68.v823907a15f37(9), userAgent ?? string.Empty);
    }

    public string GetUserAgent()
    {
        return CallString(vd16a86946a68.v823907a15f37(10));
    }

    public void SetPopupUserAgent(string id, string userAgent)
    {
        Call(vd16a86946a68.v823907a15f37(11), id ?? string.Empty, userAgent ?? string.Empty);
    }

    public void SetMargins(int left, int top, int right, int bottom, int screenW, int screenH)
    {
        Call(vd16a86946a68.v823907a15f37(12), left, top, right, bottom, screenW, screenH);
    }

    public void SetAcceptThirdPartyCookies(bool va6c9848e389c)
    {
        Call(vd16a86946a68.v823907a15f37(13), va6c9848e389c);
    }

    public void Eval(string script)
    {
        Call(vd16a86946a68.v823907a15f37(14), script ?? string.Empty);
    }

    public void EvalPopup(string id, string script)
    {
        Call(vd16a86946a68.v823907a15f37(15), id ?? string.Empty, script ?? string.Empty);
    }

    public void ClosePopup(string id)
    {
        Call(vd16a86946a68.v823907a15f37(16), id ?? string.Empty);
    }

    public bool PopupAlive(string id)
    {
        if (veacd4b242ff3 == null || v5050e8446b1f || string.IsNullOrEmpty(id))
            return false;

        try
        {
            return veacd4b242ff3.Call<bool>(vd16a86946a68.v823907a15f37(17), id);
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(18) + exception.Message);
            return false;
        }
    }

    public void ScrollToTop()
    {
        Call(vd16a86946a68.v823907a15f37(19));
    }

    public void FinishCapture(bool grant)
    {
        Call(vd16a86946a68.v823907a15f37(20), grant ? 1 : 0);
    }

    public void SetPaused(bool paused)
    {
        Call(vd16a86946a68.v823907a15f37(21), paused);
    }

    public void Destroy()
    {
        if (v5050e8446b1f)
            return;

        v5050e8446b1f = true;
        if (veacd4b242ff3 == null)
            return;

        try
        {
            veacd4b242ff3.Call(vd16a86946a68.v823907a15f37(22));
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(23) + exception.Message);
        }

        veacd4b242ff3.Dispose();
        veacd4b242ff3 = null;
    }

    private void Attach()
    {
        v1e5e14863981 = new vd48f5e20f6f0(this);
        using (var unityPlayer = new AndroidJavaClass(vd16a86946a68.v823907a15f37(24)))
        using (var activity = unityPlayer.GetStatic<AndroidJavaObject>(vd16a86946a68.v823907a15f37(25)))
        {
            if (activity == null)
                throw new InvalidOperationException(vd16a86946a68.v823907a15f37(26));

            veacd4b242ff3 = new AndroidJavaObject(vd16a86946a68.v823907a15f37(27), activity, v1e5e14863981);
        }
    }

    private void Call(string method, params object[] vd06799a8fbdf)
    {
        if (veacd4b242ff3 == null || v5050e8446b1f)
            return;

        try
        {
            if (vd06799a8fbdf == null || vd06799a8fbdf.Length == 0)
                veacd4b242ff3.Call(method);
            else
                veacd4b242ff3.Call(method, vd06799a8fbdf);
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(28) + method + vd16a86946a68.v823907a15f37(29) + exception.Message);
        }
    }

    private bool CallBool(string method)
    {
        if (veacd4b242ff3 == null || v5050e8446b1f)
            return false;

        try
        {
            return veacd4b242ff3.Call<bool>(method);
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(30) + method + vd16a86946a68.v823907a15f37(31) + exception.Message);
            return false;
        }
    }

    private string CallString(string method)
    {
        if (veacd4b242ff3 == null || v5050e8446b1f)
            return string.Empty;

        try
        {
            string value = veacd4b242ff3.Call<string>(method);
            return value ?? string.Empty;
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(32) + method + vd16a86946a68.v823907a15f37(33) + exception.Message);
            return string.Empty;
        }
    }

    private void NotifyPageStarted(string v0d13595f0079)
    {
        v68cc303029ea(vbae5af4a28ee, v0d13595f0079 ?? string.Empty);
    }

    private void NotifyPageCommitted(string v0d13595f0079)
    {
        v68cc303029ea(v6763ebe839c3, v0d13595f0079 ?? string.Empty);
    }

    private void NotifyProgress(int percent)
    {
        v68cc303029ea(v053e3da2061e, Mathf.Clamp(percent, 0, 100) / 100f);
    }

    private void NotifyPageFinished(int v35cc37776d16, string v0d13595f0079)
    {
        v68cc303029ea(v3f6189a064b3, v35cc37776d16, v0d13595f0079 ?? string.Empty);
    }

    private void NotifyPageError(string v0d13595f0079)
    {
        v68cc303029ea(v4a48fffc0b17, v0d13595f0079 ?? string.Empty);
    }

    private void NotifyPopupOpened(string id)
    {
        v68cc303029ea(vbb241c2d823c, id ?? string.Empty);
    }

    private void NotifyPopupClosed(string id)
    {
        v68cc303029ea(v33106a151e4b, id ?? string.Empty);
    }

    private void NotifyPopupStarted(string id, string v0d13595f0079)
    {
        v68cc303029ea(ve1a7896654e9, id ?? string.Empty, v0d13595f0079 ?? string.Empty);
    }

    private void NotifyPopupFinished(string id, string v0d13595f0079)
    {
        v68cc303029ea(vf7e6c4a03628, id ?? string.Empty, v0d13595f0079 ?? string.Empty);
    }

    private void v68cc303029ea<T>(Action<T> vcc73fe7a9207, T value)
    {
        if (v5050e8446b1f || vcc73fe7a9207 == null)
            return;

        try
        {
            vcc73fe7a9207(value);
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(34) + exception.Message);
        }
    }

    private void v68cc303029ea<T1, T2>(Action<T1, T2> vcc73fe7a9207, T1 first, T2 second)
    {
        if (v5050e8446b1f || vcc73fe7a9207 == null)
            return;

        try
        {
            vcc73fe7a9207(first, second);
        }
        catch (Exception exception)
        {
            Debug.LogWarning(vd16a86946a68.v823907a15f37(35) + exception.Message);
        }
    }

    private sealed class vd48f5e20f6f0 : AndroidJavaProxy
    {
        private readonly v84aacb7e185f v270cd8ab3530;

        public vd48f5e20f6f0(v84aacb7e185f v270cd8ab3530)
            : base(vd16a86946a68.v823907a15f37(36))
        {
            this.v270cd8ab3530 = v270cd8ab3530;
        }

        [UnityEngine.Scripting.Preserve]
        public int shouldHandle(string v0d13595f0079, int mainFrame, int popup)
        {
            v84aacb7e185f v75b7e1cc723f = v270cd8ab3530;
            if (v75b7e1cc723f == null || v75b7e1cc723f.v5050e8446b1f || v75b7e1cc723f.HandleRequest == null)
                return 1;

            try
            {
                bool allow = v75b7e1cc723f.HandleRequest(v0d13595f0079 ?? string.Empty, mainFrame != 0, popup != 0);
                return allow ? 1 : 0;
            }
            catch (Exception exception)
            {
                Debug.LogWarning(vd16a86946a68.v823907a15f37(37) + exception.Message);
                return 1;
            }
        }

        [UnityEngine.Scripting.Preserve]
        public void pageStarted(string v0d13595f0079)
        {
            v270cd8ab3530.NotifyPageStarted(v0d13595f0079);
        }

        [UnityEngine.Scripting.Preserve]
        public void pageCommitted(string v0d13595f0079)
        {
            v270cd8ab3530.NotifyPageCommitted(v0d13595f0079);
        }

        [UnityEngine.Scripting.Preserve]
        public void v6aa337e09394(int percent)
        {
            v270cd8ab3530.NotifyProgress(percent);
        }

        [UnityEngine.Scripting.Preserve]
        public void pageFinished(int v35cc37776d16, string v0d13595f0079)
        {
            v270cd8ab3530.NotifyPageFinished(v35cc37776d16, v0d13595f0079);
        }

        [UnityEngine.Scripting.Preserve]
        public void pageError(string v0d13595f0079)
        {
            v270cd8ab3530.NotifyPageError(v0d13595f0079);
        }

        [UnityEngine.Scripting.Preserve]
        public void popupOpened(string id)
        {
            v270cd8ab3530.NotifyPopupOpened(id);
        }

        [UnityEngine.Scripting.Preserve]
        public void popupClosed(string id)
        {
            v270cd8ab3530.NotifyPopupClosed(id);
        }

        [UnityEngine.Scripting.Preserve]
        public void popupStarted(string id, string v0d13595f0079)
        {
            v270cd8ab3530.NotifyPopupStarted(id, v0d13595f0079);
        }

        [UnityEngine.Scripting.Preserve]
        public void popupFinished(string id, string v0d13595f0079)
        {
            v270cd8ab3530.NotifyPopupFinished(id, v0d13595f0079);
        }

        [UnityEngine.Scripting.Preserve]
        public int allowCapture(string resources)
        {
            v84aacb7e185f v75b7e1cc723f = v270cd8ab3530;
            if (v75b7e1cc723f == null || v75b7e1cc723f.v5050e8446b1f || v75b7e1cc723f.AllowCapture == null)
                return 1;

            try
            {
                return v75b7e1cc723f.AllowCapture(resources ?? string.Empty);
            }
            catch (Exception exception)
            {
                Debug.LogWarning(vd16a86946a68.v823907a15f37(38) + exception.Message);
                return 0;
            }
        }
    }
}

internal static class vd16a86946a68
{
    private const byte vec7b373d6751 = 0x1F;

    private const string vefa92e1137d3 = "A200000000175630260682bd0213b29362968b532dbf1ce3fc88014630a4da69";
    private const string v5c4b3d311692 = "A200000001ac304142ee707140";
    private const string v555703850dc4 = "A20000000215258e3d4cafdfc5";
    private const string v9c3a0e43fa12 = "A200000003d1786db5835ed8c0";
    private const string v798493f7fc0f = "A200000004d8d6b5e8fb8fa582";
    private const string vace63d2e6601 = "A200000005aecff707aec7c61f3a62";
    private const string v35558e0345a4 = "A2000000064d4d7584778aead2a71df10e07";
    private const string v2167a86f3611 = "A200000007b3e2e3b2927a1cc361d9e51d5e5ffcf296";
    private const string v8eb9a9b824f2 = "A200000008e51bc6f8ad40266e304872";
    private const string va939abdeae9a = "A200000009efa3c02eb8ea201ed44eef1fed096693";
    private const string v06b69b10c97f = "A20000000ad922eb9d562e29df6605f298ed1b44d9";
    private const string v0d71f13fd0cb = "A20000000b14514279efe2000656cbc937a10a7c8783ca01410c";
    private const string v2816dcea7196 = "A20000000c7b6e865c8586f5c700312f64c90d";
    private const string vd14d8aae2d05 = "A20000000d9a9ab9a2708b962c655406241d1ddb07b006cb295f64be7e";
    private const string ve2b226c53717 = "A20000000e4ef57b745a5c249f";
    private const string vb6542cf1d6c1 = "A20000000f46907ed9ea49a4cc96f7afcf5d";
    private const string vdfc1b3114f7c = "A200000010e94db1705803e40e37c00f03c5d0";
    private const string vc82011e5271a = "A2000000115353d7deca7853591f6c0d08573e";
    private const string v7d289ae67183 = "A200000012a9ff6ad3809eefd6ed00343d1d56be5074e5dc059e3ae45a";
    private const string v449ee4983b66 = "A2000000130e860a905e90d018469c145162";
    private const string va007b7641aa0 = "A200000014a6b88d642283d3cc40e95d45500d6981a0";
    private const string v7f898b966cfe = "A200000015f3b57b21231d53c210e7eac2a6";
    private const string v864a7693f4a0 = "A20000001655fe10409277321b2f2385";
    private const string v543682c259a3 = "A2000000177522743dec606e2f17c02d6bc1f62fbc2c91fb13a3";
    private const string v7d9592db4d34 = "A20000001847e140002c1ef68d9f2737c45ad00b42fb8ad8313dbf0355c471afa32bb7afe530f6";
    private const string v2fc242901dda = "A20000001903dc66663f6f9a82ea6a19b757d6b8a6753a60";
    private const string v0d773016f068 = "A20000001a9e0dc3eb932764d934f384ff183c6ebcfcb353f18f57b8b6f03a37";
    private const string v0917e99e90e3 = "A20000001bd84caf949914d0fdeb57ea0e6a644219e328";
    private const string va1eb6600d615 = "A20000001cd05f80982b509ac36a957e0d";
    private const string vaea4c3a95f50 = "A20000001dc75a2333a410";
    private const string v732cfca9b96f = "A20000001e15bc7a2bc92ec27a43b55f03";
    private const string ve4374152b44a = "A20000001f5fb1f67259b2";
    private const string v18e588fdf256 = "A20000002038ab05fe2c6545a8877f5b1e";
    private const string vcf0fd392581a = "A200000021c20c8a1e82f3";
    private const string vfd8d68b61c93 = "A200000022481ff2af339460039a38be0b31a7817fe144b45d5e90";
    private const string v4fdb4f9ee0b6 = "A200000023dfe0ed3d77b693402c7eda83284296ee63fcf53acfe7";
    private const string vb854735b813f = "A2000000248c7886a03cbd04f4313bbc263b2a1192e8087e970e5fb1c050cac032396d5361860bb3adcc60";
    private const string v7835d0b59a10 = "A20000002508947055d768a1bc67dc22a974e5b309f3a52d54";
    private const string v5a42d0925199 = "A2000000265bc95efae71b0a2113886431769934d4f256cf0799";

    internal static string v823907a15f37(int id)
    {
        switch (id)
        {
            case 0: return vc957e39cc32c(vefa92e1137d3);
            case 1: return vc957e39cc32c(v5c4b3d311692);
            case 2: return vc957e39cc32c(v555703850dc4);
            case 3: return vc957e39cc32c(v9c3a0e43fa12);
            case 4: return vc957e39cc32c(v798493f7fc0f);
            case 5: return vc957e39cc32c(vace63d2e6601);
            case 6: return vc957e39cc32c(v35558e0345a4);
            case 7: return vc957e39cc32c(v2167a86f3611);
            case 8: return vc957e39cc32c(v8eb9a9b824f2);
            case 9: return vc957e39cc32c(va939abdeae9a);
            case 10: return vc957e39cc32c(v06b69b10c97f);
            case 11: return vc957e39cc32c(v0d71f13fd0cb);
            case 12: return vc957e39cc32c(v2816dcea7196);
            case 13: return vc957e39cc32c(vd14d8aae2d05);
            case 14: return vc957e39cc32c(ve2b226c53717);
            case 15: return vc957e39cc32c(vb6542cf1d6c1);
            case 16: return vc957e39cc32c(vdfc1b3114f7c);
            case 17: return vc957e39cc32c(vc82011e5271a);
            case 18: return vc957e39cc32c(v7d289ae67183);
            case 19: return vc957e39cc32c(v449ee4983b66);
            case 20: return vc957e39cc32c(va007b7641aa0);
            case 21: return vc957e39cc32c(v7f898b966cfe);
            case 22: return vc957e39cc32c(v864a7693f4a0);
            case 23: return vc957e39cc32c(v543682c259a3);
            case 24: return vc957e39cc32c(v7d9592db4d34);
            case 25: return vc957e39cc32c(v2fc242901dda);
            case 26: return vc957e39cc32c(v0d773016f068);
            case 27: return vc957e39cc32c(v0917e99e90e3);
            case 28: return vc957e39cc32c(va1eb6600d615);
            case 29: return vc957e39cc32c(vaea4c3a95f50);
            case 30: return vc957e39cc32c(v732cfca9b96f);
            case 31: return vc957e39cc32c(ve4374152b44a);
            case 32: return vc957e39cc32c(v18e588fdf256);
            case 33: return vc957e39cc32c(vcf0fd392581a);
            case 34: return vc957e39cc32c(vfd8d68b61c93);
            case 35: return vc957e39cc32c(v4fdb4f9ee0b6);
            case 36: return vc957e39cc32c(vb854735b813f);
            case 37: return vc957e39cc32c(v7835d0b59a10);
            case 38: return vc957e39cc32c(v5a42d0925199);
            default: return string.Empty;
        }
    }

    private static string vc957e39cc32c(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)vec7b373d6751 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
