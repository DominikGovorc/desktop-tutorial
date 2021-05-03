using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy")
        {
            other.GetComponent<explode>().OnExplode();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Collider")
        {
            Destroy(gameObject);
        }
    }
    public float bulletLifetime;
    public bool isRight;
    public float bulletSpeed;
    private void Start()
    {
        Invoke("DestroyMe", bulletLifetime);
    }
    void Update()
    {
        if(isRight)
        {
            transform.Translate(bulletSpeed*Time.deltaTime,0,0);
        }
        else
        {
            transform.Translate(-bulletSpeed*Time.deltaTime,0,0);
        }
    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
