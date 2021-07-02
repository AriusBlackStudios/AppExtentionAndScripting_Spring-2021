using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle : EnemyManager
{

    public Transform mouth;
    private float cTime = 0;
    private float mTime = 1;
    public override void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(playerPos);
        cTime += Time.deltaTime;
        if (cTime > mTime)
        {
            Instantiate(Resources.Load("Acid"), mouth.position, mouth.rotation);
            cTime = 0;
        }


    }

    public override void Move()
    {
        int distance = (int)this.transform.position.magnitude - (int)playerPos.position.magnitude;
        if (distance < 10)
        {
            agent.SetDestination(playerPos.position);
            if (distance < 5)
            {
                Attack();
            }
        }
    }

   
}
