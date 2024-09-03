using UnityEngine;
using UnityEngine.SceneManagement;

public class startmanager : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0f;
    }
    public void playgames()
    {
        SceneManager.LoadScene("mainGame");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
