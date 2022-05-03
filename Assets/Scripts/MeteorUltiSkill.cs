using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class MeteorUltiSkill : MonoBehaviour
{
    [SerializeField] private GameObject meteors;
    [SerializeField] private GameObject ultiZone;
    [SerializeField] private AudioSource meteorSound;
    [SerializeField] private Slider meteorCoolDown;
    [SerializeField] private Image meteorCoolDownImage;


    private Vector2 mousePosition;
    private Color meteorCoolDownColor;
    private Camera cam;

    public EnemyAI meteorEnemy;
    Bullet bullet;

    float meteorRate = 30f;



    private void Start()
    {
        cam = Camera.main;
        bullet = GetComponent<Bullet>();
        meteorCoolDownColor = meteorCoolDownImage.color;
    }

    private void LateUpdate()
    {
        meteorRate += Time.deltaTime;
        meteorCoolDown.value = meteorRate;

        if (meteorRate >= 40f)
        {
            meteorCoolDownColor.a = 1f;
        }
        meteorCoolDownImage.color = meteorCoolDownColor;

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (meteorRate >= 20f && bullet.playerCurrentMana >=40f)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                                
                ultiZone.transform.position = mousePosition;
                ultiZone.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                StartCoroutine(startMeteorRain());
                ultiZone.transform.position = ultiZone.transform.position;
                bullet.playerCurrentMana -= 40f;
                meteorCoolDownColor.a = .6f;
                meteorRate = 0;
            }
        }

    }

    IEnumerator startMeteorRain()
    {
        meteors.SetActive(true);
        ultiZone.SetActive(true);
        CameraShaker.Instance.ShakeOnce(3f, 12f, 5f, 0.1f);
        meteorSound.Play();
        yield return new WaitForSeconds(2.75f);

        ultiZone.SetActive(false);
        meteors.SetActive(false);
    }

    
}
