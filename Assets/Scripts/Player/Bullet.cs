using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Quaternion = System.Numerics.Quaternion;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 5f;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
      DirectionBullet();
    }

    private void DirectionBullet()
    {
        if (player.transform.localScale.x < 0f)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        Destroy(gameObject,2f);
    }
}
