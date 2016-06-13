using UnityEngine;

public static class WWWExt
{
    ///<summary>Deserialize payload text as json </summary>
    public static bool isError(this WWW handler)
    {
        return !string.IsNullOrEmpty(handler.error);
    }

    ///<summary>Deserialize payload text as json </summary>
    public static T Deserialize<T>(this WWW handler)
    {
        if (string.IsNullOrEmpty(handler.text))
            return default(T);

        return JsonUtility.FromJson<T>(handler.text);
    }
}
