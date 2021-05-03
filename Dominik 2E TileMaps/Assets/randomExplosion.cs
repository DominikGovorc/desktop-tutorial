using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomExplosion : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color start;
    private Color end;
    private float t;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        start = spriteRenderer.color;
        end = new Color(start.r, start.g, start.b, 0.0f);
    }
    void Update()
    {
        t += Time.deltaTime;
        spriteRenderer.color = Color.Lerp(start, end, t);
        if (spriteRenderer.color.a <= 0)
        {
            Destroy(gameObject);
        }
    }
}
