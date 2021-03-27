using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    private RectTransform reti;
    
    public float restingsize;
    public float maxSize;
    public float speed;
    private float currentsize;

    public Rigidbody rb;

    private void Start()
    {
        reti = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (rb.velocity.sqrMagnitude != 0)
        {
            currentsize = Mathf.Lerp(currentsize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            currentsize = Mathf.Lerp(currentsize, restingsize, Time.deltaTime * speed);
        }
        
        reti.sizeDelta = new Vector2(currentsize, currentsize);
    }
}
