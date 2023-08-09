using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

   Rigidbody2D rb;
   [SerializeField] private float velocidade = 5.0f;
   [SerializeField] private float velocidadePulo = 5.0f;
   int quantidadeDePulos = 1;
   bool podePular;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movePlayer();
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(podePular == true && quantidadeDePulos > 0)
            {            
            pulo();
            }
        }
    }

    void movePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * velocidade, rb.velocity.y);
    }

    void pulo()
    {
        quantidadeDePulos = quantidadeDePulos - 1;
        rb.velocity = new Vector2(0, velocidadePulo);
    } 


    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            quantidadeDePulos = 1;
            podePular = true;
        }
    }
              
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            if(quantidadeDePulos == 0)
            {
               podePular = false; 
            }
        }
    }
}
