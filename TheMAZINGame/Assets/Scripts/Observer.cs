using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;

    bool m_isPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_isPlayerInRange = false;
        }
    }

    void Update()
    {
        if(m_isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            if(Physics.Raycast(ray))
            {

            }
        }
    }
}
