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
        public string Points;

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

        
            UnityWebRequest task = Client.Get();

            //start the task and wait for it to complete
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

            UnityWebRequest task = Client.Get(UserName);

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

            UnityWebRequest task = Client.Post(UserName);

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

            UnityWebRequest task = Client.Delete(UserName);

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
}
