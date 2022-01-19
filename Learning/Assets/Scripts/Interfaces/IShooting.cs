public interface IShooting
{
    int Ammo { get; set; }
    int InGunAmmo { get; set; }
    int MaxAmmo { get; }
    int MaxInGunAmmo { get; }

    void Shot();
    void Reload(); 
}