using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject shot;
    [SerializeField] private Transform fire;

    public float speed = 2f;
    public Vector2 direction;
    public float livingTime = 3f;


    private float startingTime;

    private void Awake()
    {
        fire = transform.Find("Fire");
    }

    // Start is called before the first frame update
    void Start()
    {
        startingTime = Time.time;
        Destroy(gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = direction.normalized * speed * Time.deltaTime;
        // transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);
        transform.Translate(movement);
    }
    public void Shot()
    {
        Instantiate(shot, fire.position, Quaternion.identity);
        transform.Translate(Vector2.right * Time.deltaTime);
    }
}
