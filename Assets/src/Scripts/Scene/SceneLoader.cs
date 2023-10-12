using System;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum AvailableScene
    {
        PrimaryScene,
        EnemySearchingScene,
        BattleScene,
        ResultScene
    }
    
    public static void LoadAvailableScene(AvailableScene availableScene)
    {
        switch (availableScene)
        {
            case AvailableScene.PrimaryScene:
                LoadPrimaryScene();
                break;
            case AvailableScene.EnemySearchingScene:
                LoadEnemySearchingScene();
                break;
            case AvailableScene.BattleScene:
                LoadBattleScene();
                break;
            case AvailableScene.ResultScene:
                LoadResultScene();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(availableScene), availableScene, null);
        }
    }
    
    private static void LoadPrimaryScene()
    {
        SceneManager.LoadScene("PrimaryScene", LoadSceneMode.Single);
    }
    
    private static void LoadEnemySearchingScene()
    {
        SceneManager.LoadScene("EnemySearchingScene", LoadSceneMode.Single);
    }
    
    private static void LoadBattleScene()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }

    private static void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }
}
