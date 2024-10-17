using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

//-------------------------------------------------------------------------//

    private void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        HideCursor();
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!isPaused)
            {
                Debug.Log("is trying to pause");
                Pause();
            }
            else if (isPaused)
            {
                Unpause();
            }
        }
    }

//-------------------------------------------------------------------------//

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
        ShowCursor();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
        HideCursor();
    }


    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
