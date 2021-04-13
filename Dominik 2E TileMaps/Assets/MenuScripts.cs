using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public Canvas pauseMenu;
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Quit()
        {
            Application.Quit();
        }
        public void Resume()
        {
            Time.timeScale=1;
            pauseMenu.enabled=false;
        }
        public void MainMenu()
        {
            Resume();
            SceneManager.LoadScene(0);
        }
}
