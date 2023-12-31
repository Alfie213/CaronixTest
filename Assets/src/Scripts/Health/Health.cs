using System;
using Random = UnityEngine.Random;

public class Health
{
    public Action<int> OnValueChange;
    public Action OnDeath;
    
    public int Value { get; private set; }

    public Health(int minHealth, int maxHealth)
    {
        Value = Random.Range(minHealth, maxHealth);
    }

    public void DecreaseValue(int value)
    {
        Value -= value;
        OnValueChange?.Invoke(Value);
        
        if (Value <= 0)
            OnDeath?.Invoke();
    }
}
