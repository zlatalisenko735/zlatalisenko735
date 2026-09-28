using UnityEngine;

public class vd0454ff015af : MonoBehaviour
{
    public static vd0454ff015af vcf760af7341c;

    public GameObject panel_loader;
    public GameObject panel_menu;
    public GameObject panel_game;

    private void Awake()
    {
        vcf760af7341c = this;
    }

    public void v68ff587a7afb(GameObject v60ba09480dfc, GameObject v7817bab9299a)
    {
        v60ba09480dfc.SetActive(true);
        v7817bab9299a.SetActive(false);
    }

    public void v6104d0646d4b(GameObject v60ba09480dfc)
    {
        v60ba09480dfc.SetActive(true);
    }

    public void vb305ebea231f(GameObject v7817bab9299a)
    {
        v7817bab9299a.SetActive(false);
    }

    
}
