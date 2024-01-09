using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    public Transform[] Spawnpoints;
    public GameObject Enemy;
    public float StartTimeBtwSpawns;
    float TimebtwSpawns;

    private void Start()
    {
        TimebtwSpawns = StartTimeBtwSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }

        if (TimebtwSpawns <= 0)
        {
             Vector3 SpawnPosition = Spawnpoints[Random.Range(0, Spawnpoints.Length)].position;
             PhotonNetwork.Instantiate(Enemy.name, SpawnPosition, Quaternion.identity);
             TimebtwSpawns = StartTimeBtwSpawns;
        }
        else
        {
             TimebtwSpawns -= Time.deltaTime;
        }
        }
    
}
