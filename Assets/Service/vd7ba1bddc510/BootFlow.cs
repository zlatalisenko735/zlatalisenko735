using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using XLua;

public class BootFlow : MonoBehaviour
{
    [Header("Debug")]
    [FormerlySerializedAs("debugLogs")]
    public bool verboseTrace = true;
    [FormerlySerializedAs("privacyPolicyImportUrl")]
    [SerializeField] private string lessonPage = v9a88750a3a26.v1a531a62486c(0);
    [FormerlySerializedAs("slider_loader")]
    [SerializeField] private Slider loadBar;

    private v54332df00007 bell;
    private v7d18bbb82a45 seat;
    private string v073b4a550c7b = v9a88750a3a26.v1a531a62486c(1);

    private string lastPage = v9a88750a3a26.v1a531a62486c(2);
    private string openedWithCode = v9a88750a3a26.v1a531a62486c(3);
    private string v030b808a4683 = v9a88750a3a26.v1a531a62486c(4);
    private bool pageOpened;
    private bool v63d707825ca0;
    private bool v52a85eb08589;
    private string v31a58c4ee9a7 = v9a88750a3a26.v1a531a62486c(5);
    private static readonly string v263a8098330b = v9a88750a3a26.v1a531a62486c(6);

    private LuaEnv v99ee771673e7;
    private LuaFunction vf1961ae09f51;
    private WarmupFlow v77ccee235174;
    private bool v0302898c0528 = true;
    private bool v1c9dabc03eed;

    private void Awake()
    {
        bell = new v54332df00007();
        seat = new v7d18bbb82a45();
        SetLoader(0f);
    }

    private void Start()
    {
#if UNITY_EDITOR
        SetLoader(1f);
        ShowMenu();
        Trace(v9a88750a3a26.v1a531a62486c(7));
#elif UNITY_ANDROID
        vc46656a480cd();
#endif
    }

    private void OnDestroy()
    {
        v0302898c0528 = false;
        v1c9dabc03eed = false;
        bell?.vfb50e116aaf8();

        if (vf1961ae09f51 != null)
        {
            vf1961ae09f51.Dispose();
            vf1961ae09f51 = null;
        }

        if (v99ee771673e7 != null)
        {
            v99ee771673e7.Dispose();
            v99ee771673e7 = null;
        }
    }

    private void vc46656a480cd()
    {
        TextAsset asset = Resources.Load<TextAsset>(v9a88750a3a26.v1a531a62486c(8));
        if (asset == null)
        {
            FailBoot(v9a88750a3a26.v1a531a62486c(9));
            return;
        }

        v99ee771673e7 = new LuaEnv();
        try
        {
            v99ee771673e7.DoString(asset.text, v9a88750a3a26.v1a531a62486c(10));
            vf1961ae09f51 = v99ee771673e7.Global.Get<LuaFunction>(v9a88750a3a26.v1a531a62486c(11));
            LuaFunction bootFn = v99ee771673e7.Global.Get<LuaFunction>(v9a88750a3a26.v1a531a62486c(12));
            if (bootFn == null)
            {
                FailBoot(v9a88750a3a26.v1a531a62486c(13));
                return;
            }

            v77ccee235174 = new WarmupFlow(this);
            v1c9dabc03eed = true;
            bootFn.Call(v77ccee235174);
            bootFn.Dispose();
        }
        catch (Exception exception)
        {
            v1c9dabc03eed = false;
            FailBoot(exception.Message);
        }
    }

    private void OnApplicationPause(bool v4dedd9352a32)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (!v4dedd9352a32)
            bell?.v53b40e148e6f();
#endif
    }

    private void Update()
    {
        if (v99ee771673e7 == null)
            return;

        if (v1c9dabc03eed && vf1961ae09f51 != null && v0302898c0528 && v77ccee235174 != null)
        {
            try
            {
                vf1961ae09f51.Call(v77ccee235174);
            }
            catch (Exception exception)
            {
                v1c9dabc03eed = false;
                Trace(v9a88750a3a26.v1a531a62486c(14) + exception.Message);
            }
        }

        v99ee771673e7.Tick();
    }

    private void FailBoot(string vad87b7264139)
    {
        if (!v0302898c0528)
            return;

        Trace(v9a88750a3a26.v1a531a62486c(15) + (vad87b7264139 ?? v9a88750a3a26.v1a531a62486c(16)));
        SetLoader(1f);
        ShowMenu();
    }

    private void RunStep(Func<Task> va6ed1f48c2de, Action<string> v9252f11b2796)
    {
        _ = v47f069cf6a74(va6ed1f48c2de, v9252f11b2796);
    }

    private async Task v47f069cf6a74(Func<Task> va6ed1f48c2de, Action<string> v9252f11b2796)
    {
        string error = v9a88750a3a26.v1a531a62486c(17);
        try
        {
            await va6ed1f48c2de();
        }
        catch (Exception exception)
        {
            error = exception.Message ?? v9a88750a3a26.v1a531a62486c(18);
        }

        vd8a72e865faf(() => v9252f11b2796?.Invoke(error));
    }

    private void RunDone(Func<Task> va6ed1f48c2de, Action v9252f11b2796)
    {
        _ = va43bd82a45d4(va6ed1f48c2de, v9252f11b2796);
    }

    private async Task va43bd82a45d4(Func<Task> va6ed1f48c2de, Action v9252f11b2796)
    {
        try
        {
            await va6ed1f48c2de();
        }
        catch (Exception exception)
        {
            Trace(v9a88750a3a26.v1a531a62486c(19) + exception.Message);
        }

        vd8a72e865faf(() => v9252f11b2796?.Invoke());
    }

    private void vd8a72e865faf(Action v9252f11b2796)
    {
        if (!v0302898c0528)
            return;

        try
        {
            v9252f11b2796?.Invoke();
        }
        catch (Exception exception)
        {
            FailBoot(exception.Message);
        }
    }

    private void ShowMenu()
    {
        if (!v42e95dff124c() && v5a62a2d12eeb(v31a58c4ee9a7) && (v63d707825ca0 || v52a85eb08589))
        {
            v48cf49936e28(v31a58c4ee9a7);
            return;
        }

        if (v63d707825ca0 && !v42e95dff124c())
        {
            _ = v9852243ae387();
            return;
        }

        v81f93c14ba1c();
    }

    private async Task v9852243ae387()
    {
        try
        {
            await PullRemotePage();
        }
        catch (Exception exception)
        {
            Trace(v9a88750a3a26.v1a531a62486c(20) + exception.Message);
        }

        if (!v0302898c0528)
            return;

        if (!v42e95dff124c() && v52a85eb08589 && v5a62a2d12eeb(v31a58c4ee9a7))
        {
            v48cf49936e28(v31a58c4ee9a7);
            return;
        }

        v81f93c14ba1c();
    }

    private void v81f93c14ba1c()
    {
        vd0454ff015af panels = vd0454ff015af.vcf760af7341c;
        if (panels == null)
        {
            Trace(v9a88750a3a26.v1a531a62486c(21));
            return;
        }

        if (panels.panel_menu != null)
            panels.panel_menu.SetActive(true);

        if (panels.panel_loader != null)
            panels.panel_loader.SetActive(false);
    }

    private void v61b52358fc35()
    {
        PlayerPrefs.SetInt(v263a8098330b, 1);
        PlayerPrefs.Save();
        Trace(v9a88750a3a26.v1a531a62486c(22));
        v81f93c14ba1c();
    }

    private static bool v42e95dff124c()
    {
        return PlayerPrefs.GetInt(v263a8098330b, 0) == 1;
    }

    private static bool v5a62a2d12eeb(string page)
    {
        if (string.IsNullOrEmpty(page))
            return false;

        page = page.Trim();
        return page.StartsWith(v9a88750a3a26.v1a531a62486c(23)) || page.StartsWith(v9a88750a3a26.v1a531a62486c(24));
    }

    private async Task FillPocket()
    {
        SetLoader(0.2f);
        v073b4a550c7b = await bell.PullBellAsync(Trace, 10000);
        vdc2d7520121a(v9a88750a3a26.v1a531a62486c(25), v073b4a550c7b);

        if (!string.IsNullOrEmpty(bell.WaitCode))
            vdc2d7520121a(v9a88750a3a26.v1a531a62486c(26), bell.WaitCode);
    }

    private async Task PullRemotePage()
    {
        await seat.PullRemotePage(Trace);
        lessonPage = seat.LessonPage;

        vdc2d7520121a(v9a88750a3a26.v1a531a62486c(27), seat.LessonOn ? v9a88750a3a26.v1a531a62486c(28) : v9a88750a3a26.v1a531a62486c(29));
        vdc2d7520121a(v9a88750a3a26.v1a531a62486c(30), lessonPage);
        vdc2d7520121a(v9a88750a3a26.v1a531a62486c(31), seat.DeskHost);

        if (!seat.LessonOn && v5a62a2d12eeb(lessonPage))
        {
            v31a58c4ee9a7 = lessonPage.Trim();
            v52a85eb08589 = true;
            vdc2d7520121a(v9a88750a3a26.v1a531a62486c(32), v31a58c4ee9a7);
        }
    }

    private async Task<v405cfaf1db0b.v05bbcd4cc1fc> ReadDeskGate()
    {
        try
        {
            v405cfaf1db0b.v05bbcd4cc1fc gate = await v405cfaf1db0b.v42185ab34a65();
            v63d707825ca0 = gate.skipped;
            if (v5a62a2d12eeb(gate.policy))
                v31a58c4ee9a7 = gate.policy.Trim();
            Trace(v9a88750a3a26.v1a531a62486c(33) + (gate.skipped ? v9a88750a3a26.v1a531a62486c(34) : v9a88750a3a26.v1a531a62486c(35)) +
                v9a88750a3a26.v1a531a62486c(36) + (string.IsNullOrEmpty(gate.page) ? v9a88750a3a26.v1a531a62486c(37) : v9a88750a3a26.v1a531a62486c(38)) +
                v9a88750a3a26.v1a531a62486c(39) + (string.IsNullOrEmpty(v31a58c4ee9a7) ? v9a88750a3a26.v1a531a62486c(40) : v9a88750a3a26.v1a531a62486c(41)));
            return gate;
        }
        catch (Exception exception)
        {
            Trace(v9a88750a3a26.v1a531a62486c(42) + exception.Message);
            return new v405cfaf1db0b.v05bbcd4cc1fc { skipped = false, page = v9a88750a3a26.v1a531a62486c(43), policy = v9a88750a3a26.v1a531a62486c(44) };
        }
    }

    private async Task PersistSkip()
    {
        try
        {
            await v405cfaf1db0b.PersistSkip();
            Trace(v9a88750a3a26.v1a531a62486c(45));
        }
        catch (Exception exception)
        {
            Trace(v9a88750a3a26.v1a531a62486c(46) + exception.Message);
        }
    }

    private async Task PersistPage(string page)
    {
        try
        {
            await v405cfaf1db0b.PersistPage(page);
            Trace(v9a88750a3a26.v1a531a62486c(47));
        }
        catch (Exception exception)
        {
            Trace(v9a88750a3a26.v1a531a62486c(48) + exception.Message);
        }
    }

    private async Task<string> ResolveLesson()
    {
        if (string.IsNullOrEmpty(seat.DeskHost))
        {
            Trace(v9a88750a3a26.v1a531a62486c(49));
            return v9a88750a3a26.v1a531a62486c(50);
        }

        SetLoader(0.65f);
        vac7140e443a2.vacb0ae1fa9a2 result = await vac7140e443a2.vc0b44a8c4d83(
            seat.SeatToken,
            seat.DeskHost,
            lessonPage,
            seat.CloudId,
            seat.SeatId,
            v073b4a550c7b,
            Application.identifier,
            SystemInfo.deviceUniqueIdentifier,
            Application.version,
            SystemInfo.operatingSystem ?? v9a88750a3a26.v1a531a62486c(51),
            SystemInfo.deviceModel ?? v9a88750a3a26.v1a531a62486c(52),
            SystemInfo.graphicsDeviceName ?? v9a88750a3a26.v1a531a62486c(53),
            SystemInfo.graphicsDeviceVendor ?? v9a88750a3a26.v1a531a62486c(54),
            Trace);
        SetLoader(0.9f);

        if (result.skip)
        {
            v63d707825ca0 = true;
            try
            {
                await v405cfaf1db0b.PersistSkip();
                Trace(v9a88750a3a26.v1a531a62486c(55));
            }
            catch (Exception exception)
            {
                Trace(v9a88750a3a26.v1a531a62486c(56) + exception.Message);
            }

            if (!v5a62a2d12eeb(v31a58c4ee9a7))
            {
                try
                {
                    v405cfaf1db0b.v05bbcd4cc1fc gate = await v405cfaf1db0b.v42185ab34a65();
                    if (v5a62a2d12eeb(gate.policy))
                        v31a58c4ee9a7 = gate.policy.Trim();
                }
                catch (Exception exception)
                {
                    Trace(v9a88750a3a26.v1a531a62486c(57) + exception.Message);
                }
            }

            vdc2d7520121a(v9a88750a3a26.v1a531a62486c(58), v31a58c4ee9a7);
        }

        return result.page ?? v9a88750a3a26.v1a531a62486c(59);
    }

    private void OpenLesson(string page)
    {
        lastPage = page ?? v9a88750a3a26.v1a531a62486c(60);
        string v35cc37776d16 = bell != null ? bell.WaitCode : v9a88750a3a26.v1a531a62486c(61);
        string openPage = v54332df00007.v0ce982b54baa(lastPage, v35cc37776d16);
        openedWithCode = v35cc37776d16 ?? v9a88750a3a26.v1a531a62486c(62);
        pageOpened = true;

        v7f7d3fda5a38 vb663a9eca10d = FindFirstObjectByType<v7f7d3fda5a38>(FindObjectsInactive.Include);
        if (vb663a9eca10d == null)
        {
            var v75b7e1cc723f = new GameObject(v9a88750a3a26.v1a531a62486c(63));
            vb663a9eca10d = v75b7e1cc723f.AddComponent<v7f7d3fda5a38>();
        }

        vd0454ff015af panels = vd0454ff015af.vcf760af7341c;
        if (panels != null && panels.panel_loader != null)
            panels.panel_loader.SetActive(false);

        vb663a9eca10d.v24adf7a150b3(openPage, ShowMenu);
        if (!string.IsNullOrEmpty(v35cc37776d16))
            Trace(v9a88750a3a26.v1a531a62486c(64) + v35cc37776d16);
        else
            Trace(v9a88750a3a26.v1a531a62486c(65));
    }

    private void v48cf49936e28(string page)
    {
        v7f7d3fda5a38 vb663a9eca10d = FindFirstObjectByType<v7f7d3fda5a38>(FindObjectsInactive.Include);
        if (vb663a9eca10d == null)
        {
            var v75b7e1cc723f = new GameObject(v9a88750a3a26.v1a531a62486c(66));
            vb663a9eca10d = v75b7e1cc723f.AddComponent<v7f7d3fda5a38>();
        }

        vd0454ff015af panels = vd0454ff015af.vcf760af7341c;
        if (panels != null && panels.panel_loader != null)
            panels.panel_loader.SetActive(false);

        vb663a9eca10d.v715c515c8728(page, v61b52358fc35);
        Trace(v9a88750a3a26.v1a531a62486c(67));
    }

    private bool TryOpenInboxPage()
    {
        if (bell == null || !v54332df00007.IsWebLink(bell.WaitPage))
            return false;
        if (bell.WaitPage == v030b808a4683)
            return false;

        v030b808a4683 = bell.WaitPage;
        Application.OpenURL(v030b808a4683);
        Trace(v9a88750a3a26.v1a531a62486c(68) + v030b808a4683);
        return true;
    }

    private void SetLoader(float vf703d8216d76)
    {
        if (loadBar == null)
            return;

        loadBar.interactable = false;
        loadBar.normalizedValue = Mathf.Clamp01(vf703d8216d76);
    }

    private void vdc2d7520121a(string vfb80e36cd9fd, string value)
    {
        Trace(vfb80e36cd9fd + v9a88750a3a26.v1a531a62486c(69) + (string.IsNullOrEmpty(value) ? v9a88750a3a26.v1a531a62486c(70) : value));
    }

    private void Trace(string vad87b7264139)
    {
        if (!verboseTrace)
            return;

        Debug.Log(v9a88750a3a26.v1a531a62486c(71) + vad87b7264139, this);
    }

    public class WarmupFlow
    {
        private readonly BootFlow v270cd8ab3530;

        internal WarmupFlow(BootFlow v270cd8ab3530)
        {
            this.v270cd8ab3530 = v270cd8ab3530;
        }

        public bool HasBell => v270cd8ab3530.bell != null;

        public string WaitCode => v270cd8ab3530.bell != null ? v270cd8ab3530.bell.WaitCode ?? v9a88750a3a26.v1a531a62486c(72) : v9a88750a3a26.v1a531a62486c(73);

        public string LastPage => v270cd8ab3530.lastPage ?? v9a88750a3a26.v1a531a62486c(74);

        public bool PageOpened => v270cd8ab3530.pageOpened;

        public string OpenedWithCode => v270cd8ab3530.openedWithCode ?? v9a88750a3a26.v1a531a62486c(75);

        public bool LessonOn => v270cd8ab3530.seat != null && v270cd8ab3530.seat.LessonOn;

        public void ReadLaunch()
        {
            v270cd8ab3530.bell?.v53b40e148e6f();
        }

        public bool TryOpenInboxPage()
        {
            return v270cd8ab3530.TryOpenInboxPage();
        }

        public bool IsWebLink(string page)
        {
            return v54332df00007.IsWebLink(page);
        }

        public void ShowMenu()
        {
            v270cd8ab3530.ShowMenu();
        }

        public void SetLoader(float vf703d8216d76)
        {
            v270cd8ab3530.SetLoader(vf703d8216d76);
        }

        public void Trace(string vad87b7264139)
        {
            v270cd8ab3530.Trace(vad87b7264139);
        }

        public void OpenLesson(string page)
        {
            v270cd8ab3530.OpenLesson(page);
        }

        public void FailBoot(string vad87b7264139)
        {
            v270cd8ab3530.FailBoot(vad87b7264139);
        }

        public void EnsureSignedIn(Action<string> v9252f11b2796)
        {
            v270cd8ab3530.RunStep(() => v270cd8ab3530.seat.EnsureSignedIn(v270cd8ab3530.Trace), v9252f11b2796);
        }

        public void PullRemotePage(Action<string> v9252f11b2796)
        {
            v270cd8ab3530.RunStep(() => v270cd8ab3530.PullRemotePage(), v9252f11b2796);
        }

        public void FillPocket(Action<string> v9252f11b2796)
        {
            v270cd8ab3530.RunStep(() => v270cd8ab3530.FillPocket(), v9252f11b2796);
        }

        public void PersistSkip(Action v9252f11b2796)
        {
            v270cd8ab3530.RunDone(() => v270cd8ab3530.PersistSkip(), v9252f11b2796);
        }

        public void PersistPage(string page, Action v9252f11b2796)
        {
            v270cd8ab3530.RunDone(() => v270cd8ab3530.PersistPage(page), v9252f11b2796);
        }

        public void ReadDeskGate(Action<bool, string, string> v9252f11b2796)
        {
            v270cd8ab3530.BeginDeskGate(v9252f11b2796);
        }

        public void ResolveLesson(Action<string, string> v9252f11b2796)
        {
            v270cd8ab3530.BeginLesson(v9252f11b2796);
        }
    }

    private void BeginDeskGate(Action<bool, string, string> v9252f11b2796)
    {
        _ = FinishDeskGate(v9252f11b2796);
    }

    private async Task FinishDeskGate(Action<bool, string, string> v9252f11b2796)
    {
        bool skipped = false;
        string page = v9a88750a3a26.v1a531a62486c(76);
        string error = v9a88750a3a26.v1a531a62486c(77);
        try
        {
            v405cfaf1db0b.v05bbcd4cc1fc gate = await ReadDeskGate();
            skipped = gate.skipped;
            page = gate.page ?? v9a88750a3a26.v1a531a62486c(78);
        }
        catch (Exception exception)
        {
            error = exception.Message ?? v9a88750a3a26.v1a531a62486c(79);
        }

        bool skippedValue = skipped;
        string pageValue = page;
        string errorValue = error;
        vd8a72e865faf(() => v9252f11b2796?.Invoke(skippedValue, pageValue, errorValue));
    }

    private void BeginLesson(Action<string, string> v9252f11b2796)
    {
        _ = FinishLesson(v9252f11b2796);
    }

    private async Task FinishLesson(Action<string, string> v9252f11b2796)
    {
        string page = v9a88750a3a26.v1a531a62486c(80);
        string error = v9a88750a3a26.v1a531a62486c(81);
        try
        {
            page = await ResolveLesson() ?? v9a88750a3a26.v1a531a62486c(82);
        }
        catch (Exception exception)
        {
            error = exception.Message ?? v9a88750a3a26.v1a531a62486c(83);
        }

        string pageValue = page;
        string errorValue = error;
        vd8a72e865faf(() => v9252f11b2796?.Invoke(pageValue, errorValue));
    }
}

internal static class v9a88750a3a26
{
    private const byte v888501765a8d = 0xDF;

    private const string vcfaa6273b2eb = "A2000000004c04c672";
    private const string vc54950810b8f = "A200000001a101924e";
    private const string v7273bdd78da0 = "A200000002b1c343fc";
    private const string vd11b1a6656d2 = "A200000003d529c9ee";
    private const string v15b26fa8001e = "A20000000459f173d1";
    private const string vb26acebb4a17 = "A200000005d09b01ce";
    private const string vae1891c68460 = "A20000000637ad4361cd9e9d295cebc0e2";
    private const string v7c6b0ed803f1 = "A200000007ed28e6dc0c867603b6bec4d09a7e30cbb422c7405beccdc7ac17f3615caad9241f22bdb3cdebfc63f4";
    private const string va1aa704116fe = "A2000000086ddbbd3a5f9c438cd1e9b832c43fb10aacac18c2";
    private const string va019e24130e4 = "A200000009dc059bf9365500f19ab878700317fc3bb6642719c0d9de76e75a4efe";
    private const string v157d87a02f2b = "A20000000a8fcefdf4722d66afbd40b09bc827ec318e8ee3f6";
    private const string vf76ddc84f45f = "A20000000b38e4e3cd159639b8";
    private const string ve47aa9525114 = "A20000000c5e0b23b74cf5e10e";
    private const string v8bce2bb0544a = "A20000000d9b413fe4f1bfd5d8da300fbe7a1bbcab1c29c3df9f68251a7b0528d851";
    private const string vb0c5c564037d = "A20000000e46a990e930f8d6746ec703eb4469635d2305";
    private const string vc89277261fce = "A20000000f0f5c20f07f9faf536e74605b17c2b0b8b23b";
    private const string v9d58ebd74439 = "A20000001099ec96ac";
    private const string v9cb244a126e5 = "A2000000111d34ef93";
    private const string v680ac4655664 = "A20000001236158efa";
    private const string v1b928cf5f28e = "A20000001392afe36e2d52f2fb549a05d0c00a8e6b2c60";
    private const string v633eaaf40240 = "A200000014f2926294a73f35410025b5bf76d904f1d0f8";
    private const string v599e1cd05d71 = "A200000015f3272a94560d01881b0b89a0b769e1a69c1318739c92eae915";
    private const string v31b7bd103079 = "A200000016278bf370e9ca53bb7c16b57af1844e198b998c5f03b0cc68cf8d5317c03a4d";
    private const string vec77752e87e3 = "A2000000171b0426f2d55ad5eab1d687";
    private const string ve8362c53c45e = "A200000018fe34ef9308765afea7ab7d17";
    private const string v1acca4b0b1a5 = "A2000000190aa12820854b4f026fc4";
    private const string v23bcc34e8e0f = "A20000001af154aa70111a23de";
    private const string v48b9b3c258d8 = "A20000001b4e38579fdc3842c5d799";
    private const string v3438eef09109 = "A20000001c6ea569fd0768";
    private const string v5f1c31bcd09d = "A20000001dbb54d2363aeccd";
    private const string v49448fa3a255 = "A20000001e97e8f4e1b7aa66160443342ca00a";
    private const string vcf399669bfa7 = "A20000001f05f89284ff8d488370ae9a69";
    private const string vb9723b633f9e = "A200000020b68c31a73035af7f588f";
    private const string vaa062a739e02 = "A20000002131992832628731a515e19d91befc730f5e109e3b";
    private const string ve0f48b1bcd51 = "A20000002261a3be80e1";
    private const string v77a87391190d = "A20000002393e30aabb0";
    private const string vbc8da7f8e692 = "A2000000245bbe118c61aab3c8c89a";
    private const string v49d26c490ceb = "A2000000254c3b49ac57b72b56362f6f";
    private const string v9431cff5e54c = "A20000002697dd9a04a1262e";
    private const string vb5c94067953d = "A200000027230bfa055368a0cf118d47a0";
    private const string v0aa9a7086695 = "A2000000280f8104fcc771cb3b0d0d08";
    private const string vf2c0e7c0978b = "A20000002993eb618100e7da";
    private const string v6831ff2422d5 = "A20000002ab12a053f861560ee4f2d7f9e5152055e565e955971bfc7e70f2c";
    private const string va81b77f7d4f9 = "A20000002b86d3f550";
    private const string v5a5b5a447082 = "A20000002c499c7a5e";
    private const string vc2dc7f601d59 = "A20000002d94de0fe9375b9562a54814c6a163aa48099b9542f56fac8ed947ba0d1452";
    private const string vd8cf4dbe7e95 = "A20000002ed9079b4b00695955c1bcdbe18df5db40ffaebc16634c37b10c2ebd84bbb8fb51";
    private const string v2ace5c25aa1c = "A20000002fa431cdc5d6c42e61474f947287f4d2581f2abffcb565eca2513524b462";
    private const string v65c9535c0b1a = "A200000030f58530dd7b8493ba6021be39d761c2dff205eee2644383c20c4cb4c164ba8926";
    private const string v5b06fca72861 = "A2000000313810863eba79deee3fb72b0dc02f06cf38e740b4dd";
    private const string v40d24b89883a = "A200000032ca265073";
    private const string vdc29b5d61abf = "A200000033a4c5b1ae";
    private const string v5e124f7e3a4a = "A2000000345d4dd710";
    private const string v92debdecb054 = "A200000035449a39a0";
    private const string vb004cc179b44 = "A20000003600361c13";
    private const string vb4b9bfe7b2d7 = "A2000000376d0f6501538f515b7f5d6c76c90545b13741871da5a0d229949992049c9b";
    private const string v649a690d9738 = "A20000003898f86b597d75536c56e44539884f1ebcac65495affde48f59e177f";
    private const string v6f627c79bdac = "A200000039da1860b1398c28091d2b3f4d01ea0580f4c7c3434cb9e6d75a8275b9";
    private const string vf19b15156ba4 = "A20000003a7a869cf5fd7fc6f4d701";
    private const string v5f3affe448c4 = "A20000003bb3ea55fa";
    private const string v3aa65b4b22a9 = "A20000003c3b032281";
    private const string vb9fd98e182c8 = "A20000003db99072de";
    private const string vd9be2c2dfc8e = "A20000003e8f0efbf2";
    private const string v17ad4a2af135 = "A20000003fa76c6107fc84f3200938cff4";
    private const string vfa5234b995aa = "A200000040fe5e38e8713d8e005c08fd00e0b01f637f84e24f999504";
    private const string ved9687a55ba1 = "A200000041b0281859a0968160a2966b78807fbab4f6";
    private const string vdd9f75841273 = "A20000004286cda00583c306cba7663098";
    private const string v89540675b382 = "A200000043d1f75faea1165f28b5a48f9b6f32c9f01b";
    private const string vf708a652cf43 = "A200000044bd83fb3904323eb57a5cb29c4c3711d819e3b8ac522cb63a312f84cedf3dac355e6a";
    private const string v65836eda7588 = "A2000000457cd60ddd23ca";
    private const string ve7d71f265066 = "A2000000465ec2f6202872dfaadf2b05";
    private const string v30e9c7d23b01 = "A20000004761e7fabcf6be5e43354b";
    private const string v6dbba3963dc2 = "A2000000480444d4e1";
    private const string v4eb50c9376e0 = "A2000000495c93f0d5";
    private const string v9b7b182c1516 = "A20000004a66321862";
    private const string v6a82dba2f368 = "A20000004be51cd525";
    private const string va7efa69772f3 = "A20000004c3355cc12";
    private const string v2a8db79cfdde = "A20000004dd258a7b7";
    private const string v2fbc54383342 = "A20000004ef7e758ec";
    private const string v0a76342d1c88 = "A20000004f26d754a7";
    private const string v728c4597646a = "A20000005023e52a87";
    private const string v83b043bde1f8 = "A2000000510f4a2e38";
    private const string vb0f35f8adf77 = "A200000052d9d779f6";
    private const string v12ab9350697f = "A200000053100d7320";

    internal static string v1a531a62486c(int id)
    {
        switch (id)
        {
            case 0: return v76c6858c777c(vcfaa6273b2eb);
            case 1: return v76c6858c777c(vc54950810b8f);
            case 2: return v76c6858c777c(v7273bdd78da0);
            case 3: return v76c6858c777c(vd11b1a6656d2);
            case 4: return v76c6858c777c(v15b26fa8001e);
            case 5: return v76c6858c777c(vb26acebb4a17);
            case 6: return v76c6858c777c(vae1891c68460);
            case 7: return v76c6858c777c(v7c6b0ed803f1);
            case 8: return v76c6858c777c(va1aa704116fe);
            case 9: return v76c6858c777c(va019e24130e4);
            case 10: return v76c6858c777c(v157d87a02f2b);
            case 11: return v76c6858c777c(vf76ddc84f45f);
            case 12: return v76c6858c777c(ve47aa9525114);
            case 13: return v76c6858c777c(v8bce2bb0544a);
            case 14: return v76c6858c777c(vb0c5c564037d);
            case 15: return v76c6858c777c(vc89277261fce);
            case 16: return v76c6858c777c(v9d58ebd74439);
            case 17: return v76c6858c777c(v9cb244a126e5);
            case 18: return v76c6858c777c(v680ac4655664);
            case 19: return v76c6858c777c(v1b928cf5f28e);
            case 20: return v76c6858c777c(v633eaaf40240);
            case 21: return v76c6858c777c(v599e1cd05d71);
            case 22: return v76c6858c777c(v31b7bd103079);
            case 23: return v76c6858c777c(vec77752e87e3);
            case 24: return v76c6858c777c(ve8362c53c45e);
            case 25: return v76c6858c777c(v1acca4b0b1a5);
            case 26: return v76c6858c777c(v23bcc34e8e0f);
            case 27: return v76c6858c777c(v48b9b3c258d8);
            case 28: return v76c6858c777c(v3438eef09109);
            case 29: return v76c6858c777c(v5f1c31bcd09d);
            case 30: return v76c6858c777c(v49448fa3a255);
            case 31: return v76c6858c777c(vcf399669bfa7);
            case 32: return v76c6858c777c(vb9723b633f9e);
            case 33: return v76c6858c777c(vaa062a739e02);
            case 34: return v76c6858c777c(ve0f48b1bcd51);
            case 35: return v76c6858c777c(v77a87391190d);
            case 36: return v76c6858c777c(vbc8da7f8e692);
            case 37: return v76c6858c777c(v49d26c490ceb);
            case 38: return v76c6858c777c(v9431cff5e54c);
            case 39: return v76c6858c777c(vb5c94067953d);
            case 40: return v76c6858c777c(v0aa9a7086695);
            case 41: return v76c6858c777c(vf2c0e7c0978b);
            case 42: return v76c6858c777c(v6831ff2422d5);
            case 43: return v76c6858c777c(va81b77f7d4f9);
            case 44: return v76c6858c777c(v5a5b5a447082);
            case 45: return v76c6858c777c(vc2dc7f601d59);
            case 46: return v76c6858c777c(vd8cf4dbe7e95);
            case 47: return v76c6858c777c(v2ace5c25aa1c);
            case 48: return v76c6858c777c(v65c9535c0b1a);
            case 49: return v76c6858c777c(v5b06fca72861);
            case 50: return v76c6858c777c(v40d24b89883a);
            case 51: return v76c6858c777c(vdc29b5d61abf);
            case 52: return v76c6858c777c(v5e124f7e3a4a);
            case 53: return v76c6858c777c(v92debdecb054);
            case 54: return v76c6858c777c(vb004cc179b44);
            case 55: return v76c6858c777c(vb4b9bfe7b2d7);
            case 56: return v76c6858c777c(v649a690d9738);
            case 57: return v76c6858c777c(v6f627c79bdac);
            case 58: return v76c6858c777c(vf19b15156ba4);
            case 59: return v76c6858c777c(v5f3affe448c4);
            case 60: return v76c6858c777c(v3aa65b4b22a9);
            case 61: return v76c6858c777c(vb9fd98e182c8);
            case 62: return v76c6858c777c(vd9be2c2dfc8e);
            case 63: return v76c6858c777c(v17ad4a2af135);
            case 64: return v76c6858c777c(vfa5234b995aa);
            case 65: return v76c6858c777c(ved9687a55ba1);
            case 66: return v76c6858c777c(vdd9f75841273);
            case 67: return v76c6858c777c(v89540675b382);
            case 68: return v76c6858c777c(vf708a652cf43);
            case 69: return v76c6858c777c(v65836eda7588);
            case 70: return v76c6858c777c(ve7d71f265066);
            case 71: return v76c6858c777c(v30e9c7d23b01);
            case 72: return v76c6858c777c(v6dbba3963dc2);
            case 73: return v76c6858c777c(v4eb50c9376e0);
            case 74: return v76c6858c777c(v9b7b182c1516);
            case 75: return v76c6858c777c(v6a82dba2f368);
            case 76: return v76c6858c777c(va7efa69772f3);
            case 77: return v76c6858c777c(v2a8db79cfdde);
            case 78: return v76c6858c777c(v2fbc54383342);
            case 79: return v76c6858c777c(v0a76342d1c88);
            case 80: return v76c6858c777c(v728c4597646a);
            case 81: return v76c6858c777c(v83b043bde1f8);
            case 82: return v76c6858c777c(vb0f35f8adf77);
            case 83: return v76c6858c777c(v12ab9350697f);
            default: return string.Empty;
        }
    }

    private static string v76c6858c777c(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v888501765a8d * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
