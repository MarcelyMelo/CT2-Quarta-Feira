using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{
    
    [SerializeField] int numLives = 3;
    [SerializeField] int numOfHearts;

    public Image[] hearts;
    void Update()
    {
        for(int contador = 0; contador < hearts.Length; contador++)
        {
            if(contador < numLives)
            {
                hearts[contador].enabled = true;
            }
            else
            {
                hearts[contador].enabled = false;
            }
        }

        
    }
    void OnCollisionEnter2D(Collision2D outroObjeto)
        {
            if(outroObjeto.gameObject.CompareTag("Enemy"))
            {
                PerdeVida();
            }
        }

        public void PerdeVida()
        {
            numLives--;
            if (numLives <= 0)
            {
                Debug.Log("GameOver");
            }
        }
}
