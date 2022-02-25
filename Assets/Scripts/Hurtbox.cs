using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{

    //public GameObject deathEffect;
    public float chanceToDrop;
    public GameObject collectible;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Enemy")
       {
           other.transform.parent.gameObject.SetActive(false);
            float dropSelect = Random.Range(0, 100f);
          // Instantiate(deathEffect, other.transform.position, other.transform.rotation);

            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
       
       }
   }
}
