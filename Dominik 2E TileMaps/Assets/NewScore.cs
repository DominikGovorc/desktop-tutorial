using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewScore : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Text>().text = "Score: " + GameManager.score;
    }
}
