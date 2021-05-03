using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            other.GetComponent<Movement>().health-=damage;
            gameObject.GetComponent<explode>().OnExplode();
            GameManager.AddScore(-20);
            Destroy(gameObject);
        }
    }
    public float timeRemaining=1f;
    public float damage;
    public float range;
    public bool firstPatrol;
    public bool waypointAdd;
    public GameObject[] waypoints;
    public float enemySpeed = 0.2f;
    public int waypointIndex;
    public Rigidbody2D rb;
     [Header("Main bool for action")]
    public bool attacking;
    private void Start() {
        transform.position = waypoints[0].transform.position;
        waypointAdd=true;
    }
    private void Update() {
        if(Vector2.Distance(transform.position,GameObject.Find("Player").transform.position)<=range)
        {
            attacking=true;
        }
        else
        {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else{
            attacking=false;
            timeRemaining=1;
        }
        }
    }
    private void FixedUpdate() {
        if(attacking==false)
        {
            if(waypointIndex<=waypoints.Length - 1)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position,waypoints[waypointIndex].transform.position,enemySpeed/2);

                rb.MovePosition(newPosition);
                if(transform.position==waypoints[waypointIndex].transform.position)
                {
                    if(waypointAdd&&waypointIndex!=waypoints.Length - 1)
                    {
                        waypointIndex++;
                    }
                    else if(waypointIndex>0){
                        waypointAdd=false;
                        waypointIndex--;
                    }
                    else{
                        waypointAdd=true;
                        waypointIndex++;
                    }
                    if(waypointIndex<waypoints.Length)
                    {
                        Vector3 direction = waypoints[waypointIndex].transform.position-this.transform.position;
                        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
                        rb.rotation=angle;
                    }
                }
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,GameObject.Find("Player").transform.position,enemySpeed);
        }        
    }
}
