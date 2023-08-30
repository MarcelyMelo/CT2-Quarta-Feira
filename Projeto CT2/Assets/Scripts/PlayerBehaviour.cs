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
    bool podePular; 

    // Pontuação
    private GameController controladorDoPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        controladorDoPlayer = GameController.gc;
        controladorDoPlayer.coins = 0;
    }

    void Update()
    {
        movePlayer();

        //Se apertar no botão espaço
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(podePular == true && quantidadeDePulos > 0){
                pulo();
            }
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
        quantidadeDePulos = quantidadeDePulos - 1;
        rb.velocity = new Vector2(0, velocidadePulo);
    }

    //Verificar chão

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {       
            quantidadeDePulos = 2;
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

    // Moedas
    void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if(outroObjeto.gameObject.tag == "Coin")
        {
            Destroy(outroObjeto.gameObject);
            controladorDoPlayer.coins++;
            controladorDoPlayer.Score.text = controladorDoPlayer.coins.ToString();
        }
    }
}
