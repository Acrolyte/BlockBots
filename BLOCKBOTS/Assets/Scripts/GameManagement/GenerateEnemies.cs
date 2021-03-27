using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int x1, x2, z1, z2, y;
    public int enemyCount;
    public int TotalEnemies;
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < TotalEnemies)
        {
            xPos = Random.Range(x1,x2);
            zPos = Random.Range(z1, z2);
            Instantiate(theEnemy, new Vector3(xPos, y, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }   
    }

}
