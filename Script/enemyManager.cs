using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour
{
    public float EnemyHealth;
    string deathStatement;
    public Player player;
    public float attack;
    public Slider health;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        attack = 20;
       // EnemyHealth = 100;
    }

    public void DamageEnemy(float PlayerAttack)
    {
        EnemyHealth -=PlayerAttack;
        if (EnemyHealth < 0)
        {
            Destroy(gameObject);
            //player.CodeFrags++;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("PlayerMagic"))
    //    {
    //        DamageEnemy(10);
    //        Destroy(collision.gameObject);
    //    }
    //}
}
