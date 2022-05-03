using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelDeath : MonoBehaviour
{
    public void nextLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }
}
