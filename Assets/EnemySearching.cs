using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EnemySearching : MonoBehaviour
{
    [SerializeField] private Image image;
    
    private const string Uri = "https://randomuser.me/api/";
    
    private UnityAction<JObject> onGetRequestSuccessfullyFinished;

    private void Start()
    {
        StartCoroutine(GetRequest(Uri));
    }
    
    private void OnEnable()
    {
        onGetRequestSuccessfullyFinished += ParseUsername;
        onGetRequestSuccessfullyFinished += ParseImage;
    }
    
    private void OnDisable()
    {
        onGetRequestSuccessfullyFinished -= ParseUsername;
        onGetRequestSuccessfullyFinished -= ParseImage;
    }
    
    private void ParseUsername(JObject jObject)
    {
        string username = jObject["results"][0]["login"]["username"].Value<string>();
    }
    
    private void ParseImage(JObject jObject)
    {
        string pictureUri = jObject["results"][0]["picture"]["large"].Value<string>();
        StartCoroutine(Get(pictureUri));
    }
    
    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(uri))
        {
            yield return uwr.SendWebRequest();
    
            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                JObject jObject = JObject.Parse(uwr.downloadHandler.text);
                onGetRequestSuccessfullyFinished?.Invoke(jObject);
            }
        }
    }

    private IEnumerator Get(string uri)
    {
        using (UnityWebRequest uwrt = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwrt.SendWebRequest();
            
            if (uwrt.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error While Sending: " + uwrt.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwrt);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                image.sprite = sprite;
            }
        }
    }
}
