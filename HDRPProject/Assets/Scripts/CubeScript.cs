﻿using System;
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
        if (other.collider.gameObject.name == "Ethan")
        {
            rb.isKinematic = false;
        }
        else if (other.collider.gameObject.name == "Resetter")
        {
            rb.isKinematic = true;
            rb.position = originalPosition;
        }
    }

    public void ResetObject()
    {
        rb.isKinematic = true;
        transform.position = originalPosition;
        gameObject.SetActive(true);
    }
}
