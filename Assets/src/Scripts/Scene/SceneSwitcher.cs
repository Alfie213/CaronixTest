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
        EventBus.OnLoadSceneButtonClick.Subscribe(Handle_OnLoadSceneButtonClick);
    }

    private void OnDisable()
    {
        EventBus.OnEnemyDeath.Unsubscribe(Handle_OnEnemyDeath);
        EventBus.OnLoadSceneButtonClick.Unsubscribe(Handle_OnLoadSceneButtonClick);
    }

    private void Handle_OnEnemyDeath()
    {
        SceneLoader.LoadAvailableScene(SceneLoader.AvailableScene.ResultScene);
    }

    private void Handle_OnLoadSceneButtonClick(SceneLoader.AvailableScene scene)
    {
        SceneLoader.LoadAvailableScene(scene);
    }
}
