using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

   Rigidbody2D rb;
   [SerializeField] private float velocidade = 5.0f;
   [SerializeField] private float velocidadePulo = 5.0f;
   int quantidadeDePulos = 1;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movePlayer();
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
          pulo();
        }
    }

    void movePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * velocidade, rb.velocity.y);
    }

    void pulo()
    {
        rb.velocity = new Vector2(0, velocidadePulo);
    }
}
