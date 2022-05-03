using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WriteSceneManager : MonoBehaviour
{

    public GameObject fade2;
    public AudioSource audiosource;




    public void startButton()
    {

        fade2.SetActive(true);
        audiosource.Play();
    }
    

}
