using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Generated
{
    
    
    
    
    
    [DisallowMultipleComponent]
    internal sealed class vcccb7af22a7e : MonoBehaviour
    {
        private const float vda55321b8a24 = 2.2f;
        private const float v1811727ac5c5 = 0.35f;
        private const float v1669ae147760 = 0.25f;
        private const float v806c53724a3b = 12f;

        [SerializeField] private TextMeshProUGUI _starsText;
        [SerializeField] private RectTransform _starsChip;
        [SerializeField] private Image[] _lifePips;
        [SerializeField] private RectTransform _timerFill;
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TextMeshProUGUI _ringText;
        [SerializeField] private CanvasGroup _hintGroup;
        [SerializeField] private TextMeshProUGUI _noticeText;
        [SerializeField] private CanvasGroup _noticeGroup;

        private Vector3 vbdeb5d01f74b = Vector3.one;
        private float v423559e73d1e;
        private float v7ec11146243d;
        private float vd8fe34b58e6a;
        private float va9b1452c59d9;

        private void Awake()
        {
            this.vbdeb5d01f74b = this._starsChip.localScale;
            this.v423559e73d1e = this._timerFill.rect.width;
            this._noticeGroup.alpha = 0f;
        }

        internal void v9f2343748199(int va94cdbd37add, int required)
        {
            this._starsText.text = va94cdbd37add + v1d1a97a862d1.vaf585c0bf2fb(0) + required;
        }

        internal void v2c6b5dea1f62()
        {
            this.v7ec11146243d = v1811727ac5c5;
        }

        internal void vde601af15752(int ve484923919d2)
        {
            for (int i = 0; i < this._lifePips.Length; i++)
            {
                bool lit = i < ve484923919d2;
                this._lifePips[i].color = lit
                    ? va7c9379be56b.va10e8b276e1d
                    : va7c9379be56b.vb477f7abc689(va7c9379be56b.v02610b855b7f, 0.25f);
            }
        }

        internal void v0462b1da3859(float v82753a200c22, float v2d669e46e991)
        {
            float fraction = v2d669e46e991 <= 0f ? 0f : Mathf.Clamp01(v82753a200c22 / v2d669e46e991);

            Vector2 size = this._timerFill.sizeDelta;
            size.x = this.v423559e73d1e * fraction;
            this._timerFill.sizeDelta = size;

            this._timerText.text = Mathf.CeilToInt(Mathf.Max(0f, v82753a200c22)) + v1d1a97a862d1.vaf585c0bf2fb(1);
        }

        internal void v78a95eb65a39(int v87c1c391a755, int v72655518d873)
        {
            
            
            int shown = v87c1c391a755 + 1;
            this._ringText.text = shown >= v72655518d873
                ? v1d1a97a862d1.vaf585c0bf2fb(2) + shown + v1d1a97a862d1.vaf585c0bf2fb(3)
                : v1d1a97a862d1.vaf585c0bf2fb(4) + shown + v1d1a97a862d1.vaf585c0bf2fb(5);
        }

        
        internal void v1af27008665e(string vad87b7264139)
        {
            this._noticeText.text = vad87b7264139;
            this.vd8fe34b58e6a = vda55321b8a24;
        }

        private void Update()
        {
            float delta = Time.deltaTime;
            this.va9b1452c59d9 += delta;

            
            
            this._hintGroup.alpha = this.va9b1452c59d9 < v806c53724a3b ? 0.95f : 0.6f;

            if (this.v7ec11146243d > 0f)
            {
                this.v7ec11146243d -= delta;
                float swell = vc0d78983fe6a.vc58549d3874d(1f - Mathf.Clamp01(this.v7ec11146243d / v1811727ac5c5));
                this._starsChip.localScale = this.vbdeb5d01f74b * (1f + (v1669ae147760 * swell));
            }

            if (this.vd8fe34b58e6a > 0f)
            {
                this.vd8fe34b58e6a -= delta;
                float life = Mathf.Clamp01(this.vd8fe34b58e6a / vda55321b8a24);
                this._noticeGroup.alpha = Mathf.Min(1f, life * 3f);
            }
        }
    }
}

internal static class v1d1a97a862d1
{
    private const byte vb2f7cf3060f4 = 0xD2;

    private const string va3d2f0726b4b = "A200000000c434b29e9d";
    private const string v4d6901c8eb8a = "A2000000014263351804";
    private const string v2b70890e42e1 = "A200000002ad8da931b8ff923878";
    private const string vddc0a474b601 = "A200000003e7120a71e83cd2b06fe9c280e8641220fb7ee70a";
    private const string v60208af07233 = "A200000004132de7c7f944adf7ac";
    private const string v83e2f911c572 = "A200000005394c227e5a924fd7502277e7d854281a98";

    internal static string vaf585c0bf2fb(int id)
    {
        switch (id)
        {
            case 0: return v62846093dfe9(va3d2f0726b4b);
            case 1: return v62846093dfe9(v4d6901c8eb8a);
            case 2: return v62846093dfe9(v2b70890e42e1);
            case 3: return v62846093dfe9(vddc0a474b601);
            case 4: return v62846093dfe9(v60208af07233);
            case 5: return v62846093dfe9(v83e2f911c572);
            default: return string.Empty;
        }
    }

    private static string v62846093dfe9(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)vb2f7cf3060f4 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
