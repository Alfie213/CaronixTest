using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class RandomUserApiRequester
{
    public Action<JObject> OnRequestJObjectSuccess;
    
    private const string ApiUri = "https://randomuser.me/api/";

    public IEnumerator RequestJObject()
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(ApiUri))
        {
            yield return uwr.SendWebRequest();
    
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Error While Sending: " + uwr.error);
                yield break;
            }

            OnRequestJObjectSuccess?.Invoke(JObject.Parse(uwr.downloadHandler.text));
        }
    }
}
