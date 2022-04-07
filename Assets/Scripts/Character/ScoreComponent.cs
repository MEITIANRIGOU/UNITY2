using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreComponent : MonoBehaviour
{
    public int teamID;
    public string playerName;

    public float health = 100;

    public Text HP;
    public GameObject EndUI;

    public bool safe = false;

    private void Awake()
    {
        playerName = gameObject.name;
    }
    private void FixedUpdate()
    {
        HP.text = "HP: " + (int)health;
        if (!safe)
        {
            health -= 0.1f;
        }
        if (health <= 0)
        {
            EndUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
    }
}