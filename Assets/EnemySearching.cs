using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySearching : MonoBehaviour
{
    private const string ApiUri = "https://randomuser.me/api/";

    private JObject jObject;
    private string username;
    private Texture2D texture2D;
    
    private void Start()
    {
        StartCoroutine(SearchEnemy());
    }

    private IEnumerator SearchEnemy()
    {
        yield return GetJObject(ApiUri);

        ParseUsername();
        yield return ParsePictureLarge();

        Sprite sprite = ConvertTexture2DToSprite(texture2D);
    }
    
    private void ParseUsername()
    {
        username = jObject["results"][0]["login"]["username"].Value<string>();
    }
    
    private IEnumerator ParsePictureLarge()
    {
        string pictureUri = jObject["results"][0]["picture"]["large"].Value<string>();
        StartCoroutine(GetTexture2D(pictureUri));
        yield break;
    }

    private IEnumerator GetTexture2D(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();
            
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                texture2D = DownloadHandlerTexture.GetContent(uwr);
            }
        }
    }
    
    private IEnumerator GetJObject(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(uri))
        {
            yield return uwr.SendWebRequest();
    
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log("Error While Sending: " + uwr.error);
            }
            else
            {
                jObject = JObject.Parse(uwr.downloadHandler.text);
            }
        }
    }

    private Sprite ConvertTexture2DToSprite(Texture2D texture2D)
    {
        return Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
    }
}
