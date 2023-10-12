using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class UriRequester
{
    public Action<Texture2D> OnRequestTexture2DSuccess;

    public void RequestTexture2D(string uri)
    {
        CoroutineRunner.instance.StartCoroutine(RequestTexture2DCoroutine(uri));
    }
    
    private IEnumerator RequestTexture2DCoroutine(string uri)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();
            
            if (uwr.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("Error While Sending: " + uwr.error);
                yield break;
            }

            OnRequestTexture2DSuccess?.Invoke(DownloadHandlerTexture.GetContent(uwr));
        }
    }
}
