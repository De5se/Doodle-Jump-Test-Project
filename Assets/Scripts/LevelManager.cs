using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        Resume();
    }

    public void Restart()
    {
        SceneManager.LoadScene($"Game");
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene($"Menu");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene($"Game");
    }

    [SerializeField] private UnityEvent loseGame;
    public void LoseGame()
    {
        loseGame.Invoke();
    }

    [SerializeField] private UnityEvent winGame;
    public void WinGAme()
    {
        winGame.Invoke();
    }
}
