using UnityEngine;
using UnityEngine.Experimental.Networking;

public static class UnityWebRequestExt
{
    ///<summary>Deserialize payload text as json </summary>
    public static T Deserialize<T>(this UnityWebRequest handler)
    {
        if (string.IsNullOrEmpty(handler.downloadHandler.text))
            return default(T);

        return JsonUtility.FromJson<T>(handler.downloadHandler.text);
    }
}
