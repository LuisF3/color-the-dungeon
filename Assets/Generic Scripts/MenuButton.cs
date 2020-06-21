using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadSceneAsync("Scene do Luís");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
