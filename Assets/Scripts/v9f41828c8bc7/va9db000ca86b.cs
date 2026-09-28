using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Generated
{
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class va9db000ca86b : MonoBehaviour
    {
        private const int v28306a333fb7 = 1;
        private const float v34e68b04ae2d = 25f;
        private const float vba58a496c054 = 0.35f;
        private const float v8b0f0e5a4ddd = 0.25f;

        [Header("Panels")]
        [SerializeField] private GameObject _loaderPanel;
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _howToPanel;

        [Header("Loader")]
        [SerializeField] private Slider _loadingSlider;

        [Header("Menu")]
        [SerializeField] private TextMeshProUGUI _objectiveText;
        [SerializeField] private TextMeshProUGUI _bankText;
        [SerializeField] private RectTransform _bankChip;
        [SerializeField] private TextMeshProUGUI _orbitText;
        [SerializeField] private Image _orbitAccent;
        [SerializeField] private Image _emblemImage;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _orbitButton;
        [SerializeField] private Button _howToButton;
        [SerializeField] private Button _howToCloseButton;

        private float v112207b0cbef;
        private float v7ec11146243d;
        private Vector3 vf1028d3e1253 = Vector3.one;
        private int v921fe7c43825;

        
        private static readonly Color[] v7d9a9fbb65a1 =
        {
            va7c9379be56b.va10e8b276e1d,
            va7c9379be56b.v793c5f9ef2be,
            va7c9379be56b.v97a9dfa1067f,
            va7c9379be56b.vdfed27544942,
        };

        private void Awake()
        {
            this.vf1028d3e1253 = this._bankChip.localScale;

            this._playButton.onClick.AddListener(() => this.v40a70e4418db());
            this._orbitButton.onClick.AddListener(() => this.v0a6ec042df4f());
            this._howToButton.onClick.AddListener(() => this._howToPanel.SetActive(true));
            this._howToCloseButton.onClick.AddListener(() => this._howToPanel.SetActive(false));
        }

        private void Start()
        {
            this.v112207b0cbef = v34e68b04ae2d;
            this._loadingSlider.value = 0f;

            this._loaderPanel.SetActive(true);
            this._menuPanel.SetActive(false);
            this._howToPanel.SetActive(false);

            this.v921fe7c43825 = 0;
            this.vaba904efb459();
            this.veeb3ac086592();
        }

        private void Update()
        {
            if (this.v112207b0cbef > 0f)
            {
                this.v112207b0cbef -= Time.deltaTime;
                this._loadingSlider.value = 1f - Mathf.Clamp01(this.v112207b0cbef / v34e68b04ae2d);

                if (this.v112207b0cbef <= 0f)
                {
                    this._loaderPanel.SetActive(false);
                    this._menuPanel.SetActive(true);
                }
            }

            if (this.v7ec11146243d > 0f)
            {
                this.v7ec11146243d -= Time.deltaTime;
                float swell = vc0d78983fe6a.vc58549d3874d(1f - Mathf.Clamp01(this.v7ec11146243d / vba58a496c054));
                this._bankChip.localScale = this.vf1028d3e1253 * (1f + (v8b0f0e5a4ddd * swell));
            }
        }

        private void v40a70e4418db()
        {
            v5e10cba67c40.v1f54c679c1c9(this.v921fe7c43825);
            SceneManager.LoadScene(v28306a333fb7);
        }

        private void v0a6ec042df4f()
        {
            this.v921fe7c43825 = (this.v921fe7c43825 + 1) % v5e10cba67c40.v599319d93fa3;
            this.vaba904efb459();
            this.v7ec11146243d = vba58a496c054;
        }

        private void vaba904efb459()
        {
            Color accent = v7d9a9fbb65a1[this.v921fe7c43825];

            
            
            this._orbitText.text = v1d799b36e0aa.v56ac575fca52(0) + (this.v921fe7c43825 + 1);
            this._orbitAccent.color = accent;
            this._emblemImage.color = accent;
            this._objectiveText.text = v1d799b36e0aa.v56ac575fca52(1) + v2fcef25e0767.v19c1a0375d93 + v1d799b36e0aa.v56ac575fca52(2);
        }

        private void veeb3ac086592()
        {
            int best = v5e10cba67c40.v29cf3f50087e;

            
            this._bankText.text = best > 0 ? v1d799b36e0aa.v56ac575fca52(3) + best : v1d799b36e0aa.v56ac575fca52(4);
        }
    }
}

internal static class v1d799b36e0aa
{
    private const byte vaffb19d968d7 = 0x49;

    private const string vd6165989ace8 = "A2000000008b81673127d60bce141fc3";
    private const string v8cc6c14514ea = "A2000000017edeedbca6e0472a099e1ebc46b024c21e6668";
    private const string vd1af40e33883 = "A200000002876c5e2ccab42eabc68b";
    private const string vdd082b60e77e = "A200000003a5763bec4b372de7de";
    private const string vb939845d759b = "A2000000044f9b18dd50eabe4f01bf8aa5988697747df2ba6f58ca";

    internal static string v56ac575fca52(int id)
    {
        switch (id)
        {
            case 0: return v9a150895ba83(vd6165989ace8);
            case 1: return v9a150895ba83(v8cc6c14514ea);
            case 2: return v9a150895ba83(vd1af40e33883);
            case 3: return v9a150895ba83(vdd082b60e77e);
            case 4: return v9a150895ba83(vb939845d759b);
            default: return string.Empty;
        }
    }

    private static string v9a150895ba83(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)vaffb19d968d7 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
