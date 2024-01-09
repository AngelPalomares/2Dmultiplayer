using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
    PlayerController[] Players;
    PlayerController nearestPlayer;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Players = FindObjectsOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceOne = Vector2.Distance(transform.position, Players[0].transform.position);
        float DistanceTwo = Vector2.Distance(transform.position, Players[1].transform.position);

        if(DistanceOne < DistanceTwo)
        {
            nearestPlayer = Players[0];
        }
        else
        {
            nearestPlayer = Players[1];
        }

        if(nearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, Speed * Time.deltaTime);
        }
    }
}
