using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriteEffect : MonoBehaviour
{
    public float delay = 0.02f;
    public string fullText;
    private string currentText = "";
    public AudioSource audioSource;
    

    private void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0,i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
        

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.Stop();
            StopAllCoroutines();
            this.GetComponent<Text>().text = fullText;
        }
        if (currentText == fullText)
        {
            
            audioSource.Stop();
        }

    }
}
