using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;

    void Update()
    {
        //get input
        if (Input.GetAxis("Fire1") > 0.001)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        Instantiate(projectile, firePosition.position, firePosition.rotation);
    }
}
