using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySearching : MonoBehaviour
{
    private const string Uri = "https://randomuser.me/api/";
    
    private void Start()
    {
        StartCoroutine(GetRequest(Uri));
    }

    private IEnumerator GetRequest(string uri)
    {
        Debug.Log("Request");
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
