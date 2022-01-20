public interface IShooting
{
    int Ammo { get; set; } //ammo count in clip of weapon
    int AllAmmo { get; set; } //all of the available ammo
    int MaxAmmo { get; } //maximum capacity of ammo in clip

    void Shot();
    void Reload(); 
}