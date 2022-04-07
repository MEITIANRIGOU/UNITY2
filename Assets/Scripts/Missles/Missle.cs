using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    Rigidbody rb;
    public int playerID;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerTwo") && playerID == 1)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 7500 + Vector3.up * 300);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("PlayerOne") && playerID == 2)
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 7500 + Vector3.up * 300);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
