using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialControl : MonoBehaviour
{
    SkinnedMeshRenderer Material;
    float timer = 0;
    private void Start()
    {
        Material = GetComponent<SkinnedMeshRenderer>();
        
        int rand = Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                Material.material.color = Color.red;
                break;
            case 1:
                Material.material.color = Color.blue;
                break;
            case 2:
                Material.material.color = Color.green;
                break;
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            int rand = Random.Range(0, 3);
            switch(rand)
            {
                case 0:
                    Material.material.color = Color.red;
                    break;
                case 1:
                    Material.material.color = Color.blue;
                    break;
                case 2:
                    Material.material.color = Color.green;
                    break;
            }
            timer = 0;
        }
    }
}
