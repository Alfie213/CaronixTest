using Newtonsoft.Json.Linq;

public static class RandomUserJObjectParser
{
    public static string ParseEnemyName(JObject jObject)
    {
        return jObject["results"][0]["login"]["username"].Value<string>();
    }
    
    public static string ParseEnemyPictureLargeUri(JObject jObject)
    {
        return jObject["results"][0]["picture"]["large"].Value<string>();
    }
}
