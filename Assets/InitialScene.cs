using UnityEngine;

public class InitialScene : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    private void Awake()
    {
        SceneLoader.LoadAvailableScene(string.IsNullOrEmpty(playerData.entityName)
            ? SceneLoader.AvailableScene.PrimaryScene
            : SceneLoader.AvailableScene.EnemySearchingScene);
    }
}
