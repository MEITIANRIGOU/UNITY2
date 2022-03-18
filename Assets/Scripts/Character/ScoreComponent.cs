using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreComponent : MonoBehaviour
{
    public int teamID;
    public string playerName;
    private void Awake()
    {
        playerName = gameObject.name;
    }
}