using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
// Movimentacao
[SerializeField] private float velocidadePulo = 5.0f;
int quantidadePulos = 2;
Rigidbody2D rb;    
[SerializeField] private float velocidade = 5.0f;
bool podepular;
void Start()
{
    rb = GetComponent<Rigidbody2D>();

}

    
    void Update()
    {
    movePlayer();
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        if(podepular == true){
        pulo();
    }}
    }

void movePlayer()
{
    var horizontalInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(horizontalInput * velocidade, rb.velocity.y);
}
void pulo()
{
    quantidadePulos = quantidadePulos - 1;
    rb.velocity = new Vector2(0,velocidadePulo);

}
void OnCollisionEnter2D(Collision2D other)
{
if(other.gameObject.CompareTag("Ground"))
{
    quantidadePulos = 2;
    podepular = true;
}
}
void OnCollisionExit2D(Collision2D other)
{
    if(other.gameObject.CompareTag("Ground"))
    if(quantidadePulos == 0)
    {
        podepular = false;
    }
}
}