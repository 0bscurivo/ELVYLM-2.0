using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    [SerializeField]private LayerMask PisoPaSaltar;

    private float DirX = 0f;
    public float speed = 7f;
    [SerializeField]private float jumpforce = 18f;
    
    private enum Movimientos { idle, run, jump, fall}
     
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //GetComponent sirve para hallar un componente fuera del script para utilizar dentro de este
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    
    private void Update()
    {
        DirX = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(DirX * speed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && TocaPiso())    //solo se cumple si unde el boton de salto y esta tocando el piso    
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
        }
        
        Animacion();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("remord"))
        {
            speed -= .5f;
        }
    }

    private void Animacion()
    {
        Movimientos mov;

        if (DirX > 0f)
        {
            mov = Movimientos.run;
            sprite.flipX = false;
        }
        else if (DirX < 0f)
        {
            mov = Movimientos.run;
            sprite.flipX = true;
        }
        else
        {
            mov = Movimientos.idle;
        }

        if (rb2d.velocity.y > .1f)
        {
            mov = Movimientos.jump;
        }
        else if (rb2d.velocity.y < -.1f)
        {
            mov = Movimientos.fall;
        }
        anim.SetInteger("mov", (int)mov);
    }

    private bool TocaPiso()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, PisoPaSaltar);
    }
}
