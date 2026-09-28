using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Generated
{
    
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class v22bca37fe978 : MonoBehaviour
    {
        [Header("Win")]
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private TextMeshProUGUI _winHeader;
        [SerializeField] private TextMeshProUGUI _winMain;
        [SerializeField] private TextMeshProUGUI _winDetail;
        [SerializeField] private Button _winNextButton;
        [SerializeField] private Button _winMenuButton;

        [Header("Lose")]
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private TextMeshProUGUI _loseHeader;
        [SerializeField] private TextMeshProUGUI _loseMain;
        [SerializeField] private TextMeshProUGUI _loseDetail;
        [SerializeField] private Button _loseRetryButton;
        [SerializeField] private Button _loseMenuButton;

        [Header("Pause")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private TextMeshProUGUI _pauseMain;
        [SerializeField] private Button _pauseResumeButton;
        [SerializeField] private Button _pauseMenuButton;
        [SerializeField] private Button _pauseCloseButton;

        private Action vb1f480052421;
        private Action vfd1504399398;
        private Action vd52a8e1cde7f;
        private Action vb30ca3e51352;

        internal bool va9d0ac8ba808
        {
            get
            {
                return this._winPanel.activeSelf ||
                       this._losePanel.activeSelf ||
                       this._pausePanel.activeSelf;
            }
        }

        internal void v1a0df36b121b(Action v6a6993a5e764, Action vd6e54caa294a, Action vc759e81bb550, Action v377fc3da65ef)
        {
            this.vb1f480052421 = v6a6993a5e764;
            this.vfd1504399398 = vd6e54caa294a;
            this.vd52a8e1cde7f = vc759e81bb550;
            this.vb30ca3e51352 = v377fc3da65ef;

            this._winNextButton.onClick.AddListener(() => this.v68cc303029ea(this.vd52a8e1cde7f));
            this._winMenuButton.onClick.AddListener(() => this.v68cc303029ea(this.vb30ca3e51352));
            this._loseRetryButton.onClick.AddListener(() => this.v68cc303029ea(this.vfd1504399398));
            this._loseMenuButton.onClick.AddListener(() => this.v68cc303029ea(this.vb30ca3e51352));
            this._pauseResumeButton.onClick.AddListener(() => this.v68cc303029ea(this.vb1f480052421));
            this._pauseMenuButton.onClick.AddListener(() => this.v68cc303029ea(this.vb30ca3e51352));
            this._pauseCloseButton.onClick.AddListener(() => this.v68cc303029ea(this.vb1f480052421));

            this.v309aafdc7e8c();
        }

        internal void v309aafdc7e8c()
        {
            this._winPanel.SetActive(false);
            this._losePanel.SetActive(false);
            this._pausePanel.SetActive(false);
        }

        internal void v939c23489e94(int v9e5cb0549284, int required, float vf7ad42f7ad1a, string v691a44755a25)
        {
            this._winHeader.text = v824e01b904f1.vf1c05746297a(0);
            this._winMain.text = v824e01b904f1.vf1c05746297a(1) + v9e5cb0549284 + v824e01b904f1.vf1c05746297a(2) + required;
            this._winDetail.text = v824e01b904f1.vf1c05746297a(3) + v691a44755a25 + v824e01b904f1.vf1c05746297a(4) + vf7ad42f7ad1a.ToString(v824e01b904f1.vf1c05746297a(5)) + v824e01b904f1.vf1c05746297a(6);

            this.v309aafdc7e8c();
            this._winPanel.SetActive(true);
        }

        internal void v3e7f0e5bca8a(string v4bad13dfaf5c, int v9e5cb0549284, int required, int v87c1c391a755, string v691a44755a25)
        {
            this._loseHeader.text = v4bad13dfaf5c;
            this._loseMain.text = v824e01b904f1.vf1c05746297a(7) + v9e5cb0549284 + v824e01b904f1.vf1c05746297a(8) + required;
            this._loseDetail.text = v824e01b904f1.vf1c05746297a(9) + v691a44755a25 + v824e01b904f1.vf1c05746297a(10) + (v87c1c391a755 + 1);

            this.v309aafdc7e8c();
            this._losePanel.SetActive(true);
        }

        internal void v8d8874c184f8(int v87c1c391a755, int v9e5cb0549284, int required)
        {
            this._pauseMain.text = v824e01b904f1.vf1c05746297a(11) + (v87c1c391a755 + 1) + v824e01b904f1.vf1c05746297a(12) + v9e5cb0549284 + v824e01b904f1.vf1c05746297a(13) + required;

            this.v309aafdc7e8c();
            this._pausePanel.SetActive(true);
        }

        private void v68cc303029ea(Action vcc73fe7a9207)
        {
            if (vcc73fe7a9207 != null)
            {
                vcc73fe7a9207();
            }
        }
    }
}

internal static class v824e01b904f1
{
    private const byte v9d97a70eb504 = 0x3B;

    private const string v3b06f3aa1a2f = "A2000000004dc95254804cefd7fca5878f440fed5c";
    private const string v2fb2e4984316 = "A20000000128c30ee9d3991c9cd7d4";
    private const string v67af0f96c7c3 = "A200000002ea174fb602";
    private const string v19bf94232259 = "A200000003c7606a97b119e2ffb19ab07245";
    private const string v9766c05890c3 = "A200000004b8b74e974a8b2e68a5fb";
    private const string v985a5944f8e6 = "A200000005cba33a69e78f56";
    private const string v000f707c611e = "A200000006965491085c";
    private const string vaf91f9d7bc76 = "A200000007e948be893d6ef4a164af";
    private const string veec2511518b0 = "A2000000087b28bfbe20";
    private const string v1a76ee33402a = "A200000009fb8abebe1b0d8a0c372db6a419";
    private const string v533f215f2d2c = "A20000000a93ff6b02794a2fa7cf41";
    private const string v5b97eec3f81c = "A20000000ba83641cd6f4a7418d4";
    private const string vcfa4aad4434c = "A20000000cc64e310d2a976094b5155a0e80";
    private const string v0144412bcceb = "A20000000d927e955ee6";

    internal static string vf1c05746297a(int id)
    {
        switch (id)
        {
            case 0: return va3a9da72a8d7(v3b06f3aa1a2f);
            case 1: return va3a9da72a8d7(v2fb2e4984316);
            case 2: return va3a9da72a8d7(v67af0f96c7c3);
            case 3: return va3a9da72a8d7(v19bf94232259);
            case 4: return va3a9da72a8d7(v9766c05890c3);
            case 5: return va3a9da72a8d7(v985a5944f8e6);
            case 6: return va3a9da72a8d7(v000f707c611e);
            case 7: return va3a9da72a8d7(vaf91f9d7bc76);
            case 8: return va3a9da72a8d7(veec2511518b0);
            case 9: return va3a9da72a8d7(v1a76ee33402a);
            case 10: return va3a9da72a8d7(v533f215f2d2c);
            case 11: return va3a9da72a8d7(v5b97eec3f81c);
            case 12: return va3a9da72a8d7(vcfa4aad4434c);
            case 13: return va3a9da72a8d7(v0144412bcceb);
            default: return string.Empty;
        }
    }

    private static string va3a9da72a8d7(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v9d97a70eb504 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
