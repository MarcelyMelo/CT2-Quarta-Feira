using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   Rigidbody2D rb;
   [SerializeField] private float velocidade = 5.0f; 
   
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    
    void Update()
    {                                 
    // x é a horizontal
    // y é a vertical
    //    (x, y)
        rb.velocity = new Vector2(velocidade, 0);
    }

    private void OnTriggerExit2D(Collider2D outroObjeto)
    {                                                    //  1 direta
                                                         // -1 esquerda
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
}
