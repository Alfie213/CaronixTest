using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class RandomUserApiRequester
{
    public Action<string, Texture2D> OnRequestPlayerInfoSuccess;
    
    private const string ApiUri = "https://randomuser.me/api/";

    private JObject currentJObject;

    private string currentUsername;
    private Texture2D currentTexture2D;

    public IEnumerator RequestEnemyInfo()
    {
        yield return CoroutineRunner.instance.StartCoroutine(RequestJObject());
        yield return CoroutineRunner.instance.StartCoroutine(
            RequestTexture2D(RandomUserJObjectParser.ParseEnemyPictureLargeUri(currentJObject)));
        currentUsername = RandomUserJObjectParser.ParseEnemyName(currentJObject);
        
        OnRequestPlayerInfoSuccess?.Invoke(currentUsername, currentTexture2D);
    }
    
    private IEnumerator RequestJObject()
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(ApiUri))
        {
            yield return uwr.SendWebRequest();
    
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Error While Sending: " + uwr.error);
                yield break;
            }

            currentJObject = JObject.Parse(uwr.downloadHandler.text);
        }
    }
    
    private IEnumerator RequestTexture2D(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();
            
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Error While Sending: " + uwr.error);
                yield break;
            }

            currentTexture2D = DownloadHandlerTexture.GetContent(uwr);
        }
    }
}
