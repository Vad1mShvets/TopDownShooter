using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text txtAmmo;
    Text txtAllAmmo;

    public Pistol pistol;

    private void Awake()
    {
        txtAmmo = GameObject.Find("ammo txt").GetComponent<Text>();
        txtAllAmmo = GameObject.Find("all ammo txt").GetComponent<Text>();
    }

    private void Start()
    {
        pistol.ammoChanged += OnAmmoChanged;
    }

    private void OnAmmoChanged(int ammo, int allAmmo)
    {
        txtAmmo.text = ammo + "";
        txtAllAmmo.text = allAmmo + "";
    }
}
