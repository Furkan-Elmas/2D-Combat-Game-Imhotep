using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEffect : MonoBehaviour
{

    public Texture[] textures;

    LineRenderer laserline;

    int animationStep;
    float fps = 30f;
    float fpsCounter;

    private void Awake()
    {
        laserline = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fpsCounter += Time.deltaTime;
        if (fpsCounter >= 1 / fps)
        {
            animationStep++;
            if (animationStep == textures.Length)
            {
                animationStep = 0;
            }

            laserline.material.SetTexture("_MainTex",textures[animationStep]);

            fpsCounter = 0;
        }
    }

}
