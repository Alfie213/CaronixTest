using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private const int MinHealth = 50;
    private const int MaxHealth = 100;

    private const int MinDamage = 5;
    private const int MaxDamage = 10;
    
    [SerializeField] private Slider healthSlider;
    
    private Health health;

    private void Awake()
    {
        health = new Health(MinHealth, MaxHealth);

        healthSlider.maxValue = health.Value;
        healthSlider.value = health.Value;
    }

    private void OnEnable()
    {
        health.OnDeath += Handle_OnDeath;
    }
    
    private void OnDisable()
    {
        health.OnDeath -= Handle_OnDeath;
    }

    public void Handle_PointerClick() // Or IPointerClickHandler.
    {
        Debug.Log("onmousedown");
        GetDamage(Random.Range(MinDamage, MaxDamage));
    }

    private void Handle_OnDeath()
    {
        EventBus.OnEnemyDeath.Publish();
    }
    
    private void GetDamage(int damage)
    {
        health.DecreaseValue(damage);
        healthSlider.value = health.Value;
    }
}
