using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAim : MonoBehaviour
{
    
    private Transform player;
    public float lookradius = 200f;
    public float attackRange = 10f;
    public float nextShootTime;
    private ThirdPersonMovement tplayer;
    public float fireRate = 1f;
    public Transform gunEnd;
    private NavMeshAgent agent;
    
    private LineRenderer laserline;
    private WaitForSeconds shotduration = new WaitForSeconds(.07f);

   
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = PlayerManager.instance.player.transform;
        tplayer = PlayerManager.instance.tpm;
        laserline = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= lookradius)
        {
            agent.SetDestination(player.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        Aiming();
    }
    
    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }
    
    private void Aiming()
    {
        var position = player.position;
        Vector3 aimDir = (position - transform.position).normalized;
        float dist = Vector3.Distance(player.position, transform.position);
        if (dist <= attackRange)
        {
            laserline.SetPosition(0, gunEnd.position);
            float angle = Mathf.Atan2(aimDir.x, aimDir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
            if (Time.time > nextShootTime)
            {
                nextShootTime = Time.time + fireRate;
                StartCoroutine(shoteffect());
                Shooting();
            }
        } 
    }

    private void Shooting()
    {
        laserline.SetPosition(1, player.position);
        tplayer.TakeDamage(5);
    }
    
    private IEnumerator shoteffect()
    {
        // gunAudio.Play();
        laserline.enabled = true;
        yield return shotduration;
        laserline.enabled = false;
    }
    
}
