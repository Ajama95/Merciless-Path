using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausemenu;
    public static bool ispaused;
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(ispaused)
            {
                resumegame();
            }
            else
            {
                pausegame();
            }
        }
    }
    public void pausegame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;          //pause
        ispaused = true;
    }
    public void resumegame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
