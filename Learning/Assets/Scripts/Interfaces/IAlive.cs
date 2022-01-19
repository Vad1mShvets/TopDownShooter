public interface IAlive
{
    //float Health { get; set; }
    //float MaxHealth { get; set; }
    void Damage(float damage);
    void Heal(float heal);
    void Die();
}