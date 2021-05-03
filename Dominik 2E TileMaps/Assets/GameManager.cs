using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject player;
    public GameObject levelText;
    public Canvas pauseMenu;
    public Canvas gameUIv;
    public Text healthText;
    public static Text scoreText;
    public Text scoreTexta;
    public static float score;
    [SerializeField]
    public int level = 1;
    private void Start() {
        scoreText = scoreTexta;
        pauseMenu.enabled = false;
    }
    private void Awake()
    {
        if (Instance != null)
        {
        DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public static GameManager Instance
    {
        get; set;
    }
    private void Update() {
        player = GameObject.Find("Player");
        if(SceneManager.GetActiveScene().buildIndex==0)
        {
            gameUIv.enabled = false;
            score = 0;
        }
        else
        {
            gameUIv.enabled = true;
        }
        if (player.GetComponent<Movement>().health<=0)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            healthText.text = "HP " + player.GetComponent<Movement>().health;
        }
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
    public static void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: " + score;
    }
}
