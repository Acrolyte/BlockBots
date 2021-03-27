using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("hit "+other+" !!");
        Destroy(gameObject);
    }
}
