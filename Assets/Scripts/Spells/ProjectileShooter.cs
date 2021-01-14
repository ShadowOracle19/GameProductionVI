﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 30f;
    [SerializeField]
    [Range (0.1f, 1.5f)]
    private float fireRate = 1;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private Transform firePoint;

    private float timer;
    private Vector3 destination;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
          if(Input.GetButton("Fire1"))
          {
              timer = 0f;
              FireProjectile();
          }
        }
    }

    void FireProjectile()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        Ray ray = new Ray(firePoint.position, firePoint.forward);

        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }

        
        InsantiateProjectile();
    }
    
    void InsantiateProjectile()
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
