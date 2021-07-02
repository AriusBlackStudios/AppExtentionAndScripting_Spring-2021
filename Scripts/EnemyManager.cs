using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public abstract class EnemyManager : MonoBehaviour
{
    //nave mesh
    public NavMeshAgent agent;
    public Transform playerPos;

    //attacking
    public float TimeBetweenAttacks;
    public bool alreadyAttacked;




    //general system
    public float EnemyHealth, HealthDrop, EnemyDamage;
    public bool isAlive;
    public PlayerController player;//to access player methods
    public Slider enemyHealth;







    private void Awake()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;
        player = FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

        EnemyHealth = 100;
        enemyHealth.maxValue = EnemyHealth;
        isAlive = true;

    }
    void Update()
    {
        enemyHealth.value = EnemyHealth;
        if (isAlive)
        {
            Move();
            Attack();
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    //abstract methods
    public abstract void Move();
    public abstract void Attack();


    public void TakeDamage(int damage)
    {
        Debug.Log("In Enemy");
        EnemyHealth = EnemyHealth - damage;
        if (EnemyHealth <= 0)
        {
            isAlive = false;
            player.EnemiesKilled++;
        }
    }



}
