using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Health : MonoBehaviourPunCallbacks
{
    public int health = 10;

    public TMP_Text healthtext;

    private void Start()
    {
        healthtext.text = "Health: " + health.ToString();
    }

    public void TakeDamage()
    {
        photonView.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    void TakeDamageRPC()
    {
        health--;
        healthtext.text = "Health: " + health.ToString();
    }

    public void RecoverHealth()
    {
        photonView.RPC("RecoverHealthRPC", RpcTarget.All);
    }
    [PunRPC]
    void RecoverHealthRPC()
    {
        health++;
        healthtext.text = "Health: " + health.ToString();
    }
}
