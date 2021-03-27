using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public FireButton FireButton;
    public Transform gunEnd;
    
    public Camera fpsCam;
    protected bool fire;
   // private AudioSource gunAudio;
    private LineRenderer laserLine;
    private WaitForSeconds shotduration = new WaitForSeconds(.07f);

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
       Shoot();
    }

    void Shoot()
    {
        if (FireButton.Pressed && !fire)
        {
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            
            fire = true;
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
            {
                laserLine.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);
                //take damage
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin+(fpsCam.transform.forward * range));
            }
        }
        
        if (!FireButton.Pressed && fire)
        {
            fire = false;
        }
        
    }

    private IEnumerator ShotEffect()
    {
       // gunAudio.Play();
        laserLine.enabled = true;
        yield return shotduration;
        laserLine.enabled = false;
    }
    
}
