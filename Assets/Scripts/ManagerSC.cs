using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerSC : MonoBehaviour
{

    public GameObject fade;
    public AudioSource audiosource;
    public GameObject panelBossDead;
    public GameObject plaerHealtBar;






    public void startButton()
    {

        fade.SetActive(true);
        audiosource.Play();
    }
    public void quitGame()
    {
        print("Çýkýþ Yapýldý...");
        Application.Quit();
    }

    public void bossDeathPanel()
    {
        panelBossDead.SetActive(true);
        StartCoroutine(bossDeathPanelTime());
    }

    IEnumerator bossDeathPanelTime()
    {
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0f;
    }
}
