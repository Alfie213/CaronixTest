using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyInfoHandler
{
    public Action<string, Texture2D> OnRequestEnemyInfoSuccess;

    private RandomUserApiRequester requester;
    private UriRequester uriRequester;

    private string enemyNameActionArg;
    private Texture2D enemyPictureLargeActionArg;

    public EnemyInfoHandler()
    {
        requester = new RandomUserApiRequester();
        uriRequester = new UriRequester();
        
        requester.OnRequestJObjectSuccess += Handle_OnRequestJObjectSuccess;
        uriRequester.OnRequestTexture2DSuccess += Handle_OnRequestTexture2DSuccess;
    }

    public void RequestEnemyInfo()
    {
        CoroutineRunner.instance.StartCoroutine(requester.RequestJObject());
    }

    private void Handle_OnRequestJObjectSuccess(JObject jObject)
    {
        enemyNameActionArg = RandomUserJObjectParser.ParseEnemyName(jObject);
        uriRequester.RequestTexture2D(RandomUserJObjectParser.ParseEnemyPictureLargeUri(jObject));
    }

    private void Handle_OnRequestTexture2DSuccess(Texture2D texture2D)
    {
        enemyPictureLargeActionArg = texture2D;
        OnRequestEnemyInfoSuccess?.Invoke(enemyNameActionArg, enemyPictureLargeActionArg);
    }

    ~EnemyInfoHandler()
    {
        Debug.Log("enemyinfo destroyed");
        requester.OnRequestJObjectSuccess -= Handle_OnRequestJObjectSuccess;
        uriRequester.OnRequestTexture2DSuccess -= Handle_OnRequestTexture2DSuccess;
    }
}
