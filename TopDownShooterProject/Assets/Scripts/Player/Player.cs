using UnityEngine;

public class Player : MonoBehaviour, IAlive
{
    float hp = 100;
    float maxHP;

    private void Awake()
    {
        maxHP = hp;
    }

    public void Damage(float damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            Debug.Log(this.name + " has been damaged. hp: " + hp);
        }
        else
        {
            Die();
        }
    }

    public void Heal(float heal)
    {
        if (hp < maxHP && hp > 0)
        {
            hp += heal;
            Debug.Log(this.name + " has been healed. hp: " + hp);

            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }
    }

    public void Die()
    {
        Debug.Log(this.name + " has died :(");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(2.5f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Damage(5);
        }
    }
}
