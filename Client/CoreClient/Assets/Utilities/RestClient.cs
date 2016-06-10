using System;
using System.Text;
using UnityEngine.Experimental.Networking;

/// <summary>
/// Http Client which fixes bugs in UnityWebRequest
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
        UnityWebRequest task = new UnityWebRequest(UrlBase);
        task.downloadHandler = new DownloadHandlerBuffer();
        task.method = UnityWebRequest.kHttpVerbGET;
        task.Send();
        return task;
    }

    public UnityWebRequest Get(string id)
    {
        UnityWebRequest task = new UnityWebRequest(string.Format("{0}/{1}", UrlBase, id));
        task.downloadHandler = new DownloadHandlerBuffer();
        task.method = UnityWebRequest.kHttpVerbGET;
        return task;
    }

    public UnityWebRequest Post()
    {
        UnityWebRequest task = new UnityWebRequest(UrlBase);
        task.downloadHandler = new DownloadHandlerBuffer();
        task.method = UnityWebRequest.kHttpVerbPOST;
        return task;
    }

    public UnityWebRequest Post(string payload)
    {
        UnityWebRequest task = new UnityWebRequest(UrlBase);
        task.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(payload));
        task.downloadHandler = new DownloadHandlerBuffer();
        task.method = UnityWebRequest.kHttpVerbPOST;
        return task;
    }

    public UnityWebRequest Delete(string id)
    {
        UnityWebRequest task = new UnityWebRequest(string.Format("{0}/{1}", UrlBase, id));
        task.downloadHandler = new DownloadHandlerBuffer();
        task.method = UnityWebRequest.kHttpVerbDELETE;
        return task;
    }
}
