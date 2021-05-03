using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;
    public Sprite[] sprites;
    public string resourceName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            GameManager.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if(resourceName!="")
        {
            sprites = Resources.LoadAll<Sprite>(resourceName);
            var randomNumber = Random.Range(0,sprites.Length-1);
            GetComponent<SpriteRenderer>().sprite = sprites[randomNumber];
            coinValue = 5 * (1 + randomNumber);
        }
    }
}
