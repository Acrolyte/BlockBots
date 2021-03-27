using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    public GameObject player;
    [HideInInspector]
    public bool area1 = true;
    [HideInInspector]
    public bool area2 = false;
    void Start()
    {
       SpawnLevel1();
    }
    
    void SpawnLevel1()
    {
        if (area1 == true)
        {
            Destroy(player);
            Instantiate(player, new Vector3(205,5,630), Quaternion.identity);
        }
    }
    IEnumerator SpawnLevel2()
    {
        if (area2 == true)
        {
            Instantiate(player, new Vector3(205,5,630), Quaternion.identity);
        }
        yield return new WaitForSeconds(0.5f);
    }
    
    
}
