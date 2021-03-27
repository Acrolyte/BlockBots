using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startingPos;
    private Vector3 roamPos;
    void Start()
    {
        startingPos = transform.position;
        roamPos = GetRoamingPosition();
    }

    private void Update()
    {
        
    }
    
    private Vector3 GetRoamingPosition()
    {
        return startingPos + Utils.GetRandomDir() * Random.Range(10f, 70f);
    }
   
}
