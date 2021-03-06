using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{   

    public static PlayerHealthController instance;
    public int currentHealth, maxHealth;

    public float invincibleLength; //Longitud de invicibilidad

    private float invicibleCounter; //Conteo de invicibilidad

    private SpriteRenderer theSR;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;

        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime;

            if(invicibleCounter <=0){
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        
        }
    }

    public void DealDamage()
    {
        if (invicibleCounter <= 0)
        {
        
            currentHealth--;

            if(currentHealth <= 0)
            {
                currentHealth = 0;

                LevelManager.instance.RespawnPlayer();
            }else{
                invicibleCounter = invincibleLength;
                 theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                 Jugador.instance.Knockback();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
