using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public int playerID;
    void DestroySelf()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTwo") && playerID == 1)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 2500 + Vector3.up * 50);
        }
        else if (other.gameObject.CompareTag("PlayerOne") && playerID == 2)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 2500 + Vector3.up * 50);
        }
    }
}