using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player;
    public float minx, miny, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 RandomPosition = new Vector2(Random.Range(minx, maxX), Random.Range(miny, maxY));
        PhotonNetwork.Instantiate(Player.name, RandomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
