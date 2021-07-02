using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int speed;
    public float timer;
    public PlayerController player;
    public float Damage;
    // Start is called before the first frame update
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
        speed = 10;
        timer = 1;
        Damage = 500;
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered player projectile");
        if (other.tag == "Enemy")
        {
            Debug.Log("if");
            other.SendMessage("TakeDamage", Damage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
