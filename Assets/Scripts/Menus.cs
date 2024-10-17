using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public GameObject Menu2;
    public GameObject Menu;
    public GameObject pauseMenu;
    public AudioSource selectBttn;

//-------------------------------------------------------------------------//

    public void ChangeOnClick()
    {
        selectBttn.Play();
        Menu.SetActive(false);
        Menu2.SetActive(true);
    }

    public void ExitApp()
    {
        selectBttn.Play();
        Debug.Log("Has quited");
        Application.Quit();
    }

    public void StartGame()
    {
        selectBttn.Play();
        SceneManager.LoadScene("Level_01");
    }

    public void MainMenu()
    {
        selectBttn.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
    }

    public void AudioSelect()
    {
        selectBttn.Play();
    }
}
