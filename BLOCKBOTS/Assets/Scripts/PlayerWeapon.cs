using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    //private const string BULLET_PREFAB_PATH = "Prefabs/Bullet";
    //public GameObject bulletprefab;
    //public Transform BulletSpawn;
    //public float bulletSpeed = 30;
    //public float lifeTime = 3;
    public Button FireButton;
    
  
    private void Start()
    {
        FireButton = FindObjectOfType<Button>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Fire();
    }

    public void Fire()
    {
       // var bullet = ObjectPooler.GetPooledObject(BULLET_PREFAB_PATH);
      //  bullet.transform.position = position;
    //        bullet.transform.rotation = rotation;
       // GameObject bullet = Instantiate(bulletprefab);
        //bullet.SetActive(true);
        
       // Physics.IgnoreCollision(bullet.GetComponent<Collider>(), BulletSpawn.parent.GetComponent<Collider>());

        //bullet.transform.position = BulletSpawn.position;
        //Vector3 rotation = bullet.transform.rotation.eulerAngles;
        //bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        
        //bullet.GetComponent<Rigidbody>().AddForce(BulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

        //StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new  WaitForSeconds(delay);
        Destroy(bullet);
    }
    
}