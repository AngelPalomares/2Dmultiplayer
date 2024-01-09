using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float Speed;

    Vector2 movement;

    public Animator Anim;

    Health healthScript;

    LineRenderer rend;
    

    // Start is called before the first frame update
    void Start()
    {
        healthScript = FindObjectOfType<Health>();
        rend = FindObjectOfType<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            Vector2 MoveInput = new Vector2(movement.x, movement.y);
            Vector2 MoveAmount = MoveInput.normalized * Speed * Time.deltaTime;
            transform.position += (Vector3)MoveAmount;

            Anim.SetFloat("Horizontal", movement.x);
            Anim.SetFloat("Vertical", movement.y);
            Anim.SetFloat("Speed", movement.sqrMagnitude);

            rend.SetPosition(0, transform.position);
        }
        else
        {
            rend.SetPosition(1, transform.position);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (photonView.IsMine)
        {
            if (collision.tag == "Enemy")
            {
                healthScript.TakeDamage();
            }

            if(collision.tag == "Health")
            {
                healthScript.RecoverHealth();
            }
        }
    }
}
