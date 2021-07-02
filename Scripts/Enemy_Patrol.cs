using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol : EnemyManager
{
    //control time between attacks


    //for patroling enemy
    public Transform[] waypoints;
    public int count = 0;
    public float Damage = 10;


    public override void Attack()
    {
        //melee attack is touching
        int distance = (int)this.transform.position.magnitude - (int)playerPos.position.magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Character")
        {
            other.SendMessage("DamagePlayer", Damage);
        }
    }

    public override void Move()
    {
        int distance = (int)this.transform.position.magnitude - (int)playerPos.position.magnitude;
        if (distance < 10)
        {
            agent.SetDestination(playerPos.position);
            Attack();
        }
        else if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[count].position);
            if ((int)this.transform.position.magnitude == (int)waypoints[count].position.magnitude)
            {
                count++;
                if (count == waypoints.Length) { count = 0; }
            }
        }
    }
}
