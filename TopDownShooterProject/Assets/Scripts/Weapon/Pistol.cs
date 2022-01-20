using UnityEngine;

public class Pistol : MonoBehaviour, IShooting
{
    private int ammo = 14;
    private int allAmmo = 60;

    public int Ammo { get => ammo; set => ammo = value; }
    public int AllAmmo { get => allAmmo; set => allAmmo = value; }
    public int MaxAmmo => 14;

    Animator anim;

    public delegate void AmmoUpdate(int ammo, int allAmmo);
    public event AmmoUpdate  ammoChanged;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    private void Start()
    {
        ammoChanged?.Invoke(Ammo, AllAmmo); //sending event about chainging the ammo count
    }

    public void Reload()
    {
        if (Ammo < MaxAmmo && AllAmmo > 0)
        {
            int restAmmo = MaxAmmo - Ammo; //taking the number of ammo needed to fill the clip
            if (AllAmmo >= restAmmo)
            {
                AllAmmo -= restAmmo;
                Ammo += restAmmo;
            }
            else
            {
                Ammo += AllAmmo;
                AllAmmo = 0;
            }

            ammoChanged?.Invoke(Ammo, AllAmmo); //sending event about chainging the ammo count
        }
    }

    public void Shot()
    {
        if (Ammo > 0)
        {
            Ammo -= 1;

            anim.Play("Shot");

            ammoChanged?.Invoke(Ammo, AllAmmo);
        }
    }
}
