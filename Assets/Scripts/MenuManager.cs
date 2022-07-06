using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene($"Game");
    }
}
