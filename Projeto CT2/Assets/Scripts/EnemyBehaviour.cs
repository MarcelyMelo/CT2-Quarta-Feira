using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField] private float velocidade = 5.0f;
    BoxCollider2D verFimDoChao;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
    }

    void Update()
    {
                        // x é a horizontal
                        // y é a vertical
                        //      (x, y)
        rb.velocity = new Vector2(velocidade, 0);
    }

    //O colisor de verificação saiu da plataforma
    // então chegamos ao fim dela
    private void OnTriggerExit2D(Collider2D outroObjeto)
    {
                                    // 1 direita
                                    // -1 esquerda
                                    //                       (x,            y)
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }


}
