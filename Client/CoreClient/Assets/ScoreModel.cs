using System;
using UnityEngine;

/// <summary>
/// Client side data model.
/// This can be shared......
/// </summary>
[Serializable]
public class ScoreModel
{
    [SerializeField]
    public string UserName;
    [SerializeField]
    public int Points;
}

/// <summary>
/// Client side data model.
/// This can be shared......
/// </summary>
[Serializable]
public class ScoreModelContainer
{
    public ScoreModel[] Scores;
}
