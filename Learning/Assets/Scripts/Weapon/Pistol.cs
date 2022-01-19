using UnityEngine;

public class Pistol : MonoBehaviour, IShooting
{
    private int ammo = 14;
    private int inGunAmmo = 60;

    public int Ammo { get => ammo; set => ammo = value; }
    public int InGunAmmo { get => inGunAmmo; set => inGunAmmo = value; }

    public int MaxAmmo => 60;
    public int MaxInGunAmmo => 14;

    Animator anim;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    public void Reload()
    {
        if (InGunAmmo > MaxInGunAmmo)
        {
            Ammo += MaxInGunAmmo;
            InGunAmmo -= MaxInGunAmmo;
        }
        else
        {
            Ammo += InGunAmmo;
            InGunAmmo = 0;
        }
        Debug.Log("Reload. Ammo: " + Ammo + ". All ammo: " + InGunAmmo + ".");
    }

    public void Shot()
    {
        if (Ammo > 0)
        {
            Ammo -= 1;

            anim.Play("Shot");
            Debug.Log("Shot. Ammo: " + Ammo + ". All ammo: " + InGunAmmo + ".");
        }
    }
}
