using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
   
    public bool canAttack;

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.tag == "Player")
        {         
            canAttack = true;
            weapon.SetActive(true);
            Destroy(this.gameObject);
        } 
    }
   
}
