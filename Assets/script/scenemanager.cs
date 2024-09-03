using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    [SerializeField]private GameObject pausemenu;

   
    public void pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainGame");
    }
   
    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("startScene");
    }
}
