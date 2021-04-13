using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start() {
        Invoke("DestroyMe",bulletLifetime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    public float bulletLifetime;
    public bool isRight;
    public float bulletSpeed;
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
