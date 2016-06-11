using System;
using System.Collections.Generic;
using System.Linq;
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
            EnsureInitialized();
            return _instance;
        }
    }

    static void EnsureInitialized()
    {
        if (_instance == null)
        {
            var go = new GameObject("_MonoHelper");
            DontDestroyOnLoad(go);
            _instance = go.AddComponent<MonoHelper>();
        }
    }


    #region Invoke on main
    static Queue<Action> _pendingActions = new Queue<Action>();
    static object _lock = new object();

    /// <summary>
    /// Registers an action to invoke on the main thread
    /// </summary>
    /// <param name="func"></param>
    public static void InvokeOnMainThread(Action func)
    {
        EnsureInitialized();

        lock (_lock)
        {
            _pendingActions.Enqueue(func);
        }
    }


    void Update()
    {
        if(!_pendingActions.Any())
            return;

        lock (_lock)
        {
            while (_pendingActions.Any())
            {
                var action = _pendingActions.Dequeue();

                action();
            }
        }
    }


    #endregion
}

