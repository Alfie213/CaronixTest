using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    private SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = new SceneLoader();
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
        sceneLoader.LoadResultScene();
    }
}
