using System;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public enum AvailableScene
    {
        PrimaryScene,
        EnemySearchingScene,
        BattleScene,
        ResultScene
    }
    
    public void LoadPrimaryScene()
    {
        SceneManager.LoadScene("PrimaryScene", LoadSceneMode.Single);
    }
    
    public void LoadEnemySearchingScene()
    {
        SceneManager.LoadScene("EnemySearchingScene", LoadSceneMode.Single);
    }
    
    public void LoadBattleScene()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }

    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene", LoadSceneMode.Single);
    }

    public void LoadAvailableScene(AvailableScene availableScene)
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
}
