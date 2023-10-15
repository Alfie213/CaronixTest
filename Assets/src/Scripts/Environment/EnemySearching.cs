using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemySearching : MonoBehaviour
{
    [Header("Enemy UI")]
    [SerializeField] private RawImage enemyRawImage;
    [SerializeField] private TextMeshProUGUI enemyName;

    [Header("EnemyData")] [SerializeField]
    private EnemyData enemyData;

    [Header("Loading screen")] [SerializeField]
    private GameObject loadingScreen;
    
    private EnemyInfoHandler enemyInfoHandler;

    private void Awake()
    {
        enemyInfoHandler = new EnemyInfoHandler();
    }

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
        this.enemyName.text = enemyName;
        enemyRawImage.texture = enemyPictureLarge;
        loadingScreen.SetActive(false);
        enemyData.entityName = enemyName;
    }
}
