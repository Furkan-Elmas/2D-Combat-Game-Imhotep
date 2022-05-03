using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 offSet;
    [Range(1f, 10f)]
    public float smoothFactor;

    private void Start()
    {
        cam.orthographicSize = 2.5f;
    }

    private void FixedUpdate()
    {
        Fallow();
    }

    void Fallow()
    {
        Vector3 targetPosition = target.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = targetPosition;
    }
}
