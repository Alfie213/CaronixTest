using UnityEngine.SceneManagement;

public class SceneLoader
{
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
}
