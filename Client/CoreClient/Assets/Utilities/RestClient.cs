using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.Networking;

/// <summary>
/// Wraps WWW to conform to API Routing conventions.
/// Extensibility point for things like Authentication.
/// </summary>
/// <remarks>
/// Using WWW and name convention instead of HTTP verbs due to WWW limitation.
/// Not useing UnityWebRequest due to it not working.
/// </remarks>
/// <typeparam name="T"></typeparam>
public class RestClient
{
    /// <summary>
    /// Global Headers (Authentication and such)
    /// </summary>
    public static Dictionary<string, string> Headers = new Dictionary<string, string>();

    static RestClient()
    {
        Headers.Add("CONTENT-TYPE", "application/json");
        Headers.Add("ACCEPT", "application/json");
    }

    static void ApplyHeaders(UnityWebRequest task)
    {
        foreach (var header in Headers)
        {
            task.SetRequestHeader(header.Key, header.Value);
        }
    }

    public static UnityWebRequest Get(string url)
    {
        var task = UnityWebRequest.Get(url);
        ApplyHeaders(task);
        return task;
    }

    public static UnityWebRequest Get(string url, string id)
    {
        if (!url.EndsWith("/"))
            url += "/";

        url += id;

        var task = UnityWebRequest.Get(url);
        ApplyHeaders(task);
        return task;
    }

    public static UnityWebRequest Post(string url)
    {
        var task = UnityWebRequest.Post(url, string.Empty);
        ApplyHeaders(task);
        return task;
    }

    public static UnityWebRequest Post(string url, string payload)
    {
        var task = UnityWebRequest.Post(url, payload);
        ApplyHeaders(task);
        return task;
    }

    public static UnityWebRequest Delete(string url, string id)
    {
        var task = UnityWebRequest.Delete(url);
        ApplyHeaders(task);
        return task;
    }
}
