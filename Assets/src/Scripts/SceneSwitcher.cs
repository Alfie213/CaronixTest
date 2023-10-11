using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        EventBus.OnEnemyDeath.Subscribe(Handle_OnEnemyDeath);
        EventBus.OnContinueButtonSubmit.Subscribe(Handle_OnContinueButtonSubmit);
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDeath.Unsubscribe(Handle_OnEnemyDeath);
        EventBus.OnContinueButtonSubmit.Unsubscribe(Handle_OnContinueButtonSubmit);
    }

    private void Handle_OnEnemyDeath()
    {
        SceneLoader.LoadAvailableScene(SceneLoader.AvailableScene.ResultScene);
    }

    private void Handle_OnContinueButtonSubmit()
    {
        SceneLoader.LoadAvailableScene(SceneLoader.AvailableScene.EnemySearchingScene);
    }
}
