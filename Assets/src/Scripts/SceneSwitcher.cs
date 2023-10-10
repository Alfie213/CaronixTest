using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = new SceneLoader();
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
        sceneLoader.LoadResultScene();
    }

    private void Handle_OnContinueButtonSubmit()
    {
        sceneLoader.LoadEnemySearchingScene();
    }
}
