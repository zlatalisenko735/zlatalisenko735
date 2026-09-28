using System;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class v7f7d3fda5a38 : MonoBehaviour
{
    private GameObject vbbd434297564;
    private v84aacb7e185f vb663a9eca10d;
    private Canvas v8b145e489545;
    private RectTransform vf8e656813bde;
    private Rect va398227cee7a;
    private Vector2 vc8e163f2eca1;
    private bool v03aaf420da7e;
    private bool vefe3289db1f7;
    private bool v67521d3619e2;
    private bool v273f5e033a88;
    private bool v2bffbdd6a2b9;
    private bool vece3a51e327f;
    private Action v320d2582bc7b;
    private GameObject v7f68da1c353e;
    private Text v01783d8b62ea;
    private Button vbdec2f588777;
    private Button va8300ef7c72b;
    private PermissionCallbacks va4458fbe7e78;
    private int va2e7eca3edda;
    private bool vbeee936aa0ab;
    private bool vc77e6a3b4bcb;
    private bool v947405bfa4c6;
    private bool v321b47501f12;
    private Action v211b95b19e0c;
    private GameObject v7f0883396006;

    private readonly string[] v6023aa087f6e =
    {
        v6cd8e82216d0.v86e3c03bd405(0),
        v6cd8e82216d0.v86e3c03bd405(1),
        v6cd8e82216d0.v86e3c03bd405(2),
        v6cd8e82216d0.v86e3c03bd405(3),
        v6cd8e82216d0.v86e3c03bd405(4),
        v6cd8e82216d0.v86e3c03bd405(5),
        v6cd8e82216d0.v86e3c03bd405(6),
        v6cd8e82216d0.v86e3c03bd405(7),
        v6cd8e82216d0.v86e3c03bd405(8),
        v6cd8e82216d0.v86e3c03bd405(9),
        v6cd8e82216d0.v86e3c03bd405(10),
        v6cd8e82216d0.v86e3c03bd405(11),
        v6cd8e82216d0.v86e3c03bd405(12),
    };

    private static string vfc02a987c9e9()
    {
        return Application.productName + v6cd8e82216d0.v86e3c03bd405(13) + Application.version + v6cd8e82216d0.v86e3c03bd405(14) + SystemInfo.operatingSystem + v6cd8e82216d0.v86e3c03bd405(15) + SystemInfo.deviceModel + v6cd8e82216d0.v86e3c03bd405(16) + Application.systemLanguage + v6cd8e82216d0.v86e3c03bd405(17);
    }

    private void Awake()
    {
        Input.backButtonLeavesApp = false;
        v6447999c2121();
        ve33c80a8ac0b();
        v4ab26c0b7619();
        if (vb663a9eca10d == null || !vb663a9eca10d.Ready)
            return;

        vefe3289db1f7 = true;
        vb663a9eca10d.Load(v6cd8e82216d0.v86e3c03bd405(18));
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(19));
    }

    public void v24adf7a150b3(string v0d13595f0079)
    {
        v321b47501f12 = false;
        v9f3df0c551c1(v0d13595f0079, null);
    }

    public void v24adf7a150b3(string v0d13595f0079, Action v466a28c00975)
    {
        v321b47501f12 = false;
        v9f3df0c551c1(v0d13595f0079, v466a28c00975);
    }

    public void v24adf7a150b3(string v0d13595f0079, GameObject v7fe6b727edea, Action v466a28c00975)
    {
        v321b47501f12 = false;
        if (v7fe6b727edea != null)
            vbbd434297564 = v7fe6b727edea;

        v9f3df0c551c1(v0d13595f0079, v466a28c00975);
    }

    public void v715c515c8728(string v0d13595f0079, Action va6c9848e389c)
    {
        v321b47501f12 = true;
        v211b95b19e0c = va6c9848e389c;
        v9f3df0c551c1(v0d13595f0079, null);
        vc45955a9e90b();
        v17867fafc844();
    }

    private void v9f3df0c551c1(string v0d13595f0079, Action v466a28c00975)
    {
        if (!v4be514ba1639(v0d13595f0079))
        {
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(20));
            return;
        }

        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(21));
        if (!v321b47501f12)
        {
            v211b95b19e0c = null;
            v999783486e1c();
        }

        v320d2582bc7b = v466a28c00975;
        v4ab26c0b7619();
        if (vb663a9eca10d == null || !vb663a9eca10d.Ready)
        {
            Application.OpenURL(v0d13595f0079);
            return;
        }

        vefe3289db1f7 = false;
        v67521d3619e2 = false;
        v273f5e033a88 = v2bffbdd6a2b9 = false;
        vb663a9eca10d.SetUserAgent(v6cd8e82216d0.v86e3c03bd405(22));
        v17867fafc844();
        vf58434ca8f98();

        vb663a9eca10d.vfb50e116aaf8();
        vb663a9eca10d.Load(v0d13595f0079);
        vb663a9eca10d.Show();
        vece3a51e327f = true;
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(23));
    }

    private void v4ab26c0b7619()
    {
        if (vb663a9eca10d == null)
        {
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(24));
            vb663a9eca10d = new v84aacb7e185f();
#if UNITY_ANDROID && !UNITY_EDITOR
            vb663a9eca10d.SetAcceptThirdPartyCookies(true);
#endif
            vb663a9eca10d.SetUserAgent(v6cd8e82216d0.v86e3c03bd405(25));
        }

        v88bc446865ab();
        v17867fafc844();
    }

    private void v88bc446865ab()
    {
        if (v03aaf420da7e || vb663a9eca10d == null)
            return;

        v03aaf420da7e = true;
        vb663a9eca10d.AllowCapture = resources =>
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            bool video = string.IsNullOrEmpty(resources) || Contains(resources, v6cd8e82216d0.v86e3c03bd405(26));
            bool audio = Contains(resources, v6cd8e82216d0.v86e3c03bd405(27));
             string microphone = v6cd8e82216d0.v86e3c03bd405(28);
            bool needVideo = video && !Permission.HasUserAuthorizedPermission(Permission.Camera);
            bool needAudio = audio && !Permission.HasUserAuthorizedPermission(microphone);
            if (!needVideo && !needAudio)
                return 1;

            vbeee936aa0ab = needVideo;
            vc77e6a3b4bcb = needAudio;
            return 2;
#else
            return 1;
#endif
        };

        vb663a9eca10d.HandleRequest = (v0d13595f0079, mainFrame, isPopup) =>
        {
            if (string.IsNullOrEmpty(v0d13595f0079))
                return true;

            if (isPopup)
                return !v7a58c2085734(v0d13595f0079);

            if (Contains(v0d13595f0079, v6cd8e82216d0.v86e3c03bd405(29)) || v7a58c2085734(v0d13595f0079))
            {
                if (vbbd434297564 != null)
                    vbbd434297564.SetActive(false);

                return false;
            }

            if (mainFrame &&
                ((v2b9847ec96f1(v0d13595f0079) && !v273f5e033a88) ||
                 (vc1aabc9dde32(v0d13595f0079) && !v2bffbdd6a2b9)))
            {
                if (v2b9847ec96f1(v0d13595f0079))
                    v273f5e033a88 = true;
                else
                    v2bffbdd6a2b9 = true;

                vb663a9eca10d.SetUserAgent(vfc02a987c9e9());
                vb663a9eca10d.Load(v0d13595f0079);
                v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(30));
                return false;
            }

            return true;
        };

        vb663a9eca10d.vbae5af4a28ee += v0d13595f0079 =>
        {
            if (vefe3289db1f7 && v7256d8a7018d(v0d13595f0079))
                return;

            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(31));
            if (Contains(v0d13595f0079, v6cd8e82216d0.v86e3c03bd405(32)) || Contains(v0d13595f0079, v6cd8e82216d0.v86e3c03bd405(33)) || v7a58c2085734(v0d13595f0079))
            {
                vb663a9eca10d.vfb50e116aaf8();
                v98cf68d5b691(v0d13595f0079);
            }
        };

        vb663a9eca10d.v6763ebe839c3 += v0d13595f0079 =>
        {
            if (!vefe3289db1f7 && !v67521d3619e2 && v4be514ba1639(v0d13595f0079))
                ve043cad9f758(v6cd8e82216d0.v86e3c03bd405(34));
        };

        vb663a9eca10d.v053e3da2061e += v6aa337e09394 =>
        {
            if (!vefe3289db1f7 && !v67521d3619e2 && v6aa337e09394 >= 0.65f)
                ve043cad9f758(v6cd8e82216d0.v86e3c03bd405(35));
        };

        vb663a9eca10d.v3f6189a064b3 += (status, v0d13595f0079) =>
        {
            if (vefe3289db1f7 && v7256d8a7018d(v0d13595f0079))
            {
                vefe3289db1f7 = false;
                v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(36));
                return;
            }

            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(37) + status);
            if (!v67521d3619e2)
                ve043cad9f758(v6cd8e82216d0.v86e3c03bd405(38));
            else if (vbbd434297564 != null)
                vbbd434297564.SetActive(false);

            vf3bd88f81650(v0d13595f0079);
        };

        vb663a9eca10d.v4a48fffc0b17 += failing =>
        {
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(39) + failing);
            if (!string.IsNullOrEmpty(failing) && !v7256d8a7018d(failing))
            {
                vb663a9eca10d.vfb50e116aaf8();
                v7a58c2085734(failing);
            }
        };

        vb663a9eca10d.vbb241c2d823c += id =>
        {
            vb663a9eca10d.ScrollToTop();
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(40) + id);
        };

        vb663a9eca10d.v33106a151e4b += id => v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(41) + id);
    }

    private void v5fb97d7fc23f()
    {
        if (va4458fbe7e78 != null)
            return;

        va4458fbe7e78 = new PermissionCallbacks();
        va4458fbe7e78.PermissionGranted += v19204f75f68a => v8297c0ac1550(true);
        va4458fbe7e78.PermissionDenied += v19204f75f68a => v8297c0ac1550(false);
        va4458fbe7e78.PermissionDeniedAndDontAskAgain += v19204f75f68a => v8297c0ac1550(false);
    }

    private void vea0dfb5a61b8()
    {
        if (!vbeee936aa0ab && !vc77e6a3b4bcb)
            return;

        v5fb97d7fc23f();
        va2e7eca3edda = 0;
        if (vbeee936aa0ab)
        {
            vbeee936aa0ab = false;
            va2e7eca3edda++;
            Permission.RequestUserPermission(Permission.Camera, va4458fbe7e78);
        }

        if (vc77e6a3b4bcb)
        {
            vc77e6a3b4bcb = false;
            va2e7eca3edda++;
            Permission.RequestUserPermission(v6cd8e82216d0.v86e3c03bd405(42), va4458fbe7e78);
        }
    }

    private void v8297c0ac1550(bool v9bc26490acc8)
    {
        if (!v9bc26490acc8)
        {
            va2e7eca3edda = 0;
            vbeee936aa0ab = false;
            vc77e6a3b4bcb = false;
            if (vb663a9eca10d != null)
                vb663a9eca10d.FinishCapture(false);
            return;
        }

        va2e7eca3edda--;
        if (va2e7eca3edda <= 0 && vb663a9eca10d != null)
        {
            va2e7eca3edda = 0;
            vb663a9eca10d.FinishCapture(true);
        }
    }

    private void ve043cad9f758(string v72b46e3a997c)
    {
        v67521d3619e2 = true;
        vf58434ca8f98();
        if (vbbd434297564 != null)
            vbbd434297564.SetActive(false);

        v17867fafc844();
        if (vb663a9eca10d != null)
            vb663a9eca10d.Show();

        vece3a51e327f = true;
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(43) + v72b46e3a997c);
    }

    public void v49979787eaa1()
    {
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(44));
        if (vb663a9eca10d != null)
            vb663a9eca10d.Hide();

        vc2064f016f04();
        vece3a51e327f = false;
        if (vbbd434297564 != null)
            vbbd434297564.SetActive(false);

        if (v7f68da1c353e != null)
            v7f68da1c353e.SetActive(false);

        v321b47501f12 = false;
        v211b95b19e0c = null;
        v999783486e1c();

        Action v9252f11b2796 = v320d2582bc7b;
        v320d2582bc7b = null;
        if (v9252f11b2796 != null)
            v9252f11b2796.Invoke();
    }

    private void Update()
    {
        vea0dfb5a61b8();
        v1e914ba7226c();

        if (!v321b47501f12 && v9ac76553be15() && vb663a9eca10d != null && vece3a51e327f && !v69d1ecbac908.v2180913dbf11)
        {
            if (v7f68da1c353e == null || !v7f68da1c353e.activeSelf)
                v3158e33fc40a();

            return;
        }

        if (va398227cee7a != Screen.safeArea ||
            vc8e163f2eca1.x != Screen.width ||
            vc8e163f2eca1.y != Screen.height)
        {
            v17867fafc844();
        }
    }

    private void OnApplicationFocus(bool v5befd455dbf9)
    {
        if (v5befd455dbf9)
            v17867fafc844();
    }

    private void OnApplicationPause(bool v4dedd9352a32)
    {
        if (!v4dedd9352a32)
            v17867fafc844();
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

    private void v3158e33fc40a()
    {
        try
        {
            if (vb663a9eca10d.CloseTopPopup())
            {
                v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(45));
                return;
            }

            string backUrl = vb663a9eca10d.CanGoBack ? vb663a9eca10d.BackUrl() : null;
            if (!string.IsNullOrWhiteSpace(backUrl) && !v7256d8a7018d(backUrl))
            {
                v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(46));
                vb663a9eca10d.GoBack();
                return;
            }
        }
        catch (Exception e)
        {
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(47) + e.Message);
        }

        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(48));
        vb663a9eca10d.Hide();
        v5953658b1333();
    }

    private void vf58434ca8f98()
    {
        v947405bfa4c6 = true;
        v1e914ba7226c();
    }

    private void vc2064f016f04()
    {
        v947405bfa4c6 = false;
    }

    private void v1e914ba7226c()
    {
        if (!v947405bfa4c6)
            return;

        vd0454ff015af panels = vd0454ff015af.vcf760af7341c;
        if (panels == null)
            return;

        v8a1579f15447(panels.panel_loader);
        v8a1579f15447(panels.panel_menu);
        v8a1579f15447(panels.panel_game);
    }

    private static void v8a1579f15447(GameObject v1f278f2d5510)
    {
        if (v1f278f2d5510 != null && v1f278f2d5510.activeSelf)
            v1f278f2d5510.SetActive(false);
    }

    private Canvas v6447999c2121()
    {
        if (v8b145e489545 != null)
            return v8b145e489545;

        var go = new GameObject(v6cd8e82216d0.v86e3c03bd405(49), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        go.transform.SetParent(transform, false);
        v8b145e489545 = go.GetComponent<Canvas>();
        v8b145e489545.renderMode = RenderMode.ScreenSpaceOverlay;
        v8b145e489545.sortingOrder = short.MaxValue;
        v8b145e489545.overrideSorting = true;
        v0ec67c69dbf0();
        return v8b145e489545;
    }

    private void v0ec67c69dbf0()
    {
        EventSystem live = null;
        EventSystem[] all = Resources.FindObjectsOfTypeAll<EventSystem>();
        for (int i = 0; i < all.Length; i++)
        {
            EventSystem candidate = all[i];
            if (candidate == null || !candidate.isActiveAndEnabled)
                continue;
            if (candidate.gameObject.hideFlags != HideFlags.None)
                continue;

            live = candidate;
            break;
        }

        if (live == null)
        {
            var events = new GameObject(v6cd8e82216d0.v86e3c03bd405(50));
            events.transform.SetParent(transform, false);
            live = events.AddComponent<EventSystem>();
            events.AddComponent<InputSystemUIInputModule>();
            return;
        }

        if (live.GetComponent<InputSystemUIInputModule>() == null)
        {
            StandaloneInputModule oldModule = live.GetComponent<StandaloneInputModule>();
            if (oldModule != null)
                Destroy(oldModule);

            live.gameObject.AddComponent<InputSystemUIInputModule>();
        }
    }

    private void ve33c80a8ac0b()
    {
        if (vf8e656813bde != null)
            return;

        var go = new GameObject(v6cd8e82216d0.v86e3c03bd405(51), typeof(RectTransform));
        vf8e656813bde = go.GetComponent<RectTransform>();
        vf8e656813bde.SetParent(v6447999c2121().transform, false);
        vf8e656813bde.anchorMin = Vector2.zero;
        vf8e656813bde.anchorMax = Vector2.one;
        vf8e656813bde.offsetMin = vf8e656813bde.offsetMax = Vector2.zero;
    }

    private void v17867fafc844()
    {
        ve33c80a8ac0b();
        if (Screen.width <= 0 || Screen.height <= 0)
            return;

        Rect vd2a045609ac8 = Screen.safeArea;
        vf8e656813bde.anchorMin = new Vector2(vd2a045609ac8.xMin / Screen.width, vd2a045609ac8.yMin / Screen.height);
        vf8e656813bde.anchorMax = new Vector2(vd2a045609ac8.xMax / Screen.width, vd2a045609ac8.yMax / Screen.height);
        vf8e656813bde.offsetMin = vf8e656813bde.offsetMax = Vector2.zero;

        if (vb663a9eca10d != null && vb663a9eca10d.Ready)
        {
            int left = Mathf.Max(0, Mathf.RoundToInt(vd2a045609ac8.xMin));
            int right = Mathf.Max(0, Mathf.RoundToInt(Screen.width - vd2a045609ac8.xMax));
            int bottom = Mathf.Max(0, Mathf.RoundToInt(vd2a045609ac8.yMin));
            if (v321b47501f12)
                bottom += v2e55096e9a76();
            int top = Mathf.Max(0, Mathf.RoundToInt(Screen.height - vd2a045609ac8.yMax));
            vb663a9eca10d.SetMargins(left, top, right, bottom, Screen.width, Screen.height);
            v6b4189b91f15(vd2a045609ac8);
        }

        va398227cee7a = Screen.safeArea;
        vc8e163f2eca1 = new Vector2(Screen.width, Screen.height);
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(52) + Screen.width + v6cd8e82216d0.v86e3c03bd405(53) + Screen.height);
    }

    private void v5953658b1333()
    {
        vece3a51e327f = false;
        v6447999c2121();
        v8b145e489545.gameObject.SetActive(true);
        v0375a7e6f2c4();
        v01783d8b62ea.text = v6023aa087f6e[UnityEngine.Random.Range(0, v6023aa087f6e.Length)];
        vbdec2f588777.onClick.RemoveAllListeners();
        va8300ef7c72b.onClick.RemoveAllListeners();
        vbdec2f588777.onClick.AddListener(() =>
        {
            v7f68da1c353e.SetActive(false);
            if (vb663a9eca10d != null)
                vb663a9eca10d.Show();
            vece3a51e327f = true;
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(54));
        });
        va8300ef7c72b.onClick.AddListener(() =>
        {
            v7f68da1c353e.SetActive(false);
            if (vb663a9eca10d != null)
                vb663a9eca10d.Hide();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
        v7f68da1c353e.SetActive(true);
        v7f68da1c353e.transform.SetAsLastSibling();
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(55));
    }

    private void v0375a7e6f2c4()
    {
        if (v7f68da1c353e != null)
            return;

        ve33c80a8ac0b();
        Sprite uiSprite = Resources.GetBuiltinResource<Sprite>(v6cd8e82216d0.v86e3c03bd405(56));
        v7f68da1c353e = new GameObject(v6cd8e82216d0.v86e3c03bd405(57), typeof(RectTransform), typeof(Image));
        var root = v7f68da1c353e.GetComponent<RectTransform>();
        root.SetParent(vf8e656813bde, false);
        root.anchorMin = Vector2.zero;
        root.anchorMax = Vector2.one;
        root.offsetMin = root.offsetMax = Vector2.zero;
        Image dim = v7f68da1c353e.GetComponent<Image>();
        dim.sprite = uiSprite;
        dim.type = Image.Type.Sliced;
        dim.color = new Color(0f, 0f, 0f, 0.65f);

        var v1f278f2d5510 = new GameObject(v6cd8e82216d0.v86e3c03bd405(58), typeof(RectTransform), typeof(Image));
        var panelRect = v1f278f2d5510.GetComponent<RectTransform>();
        panelRect.SetParent(root, false);
        panelRect.anchorMin = panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(Mathf.Min(Screen.width * 0.86f, 720f), 380f);
        Image panelImage = v1f278f2d5510.GetComponent<Image>();
        panelImage.sprite = uiSprite;
        panelImage.type = Image.Type.Sliced;
        panelImage.color = Color.white;

        var textObject = new GameObject(v6cd8e82216d0.v86e3c03bd405(59), typeof(RectTransform), typeof(Text));
        var textRect = textObject.GetComponent<RectTransform>();
        textRect.SetParent(panelRect, false);
        textRect.anchorMin = new Vector2(0.08f, 0.42f);
        textRect.anchorMax = new Vector2(0.92f, 0.92f);
        textRect.offsetMin = textRect.offsetMax = Vector2.zero;
        v01783d8b62ea = textObject.GetComponent<Text>();
        v01783d8b62ea.font = Resources.GetBuiltinResource<Font>(v6cd8e82216d0.v86e3c03bd405(60));
        v01783d8b62ea.fontSize = 32;
        v01783d8b62ea.fontStyle = FontStyle.Bold;
        v01783d8b62ea.alignment = TextAnchor.MiddleCenter;
        v01783d8b62ea.color = new Color(0.12f, 0.12f, 0.15f);

        vbdec2f588777 = vc88cea30d111(v6cd8e82216d0.v86e3c03bd405(61), panelRect, new Vector2(0.08f, 0.1f), new Vector2(0.48f, 0.34f), new Color(0.13f, 0.77f, 0.37f), uiSprite);
        va8300ef7c72b = vc88cea30d111(v6cd8e82216d0.v86e3c03bd405(62), panelRect, new Vector2(0.52f, 0.1f), new Vector2(0.92f, 0.34f), new Color(0.95f, 0.96f, 0.98f), uiSprite);
        v7f68da1c353e.SetActive(false);
    }

    private static Button vc88cea30d111(string vc5a85fb48e5f, Transform parent, Vector2 vabb51165a107, Vector2 v2acee24e990d, Color color, Sprite sprite)
    {
        var buttonObject = new GameObject(vc5a85fb48e5f, typeof(RectTransform), typeof(Image), typeof(Button));
        var rect = buttonObject.GetComponent<RectTransform>();
        rect.SetParent(parent, false);
        rect.anchorMin = vabb51165a107;
        rect.anchorMax = v2acee24e990d;
        rect.offsetMin = rect.offsetMax = Vector2.zero;
        Image image = buttonObject.GetComponent<Image>();
        image.sprite = sprite;
        image.type = Image.Type.Sliced;
        image.color = color;

        var textObject = new GameObject(v6cd8e82216d0.v86e3c03bd405(63), typeof(RectTransform), typeof(Text));
        var textRect = textObject.GetComponent<RectTransform>();
        textRect.SetParent(rect, false);
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = textRect.offsetMax = Vector2.zero;
        var text = textObject.GetComponent<Text>();
        text.text = vc5a85fb48e5f;
        text.font = Resources.GetBuiltinResource<Font>(v6cd8e82216d0.v86e3c03bd405(64));
        text.fontSize = 28;
        text.alignment = TextAnchor.MiddleCenter;
        return buttonObject.GetComponent<Button>();
    }

    private void vf3bd88f81650(string v0d13595f0079)
    {
        bool keepGoogle = v273f5e033a88 &&
                          (v2b9847ec96f1(v0d13595f0079) || Contains(v0d13595f0079, v6cd8e82216d0.v86e3c03bd405(65)) || Contains(v0d13595f0079, v6cd8e82216d0.v86e3c03bd405(66)));
        bool keepPayment = v2bffbdd6a2b9 && vc1aabc9dde32(v0d13595f0079);
        if ((v273f5e033a88 || v2bffbdd6a2b9) && !keepGoogle && !keepPayment)
        {
            v273f5e033a88 = v2bffbdd6a2b9 = false;
            if (vb663a9eca10d != null)
                vb663a9eca10d.SetUserAgent(v6cd8e82216d0.v86e3c03bd405(67));
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(68));
        }
    }

    private void v98cf68d5b691(string v0d13595f0079)
    {
        if (v4be514ba1639(v0d13595f0079))
            Application.OpenURL(v0d13595f0079);
    }

    private bool v7a58c2085734(string v0d13595f0079)
    {
        if (string.IsNullOrEmpty(v0d13595f0079))
            return false;

#if UNITY_ANDROID && !UNITY_EDITOR
        if (v0d13595f0079.StartsWith(v6cd8e82216d0.v86e3c03bd405(69), StringComparison.OrdinalIgnoreCase)
            || v7ad9464c2ec6(v0d13595f0079)
            || (!v4be514ba1639(v0d13595f0079) && !v7256d8a7018d(v0d13595f0079)))
        {
            return v1ff0d2a69153(v0d13595f0079);
        }
#endif
        return false;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private bool v1ff0d2a69153(string v0d13595f0079)
    {
        try
        {
            using (var player = new AndroidJavaClass(v6cd8e82216d0.v86e3c03bd405(70)))
            using (var activity = player.GetStatic<AndroidJavaObject>(v6cd8e82216d0.v86e3c03bd405(71)))
            using (var uriClass = new AndroidJavaClass(v6cd8e82216d0.v86e3c03bd405(72)))
            using (var uri = uriClass.CallStatic<AndroidJavaObject>(v6cd8e82216d0.v86e3c03bd405(73), v0d13595f0079))
            using (var intent = new AndroidJavaObject(v6cd8e82216d0.v86e3c03bd405(74), v6cd8e82216d0.v86e3c03bd405(75), uri))
            {
                intent.Call<AndroidJavaObject>(v6cd8e82216d0.v86e3c03bd405(76), v6cd8e82216d0.v86e3c03bd405(77));
                intent.Call<AndroidJavaObject>(v6cd8e82216d0.v86e3c03bd405(78), 0x10000000);
                activity.Call(v6cd8e82216d0.v86e3c03bd405(79), intent);
                return true;
            }
        }
        catch (Exception e)
        {
            v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(80) + e.Message);
            Application.OpenURL(v0d13595f0079);
            return true;
        }
    }
#endif

    private static bool v4be514ba1639(string value)
    {
        return Uri.TryCreate(value, UriKind.Absolute, out Uri uri)
               && (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp);
    }

    private static bool v7256d8a7018d(string value)
    {
        return !string.IsNullOrEmpty(value)
               && value.StartsWith(v6cd8e82216d0.v86e3c03bd405(81), StringComparison.OrdinalIgnoreCase);
    }

    private static bool Contains(string v72b46e3a997c, string value)
    {
        return !string.IsNullOrEmpty(v72b46e3a997c)
               && v72b46e3a997c.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private static bool v2b9847ec96f1(string v0d13595f0079)
    {
        return Contains(v0d13595f0079, v6cd8e82216d0.v86e3c03bd405(82));
    }

    private static bool vc1aabc9dde32(string v0d13595f0079)
    {
        if (!Uri.TryCreate(v0d13595f0079, UriKind.Absolute, out Uri uri))
            return false;

        return Contains(uri.Host, v6cd8e82216d0.v86e3c03bd405(83))
               || Contains(uri.Host, v6cd8e82216d0.v86e3c03bd405(84))
               || Contains(uri.Host, v6cd8e82216d0.v86e3c03bd405(85))
               || Contains(uri.AbsolutePath, v6cd8e82216d0.v86e3c03bd405(86))
               || Contains(uri.AbsolutePath, v6cd8e82216d0.v86e3c03bd405(87))
               || Contains(uri.AbsolutePath, v6cd8e82216d0.v86e3c03bd405(88))
               || Contains(uri.AbsolutePath, v6cd8e82216d0.v86e3c03bd405(89))
               || Contains(uri.AbsolutePath, v6cd8e82216d0.v86e3c03bd405(90));
    }

    private static bool v7ad9464c2ec6(string v0d13595f0079)
    {
        return v0d13595f0079.StartsWith(v6cd8e82216d0.v86e3c03bd405(91), StringComparison.OrdinalIgnoreCase)
               || v0d13595f0079.StartsWith(v6cd8e82216d0.v86e3c03bd405(92), StringComparison.OrdinalIgnoreCase)
               || v0d13595f0079.StartsWith(v6cd8e82216d0.v86e3c03bd405(93), StringComparison.OrdinalIgnoreCase);
    }

    private void vc45955a9e90b()
    {
        if (v7f0883396006 != null)
            return;

        v6447999c2121();
        ve33c80a8ac0b();
        Sprite uiSprite = Resources.GetBuiltinResource<Sprite>(v6cd8e82216d0.v86e3c03bd405(94));
        v7f0883396006 = new GameObject(v6cd8e82216d0.v86e3c03bd405(95), typeof(RectTransform), typeof(Image));
        var root = v7f0883396006.GetComponent<RectTransform>();
        root.SetParent(vf8e656813bde, false);
        Image bar = v7f0883396006.GetComponent<Image>();
        bar.sprite = uiSprite;
        bar.type = Image.Type.Sliced;
        bar.color = new Color(0.08f, 0.08f, 0.1f, 1f);

        v8601de571dda(v6cd8e82216d0.v86e3c03bd405(96), root, new Vector2(0.04f, 0.12f), new Vector2(0.48f, 0.88f), new Color(0.95f, 0.96f, 0.98f), uiSprite, v6f79a36c1ad6);
        v8601de571dda(v6cd8e82216d0.v86e3c03bd405(97), root, new Vector2(0.52f, 0.12f), new Vector2(0.96f, 0.88f), new Color(0.13f, 0.77f, 0.37f), uiSprite, v61b52358fc35);
        v6b4189b91f15(Screen.safeArea);
    }

    private void v6b4189b91f15(Rect vd2a045609ac8)
    {
        if (v7f0883396006 == null || Screen.width <= 0 || Screen.height <= 0)
            return;

        int bar = v2e55096e9a76();
        var root = v7f0883396006.GetComponent<RectTransform>();
        root.anchorMin = new Vector2(0f, 0f);
        root.anchorMax = new Vector2(1f, 0f);
        root.pivot = new Vector2(0.5f, 0f);
        root.sizeDelta = new Vector2(0f, bar);
        root.anchoredPosition = Vector2.zero;
        v7f0883396006.SetActive(v321b47501f12);
        v7f0883396006.transform.SetAsLastSibling();
    }

    private void v999783486e1c()
    {
        if (v7f0883396006 != null)
            v7f0883396006.SetActive(false);
    }

    private void v61b52358fc35()
    {
        Action va6c9848e389c = v211b95b19e0c;
        v321b47501f12 = false;
        v211b95b19e0c = null;
        v999783486e1c();
        if (vb663a9eca10d != null)
            vb663a9eca10d.Hide();
        vc2064f016f04();
        vece3a51e327f = false;
        if (vbbd434297564 != null)
            vbbd434297564.SetActive(false);
        va6c9848e389c?.Invoke();
    }

    private void v6f79a36c1ad6()
    {
        v0dae759a354c(v6cd8e82216d0.v86e3c03bd405(98));
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private static int v2e55096e9a76()
    {
        float dpi = Screen.dpi > 0f ? Screen.dpi : 160f;
        return Mathf.Max(64, Mathf.RoundToInt(64f * dpi / 160f));
    }

    private static void v8601de571dda(string vc5a85fb48e5f, Transform parent, Vector2 vabb51165a107, Vector2 v2acee24e990d, Color color, Sprite sprite, UnityEngine.Events.UnityAction v9c82d6f5791c)
    {
        var buttonObject = new GameObject(vc5a85fb48e5f, typeof(RectTransform), typeof(Image), typeof(Button));
        var rect = buttonObject.GetComponent<RectTransform>();
        rect.SetParent(parent, false);
        rect.anchorMin = vabb51165a107;
        rect.anchorMax = v2acee24e990d;
        rect.offsetMin = rect.offsetMax = Vector2.zero;
        Image image = buttonObject.GetComponent<Image>();
        image.sprite = sprite;
        image.type = Image.Type.Sliced;
        image.color = color;
        buttonObject.GetComponent<Button>().onClick.AddListener(v9c82d6f5791c);

        var textObject = new GameObject(v6cd8e82216d0.v86e3c03bd405(99), typeof(RectTransform), typeof(Text));
        var textRect = textObject.GetComponent<RectTransform>();
        textRect.SetParent(rect, false);
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = textRect.offsetMax = Vector2.zero;
        var text = textObject.GetComponent<Text>();
        text.text = vc5a85fb48e5f;
        text.font = Resources.GetBuiltinResource<Font>(v6cd8e82216d0.v86e3c03bd405(100));
        text.fontSize = 28;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = new Color(0.12f, 0.12f, 0.15f, 1f);
    }

    private void v0dae759a354c(string text)
    {
        Debug.Log(v6cd8e82216d0.v86e3c03bd405(101) + text);
    }

    private void OnDestroy()
    {
        if (vb663a9eca10d == null)
            return;

        vb663a9eca10d.Destroy();
        vb663a9eca10d = null;
    }
}

internal static class v6cd8e82216d0
{
    private const byte v9736a27ba4aa = 0xCE;

    private const string v333896ceffe4 = "A200000000a97ae77d2e1c59759c2fed8ed7cf9dd282804d8055442fa6835f479bd7e937d787222768796a30f968b03cdcec40c2a070aa4370bf1334c5780b02c80c55c41763d0ed";
    private const string v283ca2a277c9 = "A2000000013621df7585ff133cd1837e619b5200a192a447e8eab271717a168e5e75edbc5b67c2c7bc8a2c893a3c69ceb5081358bf9c4c0b";
    private const string vaa366f0499e4 = "A2000000029a57785070f4537de68ce4540d2964cb6ed4f1351a9d23e0b225b7d3d66e48c793498a76582824d84c84d53e126527e84cc39e";
    private const string vf7d94b5f4372 = "A200000003aa1647339d35626d2f81104f308ae1fc8280536fc18cd239b12e7499149f7926051625003b96bc628bd9b03292ff0fe9ba88105509464b9ede825e4bb7e6";
    private const string v9136a6bd3853 = "A20000000473b028102f1795097879be6ade045b50d420d5396da8b2ad4fc8854fb4e7396ba28ada65338c073ab8157ea3805d65abc17e68431c560ea819f4";
    private const string v73074f0cdf07 = "A200000005e2020ce97108a1ff8b9f1458c8ac41bd3726eb020bf4bae1c3224048e442314e5b4142e8d49941f58fea40de7701e791";
    private const string vb24f6ca94ed9 = "A20000000600cdf16bcf6f633e40f440751c0896e139464459cd782d36efcd3d9699d0bc4bac6208cf33c914b0dd39d76871a916e8885a081da0";
    private const string va24e04b3b570 = "A20000000764184ce3ef8c73864a16e41ec3c07c5e359c6f283c0e098861a9e668ed808902d03a94410c300e8f0146dff2de0adbaa0a354b4be604fdd0afa7d503d8525f0f49a4e2";
    private const string v3589abde4443 = "A20000000812ce670701f165bad4974755d4e0444f03553bb51702eeb64830d1717bd7f7545c41e5b1c819c21d323755475cf05d58648a1adfeef34b";
    private const string vcc40b1bd1a2a = "A2000000091a3b494d69f51469207c57202a3c21836c7662d57ecfc4922efccce4674a8d3ad5b6474dbb79cd78b80d227067bb70f80914c2793996791133";
    private const string vd7c5b2b5c768 = "A20000000af500101d9f8f284f960bdb6fa39cfb87ff1558f891c9f07aff1065560bf8c7df377a8e60bb1d191a68cd575e110386e84f5169";
    private const string v2e50cdf8f2df = "A20000000b9acccab6c9ee2668e3e3a682f0931060d3a34ed036b24c24d8d9934d1b209aa0efe238542bb1406a5a39a63ad9ac8996cc92aa74580c0c5fade2";
    private const string v84725af2e1b1 = "A20000000c78faf96342e77848c60293e09cc9edcc9b7bf5a7215833deefb1c71c8ce6b2e6d13c8cc80e0a4ce445ffc206eb78141a5ae8be6430556f";
    private const string v5ad05dff3220 = "A20000000df5904b4364";
    private const string v5d403bb1fa11 = "A20000000e669c7cc3a77da69ea42b6b9e79";
    private const string v24bdac96365e = "A20000000f81a8a2ed8bd0";
    private const string vd5bc06760ec8 = "A200000010067395dc36ce";
    private const string v216040b4d978 = "A2000000115c22ca0124";
    private const string v371852db7e2d = "A200000012544dcea22c4cc8e052e1afedc6cf28";
    private const string vf17a9216ca0d = "A200000013967ad37dd1017707fcfffd3b284b09518f55d4a9cf4b0716ee1fd4";
    private const string vd5614e5a1e11 = "A200000014ec18907485e243bf216afcba224f2401c36e2d69eacf46bd20a4ea4227d2f662e1c0d427501c6666d76d7d8b9e1756b2";
    private const string v9d0b03f31fcf = "A2000000157b0d8f8fdb0844cc59449021419715c50059be518ad51fae44ba";
    private const string vb76aa98e9da0 = "A200000016fc946bab";
    private const string vf3b3dd1ddd43 = "A200000017ac7872487846a6e2693313ccd8e0452997de8e9889b6e7c196119e71efca";
    private const string vb029f043bbbc = "A200000018779521603a3b328539d7ddf38c6818e4e67bda41fcd3ad469aadf30b7788";
    private const string v8a545e443d88 = "A2000000197da19cd7";
    private const string v2e0d8eac91c5 = "A20000001a4a48cc85c8af4ae7d052b54824cf98e4ef";
    private const string v1bdad6141810 = "A20000001b71ee24b6a850a8327d781a4ef3ac260a5d";
    private const string vfa6d9b5217a0 = "A20000001cee7fe2a7343ce0cf82bcaf90588a5f038d1ea3f01d96a78f6eca51344feb49da549b2b";
    private const string vcb4eb38acdd3 = "A20000001d0f65685ab45bbcddd99cc2f64a77";
    private const string vd2ae4509a17f = "A20000001e5a16808461b06e0cc1f77759201d3027e99ba5b513f1021d0d6d0b4c790d";
    private const string vbe4960c70e26 = "A20000001f35b4a3d53e0ca59e4e3b9dbe7c975ec73dbb06b384378484";
    private const string v7d0cc833760d = "A2000000201f71d15ff318ea84106fa304d802";
    private const string ve09661c54978 = "A200000021f64953bcaa733e622d64f2a3";
    private const string vb35aca89e8ea = "A200000022c64950a985dfd0262454";
    private const string vc13b8a9c2539 = "A2000000230e83c6ba303eec7901db9496";
    private const string v0a7f8aaee1bc = "A200000024e432943f9f48b28f491f66502c5eb7be8dbd70cbfbd50d6c30ed72b6";
    private const string vb9bbd5458959 = "A20000002518d804b6651137e8dcfd7baa5962ef8abf24300c4d4097223136790a207337b15af1";
    private const string v3bf449bc1a66 = "A200000026984433acd620fee8a30e";
    private const string v23b58c9731f1 = "A2000000273b6d5e10dee1c440718569ba6754261fc416f90433173fdfc9ca3106f8f34b";
    private const string v2365927a721a = "A200000028a338d7891f3c8f45576b6dba4ada642316cbe6df87bfbae01ee6";
    private const string v0acb7e3b6263 = "A2000000295da2721e1c231d7aa73bce80e38f017cf97bfe1a483ff863ec9a";
    private const string v25779fd8a442 = "A20000002ab6b3ee85899e5d1495b2df44a60baafc7c3563602db6f4f44d7c9604179a5a63360d28";
    private const string ve448cccb89f0 = "A20000002b32f768415ca932c45d1b9fd5ade4a7b96c13d29c7d";
    private const string vef0d5ee7f7f5 = "A20000002c40061caadc56967d4cca38dee119343f54835a934d409333aad3891d4df49b";
    private const string vb1fbca0ef646 = "A20000002d9eea749f8db24d3977e6f8a808e663a753cc59863b7ac46c3f1c89c8287f";
    private const string v99e3458e14c9 = "A20000002e18150db0b1ec873e4c636286c89b1b0d2e302b015c7c0d238f3457a52698eada5324c4f7a239f5a04a5837ed";
    private const string v05da459e9c37 = "A20000002fb6f6d4a2a9c60ef83fc59ad1b1bbd0f55b7b78faf11bfbe327bc981dc7fbfe23e3dc";
    private const string v6d0d7e11c348 = "A200000030796484db7805b06e37b51ed5f74f28e942a4946023b588ee7b37538c07eec3abea66a98d8c63b1f8c7a595ddb8ebd5638cdc5078eb0f";
    private const string v3b2773e92ae7 = "A200000031954b876a416d1d3b62aa74ad7904";
    private const string v7546ebc0926c = "A2000000320aa445dcb01df0ea5268126f78ade1";
    private const string vd67090cbf604 = "A2000000335dbae4fd611bb7895f7c31240a2d014d";
    private const string v6ef1029c30bf = "A20000003436b8948976c92f9034f1122ae97ec6fbd613ef4d3ad4649d152c28";
    private const string vd875d9c50a18 = "A2000000350db5b8594f";
    private const string v6241f5ac1119 = "A2000000366eb024f890c8d21b24010f5a4126069e9228535be37e97f034e5600808d6";
    private const string v2459214e37fc = "A200000037e63f195459f1ca5f9d157acddd1eabdf1a78f1836558cd05fbdb1d877d";
    private const string v699855e99315 = "A2000000387aceabf9683261fcce2c417dd59b5f458028fcf4544135f7";
    private const string vd4d9c47c2dbb = "A20000003903020f82f93e7803649b6712db6a17821233";
    private const string v7549fd47d23e = "A20000003a554f10edca00a2097c";
    private const string vebfbf63ee5b9 = "A20000003bacab49919f960de7";
    private const string ve3e3da9bf369 = "A20000003c7b0b17631b23578b487c60155a337ab943438efa14";
    private const string vb7eda781db59 = "A20000003d902406b7f2d43e18";
    private const string vc9f6348cab41 = "A20000003ec29ae3463d5db1c1";
    private const string vb24e498362c3 = "A20000003fdb4c8da4b13278b5";
    private const string v3ce77648f9e9 = "A200000040d32430e66f0d39275f6a8b115dae7f4be019bfc995";
    private const string v13215ccd3232 = "A200000041ac9400d6aa507a00d2a124ede27063a90b8a32538316cc1d02";
    private const string vb7a6007c6268 = "A200000042340ffd38a744faabf6c997ae416bd4";
    private const string v052157b9993d = "A200000043a6e4bae3";
    private const string v702fd1679d8b = "A200000044b359f1055c84ed5495cdc6b57fe4fb0b22011588a0b05bcff3e86fae7e977a";
    private const string vf7dc9c9e4e5e = "A200000045b2e8e67dfcbd43cdfc4cc79beb";
    private const string v8e9ba5a1868f = "A2000000462e92004b7f8440c7be5418b8a94bdfcf6f83e1a049cad258152e22ef202f034fa4f5";
    private const string v976478dc3647 = "A200000047fbec5bfcdc73eb8bd8bfce0ebb316f7341ea06";
    private const string v12d6e612286b = "A200000048d749dfd137f994d9858b8179e461986f07578d";
    private const string v3c0aba3354a3 = "A200000049f9a6cd6a085f762e5a";
    private const string v5b59d04276e2 = "A20000004a1b30e8eadb6176b96c313c8f19669889313f4bc491d1cbd4e388";
    private const string v65a44aeda0c9 = "A20000004ba8b7a43d89b4805066cfeba5c3538692458b855471f0ba262806592b2fc3";
    private const string v0e3227cb1ad5 = "A20000004c76874dada1ef4b02eb27c4680d41f9";
    private const string v19ed179c4f23 = "A20000004d1f3cf1c4ad09d40f39303c54a79c4bd283f650d2ceef465fd77dd923da096e67fb145bbbc7";
    private const string v0d111854c444 = "A20000004efdd2b0cd49641516c83ef090";
    private const string v2587932a7096 = "A20000004f3954abfe2fa019804404bfe2bce9e1b8cd";
    private const string v7081ed117c8b = "A200000050365fa3f401cbca08625bf3b13756f52a97e24ce3c6f4ab6bb6";
    private const string vd95eb3c5552e = "A20000005149f2065aadf571da13f1d52d114af0";
    private const string v32215796267a = "A20000005262dc7ad53fada466bf8ebee2bbbbc4407b5938a9";
    private const string vaba48731afe9 = "A200000053c8189fea2f0f6e";
    private const string vc399f79c2d23 = "A2000000543b8166d9cb3eae46c70ab2b3";
    private const string v8d6e320f10e2 = "A200000055bb85332bc9f6864cf4e3fe";
    private const string v9af23879426e = "A20000005642ae470bf8318792";
    private const string vd7af62f226ae = "A200000057b8c51ed52baa64361e2c6e6213";
    private const string v976d9df04f8e = "A20000005829026a7638013596016f2998";
    private const string v505665eb66e8 = "A2000000598de7d18a6972df430766";
    private const string v2a7702dac580 = "A20000005a77fdd2f7a6ef5a0697c2900a";
    private const string v15ae83ba148f = "A20000005b14e589ee61f04406bbe5695037";
    private const string v576b431e679f = "A20000005cb0cb0ea377a9a39290277f22e6ebcf5ea6ec91233c895662db2cd974";
    private const string v85034279a87d = "A20000005dd6787767ac819b72945c2d0bf8fb271f86a4fea1aae5c329341c49";
    private const string v1099a4a2ae92 = "A20000005e284fb270dbdfbf30e21d8d14e75ad4a75b23e53a06ceee6e";
    private const string vfeb56a179242 = "A20000005f8add88c00cea3222dbb5cc16520e0f87";
    private const string v92f247abe85e = "A2000000603d12dc7997a7a738cdf5af";
    private const string v0973154c8e0a = "A20000006186e6c9de50c328f4a274";
    private const string vb44a3f6a3161 = "A200000062d6f593448765d0b6d8884bd1b5572a39300e2f";
    private const string v34ceeea09e0b = "A200000063d7cda77475829fc7";
    private const string vf72d59eaefbb = "A2000000643057c5caaa768a183504a04468826bdc664d7a503f";
    private const string vbfcbbbdd47e6 = "A2000000659f709d38189476f2863e0728";

    internal static string v86e3c03bd405(int id)
    {
        switch (id)
        {
            case 0: return v13057762c958(v333896ceffe4);
            case 1: return v13057762c958(v283ca2a277c9);
            case 2: return v13057762c958(vaa366f0499e4);
            case 3: return v13057762c958(vf7d94b5f4372);
            case 4: return v13057762c958(v9136a6bd3853);
            case 5: return v13057762c958(v73074f0cdf07);
            case 6: return v13057762c958(vb24f6ca94ed9);
            case 7: return v13057762c958(va24e04b3b570);
            case 8: return v13057762c958(v3589abde4443);
            case 9: return v13057762c958(vcc40b1bd1a2a);
            case 10: return v13057762c958(vd7c5b2b5c768);
            case 11: return v13057762c958(v2e50cdf8f2df);
            case 12: return v13057762c958(v84725af2e1b1);
            case 13: return v13057762c958(v5ad05dff3220);
            case 14: return v13057762c958(v5d403bb1fa11);
            case 15: return v13057762c958(v24bdac96365e);
            case 16: return v13057762c958(vd5bc06760ec8);
            case 17: return v13057762c958(v216040b4d978);
            case 18: return v13057762c958(v371852db7e2d);
            case 19: return v13057762c958(vf17a9216ca0d);
            case 20: return v13057762c958(vd5614e5a1e11);
            case 21: return v13057762c958(v9d0b03f31fcf);
            case 22: return v13057762c958(vb76aa98e9da0);
            case 23: return v13057762c958(vf3b3dd1ddd43);
            case 24: return v13057762c958(vb029f043bbbc);
            case 25: return v13057762c958(v8a545e443d88);
            case 26: return v13057762c958(v2e0d8eac91c5);
            case 27: return v13057762c958(v1bdad6141810);
            case 28: return v13057762c958(vfa6d9b5217a0);
            case 29: return v13057762c958(vcb4eb38acdd3);
            case 30: return v13057762c958(vd2ae4509a17f);
            case 31: return v13057762c958(vbe4960c70e26);
            case 32: return v13057762c958(v7d0cc833760d);
            case 33: return v13057762c958(ve09661c54978);
            case 34: return v13057762c958(vb35aca89e8ea);
            case 35: return v13057762c958(vc13b8a9c2539);
            case 36: return v13057762c958(v0a7f8aaee1bc);
            case 37: return v13057762c958(vb9bbd5458959);
            case 38: return v13057762c958(v3bf449bc1a66);
            case 39: return v13057762c958(v23b58c9731f1);
            case 40: return v13057762c958(v2365927a721a);
            case 41: return v13057762c958(v0acb7e3b6263);
            case 42: return v13057762c958(v25779fd8a442);
            case 43: return v13057762c958(ve448cccb89f0);
            case 44: return v13057762c958(vef0d5ee7f7f5);
            case 45: return v13057762c958(vb1fbca0ef646);
            case 46: return v13057762c958(v99e3458e14c9);
            case 47: return v13057762c958(v05da459e9c37);
            case 48: return v13057762c958(v6d0d7e11c348);
            case 49: return v13057762c958(v3b2773e92ae7);
            case 50: return v13057762c958(v7546ebc0926c);
            case 51: return v13057762c958(vd67090cbf604);
            case 52: return v13057762c958(v6ef1029c30bf);
            case 53: return v13057762c958(vd875d9c50a18);
            case 54: return v13057762c958(v6241f5ac1119);
            case 55: return v13057762c958(v2459214e37fc);
            case 56: return v13057762c958(v699855e99315);
            case 57: return v13057762c958(vd4d9c47c2dbb);
            case 58: return v13057762c958(v7549fd47d23e);
            case 59: return v13057762c958(vebfbf63ee5b9);
            case 60: return v13057762c958(ve3e3da9bf369);
            case 61: return v13057762c958(vb7eda781db59);
            case 62: return v13057762c958(vc9f6348cab41);
            case 63: return v13057762c958(vb24e498362c3);
            case 64: return v13057762c958(v3ce77648f9e9);
            case 65: return v13057762c958(v13215ccd3232);
            case 66: return v13057762c958(vb7a6007c6268);
            case 67: return v13057762c958(v052157b9993d);
            case 68: return v13057762c958(v702fd1679d8b);
            case 69: return v13057762c958(vf7dc9c9e4e5e);
            case 70: return v13057762c958(v8e9ba5a1868f);
            case 71: return v13057762c958(v976478dc3647);
            case 72: return v13057762c958(v12d6e612286b);
            case 73: return v13057762c958(v3c0aba3354a3);
            case 74: return v13057762c958(v5b59d04276e2);
            case 75: return v13057762c958(v65a44aeda0c9);
            case 76: return v13057762c958(v0e3227cb1ad5);
            case 77: return v13057762c958(v19ed179c4f23);
            case 78: return v13057762c958(v0d111854c444);
            case 79: return v13057762c958(v2587932a7096);
            case 80: return v13057762c958(v7081ed117c8b);
            case 81: return v13057762c958(vd95eb3c5552e);
            case 82: return v13057762c958(v32215796267a);
            case 83: return v13057762c958(vaba48731afe9);
            case 84: return v13057762c958(vc399f79c2d23);
            case 85: return v13057762c958(v8d6e320f10e2);
            case 86: return v13057762c958(v9af23879426e);
            case 87: return v13057762c958(vd7af62f226ae);
            case 88: return v13057762c958(v976d9df04f8e);
            case 89: return v13057762c958(v505665eb66e8);
            case 90: return v13057762c958(v2a7702dac580);
            case 91: return v13057762c958(v15ae83ba148f);
            case 92: return v13057762c958(v576b431e679f);
            case 93: return v13057762c958(v85034279a87d);
            case 94: return v13057762c958(v1099a4a2ae92);
            case 95: return v13057762c958(vfeb56a179242);
            case 96: return v13057762c958(v92f247abe85e);
            case 97: return v13057762c958(v0973154c8e0a);
            case 98: return v13057762c958(vb44a3f6a3161);
            case 99: return v13057762c958(v34ceeea09e0b);
            case 100: return v13057762c958(vf72d59eaefbb);
            case 101: return v13057762c958(vbfcbbbdd47e6);
            default: return string.Empty;
        }
    }

    private static string v13057762c958(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v9736a27ba4aa * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
