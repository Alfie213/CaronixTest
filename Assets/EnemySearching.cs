using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySearching : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    
    private const string ApiUri = "https://randomuser.me/api/";

    private JObject jObject;
    private string username;
    private Texture2D texture2D;
    
    private void Start()
    {
        SearchEnemy();
    }

    public void SearchEnemy()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(SearchingEnemy());
    }

    private IEnumerator SearchingEnemy()
    {
        yield return GetJObject(ApiUri);

        ParseUsername();
        yield return ParsePictureLarge();

        Sprite sprite = texture2D.ConvertToSprite();
        
        loadingScreen.SetActive(false);
    }
    
    private void ParseUsername()
    {
        username = jObject["results"][0]["login"]["username"].Value<string>();
    }
    
    private IEnumerator ParsePictureLarge()
    {
        string pictureUri = jObject["results"][0]["picture"]["large"].Value<string>();
        yield return StartCoroutine(GetTexture2D(pictureUri));
    }

    private IEnumerator GetTexture2D(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();
            
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Error While Sending: " + uwr.error);
                yield break;
            }
            
            texture2D = DownloadHandlerTexture.GetContent(uwr);
        }
    }
    
    private IEnumerator GetJObject(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(uri))
        {
            yield return uwr.SendWebRequest();
    
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Error While Sending: " + uwr.error);
                yield break;
            }
            
            jObject = JObject.Parse(uwr.downloadHandler.text);
        }
    }
}
