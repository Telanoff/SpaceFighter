using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerp;

    private void Start()
    {
        transform.position += offset;
    }
}
