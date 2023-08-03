using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Movimentação
    Rigidbody2D rb;
    [SerializeField] private float velocidade = 5.0f;
    
    // Pulo
    [SerializeField] private float velocidadePulo = 5.0f;
    int quantidadeDePulos = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movePlayer();
        //Se apertar no botão espaço
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            pulo();
        }
    }

    void movePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        //                              X                            Y
        rb.velocity = new Vector2(horizontalInput * velocidade, rb.velocity.y);
    }
    
    void pulo()
    {
        //                        X       Y
        rb.velocity = new Vector2(0, velocidadePulo);
    }

}
