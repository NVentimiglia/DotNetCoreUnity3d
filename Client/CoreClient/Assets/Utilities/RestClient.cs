using System;
using UnityEngine;
using UnityEngine.Experimental.Networking;

/// <summary>
/// Http client
/// </summary>
/// <typeparam name="T"></typeparam>
public class RestClient
{
    /// <summary>
    /// Http://{domain}/api/{controller}
    /// </summary>
    public string UrlBase;

    public RestClient(string urlBase)
    {
        UrlBase = urlBase;
    }

    public UnityWebRequest Get()
    {
        return UnityWebRequest.Get(UrlBase);
    }

    public UnityWebRequest Get(string id)
    {
        return UnityWebRequest.Get(string.Format("{0}/{1}", UrlBase, id));
    }

    public UnityWebRequest Post(string payload)
    {
        return UnityWebRequest.Post(UrlBase, payload);
    }

    public UnityWebRequest Delete(string id)
    {
        return UnityWebRequest.Delete(string.Format("{0}/{1}", UrlBase, id));
    }
}
