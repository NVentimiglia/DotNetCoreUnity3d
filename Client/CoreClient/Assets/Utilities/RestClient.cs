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
    /// Http://{domain}/api/{controller}/
    /// </summary>
    public string UrlBase { get; private set; }

    /// <summary>
    /// Global Headers (Authentication and such)
    /// </summary>
    public static Dictionary<string, string> Headers = new Dictionary<string, string>();

    static RestClient()
    {
        Headers.Add("CONTENT-TYPE", "application/json");
        Headers.Add("ACCEPT", "application/json");
    }

    public RestClient(string urlBase)
    {
        if (!urlBase.EndsWith("/"))
            urlBase += "/";

        UrlBase = urlBase;
    }

    public WWW Get()
    {
        //Use Post, for header support.
        Debug.Log(string.Format("{0}{1}", UrlBase, "Get"));
        return new WWW(string.Format("{0}{1}", UrlBase, "Get"), new byte[1], Headers);
    }

    public WWW Get(string id)
    {
        Debug.Log(string.Format("{0}{1}/{2}", UrlBase, "Get", id));
        return new WWW(string.Format("{0}{1}/{2}", UrlBase, "Get", id), new byte[1], Headers);
    }

    public WWW Post()
    {
        Debug.Log(string.Format("{0}{1}", UrlBase, "Post"));
        return new WWW(string.Format("{0}{1}", UrlBase, "Post"), new byte[1], Headers);
    }

    public WWW Post(string payload)
    {
        Debug.Log(string.Format("{0}{1}", UrlBase, "Post"));
        return new WWW(string.Format("{0}{1}", UrlBase, "Post"), Encoding.UTF8.GetBytes(payload), Headers);
    }

    public WWW Delete(string id)
    {
        Debug.Log(string.Format("{0}{1}/{2}", UrlBase, "Delete", id));
        return new WWW(string.Format("{0}{1}/{2}", UrlBase, "Delete", id), new byte[1], Headers);
    }
}
