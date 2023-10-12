using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyInfoHandler
{
    public Action OnRequestEnemyInfoSuccess;

    private RandomUserApiRequester requester;

    private EnemyInfoHandler()
    {
        requester.OnRequestEnemyInfoSuccess += Handle_OnRequestPlayerInfoSuccess;
    }

    public IEnumerator RequestEnemyInfo()
    {
        yield return CoroutineRunner.instance.StartCoroutine(requester.RequestEnemyInfo());
    }

    private void Handle_OnRequestPlayerInfoSuccess(JObject jObject, Texture2D enemyPicture)
    {
        
    }

    ~EnemyInfoHandler()
    {
        Debug.Log("enemyinfo destroyed");
        requester.OnRequestEnemyInfoSuccess -= Handle_OnRequestPlayerInfoSuccess;
    }
}
