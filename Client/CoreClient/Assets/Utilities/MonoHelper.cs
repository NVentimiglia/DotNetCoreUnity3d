using UnityEngine;

/// <summary>
/// Helper for accessing Unity methods from CLR objects
/// </summary>
public class MonoHelper : MonoBehaviour
{
    private static MonoHelper _instance;
    public static MonoHelper Instance
    {
        get
        {
            if (Instance == null)
            {
                var go = new GameObject();
                DontDestroyOnLoad(go);
                _instance = go.AddComponent<MonoHelper>();
            }

            return _instance;
        }
    }
}
