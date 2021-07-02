using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//jade ainsworth
//AppExtensionsAndScripting
//spring2021

public class Enemy : MonoBehaviour
{
    public Player p;
    public Transform mouth;
    public GameObject spit;
    public Slider healthBar;

    private float cTime = 0; // control spitting rate
    private float mTime = 1;
    public float Health=100;
    // Start is called before the first frame update
    void Start()
    {
        p = FindObjectOfType<Player>();
    }
    private void Update()
    {
        healthBar.value = Health;
        Attack();
        if (Health <= 0)
        {
            p.zombies--;
            Destroy(this.gameObject);
        }
    }

    public void Attack()
    {
        //if the player is close enough, it will start to spit at them
        int distance = (int)this.transform.position.magnitude - (int)p.transform.position.magnitude;
        //this makes them turn to face the player, and if i uncheck Kinigmatic
        //on the ridgid body they will start to follow the player for some reason?

        transform.LookAt(p.transform.position);
        if (distance < 1)
        {
            cTime += Time.deltaTime;
            if (cTime > mTime)
            {
                Instantiate(spit, mouth.position, mouth.rotation);
                cTime = 0;
            }
        }
    }
    //referenced in prjectile scripts
    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    //checks to see if the enemy themself has collided with the player
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("in Enemy Collision");
        if (collision.gameObject.tag == "Player")
        {
            p.SendMessage("LoseHealth", 5);
        }
    }
}
