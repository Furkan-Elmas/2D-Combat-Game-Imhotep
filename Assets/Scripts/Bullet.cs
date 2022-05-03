using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{
    public Camera cam;
    Vector2 direction;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 20f;
    [SerializeField] private Vector2 mousePosition;

    public float playerFullMana = 100f;
    public float playerCurrentMana;
    public Slider playerManaSlider;

    public AudioSource AudioSource;

    public MouseControl MouseControl;

    float fireRate = 1f;

    private void Start()
    {
        playerCurrentMana = playerFullMana;
    }

    private void LateUpdate()
    {
        fireRate += Time.deltaTime;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButton("Fire1") && fireRate >= 0.67f && playerCurrentMana >=5)
        {
            playerCurrentMana -= 5f;
            StartCoroutine(Shoot());
            fireRate = 0;
            AudioSource.Play();
            
        }        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(.2f);
        direction = mousePosition - (Vector2)firePoint.position;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (MouseControl.isTurn == true)
        {
            bullet.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            bullet.GetComponent<SpriteRenderer>().flipX = false;
        }
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(direction.normalized * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 3f);
    }



}
