using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject energyBall;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(energyBall, new Vector2(-20, Random.Range(-4,4)), Quaternion.identity);
        }
    }
}
