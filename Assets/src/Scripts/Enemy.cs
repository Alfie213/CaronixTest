using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const int MinHealth = 50;
    private const int MaxHealth = 100;

    private const int MinDamage = 5;
    private const int MaxDamage = 10;
    
    private Health health;

    private void Awake()
    {
        health = new Health(MinHealth, MaxHealth);
    }

    // private void OnEnable()
    // {
    //     health.OnDeath += Handle_OnDeath;
    // }
    //
    // private void OnDisable()
    // {
    //     health.OnDeath -= Handle_OnDeath;
    // }

    private void OnMouseDown()
    {
        GetDamage(Random.Range(MinDamage, MaxDamage));
    }

    // private void Handle_OnDeath()
    // {
    //     //...
    // }
    
    public void GetDamage(int damage)
    {
        health.DecreaseValue(damage);
    }
}
