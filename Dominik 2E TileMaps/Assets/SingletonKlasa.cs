using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonKlasa : MonoBehaviour
{
    public GameObject gameUI;
    [SerializeField]
    public int level = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LevelUp()
    {
        level++;
    }
    public static SingletonKlasa Instance
    {
        get; set;
    }
}
