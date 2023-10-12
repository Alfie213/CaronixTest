public static class EventBus
{
    public static readonly CustomAction OnEnemyDeath = new CustomAction();
    public static readonly CustomAction<SceneLoader.AvailableScene> OnLoadSceneButtonClick = new CustomAction<SceneLoader.AvailableScene>();
}