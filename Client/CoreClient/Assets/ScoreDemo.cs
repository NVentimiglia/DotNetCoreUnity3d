using System;
using UnityEngine;
using System.Collections;


public class ScoreDemo : MonoBehaviour
{
    public string ServerPath = "http://localhost:58459/api/Score";

    public RestClient Client;

    public string UserName;
    public string Points;

    void Awake()
    {
        Client = new RestClient("http://localhost:58459/api/Score");
    }


    [ContextMenu("Get High Scores")]
    public void GetScores()
    {
        StartCoroutine(GetScoresAsync());
    }

    [ContextMenu("Get My Scores")]
    public void GetScore()
    {
        StartCoroutine(GetScoreAsync());
    }

    [ContextMenu("Post My Scores")]
    public void PostScore()
    {
        StartCoroutine(PostScoreAsync());
    }

    [ContextMenu("Delete My Scores")]
    public void DeleteScore()
    {
        StartCoroutine(DeleteScoreAsync());
    }

    IEnumerator GetScoresAsync()
    {
        Debug.Log("GetScoresAsync...");
        yield return 1;

        //TODO, pass in an filter
        var task = Client.Get();
        yield return task.Send();

        if (task.isError)
        {
            Debug.LogError(task.error);
        }
        else
        {
            var scores = task.Deserialize<ScoreModel[]>();

            foreach (var score in scores)
            {
                Debug.Log(score.UserName + " " + score.Points);
            }
        }

        task.Dispose();
    }

    IEnumerator GetScoreAsync()
    {
        Debug.Log("GetScoreAsync...");
        yield return 1;

        var task = Client.Get(UserName);
        yield return task.Send();

        if (task.isError)
        {
            Debug.LogError(task.error);
        }
        else
        {
            var score = task.Deserialize<ScoreModel>();
            if (score == null)
                Debug.Log("Not Found");
            else
                Debug.Log(score.UserName + " " + score.Points);
        }

        task.Dispose();
    }

    IEnumerator PostScoreAsync()
    {
        Debug.Log("GetScoresAsync...");
        yield return 1;

        var task = Client.Get(UserName);
        yield return task.Send();

        if (task.isError)
        {
            Debug.LogError(task.error);
        }
        else
        {
            Debug.Log("Success");
        }

        task.Dispose();
    }

    IEnumerator DeleteScoreAsync()
    {
        Debug.Log("DeleteScoreAsync...");
        yield return 1;

        var task = Client.Delete(UserName);
        yield return task.Send();

        if (task.isError)
        {
            Debug.LogError(task.error);
        }
        else
        {
            Debug.Log("Success");
        }

        task.Dispose();
    }
}
