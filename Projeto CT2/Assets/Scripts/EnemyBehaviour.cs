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
        if(olhandoParaDireita())
        {
           rb.velocity = new Vector2(velocidade, 0);
        }
        else
        {
            rb.velocity = new Vector2(-velocidade, 0);
        }
        
    }

    
    
    private void OnTriggerExit2D(Collider2D outroObjeto)
    {

        if (outroObjeto.gameObject.tag == "Ground")
        {
           transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
        
    }
    private bool olhandoParaDireita()
    {
        return transform.localScale.x > 0.000001f;
    }

}
