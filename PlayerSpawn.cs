using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField] Transform playerSpawnPoint;
    void Start()
    {
        Instantiate(player,playerSpawnPoint.position,playerSpawnPoint.rotation);
    }
}
