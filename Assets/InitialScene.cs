using UnityEngine;

public class InitialScene : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    private void Awake()
    {
        SceneLoader.LoadAvailableScene(string.IsNullOrEmpty(playerData.playerName)
            ? SceneLoader.AvailableScene.PrimaryScene
            : SceneLoader.AvailableScene.EnemySearchingScene);
    }
}
