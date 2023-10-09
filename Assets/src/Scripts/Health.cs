using System;
using Random = UnityEngine.Random;

public class Health
{
    public Action<int> OnValueChange;
    public Action OnDeath;
    
    private int value;

    public Health(int minHealth, int maxHealth)
    {
        value = Random.Range(minHealth, maxHealth);
    }

    public void DecreaseValue(int value)
    {
        this.value -= value;
        OnValueChange?.Invoke(this.value);
        
        if (value <= 0)
            OnDeath?.Invoke();
    }
}
