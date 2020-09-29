using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJogador : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    public float jumpForce;
    private bool pulando = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float mov = Input.GetAxisRaw("Horizontal");

        Debug.Log(mov);

        if (mov == 1) {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (mov == -1) {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        rig.velocity = new Vector2(mov * speed, rig.velocity.y);
        if ( Input.GetKeyDown(KeyCode.Space) && pulando == false) {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pulando = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        pulando = false;
    }

}