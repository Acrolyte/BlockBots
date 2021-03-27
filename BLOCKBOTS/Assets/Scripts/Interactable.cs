using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 20f;

    private Transform player;
    private bool hasInteracted = false;
    public virtual void Interact()
    {
        //too be changed
        
    }

    private void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    private void Update()
    {
        if(!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                //increase health
                Interact();
                hasInteracted = true;
            }
        }
}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
