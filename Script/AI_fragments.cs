using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_fragments : enemyManager
{
    //pace on platform
    public Vector2 leftbound, rightbound;
    public float speed;
    public Vector2[] pacer;
    int next;



    // Start is called before the first frame update
    void Start()
    {
        next = 0;
        speed = 2;
        leftbound= new Vector2(this.transform.position.x - 3.5f, this.transform.position.y);
        rightbound= new Vector2(this.transform.position.x + 3.5f, this.transform.position.y);
        pacer = new Vector2[2];
        pacer[0] = leftbound;
        pacer[1] = rightbound;
        EnemyHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        health.value = EnemyHealth;
        if (Vector2.Distance(transform.position, pacer[next]) > 0.01)
        {
            //go towards the current thing
          
            //Vector2.MoveTowards(transform.position,pacer[next], speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), pacer[next], speed * Time.deltaTime);
            //Debug.Log("moving");
        }
        else{
            next++;
            if (next > pacer.Length - 1)
            {
                next = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerMagic"))
        {
            DamageEnemy(10);
        }
    }





}
