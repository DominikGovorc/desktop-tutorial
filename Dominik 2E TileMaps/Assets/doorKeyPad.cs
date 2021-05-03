using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKeyPad : MonoBehaviour
{
    public Canvas keyPad;
    public bool doorOpen;
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player"&&doorOpen==false)
        {
            ActivateKeyPad();
        }
        else
        {
            DeactivateKeyPad();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            DeactivateKeyPad();
        }
    }
    private void Start()
    {
        keyPad.enabled = false;
    }
    private void Update()
    {
        if (doorOpen)
        {
            DeactivateKeyPad();
        }
        animator.SetBool("doorOpen", doorOpen);
    }

    public void ActivateKeyPad()
    {
        keyPad.enabled = true;
    }
    public void DeactivateKeyPad()
    {
        keyPad.enabled = false;
    }
    public void DisableCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
