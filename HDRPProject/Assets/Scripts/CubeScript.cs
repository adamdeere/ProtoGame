using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 originalPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }

    private void OnCollisionExit(Collision other)
    {
        rb.isKinematic = false;
    }

    public void ResetObject()
    {
        rb.isKinematic = true;
        transform.position = originalPosition;
        gameObject.SetActive(true);
    }
}
