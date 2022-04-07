using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneControl : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ScoreComponent player = other.GetComponent<ScoreComponent>();
        Color bearColor = other.transform.GetChild(3).GetComponent<SkinnedMeshRenderer>().material.color;
        Color color = GetComponent<SkinnedMeshRenderer>().material.color;
        if (bearColor == color)
        {
            player.safe = true;
        }
        else
        {
            player.safe = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        ScoreComponent player = other.GetComponent<ScoreComponent>();
        Color bearColor = other.transform.GetChild(3).GetComponent<SkinnedMeshRenderer>().material.color;
        Color color = GetComponent<SkinnedMeshRenderer>().material.color;
        if (bearColor == color)
        {
            player.safe = true;
        }
        else
        {
            player.safe = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ScoreComponent player = other.GetComponent<ScoreComponent>();
        
        player.safe = false;
        
    }
}