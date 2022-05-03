using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    private int sayac;

    public GameObject settingsPanel;
    public void playButton()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void menubutton()
    {
        SceneManager.LoadScene(0);
    }

    public void exitButton()
    {
        Application.Quit();
        print("Çýkýþ Yapýldý...");
    }

    public void settingsButton()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;    
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sayac++;
            if (sayac % 2 == 0)
            {
                settingsPanel.SetActive(false);
                Time.timeScale = 1f;
            }
            if (sayac % 2 == 1)
            {
                settingsPanel.SetActive(true);
                Time.timeScale = 0f;
            }


        }
    }
}
