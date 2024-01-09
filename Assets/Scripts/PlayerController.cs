using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float Speed;

    Vector2 movement;

    public Animator Anim;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
        }    
    }
}
