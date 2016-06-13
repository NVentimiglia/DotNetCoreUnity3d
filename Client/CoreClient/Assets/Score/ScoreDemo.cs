using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Networking;

namespace Score
{
    public class ScoreDemo : MonoBehaviour
    {
        public string ServerPath = "http://localhost:58459/api/Score";

        public RestClient _client;
        public RestClient Client
        {
            get
            {
                return _client = _client ?? new RestClient(ServerPath);
            }
        }

        public string UserName;
        public int Points;

        [ContextMenu("Get All Scores")]
        public void GetScores()
        {
            StartCoroutine(GetAllAsync());
        }

        [ContextMenu("Get Score")]
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

        IEnumerator GetAllAsync()
        {
            Debug.Log("GetAllAsync...");
            yield return 1;

            var task = Client.Get();

            yield return task;

            if (task.isError())
            {
                Debug.LogError(task.error);
            }
            else
            {
                var scores = task.Deserialize<ScoreModelContainer>();

                if (scores == null || scores.Scores == null)
                    Debug.Log("Not Found");
                else
                {
                    Debug.Log("Success !");
                    foreach (var score in scores.Scores)
                    {
                        Debug.Log(score.UserName + " " + score.Points);
                    }
                }
            }

            task.Dispose();
        }

        IEnumerator GetScoreAsync()
        {

            Debug.Log("GetScoreAsync...");
            yield return 1;


            var task = Client.Get(UserName);

            //start the task and wait for it to complete
            yield return task;

            if (task.isError())
            {
                Debug.LogError(task.error);
            }
            else
            {
                var score = task.Deserialize<ScoreModel>();
                Debug.Log(score.UserName + " " + score.Points);
            }

            task.Dispose();
        }

        IEnumerator PostScoreAsync()
        {
            Debug.Log("PostScoreAsync...");
            yield return 1;

            var model = new ScoreModel
            {
                UserName = UserName,
                Points = Points,
            };

            var json = JsonUtility.ToJson(model);

            var task = Client.Post(json);

            yield return task;

            if (task.isError())
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

            yield return task;

            if (task.isError())
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
}
