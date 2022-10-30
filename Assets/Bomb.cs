using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player;
    private bool isShoot;
    private void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        isShoot = player.GetComponent<TramShootController>().isShoot;
        transform.LookAt(player);
    }
}
