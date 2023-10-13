using UnityEngine;

public class VictoryHandler : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private const int MinMoneyReward = 100;
    private const int MaxMoneyReward = 1000;    
    
    private PlayerDataHandler playerDataHandler;

    private void Awake()
    {
        playerDataHandler = new PlayerDataHandler(playerData);
    }

    private void OnEnable()
    {
        EventBus.OnEnemyDeath.Subscribe(Handle_OnEnemyDeath);
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDeath.Unsubscribe(Handle_OnEnemyDeath);
    }

    private void Handle_OnEnemyDeath()
    {
        IncreaseMoneyRandomValue();
    }

    private void IncreaseMoneyRandomValue()
    {
        playerDataHandler.IncreaseMoney(Random.Range(MinMoneyReward, MaxMoneyReward));
    }
}
