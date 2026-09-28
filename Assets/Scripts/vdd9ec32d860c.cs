using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;



public class vdd9ec32d860c : MonoBehaviour
{
    [SerializeField] private vd0454ff015af _panelsFlow;
    [SerializeField] private v69d1ecbac908 _controllerPrivacyPolicy;

    
    [SerializeField] private int game_score = 0;
    [SerializeField] private string privacyPolicy = vec103dddb69d.vea82baf6bea7(0);

    
    [SerializeField] private TextMeshProUGUI text_ui_main_score;
    [SerializeField] private Button  button_ui_main_play;
    [SerializeField] private Button  button_ui_main_privacy_policy;
    [SerializeField] private GameObject panel_ui_main;

  

    private void Awake()
    {
        _panelsFlow = vd0454ff015af.vcf760af7341c;
    }

    private void Start()
    {
        v7758d57bdc9f();
    }

    
    private void Update()
    {
        v346dee333ad7();
    }

    private void v7758d57bdc9f()
    {
        button_ui_main_play.onClick.AddListener(() => _panelsFlow.v68ff587a7afb(_panelsFlow.panel_game, _panelsFlow.panel_menu));

       button_ui_main_privacy_policy.onClick.AddListener(() => _controllerPrivacyPolicy.v2b8949161bae(privacyPolicy));
    }

    private void v346dee333ad7()
    {
        ve272d4a7a80e();
    }

    private void ve272d4a7a80e()
    {
        text_ui_main_score.text = game_score.ToString();

    }


    
}

internal static class vec103dddb69d
{
    private const byte v3fc75705aad7 = 0xF2;

    private const string vb0d84e9d3a0a = "A2000000007c899a2a";

    internal static string vea82baf6bea7(int id)
    {
        switch (id)
        {
            case 0: return vf8a60b8637f3(vb0d84e9d3a0a);
            default: return string.Empty;
        }
    }

    private static string vf8a60b8637f3(string hex)
    {
        if (string.IsNullOrEmpty(hex) || hex.Length < 18 || hex[0] != 'A' || hex[1] != '2' || ((hex.Length - 18) & 1) != 0)
        {
            return string.Empty;
        }

        int embeddedId = unchecked((int)System.Convert.ToUInt32(hex.Substring(2, 8), 16));
        uint salt = System.Convert.ToUInt32(hex.Substring(10, 8), 16);
        int count = (hex.Length - 18) / 2;
        byte[] bytes = new byte[count];
        uint state = unchecked(salt ^ ((uint)v3fc75705aad7 * 0x045D9F3Bu) ^ ((uint)embeddedId * 0x9E3779B9u) ^ 0xA5C3E27Du);
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
