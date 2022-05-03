using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.Rendering.Universal;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private float playerMaxHealth = 100f;

    private MouseControl _mouseControl;
    private Animator _animator;

    public float playerCurrentHealth;
    public AudioSource takeHit;
    public Slider playerHealtBar;
    public GameObject panel;

    public int _killedEnemyCount = 0;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mouseControl = GetComponentInParent<MouseControl>();

        playerCurrentHealth = playerMaxHealth;
    }

    public void TakeDamage(float damage)
    {
        playerCurrentHealth -= damage;
        CameraShaker.Instance.ShakeOnce(3f, 10f, 0.1f, 0.1f);
        takeHit.Play();
        playerHealtBar.value = playerCurrentHealth;

        if (playerCurrentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        _mouseControl.enabled = false;
        _animator.SetTrigger("Death");
        panel.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
        Destroy(this);
    }
    public void TurnOffTheLight()
    {
        GetComponentInChildren<Light2D>().intensity = 0;
    }
}
