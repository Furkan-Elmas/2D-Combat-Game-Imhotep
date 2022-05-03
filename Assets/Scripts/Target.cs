using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    RaycastHit hit;

    public Camera cam;

    public Transform character;

    public float laserDuration;
    public float fireDamage;

    public float range = 20f;

    LineRenderer laserLine;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        laserLine.enabled=false;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            laserLine.enabled = true;

            laserLine.SetPosition(0, character.position);

            Vector2 rayOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

            laserLine.SetPosition(1, rayOrigin);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            laserLine.enabled = false;
        }
    }
}
