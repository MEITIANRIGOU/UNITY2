using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneControl : MonoBehaviour
{
    List<ScoreComponent> PlayersInZone = new List<ScoreComponent>();

    int zoneControlTeamID = -1;
    public int zoneControlMembersCount;

    public int scoreGetEachTick;

    float timer = 0;
    public float tickInSeconds;
    private void OnTriggerEnter(Collider other)
    {
        timer = 0;

        ScoreComponent Player = other.gameObject.GetComponent<ScoreComponent>();

        if (TeamScoreManager.teamStatic.Exists(Team => Player.teamID == Team.teamID))
        {
            TeamScoreManager.Team theTeam = TeamScoreManager.teamStatic.Find(Team => Player.teamID == Team.teamID);
            if (!theTeam.members.Exists(ScoreComponent => ScoreComponent.playerName == Player.gameObject.name))
            {
                theTeam.members.Add(Player);
            }
        }
        else
        {
            TeamScoreManager.teamStatic.Add(new TeamScoreManager.Team());
            TeamScoreManager.teamStatic[TeamScoreManager.teamStatic.Count - 1].teamID = Player.teamID;
            TeamScoreManager.teamStatic[TeamScoreManager.teamStatic.Count - 1].members.Add(Player);
        }
        PlayersInZone.Add(Player);
    }
    private void OnTriggerStay(Collider other)
    {
        if (!PlayersInZone.Exists(ScoreComponent => ScoreComponent.teamID != PlayersInZone[0].teamID) && PlayersInZone.Count >= zoneControlMembersCount)
        {
            zoneControlTeamID = PlayersInZone[0].teamID;

            if (timer < tickInSeconds)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;

                TeamScoreManager.teamStatic.Find(Team => Team.teamID == zoneControlTeamID).teamScore++;

                Debug.Log("Team: " + zoneControlTeamID + "\nScore: " + TeamScoreManager.teamStatic.Find(Team => Team.teamID == zoneControlTeamID).teamScore);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ScoreComponent Player = other.gameObject.GetComponent<ScoreComponent>();
        PlayersInZone.Remove(Player);
    }
}