using Newtonsoft.Json.Linq;
using UnityEngine;

public class EnemySearching : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    private RandomUserApiRequester requester;
    
    private JObject jObject;
    private string username;
    private Texture2D texture2D;
    
    private void Start()
    {
        SearchEnemy();
    }

    private void OnEnable()
    {
        requester.OnRequestPlayerInfoSuccess += Handle_OnRequestPlayerInfoSuccess;
    }

    private void OnDisable()
    {
        requester.OnRequestPlayerInfoSuccess -= Handle_OnRequestPlayerInfoSuccess;
    }

    public void SearchEnemy()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(requester.RequestPlayerInfo());
    }

    // private IEnumerator SearchingEnemy()
    // {
    //     yield return 
    //     
    //     loadingScreen.SetActive(false);
    // }

    private void Handle_OnRequestPlayerInfoSuccess(string username, Texture2D userPicture)
    {
        // set  values
        loadingScreen.SetActive(false);
    }
}
