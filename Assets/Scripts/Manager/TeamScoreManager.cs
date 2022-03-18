using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScoreManager : MonoBehaviour
{
    public static List<Team> teamStatic = new List<Team>();
    public List<Team> teams;
    public class Team
    {
        public List<ScoreComponent> members = new List<ScoreComponent>();
        public int teamID;
        public int teamScore = 0;
    }
    private void FixedUpdate()
    {
        teams = teamStatic;
    }
}