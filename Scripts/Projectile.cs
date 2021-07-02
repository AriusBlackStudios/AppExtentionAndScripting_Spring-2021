using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//jade ainsworth
//AppExtensionsAndScripting
//spring2021

public class Projectile : MonoBehaviour
{
    public int speed=10;
    public float timer=5;
    public float damage;
   // public bool isPlayerShot;
    public void shoot()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.tag == "Player")
        {
            other.SendMessage("LoseHealth", damage);
            Destroy(this.gameObject);
        }
        if (other.tag == "E")
        {
            Debug.Log("detect enemy");
            other.SendMessage("TakeDamage", damage);
            Destroy(this.gameObject);

        }
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        shoot();
    }
}
