using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject levelText;
    public Canvas pauseMenu;
    [SerializeField]
    public int level = 1;
    private void Start() {
        pauseMenu.enabled=false;
    }
    private void Awake()
    {
        if (Instance != null)
        {
        DestroyImmediate(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static GameManager Instance
    {
        get; set;
    }
    private void Update() {
        LevelText();
        if(Input.GetKeyDown(KeyCode.Escape)&&level>0)
        {
            Time.timeScale=0;
            pauseMenu.enabled=true;
        }
        level=SceneManager.GetActiveScene().buildIndex;
    }
    private void LevelText()
    {
        if(level<=0)
        {
            levelText.SetActive(false);
        }
        else
        {
            levelText.SetActive(true);
            levelText.GetComponent<Text>().text = "Level " + level;
        }
    }
}
