using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;

    public void Shot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
