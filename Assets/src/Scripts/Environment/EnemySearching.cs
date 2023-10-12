using Newtonsoft.Json.Linq;
using UnityEngine;

public class EnemySearching : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    private EnemyInfoHandler enemyInfoHandler;
    
    private JObject jObject;
    private string username;
    private Texture2D texture2D;
    
    private void Start()
    {
        SearchEnemy();
    }

    private void OnEnable()
    {
        enemyInfoHandler.OnRequestEnemyInfoSuccess += Handle_OnRequestEnemyInfoSuccess;
    }

    private void OnDisable()
    {
        enemyInfoHandler.OnRequestEnemyInfoSuccess -= Handle_OnRequestEnemyInfoSuccess;
    }

    public void SearchEnemy()
    {
        loadingScreen.SetActive(true);
        enemyInfoHandler.RequestEnemyInfo();
    }

    private void Handle_OnRequestEnemyInfoSuccess(string enemyName, Texture2D enemyPictureLarge)
    {
        // set  values
        loadingScreen.SetActive(false);
    }
}
