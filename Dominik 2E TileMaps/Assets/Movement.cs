using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public Rigidbody2D body;

    float horizontal;
    float vertical;
    public GameObject bullet;
    public bool isRight;

    public float runSpeed = 10.0f;
    public float health=100f;
    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(horizontal<0)
        {
            isRight=false;
        }
        else
        {
            isRight=true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var obj = Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
            obj.GetComponent<Bullet>().isRight=isRight;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}

