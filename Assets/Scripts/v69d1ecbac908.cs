using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class v69d1ecbac908 : MonoBehaviour
{
    public static bool v2180913dbf11 { get; private set; }

    private v84aacb7e185f v9413259426c3;
    private GameObject vdf9c5b2e1d4e;
    private Rect va398227cee7a;
    private Vector2 vc8e163f2eca1;

    public void v2b8949161bae(string v0b45f0bcf454)
    {
        if (string.IsNullOrWhiteSpace(v0b45f0bcf454))
        {
            Debug.LogError(v2635273a69d6.v904823190934(0), this);
            return;
        }

        va6c74f7f4358();

        v9413259426c3 = new v84aacb7e185f();
#if UNITY_ANDROID && !UNITY_EDITOR
        if (v9413259426c3.Ready)
            v9413259426c3.SetAcceptThirdPartyCookies(true);
#endif
        if (!v9413259426c3.Ready)
        {
            v9413259426c3.Destroy();
            v9413259426c3 = null;
            Application.OpenURL(v0b45f0bcf454);
            return;
        }

        v2180913dbf11 = true;
        ve0ec851c9e06();
        v0328d128ee7d();
        v9413259426c3.Load(v0b45f0bcf454);
        v9413259426c3.Show();
    }

    private void Update()
    {
        if (!v2180913dbf11 || v9413259426c3 == null)
            return;

        if (v9ac76553be15())
        {
            if (v9413259426c3.CloseTopPopup())
                return;

            if (v9413259426c3.CanGoBack)
            {
                v9413259426c3.GoBack();
                return;
            }

            va6c74f7f4358();
            return;
        }

        if (va398227cee7a != Screen.safeArea ||
            vc8e163f2eca1.x != Screen.width ||
            vc8e163f2eca1.y != Screen.height)
        {
            v0328d128ee7d();
        }
    }

    private void va6c74f7f4358()
    {
        v2180913dbf11 = false;

        if (v9413259426c3 != null)
        {
            v9413259426c3.Hide();
            v9413259426c3.Destroy();
            v9413259426c3 = null;
        }

        if (vdf9c5b2e1d4e != null)
        {
            Destroy(vdf9c5b2e1d4e);
            vdf9c5b2e1d4e = null;
        }
    }

    private void OnDestroy()
    {
        va6c74f7f4358();
    }

    private void ve0ec851c9e06()
    {
        if (vdf9c5b2e1d4e != null)
            return;

        v0ec67c69dbf0();

        vdf9c5b2e1d4e = new GameObject(v2635273a69d6.v904823190934(1), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        vdf9c5b2e1d4e.transform.SetParent(transform, false);
        Canvas canvas = vdf9c5b2e1d4e.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = short.MaxValue;
        canvas.overrideSorting = true;

        Sprite uiSprite = Resources.GetBuiltinResource<Sprite>(v2635273a69d6.v904823190934(2));
        var barObject = new GameObject(v2635273a69d6.v904823190934(3), typeof(RectTransform), typeof(Image));
        RectTransform bar = barObject.GetComponent<RectTransform>();
        bar.SetParent(vdf9c5b2e1d4e.transform, false);
        bar.anchorMin = new Vector2(0f, 1f);
        bar.anchorMax = new Vector2(1f, 1f);
        bar.pivot = new Vector2(0.5f, 1f);
        Image barImage = barObject.GetComponent<Image>();
        barImage.sprite = uiSprite;
        barImage.type = Image.Type.Sliced;
        barImage.color = new Color(0.08f, 0.08f, 0.1f, 1f);

        var buttonObject = new GameObject(v2635273a69d6.v904823190934(4), typeof(RectTransform), typeof(Image), typeof(Button));
        RectTransform buttonRect = buttonObject.GetComponent<RectTransform>();
        buttonRect.SetParent(bar, false);
        buttonRect.anchorMin = new Vector2(1f, 0.15f);
        buttonRect.anchorMax = new Vector2(1f, 0.85f);
        buttonRect.pivot = new Vector2(1f, 0.5f);
        buttonRect.sizeDelta = new Vector2(160f, 0f);
        buttonRect.anchoredPosition = new Vector2(-12f, 0f);
        Image buttonImage = buttonObject.GetComponent<Image>();
        buttonImage.sprite = uiSprite;
        buttonImage.type = Image.Type.Sliced;
        buttonImage.color = new Color(0.95f, 0.96f, 0.98f, 1f);
        buttonObject.GetComponent<Button>().onClick.AddListener(va6c74f7f4358);

        var textObject = new GameObject(v2635273a69d6.v904823190934(5), typeof(RectTransform), typeof(Text));
        RectTransform textRect = textObject.GetComponent<RectTransform>();
        textRect.SetParent(buttonRect, false);
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = textRect.offsetMax = Vector2.zero;
        Text vc5a85fb48e5f = textObject.GetComponent<Text>();
        vc5a85fb48e5f.text = v2635273a69d6.v904823190934(6);
        vc5a85fb48e5f.font = Resources.GetBuiltinResource<Font>(v2635273a69d6.v904823190934(7));
        vc5a85fb48e5f.fontSize = 28;
        vc5a85fb48e5f.alignment = TextAnchor.MiddleCenter;
        vc5a85fb48e5f.color = new Color(0.12f, 0.12f, 0.15f, 1f);
    }

    private void v0328d128ee7d()
    {
        if (v9413259426c3 == null || !v9413259426c3.Ready || Screen.width <= 0 || Screen.height <= 0)
            return;

        Rect vd2a045609ac8 = Screen.safeArea;
        int left = Mathf.Max(0, Mathf.RoundToInt(vd2a045609ac8.xMin));
        int right = Mathf.Max(0, Mathf.RoundToInt(Screen.width - vd2a045609ac8.xMax));
        int bottom = Mathf.Max(0, Mathf.RoundToInt(vd2a045609ac8.yMin));
        int top = Mathf.Max(0, Mathf.RoundToInt(Screen.height - vd2a045609ac8.yMax)) + v03e873bb6e50();
        v9413259426c3.SetMargins(left, top, right, bottom, Screen.width, Screen.height);

        if (vdf9c5b2e1d4e != null)
        {
            RectTransform bar = vdf9c5b2e1d4e.transform.GetChild(0) as RectTransform;
            if (bar != null)
            {
                int safeTop = Mathf.Max(0, Mathf.RoundToInt(Screen.height - vd2a045609ac8.yMax));
                bar.anchoredPosition = new Vector2((left - right) * 0.5f, -safeTop);
                bar.sizeDelta = new Vector2(-(left + right), v03e873bb6e50());
            }
        }

        va398227cee7a = Screen.safeArea;
        vc8e163f2eca1 = new Vector2(Screen.width, Screen.height);
    }

    private static int v03e873bb6e50()
    {
        float dpi = Screen.dpi > 0f ? Screen.dpi : 160f;
        return Mathf.Max(64, Mathf.RoundToInt(56f * dpi / 160f));
    }

    private void v0ec67c69dbf0()
    {
        EventSystem[] all = Resources.FindObjectsOfTypeAll<EventSystem>();
        for (int i = 0; i < all.Length; i++)
        {
            EventSystem candidate = all[i];
            if (candidate != null && candidate.isActiveAndEnabled && candidate.gameObject.hideFlags == HideFlags.None)
                return;
        }

        var events = new GameObject(v2635273a69d6.v904823190934(8));
        events.transform.SetParent(transform, false);
        events.AddComponent<EventSystem>();
        events.AddComponent<InputSystemUIInputModule>();
    }

    private static bool v9ac76553be15()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.escapeKey.wasReleasedThisFrame)
            return true;

#if ENABLE_LEGACY_INPUT_MANAGER
        return Input.GetKeyUp(KeyCode.Escape);
#else
        return false;
#endif
    }
}

internal static class v2635273a69d6
{
    private const byte v95e8e9681150 = 0xA4;

    private const string v5d20d55e0fba = "A200000000f4400c610a3116059e1f25956b76ac100e4b4b142fa247146f73a66a7f3479f3";
    private const string v40fe02954ed4 = "A200000001394168114b44cd793c077b6a9b17493f0a565e483bfb87";
    private const string v027fa1512324 = "A20000000285f06e9efef9b21c6117dd60239c970ecf1ee75aa6a1ce64";
    private const string ve8d915480c8b = "A200000003e49fd244575db79fbaac04aa";
    private const string ve95de666777f = "A2000000045fa0d7f053d03cefca";
    private const string vd77759e63e1e = "A20000000578dc1101772b9f24";
    private const string v366cfbe50c14 = "A20000000655d75c2baaf11e5a23";
    private const string v7d16d5dd1cfa = "A200000007a07619b2a42977ed8925d6be30b2aa0b203551840d";
    private const string vd1db26412ce3 = "A200000008fb348a736583ff51e191278dea9a3103abd30e70c26aba1a";

    internal static string v904823190934(int id)
    {
        switch (id)
        {
            case 0: return v6144de374885(v5d20d55e0fba);
            case 1: return v6144de374885(v40fe02954ed4);
            case 2: return v6144de374885(v027fa1512324);
            case 3: return v6144de374885(ve8d915480c8b);
            case 4: return v6144de374885(ve95de666777f);
            case 5: return v6144de374885(vd77759e63e1e);
            case 6: return v6144de374885(v366cfbe50c14);
            case 7: return v6144de374885(v7d16d5dd1cfa);
            case 8: return v6144de374885(vd1db26412ce3);
            default: return string.Empty;
        }
    }

    private static string v6144de374885(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v95e8e9681150 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
