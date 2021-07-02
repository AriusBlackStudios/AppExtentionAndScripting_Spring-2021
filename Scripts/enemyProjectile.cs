using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour


{
    public int speed;
    public float timer;
    public PlayerController player;
    public float Damage;

    public void Shoot()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        Shoot();
    }
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        speed = 20;
        timer = 1;
        Damage = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered Enemy Projectile");
        if (other.tag == "Character")
        {
            other.SendMessage("DamagePlayer", Damage);
            Destroy(this.gameObject);
        }
        else
        {

            Destroy(this.gameObject);

        }
    }
}
