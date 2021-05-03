using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public randomExplosion coin;
    public int totalCoins = 10;
    public void OnExplode()
    {
        Destroy(gameObject);
        var t = transform;
        for (int i = 0; i < totalCoins; i++)
        {
            randomExplosion clone = Instantiate(coin, t.position, Quaternion.identity) as randomExplosion;
            clone.rb.AddForce(Vector3.right * Random.Range(-150, 150));
            clone.rb.AddForce(Vector3.up * Random.Range(-150, 150));
        }
    }
}
