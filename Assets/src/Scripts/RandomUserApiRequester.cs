using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class RandomUserApiRequester
{
    public Action<JObject, Texture2D> OnRequestEnemyInfoSuccess;
    
    private const string ApiUri = "https://randomuser.me/api/";

    private JObject jObjectActionArg;
    private Texture2D enemyPictureActionArg;

    public IEnumerator RequestEnemyInfo()
    {
        yield return CoroutineRunner.instance.StartCoroutine(RequestJObject());
        yield return CoroutineRunner.instance.StartCoroutine(
            RequestTexture2D(RandomUserJObjectParser.ParseEnemyPictureLargeUri(jObjectActionArg)));
        
        OnRequestEnemyInfoSuccess?.Invoke(jObjectActionArg, enemyPictureActionArg);
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

            jObjectActionArg = JObject.Parse(uwr.downloadHandler.text);
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

            enemyPictureActionArg = DownloadHandlerTexture.GetContent(uwr);
        }
    }
}
