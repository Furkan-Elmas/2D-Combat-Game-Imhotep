using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class UltimateSkill : MonoBehaviour
{
    [SerializeField] private GameObject thunder;

    private float _randomXPosition, _randomYPosition;

    float animRateUltiAttack = 60f;

    Vector2 randomPosition;
    Color thunderCoolDownColor;

    public AudioSource audioSource;
    public AudioSource audioSource2;
    
    public Bullet ultiMana;

    public Slider thunderCoolDown;
    public Image thunderCoolDownImage;

    private void Start()
    {
        ultiMana = GetComponent<Bullet>();
        thunderCoolDownColor = thunderCoolDownImage.color;
    }

    private void Update()
    {
        animRateUltiAttack += Time.deltaTime;
        thunderCoolDown.value = animRateUltiAttack;
        if (animRateUltiAttack >= 40f)
        {
            thunderCoolDownColor.a = 1f;
        }
        thunderCoolDownImage.color = thunderCoolDownColor;



        if (Input.GetKeyDown(KeyCode.E) && animRateUltiAttack >= 40f && ultiMana.playerCurrentMana >= 50)
        {
            StartCoroutine(ThunderBolt());
            animRateUltiAttack = 0;
            thunderCoolDownColor.a = 0.6f;
            CameraShaker.Instance.ShakeOnce(2f, 15f, 5f, 0.1f);
            audioSource.Play();
            audioSource2.Play();
            ultiMana.playerCurrentMana -= 50f;
        }
    }

    IEnumerator ThunderBolt()
    {
        #region Thunders
        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        yield return new WaitForSeconds(.2f);

        _randomXPosition = Random.Range(-1.5f, 1.5f);
        _randomYPosition = Random.Range(-1.5f, 1.5f);

        InstantiateThunder();

        #endregion
    }

    void InstantiateThunder()
    {
        randomPosition = new Vector2(_randomXPosition, _randomYPosition) + (Vector2)transform.position + new Vector2(0f, 5f);

        GameObject thunderBolt = Instantiate(thunder, randomPosition, Quaternion.identity);

        Destroy(thunderBolt, 2f);
    }

}
